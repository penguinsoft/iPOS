using System;

namespace iPOS.DRO
{
    public class BaseDRO
    {
        public ResponseItem ResponseItem { get; set; }
    }

    public class ResponseItem
    {
        public string RequestUser { get; set; }

        public bool Result { get; set; }

        public string Status { get; set; }

        public string TotalItemCount { get; set; }

        public string Message { get; set; }

        public bool IsError { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
