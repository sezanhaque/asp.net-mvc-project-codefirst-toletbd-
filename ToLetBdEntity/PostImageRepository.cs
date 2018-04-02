using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLetBdEntity
{
    public class PostImageRepository:IPostImageRepository
    {
        ToLetBdDbContext context = new ToLetBdDbContext();
        public List<PostImage> GetAll()
        {
            return this.context.PostImages.ToList();
        }

        public PostImage Get(int id)
        {
            return this.context.PostImages.SingleOrDefault(p => p.Id == id);
        }

        public PostImage GetImgByPostId(int id)
        {
            return this.context.PostImages.First(p => p.PostId == id);
        }

        public List<PostImage> GetAllImgByPostId(int id)
        {
            return this.context.PostImages.Where(x => x.PostId == id).ToList();
        }

        public int Insert(PostImage image)
        {
            this.context.PostImages.Add(image);
            return this.context.SaveChanges();
        }

        public int Update(PostImage image)
        {
            PostImage p = this.context.PostImages.SingleOrDefault(pp => pp.Id == image.Id);
            p.ImgPath = image.ImgPath;
   
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            PostImage p = this.context.PostImages.SingleOrDefault(pp => pp.Id == id);
            this.context.PostImages.Remove(p);
            return this.context.SaveChanges();
        }
    }
}
