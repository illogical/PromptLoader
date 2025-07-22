using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.Server;
using System.ComponentModel;

[McpServerToolType]
public class TemplateTools
{
    public TemplateTools()
    {
        
    }

    [McpServerTool, Description("Gets a prompt template by its title")]
    public static string GetPromptTemplate(string templateTitle, [FromServices] TemplateService templateService)
    {
        return templateService.GetTemplateFileContents(templateTitle);
    }
}