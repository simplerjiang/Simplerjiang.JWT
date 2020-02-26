using Microsoft.IdentityModel.Tokens;
using Simplerjiang.JWT.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Simplerjiang.JWT.Interface
{
    /// <summary>
    /// 此类为深层次的包装
    /// </summary>
    interface ITokenResultGenerateFactory
    {
        SymmetricSecurityKey SecurityKey { get; set; }

        SigningCredentials SigningCredentials { get; }

        DateTime AccessTokenExpiryTime { get; set; }

        DateTime RefreshTokenExpiryTime { get; set; }

        IEnumerable<Claim> Claims { get; set; }

        string Issuer { get; set; }

        string Audience { get; set; }

        TokenResult GetTokenResult();
    }
}
