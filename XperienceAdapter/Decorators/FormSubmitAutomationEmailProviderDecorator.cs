using CMS;
using CMS.Automation;
using CMS.ContactManagement;
using CMS.Core;
using CMS.EmailEngine;
using CMS.OnlineForms;
using Microsoft.Extensions.Options;
using XperienceAdapter.Decorators;

[assembly: RegisterImplementation(typeof(IFormSubmitAutomationEmailProvider), typeof(FormSubmitAutomationEmailProviderDecorator))]

namespace XperienceAdapter.Decorators;

public class FormSubmitAutomationEmailProviderDecorator(
    IFormSubmitAutomationEmailProvider defaultAutomationEmailProvider,
    ILocalizationService localizationService,
    IOptionsMonitor<SystemEmailOptions> systemEmailOptions) : IFormSubmitAutomationEmailProvider
{
    public Task<AutomationEmail> GetEmail(BizFormInfo form, BizFormItem formData, ContactInfo contact)
    {
        string contactEmail = contact.ContactEmail;

        if (string.IsNullOrEmpty(contactEmail))
            return Task.FromResult<AutomationEmail>((AutomationEmail)null);

        return Task.FromResult<AutomationEmail>(new AutomationEmail()
        {
            Subject = localizationService.GetString("autoresponderemail.default.subject"),
            Body = localizationService.GetString("autoresponderemail.default.body"),
            Sender = "no-reply@" + "trial-v69oxl505pdg785k.mlsender.net",
            Recipients = new List<string>() { contactEmail }
        });

        return defaultAutomationEmailProvider.GetEmail(form, formData, contact);
        // Gets the email address from the contact's Email attribute
        string recipient = contact.ContactEmail;

        if (string.IsNullOrEmpty(recipient))
        {
            // The user hasn't provided an email address, so no autoresponder email is sent
            return null;
        }

        // Prepares a custom autoresponder email for a form with the 'ContactUs' code name
        if (form.FormName.Equals("ContactUs", StringComparison.InvariantCultureIgnoreCase))
        {
            return Task.FromResult(new AutomationEmail
            {
                Subject = "Thanks for contacting us",
                // Builds the email body, including the name of the contact who submitted the form,
                // and the value of the 'UserMessage' form field
                Body = $"Hello {contact.ContactFirstName}, <br />" +
                       "thank you for contacting us. You sent us the following message:<br />" +
                       formData.GetStringValue("UserMessage", ""),
                Sender = "no-reply@company.com",
                Recipients = new List<string> { recipient }
            });
        }

        // Returns the default form autoresponder email as a fallback
        return defaultAutomationEmailProvider.GetEmail(form, formData, contact);
    }
}