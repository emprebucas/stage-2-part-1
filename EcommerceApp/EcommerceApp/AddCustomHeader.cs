using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EcommerceApp
{
    /// <summary>
    /// AddCustomHeaderParameter add a custom header parameter to the Swagger documentation for API operations.
    /// </summary>
    public class AddCustomHeaderParameter : IOperationFilter
    {
        /// <summary>
        /// The `Apply` method is the implementation of the interface method and is 
        /// called by Swagger during the generation of the API documentation.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            // adds a header parameter with the name "x-user-Id"
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-user-Id",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "uuid"
                }
            });
        }
    }
}