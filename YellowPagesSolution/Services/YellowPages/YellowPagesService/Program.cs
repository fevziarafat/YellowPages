using MassTransit;
using System.ComponentModel;
using YellowPagesService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEMailInformationService, YellowPages.Services.EMailInformationService>();
builder.Services.AddScoped<IYellowPagesService, YellowPagesService.Services.YellowPagesService>();
builder.Services.AddScoped<YellowPages.Services.ILocationInformationService, YellowPages.Services.LocationInformationService>();
builder.Services.AddScoped<YellowPages.Services.IPhoneInformationService, YellowPages.Services.PhoneInformationService>();

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