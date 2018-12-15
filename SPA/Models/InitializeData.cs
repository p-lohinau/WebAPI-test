namespace TestApp.Models
{
    using System.Collections.Generic;
    using System.Data.Entity;

    /// <summary>
    /// Defines the <see cref="InitializeData" />
    /// </summary>
    public class InitializeData : DropCreateDatabaseAlways<ShopDbContext>
    {
        /// <summary>
        /// Database initialize class
        /// </summary>
        /// <param name="db">The db<see cref="ShopDbContext"/></param>
        protected override async void Seed(ShopDbContext db)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Shop amazon = new Shop { ShopName = "Amazon", Schedule = "08:00 - 09:30" };
            Shop microsoft = new Shop { ShopName = "Microsoft Store", Schedule = "08:00 - 10:30" };
            Shop netflix = new Shop { ShopName = "Netflix", Schedule = "08:00 - 24:00" };
            Shop google = new Shop { ShopName = "Google Play Market", Schedule = "08:00 - 15:30" };
            Shop yandex = new Shop { ShopName = "Yandex store", Schedule = "08:00 - 16:30" };
            List<Shop> list = new List<Shop>() { amazon, microsoft, netflix, google, yandex };

            unitOfWork.Shop.AddRange(list);

            Product product11 = new Product { ProductName = "Scissors", ProductDescription = "Just a scissors. Shop Now.", Shop = amazon };
            Product product12 = new Product { ProductName = "Paper", ProductDescription = "Just a paper. Shop Now.", Shop = amazon };
            Product product13 = new Product { ProductName = "Lime", ProductDescription = "Lime is a citrus. Shop Now.", Shop = amazon };
            Product product14 = new Product { ProductName = "Watermelon", ProductDescription = "Not a water. Shop Now.", Shop = amazon };

            Product product21 = new Product { ProductName = "Minecraft", ProductDescription = "Popular videogame. Shop Now.", Shop = microsoft };
            Product product22 = new Product { ProductName = "Microsoft Lumia 925", ProductDescription = "Dual sim, great camera. Shop Now.", Shop = microsoft };
            Product product23 = new Product { ProductName = "Skype", ProductDescription = "Now you can call across the world. Free. Download now.", Shop = microsoft };

            Product product41 = new Product { ProductName = "Instagram", ProductDescription = "Popular app for sharing your photos with your followers. Shop Now.", Shop = google };
            Product product42 = new Product { ProductName = "Telegram", ProductDescription = "Free secure messenger. Shop now.", Shop = google };

            List<Product> products = new List<Product>() { product11, product12, product13, product14, product21, product22, product23, product41, product42 };

            unitOfWork.Product.AddRange(products);
            await unitOfWork.SaveChangesAsync();

            base.Seed(db);
        }
    }
}
