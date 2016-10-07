namespace _03_CollectionOfProducts
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class ProductCollection
    {
        private Dictionary<int, Product> productsById;

        private OrderedDictionary<decimal, SortedSet<Product>> productsByPriceRange;
        private Dictionary<string, SortedSet<Product>> productsByTitle;
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByTitleAndPrice;
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsBySupplierAndPrice;

        public ProductCollection()
        {
            this.productsById = new Dictionary<int, Product>();
            this.productsByPriceRange = new OrderedDictionary<decimal, SortedSet<Product>>();
            this.productsByTitle = new Dictionary<string, SortedSet<Product>>();
            this.productsByTitleAndPrice = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
            this.productsBySupplierAndPrice = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
        }
        

        public int Count
        {
            get { return this.productsById.Count; }
        }
        //•	Add new product(if the id already exists, the new product replaces the old one)
        public void Add(int id, decimal price, string title, string supplier)
        {
            var product = new Product(id, price, title, supplier);
            if (this.productsById.ContainsKey(id))
            {
                this.Remove(id);
            }
            if (!this.productsByPriceRange.ContainsKey(price))
            {
                this.productsByPriceRange.Add(price, new SortedSet<Product>());
            }
            if (!this.productsByTitle.ContainsKey(title))
            {
                this.productsByTitle.Add(title, new SortedSet<Product>());
            }

            if (!this.productsByTitleAndPrice.ContainsKey(title))
            {
                this.productsByTitleAndPrice.Add(title, new OrderedDictionary<decimal, SortedSet<Product>>());
                this.productsByTitleAndPrice[title].Add(price, new SortedSet<Product>());
            }
            if (!this.productsByTitleAndPrice[title].ContainsKey(price))
            {
                this.productsByTitleAndPrice[title].Add(price, new SortedSet<Product>());
            }

            if (!this.productsBySupplierAndPrice.ContainsKey(supplier))
            {
                this.productsBySupplierAndPrice.Add(supplier, new OrderedDictionary<decimal, SortedSet<Product>>());
                this.productsBySupplierAndPrice[supplier].Add(price, new SortedSet<Product>());
            }
            if (!this.productsBySupplierAndPrice[supplier].ContainsKey(price))
            {
                this.productsBySupplierAndPrice[supplier].Add(price, new SortedSet<Product>());
            }
            this.productsBySupplierAndPrice[supplier][price].Add(product);
          
            this.productsById[id] = product;
            this.productsByTitleAndPrice[title][price].Add(product);

            this.productsByPriceRange[price].Add(product);
            this.productsByTitle[title].Add(product);
        }
        //•	Remove product by id – returns true or false
        public bool Remove(int id)
        {           
            if (!this.productsById.ContainsKey(id))
            {
                return false;
            }
            var product = this.productsById[id];
            this.productsBySupplierAndPrice[product.Supplier][product.Price].Remove(product);
            this.productsById.Remove(id);
            this.productsByTitleAndPrice[product.Title][product.Price].Remove(product);
            this.productsByPriceRange[product.Price].Remove(product);
            this.productsByTitle[product.Title].Remove(product);

            return true;
        }
        //•	Find products in given price range[x…y] – returns the products sorted by id
        public IEnumerable<Product> FindRange(int fromPrice, int toPrice)
        {
            var productsInRange = this.productsByPriceRange.Range(fromPrice, true, toPrice, true);
            foreach (var range in productsInRange)
            {
                foreach (var product in range.Value)
                {
                    yield return product;
                }
            }
        } 
        //•	Find products by title – returns the products sorted by id
        public IEnumerable<Product> FindByTitle(string title)
        {
            if (!this.productsByTitle.ContainsKey(title))
            {
                return new List<Product>();
            }
            var productsWithTitle = this.productsByTitle[title];
            return productsWithTitle;
        } 
        //•	Find products by title + price – returns the products sorted by id
        public IEnumerable<Product> FindByTitleAndPrice(string title, decimal price)
        {
            if (!this.productsByTitleAndPrice.ContainsKey(title))
            {
                return new List<Product>();
            }
            if (!this.productsByTitleAndPrice[title].ContainsKey(price))
            {
                return new List<Product>();
            }
            var productsWithTitleAndPrice = this.productsByTitleAndPrice[title][price];
            return productsWithTitleAndPrice;
        } 
        //•	Find products by title + price range – returns the products sorted by id
        public IEnumerable<Product> FindByTitleAndPriceRange(string title, decimal fromPrice, decimal toPrice)
        {
            if (!this.productsByTitleAndPrice.ContainsKey(title))
            {
                yield break;
            }
            var range = this.productsByTitleAndPrice[title].Range(fromPrice, true, toPrice, true);
            foreach (var item in range)
            {
                foreach (var product in item.Value)
                {
                    yield return product;
                }
            }
        } 
        //•	Find products by supplier + price – returns the products sorted by id
        public IEnumerable<Product> FindBySupplierAndPrice(string supplier, decimal price)
        {
            if (!this.productsBySupplierAndPrice.ContainsKey(supplier))
            {
                return new List<Product>();
            }
            if (!this.productsBySupplierAndPrice[supplier].ContainsKey(price))
            {
                return new List<Product>();
            }
            var bySupplierAndPrice = this.productsBySupplierAndPrice[supplier][price];
            return bySupplierAndPrice;
        } 
        //•	Find products by supplier + price range – returns the products sorted by id
        public IEnumerable<Product> FindBySupplierAndPriceRange(string supplier, decimal fromPrice, decimal toPrice)
        {
            if (!this.productsBySupplierAndPrice.ContainsKey(supplier))
            {
                yield break;
            }
            var rangeSuppAndPrice = this.productsBySupplierAndPrice[supplier].Range(fromPrice, true, toPrice, true);
            foreach (var range in rangeSuppAndPrice)
            {
                foreach (var product in range.Value)
                {
                    yield return product;
                }
            }
        } 

    }
}
