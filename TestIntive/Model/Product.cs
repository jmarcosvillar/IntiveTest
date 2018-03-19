namespace TestIntive.Model
{
    /// <summary>
    /// Products class
    /// </summary>
    public class Product
    {
        string name;

        /// <summary>
        /// The name of the product
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

        public Product(string name)
        {
            this.name = name;
        }
    }
}
