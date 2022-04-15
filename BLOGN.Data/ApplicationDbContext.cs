using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLOGN.Models;
using Microsoft.EntityFrameworkCore;

namespace BLOGN.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }// burayı tanımladık veri tabanına baglanması için
        public DbSet<User> Users { get; set; }
    }
}
