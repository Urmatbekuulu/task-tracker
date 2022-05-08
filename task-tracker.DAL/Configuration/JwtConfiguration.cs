﻿using System;
using Microsoft.IdentityModel.Tokens;

namespace task_tracker.DAL.Configuration
{
    public class JwtConfiguration
    {
        /// <summary>
        /// Gets or sets the "iss" (Issues) Claim - The "iss" (issues) claim identifies the principal that is issued the JWT.
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Gets or sets the "sub" (Subject) Claim - The "sub" (subject) claim identifies the principal that is the subject of the JWT.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the "aud" (Audience) Claim - The "aud" (audience) claim identifies the recipients that the JWT is intended for.
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Gets the "exp" (Expiration Time) Claim - The "exp" (expiration time) claim identifie the expiration time on or after which the JWT MUST NOT be accepted for processing.
        /// </summary>
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        /// <summary>
        /// Gets the "iat" (Issued At) - The "iat" (issued at) claim identifies the time at which the JWT was issued.
        /// </summary>
        public DateTime IssuedAt => DateTime.UtcNow;
        
        /// <summary>
        /// Gets or sets the timespan the token will be valid for (default is 120 min)
        /// </summary>
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(120);

        /// <summary>
        /// Gets or sets the "nbf" (Not Before) Claim - The "nbf" (not before)
        /// </summary>
        public DateTime NotBefore { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets the "jti" (JWT ID) Claim (default Id is a GUID)
        /// </summary>
        public Func<string> JtiGenerator = () => Guid.NewGuid().ToString();
        
        /// <summary>
        /// Gets or sets the signing key to use when generating tokens
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
        /// <summary>
        /// Gets or sets the refresh token time to live (in days)
        /// </summary>
        public int RefreshTokenTtl { get; set; }
    }
}