namespace MVCFramework.MVC
{
    using System.Reflection;

    public class MvcContext
    {
        public static readonly MvcContext Current = new MvcContext();
        public string AssemblyName { get; set; }
        public Assembly CurrentAssembly => Assembly.Load(this.AssemblyName);
        public string ControllersFolder { get; set; }
        public string ControllersSuffix { get; set; }
        public string ViewsFolder { get; set; }
        public string ModelsFolder { get; set; }
    }
}
