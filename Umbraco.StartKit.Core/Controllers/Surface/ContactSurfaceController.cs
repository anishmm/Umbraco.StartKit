using J2N.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Mail;
using Umbraco.Cms.Core.Models.Email;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.StartKit.Core.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Umbraco.StartKit.Core.Controllers.Surface
{
    public class ContactSurfaceController : SurfaceController
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ContactSurfaceController> _logger;
        private readonly GlobalSettings _globalSettings;

        public ContactSurfaceController(
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            IEmailSender emailSender,
            ILogger<ContactSurfaceController> logger,
            IOptions<GlobalSettings> globalSettings)
            : base(umbracoContextAccessor, databaseFactory,
                  services, appCaches, profilingLogger,
                  publishedUrlProvider)
        {
            _emailSender = emailSender;
            _logger = logger;
            _globalSettings = globalSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(ContactViewModel model)
        {
            if (!ModelState.IsValid) return CurrentUmbracoPage();



            TempData["Success"] = await SendEmail(model, Request.Form);

            return RedirectToCurrentUmbracoPage();
        }

        public async Task<bool> SendEmail(ContactViewModel model, IFormCollection formData)
        {
            try
            {
                if (_globalSettings.Smtp != null)
                {

                    var toEmail = formData["toemail"];
                    if(string.IsNullOrWhiteSpace(toEmail))
                    {
                        _logger.LogError("Invalid to email address");
                        return false;
                    }


                    var fromAddress = _globalSettings.Smtp.From;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    var formMessage = "";

                    if (formData.Keys.Count > 0)
                    {
                        foreach (string description in formData.Keys)
                        {
                            if (!description.Equals("__RequestVerificationToken") && !description.Equals("ufprt")
                                && !description.ToLower().Equals("toemail")
                                && !description.ToLower().Equals("ccemail") && !description.ToLower().Equals("bccemail"))
                            {
                                sb.AppendLine(string.Format("{0}   : {1}", description, formData[description]));
                            }
                        }
                        formMessage = sb.ToString();
                    }
                    else
                    {
                        formMessage = model.Message;
                    }
                    //


                    var ccEmailAddress = formData["ccemail"];

                    List<string> ccEmail = null;
                    if (!string.IsNullOrWhiteSpace(ccEmailAddress))
                    {
                        ccEmail = new List<string>();
                        foreach (var c in ccEmailAddress.ToString().Split(','))
                        {
                            ccEmail.Add(c);
                        }
                    }

                    var tobccAddress = formData["bccemail"];
                    List<string> bccEmail = null;
                    if (!string.IsNullOrWhiteSpace(tobccAddress))
                    {
                        bccEmail = new List<string>();
                        foreach (var c in tobccAddress.ToString().Split(','))
                        {
                            bccEmail.Add(c);
                        }
                    }
                    string[] toEmails = { toEmail.ToString() };


                    var subject = string.Format("Enquiry from: {0} - {1}", model.Name, model.Email);
                    // EmailMessage message = new EmailMessage(fromAddress, model.toEmail, subject, formMessage, false);

                    EmailMessage message = new EmailMessage(fromAddress, toEmails, (ccEmail != null ? ccEmail.ToArray() : null),
                        (bccEmail != null ? bccEmail.ToArray() : null), null, subject, formMessage, false, null);


                    await _emailSender.SendAsync(message, emailType: "Contact");

                    _logger.LogInformation("Contact Form Submitted Successfully");
                    return true;
                }
                else
                {
                    _logger.LogError("Invalid SMTP details");
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error When Submitting Contact Form");
                return false;
            }
        }
    }
}