using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using prjMgr.Entities.Context;
using prjMgr.Entities.DataModels;

namespace prjMgr.DAL
{
    public class UsersDAL
    {
        private ProjectManagerDBContext db = new ProjectManagerDBContext();

        public List<Users> GetUsers()
        {
            return db.Users.ToList();
        }

        public Users GetUser(int Id)
        {
            Users users = db.Users.Find(Id);
            return users;
        }

        public bool update(Users users)
        {
            var existingUser = db.Users.Where(u => u.Id == users.Id).FirstOrDefault<Users>();
            if (existingUser != null)
            {
                existingUser.first_name = users.first_name;
                existingUser.last_name = users.last_name;
                existingUser.employee_id = users.employee_id;
                db.SaveChanges();
            }
            else
                return false;

            return true;
        }

        public bool create(Users user)
        {
            db.Users.Add(new Users()
            {
                first_name = user.first_name,
                last_name = user.last_name,
                employee_id = user.employee_id
            });
            db.SaveChanges();
            return true;
        }
    }
}
