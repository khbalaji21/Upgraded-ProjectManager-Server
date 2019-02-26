using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using prjMgr.BAL;
using prjMgr.Entities.Context;
using prjMgr.Entities.DataModels;

namespace prjMgr.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private ProjectManagerDBContext db = new ProjectManagerDBContext();
        UsersBAL usersBAL = new UsersBAL();

        public List<Users> GetUsers()
        {
            return usersBAL.getUsersBAL();
        }

        public Users GetUsers(int Id)
        {
            return usersBAL.getUserBAL(Id);
        }

        public IHttpActionResult PutUsers(int Id, Users users)
        {
            if (usersBAL.updateUserBAL(users))
            {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult post(Users users)
        {
            if (usersBAL.createUserBAL(users))
            {
                return CreatedAtRoute("DefaultApi", new { Id = users.Id }, users);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public async Task<IHttpActionResult> DeleteUsers(int id)
        {
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            await db.SaveChangesAsync();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}
