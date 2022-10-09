namespace EDiaristas.Core.Services.Email;

public class EmailParams
{
    public string Destinatario { get; set; }
    public string Assunto { get; set; }
    public TemplateOptions Template { get; set; }
    public IDictionary<string, string> Props { get; set; }

    public EmailParams(
        string destinatario,
        string assunto,
        TemplateOptions template,
        IDictionary<string, string> props)
    {
        Destinatario = destinatario;
        Assunto = assunto;
        Template = template;
        Props = props;
    }

    public enum TemplateOptions
    {
        BoasVindas,
        NovaOportunidade,
        DiaristaSelecionado,
    }
}