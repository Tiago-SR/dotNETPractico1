using DAL;
using DAL.DALs;
using DAL.IDALs;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    #region Inyeccion de dependencias.
    // DALs
    builder.Services.AddTransient<IDAL_Personas, DAL_Personas_EF>();
    builder.Services.AddTransient<IDAL_Vehiculos, DAL_Vehiculos_EF>();

    // BLs
    // builder.Services.AddSingleton<>();

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

    DBContext.UpdateDatabase();

    app.Run();

}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}
