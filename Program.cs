using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using The_Book_Circle._01.Data_Access_Layer.Models;
using The_Book_Circle._02.Business_Logic_Layer.Interfaces;
using The_Book_Circle._02.Business_Logic_Layer.Services;
using The_Book_Circle._03.Presentation_Layer.Filters;
using The_Book_Circle._03.Presentation_Layer.Middlewares;
using The_Book_Circle.Context;
using The_Book_Circle.Repositories;
using The_Book_Circle.Repositories.Interfaces;
using The_Book_Circle.Services;
using The_Book_Circle.Services.Interfaces;


namespace The_Book_Circle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BooksContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Add services to the container
            builder.Services.AddControllers();

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register repositories
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericManager<>));
            builder.Services.AddScoped<IBookRepository, BookManager>();
            builder.Services.AddScoped<IAuthorRepository, AuthorManager>();
            builder.Services.AddScoped<IPublisherRepository, PublisherManager>();
            builder.Services.AddScoped<IGenreRepository, GenreManager>();

            // Register services
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IPublisherService, PublisherService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            // Register UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            // Register FluentValidation
            builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            // Register JWT settings

            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BooksContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Ensures the token’s signature is valid
                        ValidateIssuerSigningKey = true,
                        //Ensures the token was issued by a trusted issuer
                        ValidateIssuer = true,
                        //Ensures the token is intended for a specific audience
                        ValidateAudience = true,
                        //Ensures the token has not expired
                        ValidateLifetime = true,
                        //Specifies the expected issuer of the token
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        //Specifies the expected audience of the token
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        //The secret key used to sign the token
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
                        //Eliminates the default 5-minute clock skew when validating token expiration
                        ClockSkew = TimeSpan.Zero

                    };

                });


            //Register filter
            //builder.Services.AddScoped<ValidateSearchQueryFilter>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "The Book Circle API V1");
                    c.RoutePrefix = string.Empty;
                });
            }
            //app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
