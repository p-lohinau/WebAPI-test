namespace TestApp.Models.Repository
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ProductsRepository" />
    /// </summary>
    public class ProductsRepository : IRepository<Product>
    {
        /// <summary>
        /// Defines the shopDbContext
        /// </summary>
        private ShopDbContext shopDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsRepository"/> class.
        /// </summary>
        /// <param name="shopDbContext">The shopDbContext<see cref="ShopDbContext"/></param>
        public ProductsRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Product}"/></returns>
        public Task<List<Product>> GetAllAsync()
        {
            return shopDbContext.Products.ToListAsync();
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{Product}"/></returns>
        public Task<Product> GetAsync(int id)
        {
            return shopDbContext.Products.FindAsync(id);
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Product"/></returns>
        public Task<List<Product>> GetListAsync(int id)
        {
            return shopDbContext.Products.Where(x => x.ShopId == id).ToListAsync();
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        public void Add(Product product)
        {
            shopDbContext.Products.Add(product);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="products">The products<see cref="IEnumerable{Product}"/></param>
        public void AddRange(IEnumerable<Product> products)
        {
            shopDbContext.Products.AddRange(products);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        public void Update(Product product)
        {
            shopDbContext.Entry(product).State = EntityState.Modified;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task DeleteAsync(int id)
        {
            Product order = await shopDbContext.Products.FindAsync(id);
            if (order != null)
            {
                shopDbContext.Products.Remove(order);
            }
        }
    }
}
