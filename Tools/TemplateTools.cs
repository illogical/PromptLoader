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

// TODO: Should I refer to prompt templates as "instructions"?

    [McpServerTool, Description("Gets a prompt template by its title")]
    public static string GetPromptTemplate(string templateTitle, [FromServices] TemplateService templateService)
    {
        return templateService.GetTemplateFileContents(templateTitle);
    }
    
    [McpServerTool, Description("Adds a new prompt template with the specified title and content")]
    public static void AddPromptTemplate(string templateTitle, string content, [FromServices] TemplateService templateService)
    {
        templateService.AddTemplate(templateTitle, content);
    }
}