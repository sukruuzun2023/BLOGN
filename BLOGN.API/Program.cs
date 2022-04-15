using System.Text;
using BLOGN.API;
using BLOGN.Data;
using BLOGN.Data.Repositories.IRepository;
using BLOGN.Data.Repositories.Repository;
using BLOGN.Data.Services;
using BLOGN.Data.Services.IService;
using BLOGN.SharedTools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(); // user controller
builder.Services.AddAutoMapper(typeof(Program));  // program.cs i�ersindek, Scoped kodlar�m�z
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Services<>));

//builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IArticleService, ArticleService>(); // article tan�ml�yoruz
builder.Services.AddScoped<IUserService, UserService>(); // User Tan�mlad�k
builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();// Swagger �ifre ile ula�mak i�in
builder.Services.AddSwaggerGen();

// AppSettings Secret Olu�turma
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettings);

//JWT ��in Json Token -- app.UseAuthorization(); bak 
var appSettingsB = appSettings.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettingsB.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata=false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); // JWT ��in
app.UseAuthentication(); // JWT ��in
app.UseAuthorization();

app.MapControllers();

app.Run();
