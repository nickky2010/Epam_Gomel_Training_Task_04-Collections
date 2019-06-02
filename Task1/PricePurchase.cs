using System;

namespace Task1
{
    class PricePurchase: Purchase
    {
        private decimal discount;
        public decimal Discount
        {
            get => discount;
            private set
            {
                if (value > Price)
                {
                    throw new ArgumentException("The discount can't be more than price");
                }
                if (value < 0)
                {
                    throw new ArgumentException("The discount can't be less than 0");
                }
                discount = value;
            }
        }
        public PricePurchase()
        {
            Discount = 0;
        }
        public PricePurchase(string name, decimal price, int count, decimal discount) 
            : base(name, price, count)
        {
            Discount = discount;
        }
        public override string GetTableRow()
        {
            return (base.GetTableRow() + String.Format("{0,10:N0}", discount));
        }
        public override decimal GetCost()
        {
            if (discount > 0)
            {
                return (decimal.Round(Price - discount) * Count);
            }
            else
            {
                return base.GetCost();
            }
        }
        public override string ToString()
        {
            return (base.ToString()+";"+ discount);
        }
    }
}
