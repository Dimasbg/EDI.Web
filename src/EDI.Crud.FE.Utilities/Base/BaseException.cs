using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Utilities.Base
{
    public class DataApiLayerException : Exception
    {
        public DataApiLayerException()
        {
        }

        public DataApiLayerException(string message) : base(message)
        {
        }

        public DataApiLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataApiLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
