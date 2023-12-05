using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Data.Api.UserRepo.Models
{
    public class UserApiModel
    {
        public int UserId { get; set; }
        public string NamaLengkap { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public char Status { get; set; }
    }
}
