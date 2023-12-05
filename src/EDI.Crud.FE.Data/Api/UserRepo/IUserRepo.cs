using EDI.Crud.FE.Data.Api.UserRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Data.Api.UserRepo
{
    public interface IUserRepo
    {
        public Task<UserApiModel> Create(UserApiModel d, CancellationToken c);
        public Task<UserApiModel> Read(int id, CancellationToken c);
        public Task Delete(int id, CancellationToken c);
        public Task<UserDTResponseApiModel> DataTable(UserDTParamApiModel p, CancellationToken c);
    }
}
