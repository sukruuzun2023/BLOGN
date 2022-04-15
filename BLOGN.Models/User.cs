using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? FullName { get; set; } // boş geçilebilir oludğunu belirttik ? işareti ile
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Confirmation { get; set; }        
        
        [NotMapped] // Maplenmesini istemiyoruz
        public string Token { get; set; } // Token alanının maplenmesini istemiyoruz


    }
}
