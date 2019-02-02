using System.Data.Entity;

namespace SchoolApp.Server.Models
{
    public class BookServiceContext : DbContext
    {
        public BookServiceContext() : base("name=BookServiceContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<SchoolApp.Server.Models.DataObject.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<SchoolApp.Server.Models.DataObject.Book> Books { get; set; }

    }
}