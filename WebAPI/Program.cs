using BL.BLs;
using BL.IBLs;
using DAL.DALs;
using DAL.IDALs;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    builder.Services.AddDbContext<DAL.DBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    #region Inyeccion de dependencias.
    // DALs
    builder.Services.AddTransient<IDAL_Personas, DAL_Personas_EF>();
    builder.Services.AddTransient<IDAL_Vehiculos, DAL_Vehiculos_EF>();

    // BLs
    builder.Services.AddSingleton<IBL_Personas, BL_Personas>();
    builder.Services.AddSingleton<IBL_Vehiculo, BL_Vehiculo>();

    #endregion

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

    UpdateDatabase();

    app.Run();

}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}

static void UpdateDatabase() {
    using var context = new DAL.DBContext();
    //context?.Database.Migrate();
    context.Database.Migrate();
}