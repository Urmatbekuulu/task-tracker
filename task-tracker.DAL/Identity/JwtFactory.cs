using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using task_tracker.DAL.Configuration;
using task_tracker.DAL.Entities;
using task_tracker.DAL.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace task_tracker.DAL.Identity
{
    public class JwtFactory:IJwtFactory
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfiguration _jwtConfiguration;

        public JwtFactory(UserManager<ApplicationUser> userManager, IOptions<JwtConfiguration> jwtConfiguration)
        {
            _userManager = userManager;
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public async Task<(string token, DateTime expiration)> CreateTokenAsync(string userId, string email, IEnumerable<Claim> additionalClaims = default)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userId),
                new(JwtRegisteredClaimNames.Email, email),
                new(JwtRegisteredClaimNames.Jti, _jwtConfiguration.JtiGenerator()),
                new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(_jwtConfiguration.IssuedAt)
                    .ToUnixTimeSeconds()
                    .ToString(), ClaimValueTypes.Integer64)
            };
            
            claims.AddRange(additionalClaims ?? Array.Empty<Claim>());
            claims.AddRange(roles.Select(x=>new Claim(ClaimTypes.Role,x)));

            var expires = _jwtConfiguration.Expiration;

            var jwt = new JwtSecurityToken(
                issuer:_jwtConfiguration.Issuer,
                audience:_jwtConfiguration.Audience,
                claims:claims,
                notBefore:_jwtConfiguration.NotBefore,
                expires:expires,
                signingCredentials:_jwtConfiguration.SigningCredentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            return (tokenHandler.WriteToken(jwt), expires);

        }

        private static void ThrowIfInvalidOptions(JwtConfiguration options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero) throw new ArgumentException("Must be a nonzero Time-Span.");

            if (options.SigningCredentials == null)
                throw new ArgumentException(nameof(JwtConfiguration.SigningCredentials));
        }
    }
}