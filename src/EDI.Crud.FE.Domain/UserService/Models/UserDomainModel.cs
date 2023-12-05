using EDI.Crud.FE.Data.Api.UserRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Domain.UserService.Models
{
    public class UserDomainModel : UserApiModel
    {
        public static UserDomainModel FromApiModel(UserApiModel d)
            => new UserDomainModel
            {
                NamaLengkap = d.NamaLengkap,
                Password = d.Password,
                Status = d.Status,
                UserId = d.UserId,
                UserName = d.UserName
            };
    }
}
