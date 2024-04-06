using ApiMonitoring.Application.DTOs.UserDtos;
using ApiMonitoring.Application.Services.UserServices;
using Microsoft.AspNetCore.Identity;

namespace ApiMonitoring.Application.Services.UserService
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserServices(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResult> RegisterUserAsync(RegisterUserDTO userDTO)
        {
            var validationErrors = ValidateUser(userDTO);
            if (validationErrors.Any())
            {
                return new RegisterResult
                {
                    Succeeded = false,
                    Errors = validationErrors
                };
            }

            var user = new IdentityUser
            {
                UserName = userDTO.Username,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber
            };
            

            var identityResult =await _userManager.CreateAsync(user, userDTO.Password);
           
            if (identityResult != null)
            {
                return new RegisterResult
                {
                    Succeeded = false,
                    //Errors = MapIdentityErrors(identityResult.Errors)
                };
            }

            // ... پیاده سازی عملیات مربوط به ثبت نام موفق (مانند ارسال ایمیل تأیید)

            return new RegisterResult
            {
                Succeeded = true
            };
        }

        private Dictionary<string, string> ValidateUser(RegisterUserDTO userDTO)
        {
            var errors = new Dictionary<string, string>();

            // ... پیاده سازی قوانین اعتبارسنجی

            return errors;
        }

        private Dictionary<string, string> MapIdentityErrors(IEnumerable<IdentityError> errors)
        {
            var mappedErrors = new Dictionary<string, string>();

            foreach (var error in errors)
            {
                mappedErrors.Add(error.Code, error.Description);
            }

            return mappedErrors;
        }
    }
}
