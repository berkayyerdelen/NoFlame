using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Infrastructure.Repository.Authentication
{
    public interface IJwtAuthManager
    {
        IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }
        Task<JwtAuthResult> GenerateTokens(string username, List<Claim> claims, DateTime now);
        Task<JwtAuthResult> Refresh(string refreshToken, string accessToken, DateTime now);
        Task RemoveExpiredRefreshTokens(DateTime now);
        Task RemoveRefreshTokenByUserName(string userName);
        Task<(ClaimsPrincipal, JwtSecurityToken)> DecodeJwtToken(string token);
    }
}
