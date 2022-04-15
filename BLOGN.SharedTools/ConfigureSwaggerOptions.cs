using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BLOGN.SharedTools
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition(
                "Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Kimlik Doğrulama için bu alanı kullanın. Bearer Ön ekini girdikten sonra bir boşluk bırakarak" +
                    "token girişi yapabilirsiniz. Örneğin-'Bearer mytoken'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {   {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type= ReferenceType.SecurityScheme,
                            Id="Bearer"
                        },
                        Scheme ="oauth2",
                        Name="Bearer",
                        In= ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
            var xmlFileComment = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; //xml yolunu yazdık
            var xmlFullPath = Path.Combine(AppContext.BaseDirectory, xmlFileComment);
            options.IncludeXmlComments(xmlFullPath);
            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            //options.IncludeXmlComments(xmlPath);
        }
    }
}

