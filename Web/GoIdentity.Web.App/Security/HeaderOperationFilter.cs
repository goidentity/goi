using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace GoIdentity.Web.Security
{
    public class HeaderOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Authorization",
                In = "header",
                Type = "string",
                Required = true,
                Default = "Bearer "
            });

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "TimezoneOffset",
                In = "header",
                Type = "string",
                Required = true,
                Default = "0"
            });

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Content-Type",
                In = "header",
                Type = "string",
                Required = false,
                Default = @"application/json"
            });
        }
    }
}
