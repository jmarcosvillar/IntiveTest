using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestIntive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntive.MockupData;

namespace TestIntive.Model.Tests
{
    [TestClass()]
    public class RentalTests
    {
        [TestMethod()]
        public void RentalTest()
        {
            Rental rental = new Rental(RentalType.Week, 60, MockUp.GetProduct());
            Assert.AreEqual(60, rental.Price);
            Assert.AreEqual(MockUp.GetProduct().Name, rental.Product.Name);
            Assert.AreEqual(RentalType.Week, rental.Type);
        }
    }
}