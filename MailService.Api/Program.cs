using MailService.Api;
using MailService.Api.Models;
using MailService.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MailDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("NpgMailDbConnection"));
});

builder.Services.AddSingleton(new SmtpSettings // todo: register smtp client instead (System.Net.Mail legacy)
{
    Host = builder.Configuration.GetValue<string>("Smtp:Host"),
    Port = builder.Configuration.GetValue<int>("Smtp:Port"),
    UseSsl = builder.Configuration.GetValue<bool>("Smtp:UseSsl"),
    UserName = builder.Configuration.GetValue<string>("Smtp:UserName"),
    Password = builder.Configuration.GetValue<string>("Smtp:Password"),
    FromName = builder.Configuration.GetValue<string>("Smtp:FromName"),
    FromAddress = builder.Configuration.GetValue<string>("Smtp:FromAddress")
});
// todo: builder.Configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
builder.Services.RegisterDomainLayer();

var app = builder.Build();

// DateTime to npgsql timestamp with time zone; todo: fix column type
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
