using System.Net;
using System.Text;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Implementation;
using Services.Interfaces;
using Services.Settings;

var builder = WebApplication.CreateBuilder(args);

const string dbConnectionString = "DefaultConnection";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseNpgsql(
		builder.Configuration.GetConnectionString(dbConnectionString),
		b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
	));
builder.Services.AddDbContext<IdentityContext>(options =>
	options.UseNpgsql(
		builder.Configuration.GetConnectionString(dbConnectionString),
		b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)
	));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<IdentityContext>()
	.AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
	.AddApiAuthorization<ApplicationUser, IdentityContext>();

builder.Services.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddIdentityServerJwt()
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value ??
			              throw new Exception("No jwt issuer is configured in the 'Jwt:Issuer' configuration section"),
			ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value ??
			                throw new Exception(
				                "No jwt audience is configured in the 'Jwt:Audience' configuration section"),
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				builder.Configuration.GetSection("Jwt:Key").Value ??
				throw new Exception("No jwt key is configured in the 'Jwt:Key' configuration section")))
		};

		options.Events = new JwtBearerEvents
		{
			OnChallenge = context =>
			{
				context.HandleResponse();
				context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
				context.Response.ContentType = "text/plain";
				return context.Response.WriteAsync("You are not authorized");
			},
			OnForbidden = context =>
			{
				context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
				context.Response.ContentType = "text/plain";
				return context.Response.WriteAsync("You are not allowed to access this resource");
			}
		};
	}).AddGoogle(googleOptions =>
	{
		var clientId = builder.Configuration["Authentication:Google:ClientId"];
		var clientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
		if (clientId == null || clientSecret == null)
		{
			throw new Exception("No client_id and client_secret configured for google authorization");
		}

		googleOptions.ClientId = clientId;
		googleOptions.ClientSecret = clientSecret;
		googleOptions.SignInScheme = IdentityConstants.ExternalScheme;
	});

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(options =>
	options.AddPolicy(
		"AllowAll",
		policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
	)
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1",
		new OpenApiInfo { Version = "v1", Title = "Video blog API", Description = "Video blog API documentation" });

	options.AddSecurityDefinition("Bearer",
		new OpenApiSecurityScheme
		{
			Name = "Authorization",
			In = ParameterLocation.Header,
			Type = SecuritySchemeType.Http,
			Scheme = "bearer",
			BearerFormat = "JWT",
			Description = "Standard Authorization header using th Bearer scheme: 'Bearer {token}'"
		});

	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
			},
			new List<string>()
		}
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
	Console.WriteLine("Applying migrations");
	var services = scope.ServiceProvider;
	var identityContext = services.GetRequiredService<IdentityContext>();
	if (identityContext.Database.GetPendingMigrations().Any())
	{
		identityContext.Database.Migrate();
	}

	var applicationContext = services.GetRequiredService<ApplicationDbContext>();
	if (applicationContext.Database.GetPendingMigrations().Any())
	{
		applicationContext.Database.Migrate();
	}

	Console.WriteLine("Migrations completed successfully");
}

app.UseCors("AllowAll");

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
