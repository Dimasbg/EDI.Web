using EDI.Crud.FE.Data.Api.UserRepo;
using EDI.Crud.FE.Data.Api.UserRepo.Models;
using EDI.Crud.FE.Domain.UserService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Domain.UserService.Impl
{
    public class UserServiceImpl : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserServiceImpl(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDomainModel> Create(UserDomainModel d, CancellationToken c)
            => UserDomainModel.FromApiModel(await _userRepo.Create(d, c));

        public async Task Delete(int id, CancellationToken c)
            => await _userRepo.Delete(id, c);

        public async Task<UserDTResponseDomainModel> PagingDataTable(IFormCollection reqFormData, CancellationToken c)
        {
            UserDTParamApiModel p = new UserDTParamApiModel();
            p.Skip = Convert.ToInt32(reqFormData["start"].ToString());
            p.PageSize = Convert.ToInt32(reqFormData["length"].ToString());
            p.ColumnIndex = ColumnOrder(reqFormData);
            p.SortDirection = !string.IsNullOrEmpty(reqFormData["order[0][dir]"].ToString()) ? reqFormData["order[0][dir]"].ToString() : "desc";
            p.Draw = Convert.ToInt32(reqFormData["draw"].ToString());

            return UserDTResponseDomainModel.FromApiModel(await _userRepo.DataTable(p, c));
        }

        private string ColumnOrder(IFormCollection reqFormData)
        {
            string ColumnIndex = "Id";
            if (!string.IsNullOrWhiteSpace(reqFormData["order[0][column]"].ToString()))
            {
                string s = reqFormData["columns[" + reqFormData["order[0][column]"] + "][data]"].ToString();
                if (!string.IsNullOrEmpty(s))
                    ColumnIndex = char.ToUpper(s[0]) + s.Substring(1);
            }
            return ColumnIndex;
        }

        public async Task<UserDomainModel> Read(int id, CancellationToken c)
            => UserDomainModel.FromApiModel(await _userRepo.Read(id, c));
    }
}
