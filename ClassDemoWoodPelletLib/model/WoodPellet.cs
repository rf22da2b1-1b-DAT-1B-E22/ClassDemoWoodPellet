using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoWoodPelletLib.model
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public String Brand { get; set; }
        public double Price { get; set; }
        public int Quality { get; set; }



        public WoodPellet() : this(0, "dummy", 0, 1)
        {
        }

        public WoodPellet(int id, string brand, double price, int quality)
        {
            Id = id;
            Brand = brand;
            Price = price;
            Quality = quality;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Brand)}={Brand}, {nameof(Price)}={Price.ToString()}, {nameof(Quality)}={Quality.ToString()}}}";
        }



        /*
         * Checkin constraints
         */

        public bool CheckBrand()
        {
            if (string.IsNullOrWhiteSpace(Brand) || Brand.Length < 2)
            {
                throw new ArgumentException("Brand must be at least 2 characters");
            }
            return true;
        }

        public bool CheckPrice()
        {
            if (Price < 0)
            {
                throw new ArgumentException("Price must be a positive number or zero");
            }
            return true;
        }

        public bool CheckQuality()
        {
            if (Quality < 1 || 5 < Quality)
            {
                throw new ArgumentException("Quality must be a number between 1-5, both included");
            }
            return true;
        }

        public bool Validate()
        {
            CheckBrand();
            CheckPrice();
            CheckQuality();

            return true;
        }

    }
}
