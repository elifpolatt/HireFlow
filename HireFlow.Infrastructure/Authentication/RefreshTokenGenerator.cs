using HireFlow.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HireFlow.Infrastructure.Authentication
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        public string Generate()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);

            return Convert.ToBase64String(bytes);
        }
    }
}
