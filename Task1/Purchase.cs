using System;

namespace Task1
{
    class Purchase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public Purchase()
        {
            Name = null;
            Price = 0;
            Count = 0;
        }
        public Purchase(string name, decimal price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }
        public virtual string GetTableRow()
        {
            return String.Format("{0,-10:N0}{1,10:N0}{2,10:N0}{3,10:N0}", Name, Price, Count, GetCost());
        }
        public virtual decimal GetCost()
        {
            return (Price*Count);
        }
        public override string ToString()
        {
            return (Name+";"+Price+";"+Count+";"+GetCost().ToString("f2"));
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            return (this.GetHashCode() == obj.GetHashCode());
        }
        public override int GetHashCode()
        {
            return (Name.GetHashCode()+Price.GetHashCode());
        }
    }
}
