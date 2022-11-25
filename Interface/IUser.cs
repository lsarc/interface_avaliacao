using d3_avaliacao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d3_avaliacao.Interface
{
    public interface IUser
    {
        User Read(string email, string password);
    }
}
