using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolApp.Server.Models
{
    public class BookServiceContext : DbContext
    {
        public BookServiceContext() : base("name=BookServiceContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<SchoolApp.Server.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<SchoolApp.Server.Models.Book> Books { get; set; }

    }
}