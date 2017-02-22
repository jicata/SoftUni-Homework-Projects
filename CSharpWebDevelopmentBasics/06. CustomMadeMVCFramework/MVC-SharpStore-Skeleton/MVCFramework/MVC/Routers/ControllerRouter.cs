namespace MVCFramework.MVC.Routers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using Attributes.Methods;
    using Controllers;
    using Extensions;
    using Interfaces;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;

    public class ControllerRouter
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        private string[] controllerActionParams;
        private string[] controllerAction;

        private HttpRequest request;
        private HttpResponse response;
        public ControllerRouter()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
            this.request = new HttpRequest();
            this.response = new HttpResponse();
        }
        public HttpResponse Handle(HttpRequest request)
        {
            this.request = request;
            this.response = new HttpResponse();
            this.ParseInput();

                IInvocable result =
                (IInvocable)this.GetMethod()
                .Invoke(this.GetController(), this.methodParams);

            if (string.IsNullOrEmpty(this.response.Header.Location))
            {
                this.response.StatusCode = ResponseStatusCode.Ok;
                this.response.ContentAsUTF8 = result.Invoke();
            }

            this.ClearParameters();

            return this.response;
        }

        private void ClearParameters()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
        }

        private void InitRequestMethod()
        {
            this.requestMethod = this.request.Method.ToString();
        }

        private void InitControllerName()
        {
            this.controllerName = this.controllerAction[this.controllerAction.Length - 2].ToUpperFirst() + MvcContext.Current.ControllersSuffix;
        }

        private void InitActionName()
        {
            this.actionName = this.controllerAction[this.controllerAction.Length - 1].ToUpperFirst();
        }

        public void ParseInput()
        {

            string uri = WebUtility.UrlDecode(this.request.Url);
            string query = string.Empty;
            if (this.request.Url.Contains("?"))
            {
                query = this.request.Url.Split('?')[1];
            }
            this.controllerActionParams = uri.Split('?');
            this.controllerAction = this.controllerActionParams[0].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            this.controllerActionParams = query.Split('&');

            //Retrieve GET parameters
            if (this.controllerActionParams.Length >= 1)
            {
                foreach (var pair in this.controllerActionParams)
                {
                    if (pair.Contains("="))
                    {
                        string[] keyValue = pair.Split('=');
                        this.getParams.Add(keyValue[0], keyValue[1]);
                    }
                }
            }

            //Retrieve POST parameters
            string postParameters = WebUtility.UrlDecode(this.request.Content);
            if (!string.IsNullOrWhiteSpace(postParameters))
            {
                string[] pairs = new string[1];
                if (postParameters.Contains('&'))
                {
                    pairs = postParameters.Split('&');
                }
                else
                {
                    pairs[0] = postParameters;
                }
               
                foreach (var pair in pairs)
                {
                    string[] keyValue = pair.Split('=');
                    this.postParams.Add(keyValue[0], keyValue[1]);
                }
            }

            this.InitRequestMethod();
            this.InitControllerName();
            this.InitActionName();

            MethodInfo method = this.GetMethod();

            if (method == null)
            {
                throw new NotSupportedException("No such method");
            }

            IEnumerable<ParameterInfo> parameters
                = method.GetParameters();

            this.methodParams
                = new object[parameters.Count()];


            int index = 0;
            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive || param.ParameterType.Name=="String")
                {
                    //TODO: test and evaluate if best approach

                    object value = this.getParams.ContainsKey(param.Name) ? this.getParams[param.Name] : null;

                    this.methodParams[index] = Convert.ChangeType(
                        value,
                        param.ParameterType
                        );
                    index++;
                }
                else if (param.ParameterType == typeof(HttpRequest))
                {
                    this.methodParams[index] = this.request;
                    index++;
                }
                else if (param.ParameterType == typeof(HttpSession))
                {
                    this.methodParams[index] = this.request.Session;
                    index++;
                }
                else if (param.ParameterType == typeof(HttpResponse))
                {
                    this.methodParams[index] = this.response;
                    index++;
                }
                else
                {
                    Type bindingModelType =
                        MvcContext.Current.CurrentAssembly.GetTypes().FirstOrDefault(t => t == param.ParameterType);
                    object bindingModel =
                        Activator.CreateInstance(bindingModelType);

                    IEnumerable<PropertyInfo> properties
                        = bindingModelType.GetProperties();

                    foreach (KeyValuePair<string,string> postParam in postParams)
                    {
                        var property = properties.FirstOrDefault(p => p.Name == postParam.Key && p.Name.ToLower()!="id");
                        if (property != null)
                        {
                            property.SetValue(
                            bindingModel,
                            Convert.ChangeType(
                                postParam.Value,
                                property.PropertyType
                                )
                            );
                        }                        
                    }

                    this.methodParams[index] = Convert.ChangeType(
                        bindingModel,
                        bindingModelType
                        );
                    index++;
                }
            }
        }
        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            return this.GetController()
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerType = string.Format(
                "{0}.{1}.{2}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ControllersFolder,
                this.controllerName);

            var controller =
                (Controller)Activator.CreateInstance(MvcContext.Current.CurrentAssembly.GetType(controllerType));
            return controller;
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;
            foreach (MethodInfo methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any() && this.requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
                
            }

            return method;
        }
    }
}
