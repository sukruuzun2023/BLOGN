using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;

namespace BLOGN.Data.Repositories.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository // Kodlarımızı yazıp Context tanımlamasını yapıyopruz ArticleRepository için
    {
        private ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    
    }
}
