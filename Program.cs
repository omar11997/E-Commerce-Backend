
using System.Text;
using Karem_Ecommerce.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Karem_Ecommerce
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<Context>(options =>
			{
				options.UseNpgsql(builder.Configuration.GetConnectionString("myconnection"));
			});
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Context>();
			/////Handle Authorize Attribute
			builder.Services.AddAuthentication(options =>
			{
				////// Make Authentication based on Token that you created 
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //// schema of Authentication 
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //// schema  indicate that if you are not regesterd to go to register page 
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; ///// another default schemas
			}).AddJwtBearer(options =>
			{
				options.SaveToken = true; //// token still in expirtaion date 
				options.RequireHttpsMetadata = false; /// indicate the protocol of request 
				options.TokenValidationParameters = new TokenValidationParameters() /// check on parameters in token to be from the same provider {NOT FAKE TOKEN}
				{
					ValidateIssuer = true,
					ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
					ValidateAudience = true,
					ValidAudience = builder.Configuration["JWT:ValidAudience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecutiryKey"])),

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
			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}