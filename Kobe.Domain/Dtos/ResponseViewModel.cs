using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Domain.Dtos
{
    public class ResponseViewModel
    {
        public ResponseViewModel()
        {
            status = 0;
            message = "Error";
        }
        public string message { get; set; }
        public object responseData { get; set; }
        public int status { get; set; }
        public int Total { get; set; }
    }
}
