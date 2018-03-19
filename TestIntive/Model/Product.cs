namespace TestIntive.Model
{
    public class Product
    {
        string name;

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
        public Product(string name)
        {
            this.name = name;
        }
    }
}
