using DrakionTech.Crm.Business;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Business.Mapping;
using DrakionTech.Crm.Business.Options;
using DrakionTech.Crm.Business.Services;
using DrakionTech.Crm.Data;
using DrakionTech.Crm.Web.Components;
using DrakionTech.Crm.Data.Repositories;
using static GoogleDriveService;
using DrakionTech.Crm.Data.Repositories.Interfaces;
//using DrakionTech.Crm.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Capa de datos
builder.Services.AddCrmData(builder.Configuration);

// Capa de negocio
builder.Services.AddCrmBusiness();

// AutoMapper
builder.Services.AddAutoMapper(typeof(CrmMappingProfile));

//Whatsapp
builder.Services.Configure<WhatsAppOptions>(
    builder.Configuration.GetSection("WhatsApp"));

builder.Services.AddHttpClient<IWhatsAppNotificationService, WhatsAppNotificationService>();
//empleado
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

//azure 
builder.Services.AddScoped<AzureBlobService>();

builder.Services.AddScoped<GoogleAuthService>();
builder.Services.AddScoped<GoogleEventoReadService>();
builder.Services.AddScoped<GoogleDriveService>();

// UI / Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// Middleware de manejo de excepciones
//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Endpoints
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
