using Microsoft.EntityFrameworkCore;
using PIMAPI.Application.Infra.Data.DBContext;
using PIMAPI.Application.Infra.Data.Repository;
using PIMAPI.Extension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddRepository();
builder.Services.AddControllers(
options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddControllers(x => x.AllowEmptyInputInBodyModelBinding = true);


builder.Services.AddDbContext<PIMAPIdb>(options =>
{
    var cnn = builder.Configuration.GetConnectionString("PIMAPIdb");
    options.UseSqlServer(cnn);
});


var app = builder.Build();

app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
