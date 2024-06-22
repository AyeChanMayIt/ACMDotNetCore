using ACMDotNetCore.ConsoleApp.Services;
using ACMDotNetCore.MinimalAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMDotNetCore.MinimalAPI.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
      
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
