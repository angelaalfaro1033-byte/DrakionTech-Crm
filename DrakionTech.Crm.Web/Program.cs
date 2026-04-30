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
using DrakionTech.Crm.Business.Services.Email;
using DrakionTech.Crm.Business.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using DrakionTech.Crm.Data.Entities;
//using DrakionTech.Crm.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Capa de datos
builder.Services.AddCrmData(builder.Configuration);

// Capa de negocio
builder.Services.AddCrmBusiness();

// AutoMapper
builder.Services.AddAutoMapper(typeof(CrmMappingProfile));
builder.Services.AddScoped<IAuthService, AuthService>();
//Whatsapp
builder.Services.Configure<WhatsAppOptions>(
    builder.Configuration.GetSection("WhatsApp"));
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("Email"));
builder.Services.AddHttpClient<IWhatsAppNotificationService, WhatsAppNotificationService>();
builder.Services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
builder.Services.AddScoped<IEmailTemplateRenderer, EmailTemplateRenderer>();
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/login";
    });

builder.Services.AddAuthorization();
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
app.UseAuthentication();
app.UseAuthorization();

// Endpoints
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapPost("/account/login", async (HttpContext ctx, IEmpleadoRepository repo) =>
{
    var form = await ctx.Request.ReadFormAsync();
    var email = form["email"].ToString();
    var password = form["password"].ToString();

    var user = (await repo.GetAllAsync())
        .FirstOrDefault(x => x.Email == email);

    if (user == null || string.IsNullOrEmpty(user.PasswordHash))
        return Results.Redirect("/login?error=credenciales");

    if (!user.IsActive)
        return Results.Redirect("/login?error=inactivo");

    if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        return Results.Redirect("/login?error=credenciales");

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Email),
        new Claim("UserId", user.Id.ToString())
    };
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new ClaimsPrincipal(identity);

    await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    return Results.Redirect("/");
}).DisableAntiforgery();

app.MapPost("/account/logout", async (HttpContext ctx) =>
{
    await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/login");
}).DisableAntiforgery();

app.MapPost("/account/registro-inicial", async (HttpContext ctx, IEmpleadoRepository repo) =>
{
    var usuarios = await repo.GetAllAsync();
    if (usuarios.Any())
        return Results.Redirect("/login");

    var form = await ctx.Request.ReadFormAsync();
    var nombre = form["nombre"].ToString().Trim();
    var apellido = form["apellido"].ToString().Trim();
    var email = form["email"].ToString().Trim();
    var password = form["password"].ToString();
    var confirmar = form["confirmar"].ToString();

    if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
        string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        return Results.Redirect("/registro-inicial?error=campos");

    if (password != confirmar)
        return Results.Redirect("/registro-inicial?error=passwords");

    if (password.Length < 8)
        return Results.Redirect("/registro-inicial?error=longitud");

    var admin = new Empleado
    {
        Nombre = nombre,
        Apellido = apellido,
        Email = email,
        Cargo = "Administrador",
        Rol = "Administrador",
        Activo = true,
        FechaCreacion = DateTime.UtcNow,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
        IsActive = true,
        ActivationToken = null,
        ActivationTokenExpiration = null
    };

    await repo.AddAsync(admin);

    return Results.Redirect("/login?mensaje=cuenta-creada");
}).DisableAntiforgery();
app.Run();
app.Run();
