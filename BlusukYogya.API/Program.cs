using BlusukYogya.BLL;
using BlusukYogya.BLL.Interface;
using BlusukYogya.BLL.DTO;
using BlusukYogya.Data;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using BlusukYogya.BLL.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<YogyaBlusukContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString"));
});
//DI
builder.Services.AddScoped<IImageData, ImageData>();
builder.Services.AddScoped<IImageBLL, ImageBLL>();
builder.Services.AddScoped<IPlaceData, PlaceData>();
builder.Services.AddScoped<IPlaceBLL, PlaceBLL>();
builder.Services.AddScoped<ITagData, TagData>();
builder.Services.AddScoped<ITagBLL, TagBLL>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IRoleData, RoleData>();
builder.Services.AddScoped<IRoleBLL, RoleBLL>();
builder.Services.AddScoped<IVacationPlanData, VacationPlanData>();
builder.Services.AddScoped<IVacationPlanBLL, VacationPlanBLL>();
builder.Services.AddScoped<IPlaceReviewData, PlaceReviewData>();
builder.Services.AddScoped<IPlaceReviewBLL, PlaceReviewBLL>();



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});

var app = builder.Build();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
});

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
