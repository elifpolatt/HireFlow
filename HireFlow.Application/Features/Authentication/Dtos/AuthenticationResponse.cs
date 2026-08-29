using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Features.Authentication.Dtos
{
    public record AuthenticationResponse(string AccessToken, string RefreshToken, DateTime AccessTokenExpiresAt);
}
