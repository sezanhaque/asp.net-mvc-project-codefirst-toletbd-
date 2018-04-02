using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLetBdEntity
{
    interface ICommentRepository
    {
        List<Comment> GetAll();
        Comment Get(int id);
        int Insert(Comment comment);
 
        
    }
}
