namespace Kirjakortisto.Context
{
    using Models;
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Core.EntityClient;
    using System.Linq;

    public interface ILibraryContext
    {
        IDbSet<Book> Books { get; set; }
    }

    public class LibraryContext : DbContext, ILibraryContext
    {
        public LibraryContext()
            : base("name=Library")
        {
        }

        public LibraryContext(string name)
            : base("name=" + name)
        {
        }

        public LibraryContext(DbConnection connection)
            : base(connection, true)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public LibraryContext(EntityConnection connection)
            : base(connection, true)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        /*
                public new IDbSet<T> Set<T>() where T : class
                {
                    return base.Set<T>();
                }


                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    //Configure domain classes using Fluent API here

                    base.OnModelCreating(modelBuilder);
                }

                public void ExecuteCommand(string command, params object[] parameters)
                {
                    base.Database.ExecuteSqlCommand(command, parameters);
                }*/


        public IDbSet<Book> Books { get; set; }
    }

}