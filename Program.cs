var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()     // Enables MCP (function calling) access
    .WithToolsFromAssembly();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<TemplateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
