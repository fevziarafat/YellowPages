using System.ComponentModel;
using YellowPagesService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEMailInformationService, YellowPages.Services.EMailInformationService>();
builder.Services.AddScoped<IYellowPagesService, YellowPagesService.Services.YellowPagesService>();
builder.Services.AddScoped<YellowPages.Services.ILocationInformationService, YellowPages.Services.LocationInformationService>();
builder.Services.AddScoped<YellowPages.Services.IPhoneInformationService, YellowPages.Services.PhoneInformationService>();

builder.Services.AddControllers();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
