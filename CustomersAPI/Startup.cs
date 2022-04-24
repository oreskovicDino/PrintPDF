namespace CustomersAPI
{
    using Customers.DAL.DataAccess;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup ( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices ( IServiceCollection services )
        {
            services.AddDbContext<CustomerDataContext> ( options =>
              options.UseSqlServer ( Configuration.GetConnectionString ( "Connection" ) )
              );

            #region AutoMapper Init
            var configMapper = new AutoMapper.MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfiles()); });
            var mapper = configMapper.CreateMapper();
            #endregion

            #region DI
            services.AddScoped<ICustomerRepository, CustomerRepository> ( );
            services.AddSingleton ( mapper );
            #endregion

            services.AddCors ( options =>
            {
                options.AddPolicy (
                    name: "AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin ( )
                        .AllowAnyMethod ( )
                        .AllowAnyHeader ( );
                    }
                    );
            } );


            services.AddControllers ( );
            services.AddSwaggerGen ( c =>
              {
                  c.SwaggerDoc ( "v1", new OpenApiInfo { Title = "CustomersAPI", Version = "v1" } );
              } );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure ( IApplicationBuilder app, IWebHostEnvironment env )
        {
            app.UseCors ( "AllowOrigin" );

            if ( env.IsDevelopment ( ) )
            {
                app.UseDeveloperExceptionPage ( );
                app.UseSwagger ( );
                app.UseSwaggerUI ( c => c.SwaggerEndpoint ( "/swagger/v1/swagger.json", "CustomersAPI v1" ) );
            }

            app.UseHttpsRedirection ( );

            app.UseRouting ( );

            app.UseAuthorization ( );

            app.UseEndpoints ( endpoints =>
              {
                  endpoints.MapControllers ( );
              } );
        }
    }
}
