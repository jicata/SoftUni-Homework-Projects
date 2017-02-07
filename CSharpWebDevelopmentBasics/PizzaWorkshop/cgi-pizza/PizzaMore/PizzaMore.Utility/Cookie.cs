namespace PizzaMore.Utility
{
    public class Cookie
    {
        public Cookie()
        {
            this.Name = null;
            this.Value = null;
        }

        public Cookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }
    }
}
