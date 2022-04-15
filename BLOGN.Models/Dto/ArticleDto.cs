using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Models.Dto
{
    public class ArticleDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime ArticleDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
       // public Category Category { get; set; } //kullanıcın görmesini istemiyorum 
    }
}
