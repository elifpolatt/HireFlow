using HireFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Contracts.Services
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user);

        DateTime GetAccessTokenExpiration();
    }
}
