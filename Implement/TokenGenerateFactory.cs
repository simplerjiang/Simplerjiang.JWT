using Microsoft.IdentityModel.Tokens;
using shared.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Simplerjiang.JWT.Implement
{
    internal class TokenGenerateFactory : ITokenGenerateFactory
    {
        public string Generate(string Issuer, string Audience,IEnumerable<Claim> Claims, DateTime ExpriyTime, SigningCredentials Cerds)
        {
            //生成token
            var token = new JwtSecurityToken(
                Issuer,
                Audience,
                Claims,
                expires: ExpriyTime,
                signingCredentials: Cerds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
