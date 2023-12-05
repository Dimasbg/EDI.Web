using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Utilities.Base
{
    public class BaseJsonResponse<T>
    {
        public string Status { get; set; } = BaseConstants.SUCCESS;

        public string ErrorMsg { get; set; }

        public T Response { get; set; }
    }
    public class BaseJsonResponse
    {
        public string Status { get; set; } = BaseConstants.SUCCESS;

        public string ErrorMsg { get; set; }
    }
}
