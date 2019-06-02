using System.Collections.Generic;

namespace Task1
{
    class PurchasesByNamesComparator : IComparer<Purchase>
    {
        public int Compare(Purchase x, Purchase y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            if (x.Name != y.Name)
            {
                return (x.Name.CompareTo(y.Name));
            }
            else
            {
                if (x.GetType() == y.GetType())
                {
                    return x.GetCost().CompareTo(y.GetCost());
                }
                if (x.GetType() == typeof(PricePurchase))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
