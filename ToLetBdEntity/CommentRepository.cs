using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLetBdEntity
{
    public class CommentRepository:ICommentRepository
    {
        ToLetBdDbContext context = new ToLetBdDbContext();
        public List<Comment> GetAll()
        {
            return this.context.Comments.ToList();
        }

        public Comment Get(int id)
        {
            return this.context.Comments.SingleOrDefault(c => c.Id == id);
        }

        public List<Comment> GetByPostId(int id)
        {
            return this.context.Comments.Where(c => c.PostId == id).ToList();
        }

        public int Insert(Comment comment)
        {
            this.context.Comments.Add(comment);
            return this.context.SaveChanges();
        }

     

     
    }
}
