using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToLetBdEntity
{
    public class UserRepository:IUserRepository
    {
        ToLetBdDbContext context = new ToLetBdDbContext();
        public List<User> GetAll()
        {
            return this.context.Users.ToList();
        }

        public User Get(int id)
        {
            return this.context.Users.SingleOrDefault(u => u.Id == id);
        }


        public int ChangePassById(int id, String pass)
        {
           
            User us = this.context.Users.SingleOrDefault(u => u.Id == id);
            us.Password = pass;
            return this.context.SaveChanges();
       

        }

        public User GetByEmailAndPass(User u)
        {
            return this.context.Users.SingleOrDefault(x => x.Email == u.Email && x.Password==u.Password);
        }

        public List<User> GetByUserTypeId(int id)
        {
            return this.context.Users.Where(x => x.UserTypeId == id).ToList();
        }

        public int Insert(User user)
        {
            this.context.Users.Add(user);
            return this.context.SaveChanges();
        }

        public int Update(User user)
        {
            User u = this.context.Users.SingleOrDefault(us => us.Id == user.Id);
            u.Name = user.Name;
            u.Email = user.Email;
            u.PhnNo = user.PhnNo;
            return this.context.SaveChanges();
        }

        public int UpdateWithImg(User user)
        {
            User u = this.context.Users.SingleOrDefault(us => us.Id == user.Id);
            u.Name = user.Name;
            u.Email = user.Email;
            u.PhnNo = user.PhnNo;
            u.ImgPath = user.ImgPath;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            
            User u = this.context.Users.SingleOrDefault(uu => uu.Id == id);
            this.context.Users.Remove(u);
            return this.context.SaveChanges();
        }

        public int totalHouseOwner()
        {
            var c = this.context.Users.Where(u => u.UserTypeId == 2).Count();
            return c;
        }

        public int totalRenter()
        {
            var c = this.context.Users.Where(u => u.UserTypeId == 3).Count();
            return c;
        }

        
      

        
    }
}
