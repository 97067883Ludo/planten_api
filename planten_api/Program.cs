
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;
using planten_api.Data;
using Quartz;

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