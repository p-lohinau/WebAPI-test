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
    /// Defines the <see cref="ShopsController" />
    /// </summary>
    public class ShopsController : ApiController
    {
        /// <summary>
        /// Defines the unitOfWork
        /// </summary>
        private UnitOfWork unitOfWork;

        /// <summary>
        /// Prevents a default instance of the <see cref="ShopsController"/> class from being created.
        /// </summary>
        private ShopsController()
        {
            unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// The GetShops
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Shop}"/></returns>
        public async Task<IHttpActionResult> GetShopsAsync()
        {
            return Json(await unitOfWork.Shop.GetAllAsync());
        }

        /// <summary>
        /// The GetShop
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Task{IHttpActionResult}"/></returns>
        [ResponseType(typeof(Shop))]
        public async Task<IHttpActionResult> GetShopAsync(int id)
        {
            Shop shop = await unitOfWork.Shop.GetAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            return Json(shop);
        }

        /// <summary>
        /// The PutShop
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="shop">The shop<see cref="Shop"/></param>
        /// <returns>The <see cref="Task{IHttpActionResult}"/></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShopAsync(int id, Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shop.Id)
            {
                return BadRequest();
            }

            unitOfWork.Shop.Update(shop);

            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ShopExistsAsync(id))
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
        /// The PostShop
        /// </summary>
        /// <param name="shop">The shop<see cref="Shop"/></param>
        /// <returns>The <see cref="Task{IHttpActionResult}"/></returns>
        [ResponseType(typeof(Shop))]
        public async Task<IHttpActionResult> PostShopAsync(Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.Shop.Add(shop);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shop.Id }, shop);
        }

        /// <summary>
        /// The DeleteShop
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Task{IHttpActionResult}"/></returns>
        [ResponseType(typeof(Shop))]
        public async Task<IHttpActionResult> DeleteShopAsync(int id)
        {
            Shop shop = await unitOfWork.Shop.GetAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            await unitOfWork.Shop.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();

            return Ok(shop);
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
        /// The ShopExists
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private async Task<bool> ShopExistsAsync(int id)
        {
            return (await unitOfWork.Shop.GetAllAsync()).Count(e => e.Id == id) > 0;
        }
    }
}
