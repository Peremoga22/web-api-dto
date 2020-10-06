using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAppApi.Domain;

namespace WebAppApi.Services.Contract
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}
