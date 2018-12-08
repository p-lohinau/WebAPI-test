namespace TestApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Shop" />
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ShopName
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Shop name")]

        public string ShopName { get; set; } = "DefaultShopName";

        /// <summary>
        /// Gets or sets the Schedule
        /// </summary>
        public string Schedule { get; set; } = "08:00  - 19:00";

        /// <summary>
        /// Gets or sets the Products
        /// </summary>
        public ICollection<Product> Products { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shop"/> class.
        /// </summary>
        public Shop()
        {
            Products = new List<Product>();
        }
    }
}
