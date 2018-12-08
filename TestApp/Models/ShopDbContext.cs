namespace TestApp.Models
{
    using System.Data.Entity;

    /// <summary>
    /// Defines the <see cref="ShopDbContext" />
    /// </summary>
    public class ShopDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the Shops
        /// </summary>
        public virtual DbSet<Shop> Shops { get; set; }

        /// <summary>
        /// Gets or sets the Products
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopDbContext"/> class.
        /// </summary>
        public ShopDbContext()
            : base("ShopDB")
        {
        }
    }
}
