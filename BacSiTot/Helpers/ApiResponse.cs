namespace BacSiTot.Helpers
{
    public class ApiResponse
    {
        public string Token { get; set; } // user's token
        public string Status { get; set; } // api 's status: success, failed
        public object Data { get; set; } // api 's result include messages error
        public object Extend { get; set; } //  pagination

        public string GetToken()
        {
            return Token;
        }

        public void SetToken(string token)
        {
            Token = token;
        }

        public string GetStatus()
        {
            return Status;
        }
        public void SetMessage(int statusCode, string message)
        {
            Data = new JMessage(statusCode, message);
        }

        public void SetStatusSuccess()
        {
            Status = "SUCCESS";
        }
        public void SetStatusFailed()
        {
            Status = "FAILED";
        }

        public object GetData()
        {
            return Data;
        }

        public void SetData(object data)
        {
            Data = data;
        }

        public object GetExt()
        {
            return Extend;
        }

        public void SetExt(object ext)
        {
            Extend = ext;
        }
    }

    public class JMessage
    {
        public string Msg { get; set; }
        public int StatusCode { get; set; }

        public JMessage(int sttCode, string msg)
        {
            Msg = msg;
            StatusCode = sttCode;
        }
    }

    public class JPaging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}