using System;
namespace UeharaApi_91Tel.Models
{
    public class Response91Model
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public int Expires_In { get; set; }
        public string Username { get; set; }
        public string Issued { get; set; }
        public string Expires { get; set; }
    };
}
