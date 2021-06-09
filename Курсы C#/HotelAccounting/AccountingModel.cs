using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    //создайте класс AccountingModel здесь
    public class AccountingModel : ModelBase
    {
        private double price;
        private int nightsCount;
        private double discount;
        private double total;
        public double Price 
        {
            get { return price; }
            set
            {
                if (value >= 0)
                {
                    price = value;
                    Total = price * nightsCount * (1 - discount / 100);
                    Notify(nameof(Price));
                }
                else throw new ArgumentException();
            } 
        }

        public int NightsCount
        {
            get { return nightsCount; }
            set
            {
                if (value > 0)
                {
                    nightsCount = value;
                    Total = price * nightsCount * (1 - discount / 100);
                    Notify(nameof(NightsCount));
                }
                else throw new ArgumentException();
            }
        }

        public double Discount 
        {
            get { return discount; } 
            set 
            {
                if (value <= 100)
                {
                    discount = value;
                    Total = price * nightsCount * (1 - discount / 100);
                    Notify(nameof(Discount));
                }
                else throw new ArgumentException();
            } 
        }
        
        public double Total
        {
            get { return total; }
            set
            {
                if (value >= 0)
                {
                    total = price * nightsCount * (1 - discount / 100);
                    Discount = (1 - value / (price * nightsCount)) * 100;
                    Notify(nameof(Total));
                }                 
                else throw new ArgumentException();
            }
        }
    }
}
