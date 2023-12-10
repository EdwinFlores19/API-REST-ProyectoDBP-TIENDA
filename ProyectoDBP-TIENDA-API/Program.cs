using ProyectoDBP_TIENDA_API.Services.Interface;
using ProyectoDBP_TIENDA_API.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Add(new ServiceDescriptor(typeof(IAdmin), new AdminRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IUsuario), new UsuarioRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IProducto), new ProductoRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IProveedor), new ProveedorRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IFactura), new FacturaRepository()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
