using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HemNetCore.WebAPI.Authorization
{
    /// <summary>
    /// Token身份证验证过滤器
    /// </summary>
    public class TokenAuthorizeFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizationAttribute);
            if (isAuthorized)
            {
                if (operation.Parameters == null)
                {
                    operation.Parameters = new List<OpenApiParameter>();
                }
                operation.Parameters.Add(new OpenApiParameter
                {
                    Description = "身份验证",
                    Required = false,
                    Name = "SYSTOKEN",
                    In = ParameterLocation.Header
                });
            }
        }
    }
}
