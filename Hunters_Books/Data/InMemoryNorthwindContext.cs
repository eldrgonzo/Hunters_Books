/*using Hunters_Books.Data;
using Hunters_Books.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace Hunters_Books.Data
{
    public class InMemoryNorthwindContext : DbContext
    {
        

        public List<Books> Genera => Set<Books>();

        protected override IEnumerable<Books> Source => Books;
        protected override int GetKey(Books item) => item.BookID;
        protected override void SetKey(Books item, int key) => item.BookID = key;

    }
}*/
/*
using Hunters_Books.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Hunters_Books.Data
{
    public class InMemoryNorthwindContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<InMemoryNorthwindContext>(null);

            modelBuilder.Entity<Author>()
                .HasKey(a => a.ID);

            modelBuilder.Entity<Books>()
                .HasKey(b => b.Id)
                .HasRequired(b => b.Author)
                .WithMany(a => a.Books
                .HasForeignKey(b => b.AuthorID);
        }

        public List<Books> Genera
        {
            get { return Set<Books>().ToList(); }
        }
    }
}*/

using Hunters_Books.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Hunters_Books.Data
{
    public class InMemoryNorthwindContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<InMemoryNorthwindContext>(null);

            modelBuilder.Entity<Author>()
                .HasKey(a => a.ID);

            modelBuilder.Entity<Books>()
                .HasKey(b => b.Id)
                .HasRequired(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.Author);
        }


        public List<Books> Genres
        {
            get { return Set<Books>().ToList(); }
        }
    }
}
