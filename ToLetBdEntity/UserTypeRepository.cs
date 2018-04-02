using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLetBdEntity
{
    public class UserTypeRepository:IUserTypeRepository
    {
        ToLetBdDbContext context = new ToLetBdDbContext();
        public List<UserType> GetAll()
        {
            return this.context.UserTypes.ToList();
        }

        public UserType Get(int id)
        {
            return this.context.UserTypes.SingleOrDefault(u => u.Id == id);
        }

        public int Insert(UserType uType)
        {
            this.context.UserTypes.Add(uType);
            return this.context.SaveChanges();
        }

        public int Update(UserType uType)
        {
            UserType u = this.context.UserTypes.SingleOrDefault(ut => ut.Id == uType.Id);
            u.TypeName = uType.TypeName;
           
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            UserType u = this.context.UserTypes.SingleOrDefault(uu => uu.Id == id);
            this.context.UserTypes.Remove(u);
            return this.context.SaveChanges();
        }

       
    }
}
