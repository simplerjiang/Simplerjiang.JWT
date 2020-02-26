using System;
using System.Collections.Generic;
using System.Text;

namespace Simplerjiang.JWT.Model
{
    class TokenResult
    {

        public string AccessToken { get; set; }

        public DateTime AccessTokenExpiryTime { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
