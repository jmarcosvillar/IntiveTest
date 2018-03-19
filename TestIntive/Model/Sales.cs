using System;
using System.Collections.Generic;

namespace TestIntive.Model
{
    public class Sales
    {
        DateTime startTime;
        List<Rental> rentals;
        Promotion promotion;
        double totalAmount;

        /// <summary>
        /// Date of the creation of the Sale
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }
        
        /// <summary>
        /// The list of the rentals associated to this sale
        /// </summary>
        public List<Rental> Rentals
        {
            get
            {
                return rentals;
            }
        }

        /// <summary>
        /// The promotion of the Sale
        /// You only can apply one promotion to each Sale.
        /// </summary>
        public Promotion Promotion
        {
            get
            {
                return promotion;
            }
            set
            {
                if (promotion != null)
                    totalAmount -= promotion.TotalAmount;

                promotion = value;
                totalAmount += value.TotalAmount;
            }
        }

        /// <summary>
        /// The total price of the sale, with the discounts of the promotion applied
        /// </summary>
        public double TotalAmount
        {
            get
            {
                return totalAmount;
            }
        }

        public Sales()
        {
            rentals = new List<Rental>();
            startTime = DateTime.Now;
        }

        /// <summary>
        /// Add a new rental to the Sale
        /// </summary>
        /// <param name="r">Rental to be added</param>
        public void AddRental(Rental r)
        {
            rentals.Add(r);
            totalAmount += r.Price;
        }
    }
}
