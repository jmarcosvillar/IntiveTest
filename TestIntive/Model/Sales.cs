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

        public List<Rental> Rentals
        {
            get
            {
                return rentals;
            }
        }

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

        public void AddRental(Rental r)
        {
            rentals.Add(r);
            totalAmount += r.Price;
        }
    }
}
