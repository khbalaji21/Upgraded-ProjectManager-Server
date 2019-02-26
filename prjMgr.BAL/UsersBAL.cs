using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using prjMgr.DAL;
using prjMgr.Entities.DataModels;

namespace prjMgr.BAL
{
    public class UsersBAL
    {
        UsersDAL dal = new UsersDAL();

        public List<Users> getUsersBAL()
        {
            return dal.GetUsers();
        }

        public Users getUserBAL(int Id)
        {
            return dal.GetUser(Id);
        }

        public bool updateUserBAL(Users users)
        {
            return dal.update(users);
        }

        public bool createUserBAL(Users users)
        {
            return dal.create(users);
        }
    }
}
