using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Data.Api.UserRepo.Models
{
    public class UserDTResponseApiModel
    {
        public int Draw { get; set; }

        public int RecordsFiltered { get; set; }

        public int RecordsTotal { get; set; }

        public IEnumerable<UserApiModel> Data { get; set; }
    }
}
