using System;
using System.Collections.Generic;
using System.Text;

namespace HireFlow.Application.Contracts.Services
{
    public interface IRefreshTokenGenerator
    {
        string Generate();
    }
}
