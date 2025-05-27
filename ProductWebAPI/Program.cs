
using Microsoft.AspNetCore.Http.Metadata;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;
using System.Text.Json.Serialization;

namespace ProductWebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
				options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
			});
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSingleton<IProductRepository, ProductRepository>();
			builder.Services.AddSingleton<IProductService, ProductService>();
			builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
			builder.Services.AddSingleton<IAccountService, AccountService>();
			builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
			builder.Services.AddSingleton<ICategoryService, CategoryService>();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
