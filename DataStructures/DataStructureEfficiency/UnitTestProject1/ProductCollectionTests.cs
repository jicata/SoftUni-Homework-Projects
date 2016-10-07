using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using System.Collections.Generic;
    using System.Linq;
    using _03_CollectionOfProducts;

    [TestClass]
    public class ProductCollectionTests
    {
        private ProductCollection collection;

        [TestInitialize]
        public void TestInit()
        {
            this.collection = new ProductCollection();
        }

        [TestMethod]
        public void Add_NewItem_ShouldIncreaseCount()
        {
            this.collection.Add(1,50,"Vafla Mura", "MuraOOD");
            this.collection.Add(2,55,"Vafla Mura","MuraOOD");
            this.collection.Add(3,70,"Banan","Kongo");
            this.collection.Add(4,90,"Portokal","Maika ti");

            Assert.AreEqual(4, this.collection.Count);
        }

        [TestMethod]
        public void Add_NewItem_WithExistingID_ShouldOverrideOldItemAndNotIncreaseCount()
        {
            this.collection.Add(1, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(2, 55, "Vafla Mura", "MuraOOD");
            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(4, 90, "Portokal", "Maika ti");
            this.collection.Add(2, 55, "Vafla Moreni", "MoreniOOD");

            Assert.AreEqual(4, this.collection.Count);
        }

        [TestMethod]
        public void Remove_ExistingItem_ShouldDecreaseCountAndReturnTrue()
        {
            this.collection.Add(1, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(2, 55, "Vafla Mura", "MuraOOD");
            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(4, 90, "Portokal", "Maika ti");

            bool hasBeenRemoved = this.collection.Remove(2);
            Assert.AreEqual(3, this.collection.Count);
            Assert.AreEqual(true,hasBeenRemoved);
        }
        [TestMethod]
        public void Remove_NonExistingItem_ShouldReturnFalseAndNotDecreaseCount()
        {
            this.collection.Add(1, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(2, 55, "Vafla Mura", "MuraOOD");
            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(4, 90, "Portokal", "Maika ti");

            bool hasBeenRemoved = this.collection.Remove(90);
            Assert.AreEqual(4, this.collection.Count);
            Assert.AreEqual(false, hasBeenRemoved);
        }

        [TestMethod]
        public void Find_ProductsInRange_WithValidRange_ShouldReturnSortedCollection()
        {
            List<Product> expectedCollection = new List<Product>();
            expectedCollection.Add(new Product(1, 50, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(2, 55, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(3, 70, "Banan", "Kongo"));
            expectedCollection.Add(new Product(4, 90, "Portokal", "Maika ti"));

            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(1, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(4, 90, "Portokal", "Maika ti");
            this.collection.Add(2, 55, "Vafla Mura", "MuraOOD");

            var range = this.collection.FindRange(50, 90);
            List<Product> actualCollection = new List<Product>(range);
            for (int i = 0; i < actualCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Id, actualCollection[i].Id);
            }
            
        }
        [TestMethod]
        public void Find_ProductsInRange_WithInvalidRange_ShouldReturnEmptyCollection()
        {

            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(1, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(4, 90, "Portokal", "Maika ti");
            this.collection.Add(2, 55, "Vafla Mura", "MuraOOD");

            var range = this.collection.FindRange(100, 190);
            List<Product> actualCollection = new List<Product>(range);
            Assert.AreEqual(0, actualCollection.Count);
        }

        [TestMethod]
        public void Find_ProductsByTitle_ShouldReturnSortedCollection()
        {
            List<Product> expectedCollection = new List<Product>();
            expectedCollection.Add(new Product(1, 50, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(2, 55, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(3, 70, "Banan", "Kongo"));
            expectedCollection.Add(new Product(4, 90, "Portokal", "Maika ti"));

            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(1, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(4, 90, "Portokal", "Maika ti");
            this.collection.Add(2, 55, "Vafla Mura", "MuraOOD");

            var byTitle = this.collection.FindByTitle("Vafla Mura");
            List<Product> actualCollection = new List<Product>(byTitle);

            for (int i = 0; i < actualCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Id, actualCollection[i].Id); 
                // comparing only the first and second item
            }
        }
        public void Find_ProductsByTitleAndPrice_ShouldReturnSortedCollection()
        {
            List<Product> expectedCollection = new List<Product>();
            expectedCollection.Add(new Product(1, 50, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(2, 50, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(5, 65, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(3, 70, "Banan", "Kongo"));
            expectedCollection.Add(new Product(4, 90, "Portokal", "Maika ti"));

            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(1, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(4, 90, "Portokal", "Maika ti");
            this.collection.Add(2, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(5, 65, "Vafla Mura", "MuraOOD");

            var byTitle = this.collection.FindByTitleAndPrice("Vafla Mura", 50);
            List<Product> actualCollection = new List<Product>(byTitle);

            for (int i = 0; i < actualCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Id, actualCollection[i].Id);

            }
        }

        [TestMethod]
        public void Find_ProductsByTitleAndPriceRange_ShouldReturnSortedCollection()
        {
            List<Product> expectedCollection = new List<Product>();
            expectedCollection.Add(new Product(1, 50, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(2, 55, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(5, 65, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(3, 70, "Banan", "Kongo"));
            expectedCollection.Add(new Product(4, 90, "Portokal", "Maika ti"));

            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(1, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(4, 90, "Portokal", "Maika ti");
            this.collection.Add(2, 55, "Vafla Mura", "MuraOOD");
            this.collection.Add(5, 65, "Vafla Mura", "MuraOOD");

            var byTitle = this.collection.FindByTitleAndPriceRange("Vafla Mura", 50, 55);
            List<Product> actualCollection = new List<Product>(byTitle);

            for (int i = 0; i < actualCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Id, actualCollection[i].Id);
               
            }
        }
        [TestMethod]
        public void Find_ProductsBySupplierAndPrice_ShouldReturnStedCollection()
        {
            List<Product> expectedCollection = new List<Product>();
            expectedCollection.Add(new Product(1, 50, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(2, 50, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(5, 65, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(3, 70, "Banan", "Kongo"));
            expectedCollection.Add(new Product(4, 90, "Portokal", "Maika ti"));

            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(1, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(4, 90, "Portokal", "Maika ti");
            this.collection.Add(2, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(5, 65, "Vafla Mura", "MuraOOD");

            var byTitle = this.collection.FindBySupplierAndPrice("Vafla Mura", 50);
            List<Product> actualCollection = new List<Product>(byTitle);

            for (int i = 0; i < actualCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Id, actualCollection[i].Id);

            }
        }
        [TestMethod]
        public void Find_ProductsBySupplierAndPriceRange_ShouldReturnStedCollection()
        {
            List<Product> expectedCollection = new List<Product>();
            expectedCollection.Add(new Product(1, 50, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(2, 55, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(5, 65, "Vafla Mura", "MuraOOD"));
            expectedCollection.Add(new Product(3, 70, "Banan", "Kongo"));
            expectedCollection.Add(new Product(4, 90, "Portokal", "Maika ti"));

            this.collection.Add(3, 70, "Banan", "Kongo");
            this.collection.Add(1, 55, "Vafla Mura", "MuraOOD");
            this.collection.Add(4, 90, "Portokal", "Maika ti");
            this.collection.Add(2, 50, "Vafla Mura", "MuraOOD");
            this.collection.Add(5, 65, "Vafla Mura", "MuraOOD");

            var byTitle = this.collection.FindBySupplierAndPriceRange("Vafla Mura", 50, 65);
            List<Product> actualCollection = new List<Product>(byTitle);

            for (int i = 0; i < actualCollection.Count; i++)
            {
                Assert.AreEqual(expectedCollection[i].Id, actualCollection[i].Id);

            }
        }
    }
}
