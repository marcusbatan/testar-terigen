using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public class BlogRepos
    {
        public BlogPost AddBlogg(string cat, string text, string userId)
        {
            using (var db = new HemsidaEntities())
            {
                var post = new BlogPost
                {
                    BlogId = Guid.NewGuid(),
                    Category = cat,
                    Text = text,
                    UserId = userId
                };
                db.BlogPost.Add(post);
                db.SaveChanges();
                return post;
            }
        }
    }
}
