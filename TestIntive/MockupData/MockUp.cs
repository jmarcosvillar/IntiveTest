using System.Collections.Generic;
using TestIntive.Model;

namespace TestIntive.MockupData
{
    public class MockUp
    {
        public static Product GetProduct()
        {
            Product product = new Model.Product("Bike");
            return product;
        }
        public static Rental GetRentalByHour()
        {
            Rental rental = new Rental(RentalType.Hour, 5, GetProduct());
            return rental;
        }
        public static Rental GetRentalByDay()
        {
            Rental rental = new Rental(RentalType.Day, 20, GetProduct());
            return rental;
        }
        public static Rental GetRentalByWeek()
        {
            Rental rental = new Rental(RentalType.Week, 60, GetProduct());
            return rental;
        }
        public static Promotion GetFamilyPromotion(List<Rental> rentals)
        {
            Promotion promotion = new Promotion("Family Promotion", PromotionType.Percentage, 30, rentals);
            return promotion;
        }
        public static Sales GetSale()
        {
            Sales sale = new Sales();
            return sale;
        }
    }
}
