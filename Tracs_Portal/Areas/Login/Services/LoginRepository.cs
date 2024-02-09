using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TracsBusinessLogic;
using Tracs.Common.Enumeration;
using Tracs.Common.Models;
using StaticHttpContextAccessor.Helpers;

namespace TRACSPortal.Areas.Login.Services
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ILogger<ILoginRepository> _logger;
        private IHostingEnvironment _evn;
        public LoginRepository(IHostingEnvironment evn, ILogger<LoginRepository> logger)
        {
            _logger = logger;
            _evn = evn;

        }
        public string PasswordResetUpdate(string UserId, string Password)
        {
            return TracsBusinessLogic.Login.PasswordResetUpdate(UserId, Password);
        }
        public string VerifyCodeUpdate(string UserId, string VerificationCode)
        {
            return TracsBusinessLogic.Login.VerifyCodeUpdate(UserId, VerificationCode);
        }
        public string ResendCode(string UserId)
        {
            return TracsBusinessLogic.Login.ResendCode(UserId);
        }

        public string ValidateEmailUpdate(string Email)
        {
            return TracsBusinessLogic.Login.ValidateEmailUpdate(Email);
        }
        public string UserRegistrationUpdate(UserRegistrationModel model)
        {
            return TracsBusinessLogic.Login.UserRegistrationUpdate(model);
        }
        public dynamic ValidateLogin(LoginModel model)
        {
            return TracsBusinessLogic.Login.ValidateLogin(model);
        }
        public  List<ReturnAddressModel> GetReturnAddresses(string UserId)
        {
            return TracsBusinessLogic.CommonFunctions.GetReturnAddresses(UserId);
        }
        public List<CountryModel> GetCountries()
        {
            return CommonFunctions.GetCountries();
        }
        public List<FirmModel> GetFirms()
        {
            return CommonFunctions.GetFirms();
        }
        public object SubmitReturnAddress(ReturnAddressModel model)
        {
            object returnValue = TracsBusinessLogic.Login.SubmitReturnAddress(model);
            return returnValue;
        }
        #region Private Functions



        #endregion
    }

}
