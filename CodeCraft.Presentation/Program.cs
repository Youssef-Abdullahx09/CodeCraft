using System.Text.Json;
using System.Text.Json.Serialization;
using CodeCraft.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCodeCraftApplication(builder.Configuration);
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type?.FullName?.Replace(".", "_"));
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Configure enums to be serialized as strings
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

        // Make enum deserialization case-insensitive
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

builder.Services.AddLogging(config => config.AddConsole().AddDebug());
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync(CancellationToken.None);