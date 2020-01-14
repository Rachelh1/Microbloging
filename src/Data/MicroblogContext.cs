using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microbloging.Models;

namespace Microbloging.Data
{

    public class MicroblogContext : DbContext
    {
        public MicroblogContext() :base("name=DefaultConnection")
        {
            Database.SetInitializer<MicroblogContext>(new CreateDatabaseIfNotExists<MicroblogContext>());
            //Database.SetInitializer<SchoolDBContext>(null);
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey<int>(s => s.Id);

            //base.OnModelCreating(modelBuilder); 
        }
    }
}
