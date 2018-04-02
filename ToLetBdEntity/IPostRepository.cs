using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLetBdEntity
{
    interface IPostRepository
    {
        List<Post> GetAll();
        Post Get(int id);
        int Insert(Post post);
        int Update(Post post);
        int Delete(int id);
    }
}
