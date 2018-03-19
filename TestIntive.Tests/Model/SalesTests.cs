using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestIntive.MockupData;

namespace TestIntive.Model.Tests
{
    [TestClass()]
    public class SalesTests
    {
        [TestMethod()]
        public void SalesTest()
        {
            Sales sale = new Sales();
            sale.AddRental(MockUp.GetRentalByDay());
            Assert.AreEqual(20, sale.TotalAmount);
            sale.AddRental(MockUp.GetRentalByHour());
            Assert.AreEqual(25, sale.TotalAmount);
            sale.AddRental(MockUp.GetRentalByWeek());
            Assert.AreEqual(85, sale.TotalAmount);

            List<Rental> rentals = new List<Rental>();
            rentals.Add(MockUp.GetRentalByDay());
            rentals.Add(MockUp.GetRentalByDay());
            rentals.Add(MockUp.GetRentalByDay());

            sale.Promotion = MockUp.GetFamilyPromotion(rentals);
            // 85 previous, 60 new - 30% on the 60
            Assert.AreEqual(127, sale.TotalAmount);
        }

        [TestMethod()]
        public void AddRentalTest()
        {
            Sales sale = new Sales();
            sale.AddRental(MockUp.GetRentalByDay());
            Assert.AreEqual(20, sale.TotalAmount);
            sale.AddRental(MockUp.GetRentalByHour());
            Assert.AreEqual(25, sale.TotalAmount);
            sale.AddRental(MockUp.GetRentalByWeek());
            Assert.AreEqual(85, sale.TotalAmount);

            List<Rental> rentals = new List<Rental>();
            rentals.Add(MockUp.GetRentalByDay());
            rentals.Add(MockUp.GetRentalByDay());
            rentals.Add(MockUp.GetRentalByDay());

            sale.Promotion = MockUp.GetFamilyPromotion(rentals);
            // 85 previous, 60 new - 30% on the 60
            Assert.AreEqual(127, sale.TotalAmount);
        }
    }
}