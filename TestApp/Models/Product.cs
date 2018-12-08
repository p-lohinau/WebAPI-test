namespace TestApp.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Product" />
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Product name")]
        public string ProductName { get; set; } = "DefaultProductName";

        /// <summary>
        /// Gets or sets the ProductDescription
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Product description")]
        public string ProductDescription { get; set; } = "Some product description";

        /// <summary>
        /// Gets or sets the ShopId
        /// </summary>
        public int? ShopId { get; set; }

        /// <summary>
        /// Gets or sets the Shop
        /// </summary>
        public Shop Shop { get; set; }
    }
}
