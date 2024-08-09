using LIB_C_BASE;
using WEB_API_V2.MAPPING;

#nullable disable

namespace WEB_API_V2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.
            builder.Services.AddAuthorization();

            //builder.Services.AddSingleton<C_BASE>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Creation_Mapping_GET_DATE();
            app.Creation_Mapping_Get_Ip();
            app.Creation_Mapping_Get_Info_OS();
            app.Creation_Mapping_Get_Info_CPU();

            app.Creation_Mapping_Get_Driver();
            app.Creation_Mapping_Get_Constructeur();

            app.Creation_Mapping_Add_Driver();
            app.Creation_Mapping_Add_Constructeur();

            app.Creation_Mapping_Delete_Driver();
            app.Creation_Mapping_Delete_Constructeur();

            app.Creation_Mapping_Update_Driver();
            app.Creation_Mapping_Update_Constructeur();

            app.Run();
        }
    }
}
