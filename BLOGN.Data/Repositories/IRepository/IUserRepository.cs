using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLOGN.Models;

namespace BLOGN.Data.Repositories.IRepository
{
    public interface IUserRepository //: IRepository<User>
    {
        bool IsUniqueUser(string username);
        User Authenticate(string username,string password);
        User Register(string username,string password);
    }
}
