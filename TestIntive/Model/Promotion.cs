using System.Collections.Generic;
using TestIntive.Exceptions;

namespace TestIntive.Model
{
    public class Promotion
    {
        private const int MAX_RENTAL_AMOUNT = 5;
        private const int MIN_RENTAL_AMOUNT = 3;

        string name;
        PromotionsType type;
        double discount;
        List<Rental> rentals;
        double totalAmount = 0;
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
        public PromotionsType Type
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
        public double TotalAmount
        {
            get
            {
                return totalAmount;
            }
        }

        public Promotion(string name, PromotionsType type, double discount, List<Rental> rentals)
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
                case PromotionsType.Percentage:
                    r.Price -= (r.Price * discount) / 100;
                    break;
                case PromotionsType.FixedAmount:
                    r.Price = r.Price - discount;
                    break;
            }
        }
    }

    public enum PromotionsType
    {
        FixedAmount = 1,
        Percentage = 2
    }
}
