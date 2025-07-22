public class TemplateService
{
    private readonly IConfiguration _configuration;

    public TemplateService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetTemplateFileContents(string templateTitle)
    {
        // Get the directory path from IConfiguration
        string directoryPath = _configuration["TemplateDirectoryPath"];
        if (string.IsNullOrEmpty(directoryPath))
        {
            throw new InvalidOperationException("Template directory path is not configured.");
        }

        // Define possible file extensions
        string[] fileExtensions = { ".txt", ".json", ".yml", ".yaml" };

        // Check if a file exists with the given templateTitle and any of the extensions
        foreach (var extension in fileExtensions)
        {
            string filePath = Path.Combine(directoryPath, templateTitle + extension);
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }

        // If no file is found, return a message
        return $"No template found for \"{templateTitle}\"";
    }
}
