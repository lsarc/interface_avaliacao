using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_avaliacao.Data
{
    public class User
    {
        [Key]
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }


}
