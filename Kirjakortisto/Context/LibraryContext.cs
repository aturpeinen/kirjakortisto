namespace Kirjakortisto.Context
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=Library")
        {
        }


        public virtual DbSet<Book> MyEntities { get; set; }
    }

}