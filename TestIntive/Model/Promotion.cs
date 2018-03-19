using System.Collections.Generic;
using TestIntive.Exceptions;

namespace TestIntive.Model
{
    /// <summary>
    /// The promotions have multiple rentals and apply discounts
    /// </summary>
    public class Promotion
    {
        private const int MAX_RENTAL_AMOUNT = 5;
        private const int MIN_RENTAL_AMOUNT = 3;

        string name;
        PromotionType type;
        double discount;
        List<Rental> rentals;
        double totalAmount = 0;

        /// <summary>
        /// The name of the promotion
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Type of promotion
        /// </summary>
        public PromotionType Type
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
        /// Apply discounts to the price of each rentals. 
        /// </summary>
        /// <remarks>Take in account the PromotionType</remarks>
        public double Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }

        /// <summary>
        /// The total price of all the rentals on this promotion, with the discount applied
        /// </summary>
        public double TotalAmount
        {
            get
            {
                return totalAmount;
            }
        }

        /// <summary>
        /// Create a new promotion
        /// </summary>
        /// <param name="name">Name of the promotion</param>
        /// <param name="type">Type of the promotion</param>
        /// <param name="discount">Discount to be applied to the rentals</param>
        /// <param name="rentals">Rentals contained on this promotion</param>
        public Promotion(string name, PromotionType type, double discount, List<Rental> rentals)
        {
            if (rentals.Count >= MIN_RENTAL_AMOUNT)
            {
                if (rentals.Count <= MAX_RENTAL_AMOUNT)
                {
                    this.name = name;
                    this.type = type;
                    this.discount = discount;

                    foreach (Rental r in rentals)
                    {
                        CalculatePromotions(r);
                        totalAmount += r.Price;
                    }

                    this.rentals = rentals;
                }
                else
                {
                    throw new TooManyRentalException();
                }
            }
            else
            {
                throw new NotEnoughRentalsException();
            }
        }

        /// <summary>
        /// Add a new rental to this promotion.
        /// </summary>
        /// <remarks>Take in account the max rental amount</remarks>
        /// <param name="rental">Rental too add</param>
        public void AddRental(Rental rental)
        {
            if (rentals.Count <= MAX_RENTAL_AMOUNT)
            {
                CalculatePromotions(rental);
                rentals.Add(rental);
                totalAmount += rental.Price;
            }
            else
            {
                throw new TooManyRentalException();
            }
        }
        private void CalculatePromotions(Rental r)
        {
            switch (type)
            {
                case PromotionType.Percentage:
                    r.Price -= (r.Price * discount) / 100;
                    break;
                case PromotionType.FixedAmount:
                    r.Price = r.Price - discount;
                    break;
            }
        }
    }

    /// <summary>
    /// Promotion type
    /// </summary>
    public enum PromotionType
    {
        FixedAmount = 1,
        Percentage = 2
    }
}
