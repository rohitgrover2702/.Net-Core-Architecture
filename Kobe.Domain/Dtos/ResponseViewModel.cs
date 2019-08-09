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

    public class Constants
    {
        public const string Error = "Some Internal Error Occurred";
        public const string Success = "Data Saved Successfully";
        public const string Delete = "Data Deleted Successfully";
        public const string Warning = "Data Is Not In Proper Format";
        public const string Retreived = "Data Retrieved Successfully";
        public const string NotFound = "Data Not Found";
    }
}
