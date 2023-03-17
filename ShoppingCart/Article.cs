using System;

namespace ShoppingCart
{
    /// <summary>
    /// Describe a shopping cart entry with product name and quantity. 
    /// </summary>
    public class Article
    {
        private int quantity;

        /// <summary>
        /// Initializes a new article entry for a shopping cart
        /// </summary>
        /// <param name="productName">Name of the product</param>
        /// <param name="qty">Quantity of this product</param>
        /// <param name="price">Unit price</param>
        /// <exception cref="ArgumentOutOfRangeException">thrown if qty or price are nul</exception>
        public Article(string productName, int qty, decimal price)
        {
            if(price <= 0m)
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative or zero.");
            }
            ProductName = productName;
            Quantity = qty;
            Price = price;
        }
        /// <summary>
        /// Gets the product name
        /// </summary>
        public string ProductName { get; private set; }

        /// <summary>
        /// Gets the unit price
        /// </summary>
        public decimal Price { get; private set; }
        /// <summary>
        /// Gets the total price from the unit price and the quantity
        /// </summary>
        public decimal TotalPrice => Quantity * Price;
        /// <summary>
        /// Gets the product quantity for the entry
        /// </summary>
        public int Quantity
        {
            get => quantity;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Quantity cannot be negative or zero");
                }
                quantity = value;
            }
        }
        /// <summary>
        /// Checks if the given article matches the current article
        /// </summary>
        /// <param name="obj">Article to check equality with</param>
        /// <returns>true if the quantity, price and productname of the given object match the current article</returns>
        public override bool Equals(object obj)
            => obj is Article
            && ProductName == (obj as Article).ProductName
            && Price == (obj as Article).Price
            && Quantity == (obj as Article).Quantity;

        /// <summary>
        /// Gets the article hash code. Hash code of equal articles are equals.
        /// </summary>
        /// <returns>Hash code for the current article.</returns>
        public override int GetHashCode()
            => (ProductName,quantity,Price).GetHashCode();
    }
}
