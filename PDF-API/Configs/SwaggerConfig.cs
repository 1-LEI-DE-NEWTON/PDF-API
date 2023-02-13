using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PDF_API.Configs
{
    public class FormFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.RequestBody == null)
            {
                return;
            }

            var fileParameters = context.ApiDescription
                .ActionDescriptor
                .Parameters
                .Where(p => p.ParameterType == typeof(IFormFile))
                .ToList();

            if (fileParameters.Count < 1)
            {
                return;
            }

            operation.RequestBody.Content.Add(
                "multipart/form-data",
                new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "object",
                        Properties = new Dictionary<string, OpenApiSchema>
                        {
                        {
                            "file",
                            new OpenApiSchema
                            {
                                Type = "string",
                                Format = "binary"
                            }
                        }
                        }
                    }
                });
        }
    }   
}
