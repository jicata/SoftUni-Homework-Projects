namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ShoppingCenter
    {
       
        private OrderedMultiDictionary<decimal, Product> productsByPrice;
        private MultiDictionary<string, Product> productsByProducer;
        private MultiDictionary<string, Product> productsByName;
        private MultiDictionary<string, Product> productsByNameAndProducer;
        

        public ShoppingCenter()
        {
            this.productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
            this.productsByProducer = new MultiDictionary<string, Product>(true);
            this.productsByName = new MultiDictionary<string, Product>(true);
            this.productsByNameAndProducer = new MultiDictionary<string, Product>(true);
            
    }

        public string AddProduct(string name, decimal price, string producer)
        {
            var product = new Product(name, price, producer);
           
            string producerNameCombined = this.CombineProducerAndName(producer, name);

            this.productsByProducer[producer].Add(product);
            this.productsByPrice[price].Add(product);
            this.productsByName[name].Add(product);
            this.productsByNameAndProducer[producerNameCombined].Add(product);
            return "Product added";
        }

        public string OrderAndPrint(IEnumerable<Product> products)
        {
            var productsOrdered = products.OrderBy(p => p.Name).ThenBy(p => p.Producer).ThenBy(p => p.Price);
            StringBuilder sb = new StringBuilder();
            foreach (var product in productsOrdered)
            {
                sb.AppendLine(product.ToString());
            }
            return sb.ToString().Trim();
        }
        public string DeleteProductsByProducer(string producer)
        {
            if (!this.productsByProducer.ContainsKey(producer) || this.productsByProducer[producer].Count == 0)
            {
                return "No products found";
            }
            var itemsToRemove = this.productsByProducer[producer];
            int count = itemsToRemove.Count;

            foreach (var product in itemsToRemove)
            {
                this.productsByName[product.Name].Remove(product);
                string nameCombined = CombineProducerAndName(producer, product.Name);
                this.productsByNameAndProducer[nameCombined].Remove(product);
                this.productsByPrice[product.Price].Remove(product);
                
            }
            this.productsByProducer.Remove(producer);
            return count + " products deleted";
        }

        public string DeleteProductsByNameAndProducer(string name, string producer)
        { 
            string nameAndProducer = this.CombineProducerAndName(producer, name);
            if (!this.productsByNameAndProducer.ContainsKey(nameAndProducer) || this.productsByNameAndProducer[nameAndProducer].Count == 0)
            {
                return "No products found";
            }
            var itemsToRemove = this.productsByNameAndProducer[nameAndProducer];
            int count = itemsToRemove.Count;
            foreach (var product in itemsToRemove)
            {
                this.productsByProducer[producer].Remove(product);
                this.productsByName[name].Remove(product);
                this.productsByPrice[product.Price].Remove(product);
            }
            this.productsByNameAndProducer.Remove(nameAndProducer);
            return count + " products deleted";
        }
        private string CombineProducerAndName(string producer, string name)
        {
            string separator = "|!|";
            return name + separator + producer;
        }

        public string FindProductsByProducer(string producer)
        {
            if (!this.productsByProducer.ContainsKey(producer) || this.productsByProducer[producer].Count == 0)
            {
                return "No products found";
            }
            var products = this.productsByProducer[producer];
            
            return this.OrderAndPrint(products);
        }

        public string FindProductsByName(string name)
        {
            if (!this.productsByName.ContainsKey(name) || this.productsByName[name].Count == 0)
            {
                return "No products found";
            }
            var products = this.productsByName[name];

            return this.OrderAndPrint(products);
        }
        private string FindProductsByPriceRange(decimal priceFrom, decimal priceTo)
        {
            var range = this.productsByPrice.Range(priceFrom, true, priceTo, true);
            if (range.Count == 0)
            {
                return "No products found";
            }
            var products = range.SelectMany(x => x.Value);
            return this.OrderAndPrint(products);

        }
        public string ProcessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parameterValues = command.Substring(indexOfFirstSpace + 1);
            string[] parameters = parameterValues.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            switch (method)
            {
                case "AddProduct":
                    return AddProduct(parameters[0], decimal.Parse(parameters[1]), parameters[2]);
                case "DeleteProducts":
                    if (parameters.Length == 1)
                    {
                        return DeleteProductsByProducer(parameters[0]);
                    }
                    else
                    {
                        return DeleteProductsByNameAndProducer(parameters[0], parameters[1]);
                    }
                case "FindProductsByName":
                    return FindProductsByName(parameters[0]);
                case "FindProductsByPriceRange":
                    return FindProductsByPriceRange(decimal.Parse(parameters[0]), decimal.Parse(parameters[1]));
                case "FindProductsByProducer":
                    return FindProductsByProducer(parameters[0]);
                default:
                    return "KUR";
            }
        }

        
    }
}
