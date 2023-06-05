
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddScoped<YellowPagesReportService.Services.IYellowPagesReportService,
        YellowPagesReportService.Services.YellowPagesReportService>();
//builder.Services.AddControllers(
//    opt => { opt.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter()); }
//);

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
//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();
