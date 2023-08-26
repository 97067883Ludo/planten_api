using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using planten_api.Common;
using planten_api.Data;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{ 
    options.AddPolicy("Cors",
        policy =>
        {
            policy.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
}); 

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false, //demo
        ValidateIssuer = false, // demo 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:DOTNET_JWT_KEY").Value!))
    };
});


//var properties = new NameValueCollection();

//IScheduler scheduler = await SchedulerBuilder.Create(properties)
//    .UseDefaultThreadPool(x => x.MaxConcurrency = 5)
//    .UseXmlSchedulingConfiguration(x =>
//   {
//        x.Files = new[] { "~/quartz_jobs.xml" };
//
//        x.FailOnFileNotFound = false;
//
//        x.FailOnSchedulingError = true;
//    })
//    .BuildScheduler();

//await scheduler.Start();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SoilMoistureContext>();
builder.Services.AddDbContext<DbContext>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();