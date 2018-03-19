using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestIntive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIntive.Model.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void ProductTest()
        {
            Product product = new Product("Bike");
            Assert.AreEqual("Bike", product.Name);
        }
    }
}