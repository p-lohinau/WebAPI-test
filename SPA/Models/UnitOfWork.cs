namespace TestApp.Models
{
    using System;
    using System.Threading.Tasks;
    using TestApp.Models.Interface;
    using TestApp.Models.Repository;

    /// <summary>
    /// Defines the <see cref="UnitOfWork" />
    /// </summary>
    public class UnitOfWork : IUnitOfWork ,IDisposable
    {
        /// <summary>
        /// Defines the shopDbContext
        /// </summary>
        private ShopDbContext shopDbContext = new ShopDbContext();

        /// <summary>
        /// Defines the shopRepository
        /// </summary>
        private ShopRepository shopRepository;

        /// <summary>
        /// Defines the productRepository
        /// </summary>
        private ProductsRepository productRepository;

        /// <summary>
        /// Gets the Shop
        /// </summary>
        public ShopRepository Shop
        {
            get
            {
                if (shopRepository == null)
                {
                    shopRepository = new ShopRepository(shopDbContext);
                }

                return shopRepository;
            }
        }

        /// <summary>
        /// Gets the Product
        /// </summary>
        public ProductsRepository Product
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductsRepository(shopDbContext);
                }

                return productRepository;
            }
        }

        /// <summary>
        /// The Commit
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        public Task SaveChangesAsync()
        {
            return shopDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Defines the disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    shopDbContext.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
