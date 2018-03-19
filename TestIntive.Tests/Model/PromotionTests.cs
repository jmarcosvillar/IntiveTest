using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestIntive.Exceptions;
using TestIntive.MockupData;

namespace TestIntive.Model.Tests
{
    [TestClass()]
    public class PromotionTests
    {
        [TestMethod()]
        public void PromotionTest()
        {
            List<Rental> rentals = new List<Rental>();
            var rental1 = MockUp.GetRentalByDay();
            var rental2 = MockUp.GetRentalByHour();
            var rental3 = MockUp.GetRentalByWeek();
            rentals.Add(rental1);
            rentals.Add(rental2);
            rentals.Add(rental3);

            var price1 = rental1.Price;
            var price2 = rental2.Price;
            var price3 = rental3.Price;

            Promotion promotion = MockUp.GetFamilyPromotion(rentals);

            var discount = (price1 + price2 + price3) * 0.3;

            Assert.AreEqual(85 - discount, promotion.TotalAmount);
        }

        [TestMethod()]
        public void AddRentalTest()
        {
            List<Rental> rentals = new List<Rental>();
            var rental1 = MockUp.GetRentalByDay();
            var rental2 = MockUp.GetRentalByHour();
            var rental3 = MockUp.GetRentalByWeek();
            rentals.Add(rental1);
            rentals.Add(rental2);
            rentals.Add(rental3);

            var price1 = rental1.Price;
            var price2 = rental2.Price;
            var price3 = rental3.Price;

            Promotion promotion = MockUp.GetFamilyPromotion(rentals);

            var discount = (price1 + price2 + price3) * 0.3;
            var valueWithDiscount = 85 - discount;

            Assert.AreEqual(valueWithDiscount, promotion.TotalAmount);

            promotion.AddRental(MockUp.GetRentalByDay());

            Assert.AreEqual(14 + valueWithDiscount, promotion.TotalAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughRentalsException),
       "To apply this promotion, you need to have more Rentals")]
        public void PromotionNotEnoughRentalsTest()
        {
            List<Rental> rentals = new List<Rental>();
            rentals.Add(MockUp.GetRentalByDay());
            rentals.Add(MockUp.GetRentalByHour());

            Promotion promotion = MockUp.GetFamilyPromotion(rentals);
        }

        [TestMethod]
        [ExpectedException(typeof(TooManyRentalException),
        "To apply this promotion, you need to have less Rentals")]
        public void PromotionTooManyRentalsTest()
        {
            List<Rental> rentals = new List<Rental>();
            rentals.Add(MockUp.GetRentalByDay());
            rentals.Add(MockUp.GetRentalByHour());
            rentals.Add(MockUp.GetRentalByWeek());
            rentals.Add(MockUp.GetRentalByDay());
            rentals.Add(MockUp.GetRentalByHour());
            rentals.Add(MockUp.GetRentalByWeek());

            Promotion promotion = MockUp.GetFamilyPromotion(rentals);
        }

        [TestMethod]
        public void PromotionApplyedOnRentalsTest()
        {
            List<Rental> rentals = new List<Rental>();
            var rental1 = MockUp.GetRentalByDay();
            var rental2 = MockUp.GetRentalByHour();
            var rental3 = MockUp.GetRentalByWeek();
            rentals.Add(rental1);
            rentals.Add(rental2);
            rentals.Add(rental3);

            var price1 = rental1.Price;
            var price2 = rental2.Price;
            var price3 = rental3.Price;

            Promotion promotion = MockUp.GetFamilyPromotion(rentals);

            var discount = (price1 + price2 + price3) * 0.3;

            Assert.AreEqual(85 - discount, promotion.TotalAmount);
        }
    }
}