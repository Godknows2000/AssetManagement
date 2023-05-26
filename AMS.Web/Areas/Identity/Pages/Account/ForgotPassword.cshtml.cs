using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AMS.Data;
using Microsoft.EntityFrameworkCore;
using AMS.Web.Pages;
using wCyber.Helpers.Identity;
using AMS.Lib;

namespace AMS.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : SysPageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        public ForgotPasswordModel(UserManager<User> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = null!;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                //if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                if (user == null)
                {
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { code },
                    protocol: Request.Scheme);

                //var emailConfig = await Db.EmailConfigs.FirstAsync(c => c.IsActive && (c.TargetId & (int)EmailConfigTarget.LOGIN_ACCOUNT_MANAGEMENT) == (int)EmailConfigTarget.LOGIN_ACCOUNT_MANAGEMENT);
                //if (emailConfig != null)
                //{
                //    var sender = new EmailSender(emailConfig.GetOptions());
                //    await sender.SendEmailAsync(
                //         Input.Email,
                //         "Reset Password",
                //         $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl!)}'>clicking here</a>.");
                //}
                //else
                //{
                //    await _emailSender.SendEmailAsync(
                //        Input.Email,
                //        "Reset Password",
                //        $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl!)}'>clicking here</a>.");
                //}
                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
