using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EDiaristas.Core.Services.Email.Smtp;

public class SmtpEmailService : IEmailService
{
    private readonly string _host;
    private readonly int _port;
    private readonly string _from;
    private readonly string _name;
    private readonly string _username;
    private readonly string _password;
    private readonly bool _enableSsl;
    private readonly IRazorViewEngine _viewEngine;
    private readonly IServiceProvider _serviceProvider;
    private readonly ITempDataProvider _tempDataProvider;

    public SmtpEmailService(
        IConfiguration configuration,
        IRazorViewEngine viewEngine,
        IServiceProvider serviceProvider,
        ITempDataProvider tempDataProvider)
    {
        _host = configuration.GetValue<string>("Smtp:Host");
        _port = configuration.GetValue<int>("Smtp:Port");
        _from = configuration.GetValue<string>("Smtp:From");
        _name = configuration.GetValue<string>("Smtp:Name");
        _username = configuration.GetValue<string>("Smtp:Username");
        _password = configuration.GetValue<string>("Smtp:Password");
        _enableSsl = configuration.GetValue<bool>("Smtp:EnableSsl");
        _viewEngine = viewEngine;
        _serviceProvider = serviceProvider;
        _tempDataProvider = tempDataProvider;
    }

    public async Task EnviarAsync(EmailParams emailParams)
    {
        using (var client = new SmtpClient(_host, _port))
        {
            client.EnableSsl = _enableSsl;
            client.Credentials = new NetworkCredential(_username, _password);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_from, _name),
                Subject = emailParams.Assunto,
                Body = await parseTemplateAsync(emailParams.Template.ToString(), emailParams.Props),
                IsBodyHtml = true
            };

            mailMessage.To.Add(emailParams.Destinatario);

            await client.SendMailAsync(mailMessage);
        }
    }

    private async Task<string> parseTemplateAsync(string template, IDictionary<string, string> props)
    {
        var httpContext = new DefaultHttpContext
        {
            RequestServices = _serviceProvider
        };
        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

        var viewEngineResult = _viewEngine.FindView(actionContext, $"Email/{template}", false);

        if (!viewEngineResult.Success)
        {
            throw new InvalidOperationException($"Não foi possível encontrar a view Email/{template}");
        }

        var view = viewEngineResult.View;

        using (var output = new StringWriter())
        {
            var viewContext = new ViewContext(
                actionContext,
                view, new ViewDataDictionary(
                    metadataProvider: new EmptyModelMetadataProvider(),
                    modelState: new ModelStateDictionary())
                {
                    Model = props
                },
                new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                output,
                new HtmlHelperOptions()
            );

            await view.RenderAsync(viewContext);

            return output.ToString();
        }
    }
}