public class TemplateService
{
    private readonly IConfiguration _configuration;
    private string _templateDirectory = string.Empty;

    public TemplateService(IConfiguration configuration)
    {
        _configuration = configuration;
        _templateDirectory = _configuration["TemplateDirectoryPath"];
    }

    public string GetTemplateFileContents(string templateTitle)
    {
        if (string.IsNullOrEmpty(_templateDirectory))
        {
            throw new InvalidOperationException("Template directory path is not configured.");
        }

        // Define possible file extensions
        string[] fileExtensions = { ".txt", ".json", ".yml", ".yaml" };

        // Check if a file exists with the given templateTitle and any of the extensions
        foreach (var extension in fileExtensions)
        {
            string filePath = Path.Combine(_templateDirectory, templateTitle + extension);
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }

        // If no file is found, return a message
        return $"No template found for \"{templateTitle}\"";
    }

    public void AddTemplate(string templateTitle, string content)
    {
        if (string.IsNullOrEmpty(_templateDirectory))
        {
            throw new InvalidOperationException("Template directory path is not configured.");
        }

        // Define the file path
        string filePath = Path.Combine(_templateDirectory, templateTitle + ".txt");

        // Write the content to the file
        File.WriteAllText(filePath, content);
    }
}
