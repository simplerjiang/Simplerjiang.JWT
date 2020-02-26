using Microsoft.IdentityModel.Tokens;
using shared.Interface;
using Simplerjiang.JWT.Interface;
using Simplerjiang.JWT.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Simplerjiang.JWT.Implement
{
    class DefaultTokenResultGenerateFactory : ITokenResultGenerateFactory
    {
        public SymmetricSecurityKey SecurityKey { get; set; }

        public SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

        public DateTime AccessTokenExpiryTime { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

        private ITokenGenerateFactory _tokenGenerateFactory;


        /// <summary>
        /// 默认
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Issuer"></param>
        /// <param name="Audience"></param>
        /// <param name="Claims"></param>
        public DefaultTokenResultGenerateFactory(string Key, string Issuer, string Audience, IEnumerable<Claim> Claims)
        {
            this.Claims = Claims;
            this.Issuer = Issuer;
            this.Audience = Audience;
            this.SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

            this.AccessTokenExpiryTime = DateTime.Now.AddDays(Simplerjiang.JWT.Model.Config.AccessTokenExpiryTimeInDays);
            this.RefreshTokenExpiryTime = DateTime.Now.AddDays(Simplerjiang.JWT.Model.Config.RefreshTokenExpiryTimeIndays);

            _tokenGenerateFactory = new TokenGenerateFactory();
        }


        public TokenResult GetTokenResult()
        {
            var result = new TokenResult()
            {
                AccessTokenExpiryTime = this.AccessTokenExpiryTime,
                AccessToken = _tokenGenerateFactory.Generate(Issuer, Audience, Claims, this.AccessTokenExpiryTime, this.SigningCredentials),
                RefreshTokenExpiryTime = this.RefreshTokenExpiryTime,
                RefreshToken = _tokenGenerateFactory.Generate(Issuer, Audience, Claims, this.RefreshTokenExpiryTime, this.SigningCredentials),
            };
            return result;
        }
    }
}
