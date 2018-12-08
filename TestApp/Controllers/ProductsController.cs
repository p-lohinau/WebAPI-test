namespace TestApp.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    using TestApp.Models;

    /// <summary>
    /// Defines the <see cref="ProductsController" />
    /// </summary>
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Defines the unitOfWork
        /// </summary>
        private UnitOfWork unitOfWork;

        /// <summary>
        /// Prevents a default instance of the <see cref="ProductsController"/> class from being created.
        /// </summary>
        private ProductsController()
        {
            unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// The GetProducts
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Product}"/></returns>
        public Task<List<Product>> GetProductsAsync()
        {
            return unitOfWork.Product.GetAllAsync();
        }

        /// <summary>
        /// The GetProduct
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Task{IHttpActionResult}"/></returns>
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProductListAsync(int id)
        {
            List<Product> product = await unitOfWork.Product.GetListAsync(id);
            if (product.Count == 0)
            {
                return NotFound();
            }

            return Json(product);
        }

        /// <summary>
        /// The PutProduct
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="product">The product<see cref="Product"/></param>
        /// <returns>The <see cref="Task{IHttpActionResult}"/></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductAsync(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            unitOfWork.Product.Update(product);

            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// The PostProduct
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        /// <returns>The <see cref="Task{IHttpActionResult}"/></returns>
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProductAsync(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.Product.Add(product);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        /// <summary>
        /// The DeleteProduct
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Task{IHttpActionResult}"/></returns>
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProductAsync(int id)
        {
            Product product = await unitOfWork.Product.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await unitOfWork.Product.DeleteAsync(product.Id);
            await unitOfWork.SaveChangesAsync();

            return Ok(product);
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The ProductExists
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private async Task<bool> ProductExistsAsync(int id)
        {
            return (await unitOfWork.Product.GetAllAsync()).Count(e => e.Id == id) > 0;
        }
    }
}
