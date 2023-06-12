using MassTransit;
using System.ComponentModel;
using YellowPages.Data.Abstract;
using YellowPages.Data.Concrete;

using YellowPagesService.Business.Abstract;
using YellowPagesService.Business.Concrete;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IYellowPagesReportDal, YellowPagesReportDal>();
builder.Services.AddSingleton<IYellowPagesDal, YellowPagesDal>();
builder.Services.AddSingleton<IEMailInformationDal, EMailInformationDal>();
builder.Services.AddSingleton<IPhoneInformationDal, PhoneInformationDal>();
builder.Services.AddSingleton<ILocationInformationDal, LocationInformationDal>();
builder.Services.AddScoped<IEMailInformationService, EMailInformationService>();
builder.Services.AddScoped<IYellowPagesService, YellowPagesService.Business.Concrete.YellowPagesService>();
builder.Services.AddScoped<ILocationInformationService, LocationInformationService>();
builder.Services.AddScoped<IPhoneInformationService, PhoneInformationService>();

builder.Services.AddControllers(opt => { opt.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter()); }
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<YellowPages.Shared.Settings.DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<YellowPages.Shared.Settings.IDatabaseSettings>(sp =>
{
    return sp
        .GetRequiredService<Microsoft.Extensions.Options.IOptions<YellowPages.Shared.Settings.DatabaseSettings>>()
        .Value;
});

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });
    });
});


builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = "resource_yellowpages";
    options.RequireHttpsMetadata = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();