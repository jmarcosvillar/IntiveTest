using System;

namespace TestIntive.Model
{
    public class Rental
    {
        RentalType type;
        double price;
        Product product;
        DateTime startTime;

        /// <summary>
        /// The rental type
        /// </summary>
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

        /// <summary>
        /// The price of the rental
        /// </summary>
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

        /// <summary>
        /// The product that it will be rented
        /// </summary>
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

        /// <summary>
        /// Create a new rental
        /// </summary>
        /// <param name="type">Type of the rental</param>
        /// <param name="price">Price of the rental</param>
        /// <param name="product">Product that will be rented</param>
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
