using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;

namespace BLOGN.Data.Repositories.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository // Kodlarımızı yazıp Context tanımlamasını yapıyopruz CategoryRepository için
    {
        private ApplicationDbContext _context;   
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
