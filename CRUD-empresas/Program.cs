using CRUD_empresas.Database;
using CRUD_empresas.Interfaces;
using CRUD_empresas.Repositorys;
using CRUD_empresas.Repositorys.Interfaces;
using CRUD_empresas.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ContextDB>(options =>
    {
        options.UseNpgsql("Default",
            assembly => assembly.MigrationsAssembly(typeof(ContextDB).Assembly.FullName));
        
    });

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IFuncionarioService,  FuncionarioService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();



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
