using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace task_tracker.DAL.Interfaces
{
    public interface IJwtFactory
    {
        /// <summary>
        /// creates the jwt token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <param name="additionalClaims"></param>
        /// <returns></returns>
        Task<(string token, DateTime expiration)> CreateTokenAsync(string userId, string email,IEnumerable<Claim> additionalClaims = default);
    }
}