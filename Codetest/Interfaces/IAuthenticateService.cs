using Codetest.Models.Requests;
using Codetest.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Codetest.Interfaces;

public interface IAuthenticateService
{
    Task<LoginResponse> Login(LoginModel model);
    Task Register(RegisterModel model);
}

