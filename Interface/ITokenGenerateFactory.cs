using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace shared.Interface
{
    interface ITokenGenerateFactory
    {
        string Generate(string Issuer, string Audience,IEnumerable<Claim> Claims, DateTime ExpriyTime, SigningCredentials Cerds);
    }
}
