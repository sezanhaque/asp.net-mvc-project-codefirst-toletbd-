using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLetBdEntity
{
    public class PostRepository:IPostRepository
    {
        ToLetBdDbContext context = new ToLetBdDbContext();
        public List<Post> GetAll()
        {
            return this.context.Posts.ToList();
        }

        public List<Post> GetPostByArea(String area)
        {
            return this.context.Posts.Where(x => x.Address.Contains(area)).ToList();
        }

        public Post Get(int id)
        {
            return this.context.Posts.SingleOrDefault(p => p.Id == id);
        }

        public List<Post> GetByUserId(int id)
        {
        
            return this.context.Posts.Where(x => x.UserId == id).ToList();
        }

        public List<Post> GetPendingPost()
        {

            return this.context.Posts.Where(x => x.Status == "Pending").ToList();
        }

        public List<Post> GetPublishPost()
        {

            return this.context.Posts.Where(x => x.Status == "Active").ToList();
        }

        public int Insert(Post post)
        {
            this.context.Posts.Add(post);
            return this.context.SaveChanges();
        }

        public int DesablePost(int id)
        {
            Post p = this.context.Posts.SingleOrDefault(pp => pp.Id == id);
            p.Status = "Pending";
            return this.context.SaveChanges();
        }

        public int PublishPost(int id)
        {
            Post p = this.context.Posts.SingleOrDefault(pp => pp.Id == id);
            p.Status = "Active";
            return this.context.SaveChanges();
        }

        public int Update(Post post)
        {
            Post p = this.context.Posts.SingleOrDefault(pp => pp.Id == post.Id);
            p.PostDateTime = post.PostDateTime;
            p.RoomRent = post.RoomRent;
            p.NoOfRoom = post.NoOfRoom;
            p.Title = post.Title;
            p.Address = post.Address;
            p.ShortDesc = post.ShortDesc;
            p.Status = post.Status;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Post p = this.context.Posts.SingleOrDefault(pp => pp.Id == id);
            this.context.Posts.Remove(p);
            return this.context.SaveChanges();
        }

        public int totalPendingPost()
        {
            var c = this.context.Posts.Where(u => u.Status == "Pending").Count();
            return c;
        }

        public int totalPublishedPost()
        {
            var c = this.context.Posts.Where(u => u.Status == "Active").Count();
            return c;
        }

        public int totalPendingPostByUserId(int id)
        {
            var c = this.context.Posts.Where(u => u.Status == "Pending" && u.UserId == id).Count();
            return c;
        }

        public int totalPublishedPostByUserId(int id)
        {
            var c = this.context.Posts.Where(u => u.Status == "Active" && u.UserId == id).Count();
            return c;
        }

        public int EditPost(Post post) { 
            Post p = this.context.Posts.SingleOrDefault(pp => pp.Id == post.Id);
            p.Title = post.Title;
            p.ShortDesc = post.ShortDesc;
            p.RoomRent = post.RoomRent;
            p.Address = post.Address;
            p.NoOfRoom = post.NoOfRoom;
            return this.context.SaveChanges();
        }
    }
}
