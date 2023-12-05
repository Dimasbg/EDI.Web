using EDI.Crud.FE.Domain.UserService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Domain.UserService
{
    public interface IUserService
    {
        public Task<UserDomainModel> Create(UserDomainModel d, CancellationToken c);
        public Task<UserDomainModel> Read(int id, CancellationToken c);
        public Task Delete(int id, CancellationToken c);
        public Task<UserDTResponseDomainModel> PagingDataTable(IFormCollection reqFormData, CancellationToken c);
    }
}
