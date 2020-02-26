namespace LoanApi
{
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using LoanApi.Options;
    using Boxed.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    internal static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddCustomJsonOptions(
            this IMvcBuilder builder,
            IWebHostEnvironment webHostEnvironment) =>
            builder.AddJsonOptions(
                options =>
                {
                    var jsonSerializerOptions = options.JsonSerializerOptions;
                    if (webHostEnvironment.IsDevelopment())
                    {
                        // Pretty print the JSON in development for easier debugging.
                        jsonSerializerOptions.WriteIndented = true;
                    }

                    jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    jsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

        public static IMvcBuilder AddCustomMvcOptions(this IMvcBuilder builder, IConfiguration configuration) =>
            builder.AddMvcOptions(
                options =>
                {
                    // Controls how controller actions cache content from the appsettings.json file.
                    foreach (var keyValuePair in configuration
                        .GetSection(nameof(ApplicationOptions.CacheProfiles))
                        .Get<CacheProfileOptions>())
                    {
                        options.CacheProfiles.Add(keyValuePair);
                    }

                    // Remove plain text (text/plain) output formatter.
                    options.OutputFormatters.RemoveType<StringOutputFormatter>();

                    var jsonInputFormatterMediaTypes = options
                        .InputFormatters
                        .OfType<SystemTextJsonInputFormatter>()
                        .First()
                        .SupportedMediaTypes;
                    var jsonOutputFormatterMediaTypes = options
                        .OutputFormatters
                        .OfType<SystemTextJsonOutputFormatter>()
                        .First()
                        .SupportedMediaTypes;

                    // Remove JSON text (text/json) media type from the JSON input and output formatters.
                    jsonInputFormatterMediaTypes.Remove("text/json");
                    jsonOutputFormatterMediaTypes.Remove("text/json");

                    // Add ProblemDetails media type (application/problem+json) to the output formatters.
                    // See https://tools.ietf.org/html/rfc7807
                    jsonOutputFormatterMediaTypes.Insert(0, ContentType.ProblemJson);

                    // Add RESTful JSON media type (application/vnd.restful+json) to the JSON input and output formatters.
                    // See http://restfuljson.org/
                    jsonInputFormatterMediaTypes.Insert(0, ContentType.RestfulJson);
                    jsonOutputFormatterMediaTypes.Insert(0, ContentType.RestfulJson);

                    // Returns a 406 Not Acceptable if the MIME type in the Accept HTTP header is not valid.
                    options.ReturnHttpNotAcceptable = true;
                });
    }
}
