using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public class ProductRepos
    {
        public Product AddProduct(Product product)
        {
            using(var db = new HemsidaEntities())
            {
                db.Product.Add(product);
                db.SaveChanges();
                return product;
            }
        }
    }
}
