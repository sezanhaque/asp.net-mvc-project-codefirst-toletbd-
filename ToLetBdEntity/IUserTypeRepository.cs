using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLetBdEntity
{
    interface IUserTypeRepository
    {
        List<UserType> GetAll();
        UserType Get(int id);
        int Insert(UserType uType);
        int Update(UserType uType);
        int Delete(int id);
    }
}
