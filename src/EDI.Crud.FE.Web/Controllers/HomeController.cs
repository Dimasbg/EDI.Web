using EDI.Crud.FE.Domain.UserService;
using EDI.Crud.FE.Utilities.Base;
using EDI.Crud.FE.Web.Models;
using EDI.Crud.FE.Web.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Paging(CancellationToken c)
        {
            var result = await _userService.PagingDataTable(Request.Form, c);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken c)
        {
            try
            {
                await _userService.Delete(id, c);
                return Ok(new BaseJsonResponse());
            }
            catch (DataApiLayerException e)
            {
                return Ok(new BaseJsonResponse
                {
                    Status = BaseConstants.FAILED,
                    ErrorMsg = e.Message
                });
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel p, CancellationToken c)
        {
            try
            {
                var result = await _userService.Create(p, c);
                return Ok(new BaseJsonResponse());
            }
            catch (DataApiLayerException e)
            {
                return Ok(new BaseJsonResponse
                {
                    Status = BaseConstants.FAILED,
                    ErrorMsg = e.Message
                });
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
