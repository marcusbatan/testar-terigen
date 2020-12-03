using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public class CategoryRepos
    {
        public Category CreateCategory(string catName, string desc)
        {
            using (var db = new HemsidaEntities())
            {
                var cat = new Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = catName,
                    Description = desc
                };
                db.Category.Add(cat);
                db.SaveChanges();
                return cat;
            }
        }
    }
}
