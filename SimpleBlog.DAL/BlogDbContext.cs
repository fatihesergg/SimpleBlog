using Microsoft.EntityFrameworkCore;
using SimpleBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.DAL
{
    public class BlogDbContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BlogDbContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
