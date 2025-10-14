namespace Poo.Bussisness
{
    public abstract class Bebida
    {
        private string _name = string.Empty;
        public string Name { get => _name; set => _name = $"cerveza {value}"; }
        public decimal Price { get; set; }

        public string Category { get; set; } = string.Empty;

        public abstract string GetInfo();

        public abstract string GetCategory();

        public Bebida() { }

        public Bebida(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}