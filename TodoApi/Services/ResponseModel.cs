using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Context
{
    public class ResponseModel
    {
        public bool IsSuccess
        {
            get;
            set;
        }
        public string Messsage
        {
            get;
            set;
        }
    }
}
