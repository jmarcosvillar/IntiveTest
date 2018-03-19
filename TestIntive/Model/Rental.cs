using System;

namespace TestIntive.Model
{
    public class Rental
    {
        RentalType type;
        double price;
        Product product;
        DateTime startTime;

        public RentalType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        public Product Product
        {
            get
            {
                return product;
            }

            set
            {
                product = value;
            }
        }

        public Rental(RentalType type, double price, Product product)
        {
            this.type = type;
            this.price = price;
            this.product = product;
            startTime = DateTime.Now;
        }
    }

    public enum RentalType
    {
        Hour = 1,
        Day = 2,
        Week = 3
    }
}
