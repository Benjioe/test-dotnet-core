using Microsoft.AspNetCore.Razor.TagHelpers;

//Correspond a la balise <email />
public class EmailTagHelper : TagHelper
{
    private const string EmailDomain = "contoso.com";

    //Correspond à la propriété mail-to
    public string MailTo { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";    // Replaces <email> with <a> tag

        var address = MailTo + "@" + EmailDomain;
        output.Attributes.SetAttribute("href", "mailto:" + address);
        output.Content.SetContent(address);
    }
}