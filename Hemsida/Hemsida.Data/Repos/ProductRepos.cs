using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public interface ProductRepos
    {
        IEnumerable<Product> Products { get; set; }
        IEnumerable<Product> PrefdProducts { get; set; }
        Product GetProductById(Guid id);
    }
}
