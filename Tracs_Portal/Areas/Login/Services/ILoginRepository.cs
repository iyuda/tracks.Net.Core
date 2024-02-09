using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Models;

namespace TRACSPortal.Areas.Login.Services
{
    public interface ILoginRepository
    {
        string PasswordResetUpdate(string UserId, string Password);
        string VerifyCodeUpdate(string UserId, string Password);
        string ResendCode(string UserId);
        string ValidateEmailUpdate(string Email);
        string UserRegistrationUpdate(UserRegistrationModel model);
        dynamic ValidateLogin(LoginModel model);
        List<ReturnAddressModel> GetReturnAddresses(string UserId);
        List<CountryModel> GetCountries();
        List<FirmModel> GetFirms();
        object SubmitReturnAddress(ReturnAddressModel model);
    }
}
