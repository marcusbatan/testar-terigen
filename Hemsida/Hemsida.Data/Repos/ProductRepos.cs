using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public class ProductRepos
    {
        public Product AddProduct(decimal price, string longDesc, string shortDesc, byte[] img, string prodName, Guid? catId)
        {
            using(var db = new HemsidaEntities())
            {

                var prod = new Product
                {
                    ProductId = Guid.NewGuid(),
                    DateTime = DateTime.Now,
                    Price = price,
                    LongDescription = longDesc,
                    ShortDescription = shortDesc,
                    Img = img,
                    Name = prodName,
                    CategoryId = catId
                };
                db.Product.Add(prod);
                db.SaveChanges();
                return prod;
            }
        }
        public Product getProduct(Guid id)
        {
            using(var db = new HemsidaEntities())
            {
                var getTheProduct = db.Product.Where(u => u.ProductId == id).FirstOrDefault();
                return getTheProduct;
            }
        }
        public List<Product> SearchProd(string search)
        {
            using(var db = new HemsidaEntities())
            {
                return db.Product.Where(u => u.Name.Contains(search)).ToList();
            }
        }
    }
}
