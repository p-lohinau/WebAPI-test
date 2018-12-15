namespace TestApp.Models.Repository
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ShopRepository" />
    /// </summary>
    public class ShopRepository : IRepository<Shop>
    {
        /// <summary>
        /// Defines the shopDbContext
        /// </summary>
        private ShopDbContext shopDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopRepository"/> class.
        /// </summary>
        /// <param name="shopDbContext">The shopDbContext<see cref="ShopDbContext"/></param>
        public ShopRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Shop}"/></returns>
        public async Task<List<Shop>> GetAllAsync()
        {
            List<Shop> aa = await shopDbContext.Shops.ToListAsync();
            return aa;
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Shop"/></returns>
        public Task<Shop> GetAsync(int id)
        {
            return shopDbContext.Shops.FindAsync(id);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="shop">The shop<see cref="Shop"/></param>
        public void Add(Shop shop)
        {
            shopDbContext.Shops.Add(shop);
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="shops">The shops<see cref="IEnumerable{Shop}"/></param>
        public void AddRange(IEnumerable<Shop> shops)
        {
            shopDbContext.Shops.AddRange(shops);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="shop">The shop<see cref="Shop"/></param>
        public void Update(Shop shop)
        {
            shopDbContext.Entry(shop).State = EntityState.Modified;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task DeleteAsync(int id)
        {
            Shop shop = await shopDbContext.Shops.FindAsync(id);
            if (shop != null)
            {
                shopDbContext.Shops.Remove(shop);
            }
        }
    }
}
