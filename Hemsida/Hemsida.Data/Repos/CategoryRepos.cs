using Hemsida.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemsida.Data.Repos
{
    public interface CategoryRepos
    {
        IEnumerable<Category> Categories { get; }
    }
}
