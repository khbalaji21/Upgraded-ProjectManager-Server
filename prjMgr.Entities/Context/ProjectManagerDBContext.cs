using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using prjMgr.Entities.DataModels;

namespace prjMgr.Entities.Context
{
    public class ProjectManagerDBContext : DbContext
    {
        public ProjectManagerDBContext() : base("name=ProjectEntities")
        {

        }

        public DbSet<Users> Users { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
           
        //}
    }
}
