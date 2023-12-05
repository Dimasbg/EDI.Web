using EDI.Crud.FE.Data.Api.UserRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Domain.UserService.Models
{
    public class UserDTResponseDomainModel : UserDTResponseApiModel
    {
        public static UserDTResponseDomainModel FromApiModel(UserDTResponseApiModel d)
            => new UserDTResponseDomainModel
            {
                Data = d.Data,
                Draw = d.Draw,
                RecordsFiltered = d.RecordsFiltered,
                RecordsTotal = d.RecordsTotal
            };
    }
}
