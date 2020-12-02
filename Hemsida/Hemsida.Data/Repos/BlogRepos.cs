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
        public Blog AddBlogg(string cat, string text, string userId, DateTime time, byte[] img)
        {
            using(var db = new HemsidaEntities())
            {
                var post = new Blog
                {
                    BlogId = Guid.NewGuid(),
                    Category = cat,
                    Text = text,
                    UserId = userId,
                    DateTime = time,
                    Img = img
                };
                db.Blog.Add(post);
                db.SaveChanges();
                return post;
            }
        }
        public Blog GetBlog (Guid id)
        {
            using (var db = new HemsidaEntities())
            {
                var blog = db.Blog.Where(u => u.BlogId == id).FirstOrDefault();
                return blog;
            }
        }
    }
}
