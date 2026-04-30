using DrakionTech.Crm.Data.Entities;
using DrakionTech.Crm.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DrakionTech.Crm.Data.Seed
{
    public static class InitialSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedPaises(modelBuilder);
            SeedCiudades(modelBuilder);
            SeedEstados(modelBuilder);
            SeedSectores(modelBuilder);
            SeedPrefijosTelefonicos(modelBuilder);
            SeedTiposActividad(modelBuilder);
            SeedEstadosActividad(modelBuilder);
            SeedEmailTemplates(modelBuilder);
        }

        private static void SeedPaises(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().HasData(
                new Pais { Id = SeedIds.Colombia, Nombre = "Colombia", CodigoIso = "CO" },
                new Pais { Id = SeedIds.Argentina, Nombre = "Argentina", CodigoIso = "AR" },
                new Pais { Id = SeedIds.Bolivia, Nombre = "Bolivia", CodigoIso = "BO" },
                new Pais { Id = SeedIds.Brasil, Nombre = "Brasil", CodigoIso = "BR" },
                new Pais { Id = SeedIds.Chile, Nombre = "Chile", CodigoIso = "CL" },
                new Pais { Id = SeedIds.Ecuador, Nombre = "Ecuador", CodigoIso = "EC" },
                new Pais { Id = SeedIds.Guyana, Nombre = "Guyana", CodigoIso = "GY" },
                new Pais { Id = SeedIds.Paraguay, Nombre = "Paraguay", CodigoIso = "PY" },
                new Pais { Id = SeedIds.Peru, Nombre = "Perú", CodigoIso = "PE" },
                new Pais { Id = SeedIds.Surinam, Nombre = "Surinam", CodigoIso = "SR" },
                new Pais { Id = SeedIds.Uruguay, Nombre = "Uruguay", CodigoIso = "UY" },
                new Pais { Id = SeedIds.Venezuela, Nombre = "Venezuela", CodigoIso = "VE" },

                new Pais { Id = SeedIds.Mexico, Nombre = "México", CodigoIso = "MX" },
                new Pais { Id = SeedIds.USA, Nombre = "Estados Unidos", CodigoIso = "US" },
                new Pais { Id = SeedIds.Canada, Nombre = "Canadá", CodigoIso = "CA" }
               );
        }

        private static void SeedCiudades(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>().HasData(
        // colombia
        new Ciudad { Id = SeedIds.Bogota, Nombre = "Bogotá", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Medellin, Nombre = "Medellín", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Cali, Nombre = "Cali", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Barranquilla, Nombre = "Barranquilla", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Cartagena, Nombre = "Cartagena", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Bucaramanga, Nombre = "Bucaramanga", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Cúcuta, Nombre = "Cúcuta", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Pereira, Nombre = "Pereira", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Manizales, Nombre = "Manizales", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Armenia, Nombre = "Armenia", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Ibagué, Nombre = "Ibagué", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Neiva, Nombre = "Neiva", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Villavicencio, Nombre = "Villavicencio", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Pasto, Nombre = "Pasto", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Popayan, Nombre = "Popayán", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.SantaMarta, Nombre = "Santa Marta", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Valledupar, Nombre = "Valledupar", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Monteria, Nombre = "Montería", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Sincelejo, Nombre = "Sincelejo", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Riohacha, Nombre = "Riohacha", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Yopal, Nombre = "Yopal", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Tunja, Nombre = "Tunja", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Florencia, Nombre = "Florencia", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Mocoa, Nombre = "Mocoa", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.SanJoseDelGuaviare, Nombre = "San José del Guaviare", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Leticia, Nombre = "Leticia", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Mitú, Nombre = "Mitú", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.PuertoCarreño, Nombre = "Puerto Carreño", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Quibdó, Nombre = "Quibdó", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Arauca, Nombre = "Arauca", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.SanAndres, Nombre = "San Andrés", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Inirida, Nombre = "Inírida", PaisId = SeedIds.Colombia },
        new Ciudad { Id = SeedIds.Buenaventura, Nombre = "Buenaventura", PaisId = SeedIds.Colombia },

        // argentina
        new Ciudad { Id = SeedIds.BuenosAires, Nombre = "Buenos Aires", PaisId = SeedIds.Argentina },
        new Ciudad { Id = SeedIds.Cordoba, Nombre = "Córdoba", PaisId = SeedIds.Argentina },

        // brazil
        new Ciudad { Id = SeedIds.SaoPaulo, Nombre = "São Paulo", PaisId = SeedIds.Brasil },
        new Ciudad { Id = SeedIds.RioDeJaneiro, Nombre = "Rio de Janeiro", PaisId = SeedIds.Brasil },

        // chile
        new Ciudad { Id = SeedIds.Santiago, Nombre = "Santiago", PaisId = SeedIds.Chile },

        // peru
        new Ciudad { Id = SeedIds.Lima, Nombre = "Lima", PaisId = SeedIds.Peru },

        // mexico
        new Ciudad { Id = SeedIds.CiudadDeMexico, Nombre = "Ciudad de México", PaisId = SeedIds.Mexico },
        new Ciudad { Id = SeedIds.Monterrey, Nombre = "Monterrey", PaisId = SeedIds.Mexico },

        // usa
        new Ciudad { Id = SeedIds.NewYork, Nombre = "New York", PaisId = SeedIds.USA },
        new Ciudad { Id = SeedIds.LosAngeles, Nombre = "Los Ángeles", PaisId = SeedIds.USA },

        // Bolivia
        new Ciudad { Id = SeedIds.LaPaz, Nombre = "La Paz", PaisId = SeedIds.Bolivia },

        // Ecuador
        new Ciudad { Id = SeedIds.Quito, Nombre = "Quito", PaisId = SeedIds.Ecuador },

        // Guyana
        new Ciudad { Id = SeedIds.Georgetown, Nombre = "Georgetown", PaisId = SeedIds.Guyana },

        // Paraguay
        new Ciudad { Id = SeedIds.Asuncion, Nombre = "Asunción", PaisId = SeedIds.Paraguay },

        // Surinam
        new Ciudad { Id = SeedIds.Paramaribo, Nombre = "Paramaribo", PaisId = SeedIds.Surinam },

        // Uruguay
        new Ciudad { Id = SeedIds.Montevideo, Nombre = "Montevideo", PaisId = SeedIds.Uruguay },

        // Venezuela
        new Ciudad { Id = SeedIds.Caracas, Nombre = "Caracas", PaisId = SeedIds.Venezuela }

            );
        }

        private static void SeedEstados(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>().HasData(
                new Estado { Id = SeedIds.EstadoLead, Nombre = "Lead" },
                new Estado { Id = SeedIds.EstadoProspecto, Nombre = "Prospecto" },
                new Estado { Id = SeedIds.EstadoCliente, Nombre = "Cliente" },
                new Estado { Id = SeedIds.EstadoInactivo, Nombre = "Inactivo" }
            );
        }

        private static void SeedSectores(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sector>().HasData(
                new Sector { Id = SeedIds.SectorSalud, Nombre = "Salud" },
                new Sector { Id = SeedIds.SectorEducacion, Nombre = "Educación" },
                new Sector { Id = SeedIds.SectorRetail, Nombre = "Retail Comercio" },
                new Sector { Id = SeedIds.SectorLogistica, Nombre = "Logística y Transporte" },
                new Sector { Id = SeedIds.SectorInmobiliario, Nombre = "Inmobiliario" },
                new Sector { Id = SeedIds.SectorFinanzas, Nombre = "Finanzas" },
                new Sector { Id = SeedIds.SectorManufactura, Nombre = "Manufactura" },
                new Sector { Id = SeedIds.SectorServicios, Nombre = "Servicios Profesionales" },
                new Sector { Id = SeedIds.SectorGobierno, Nombre = "Gobierno / Sector Público" },
                new Sector { Id = SeedIds.SectorConstruccion, Nombre = "Construcción" },
                new Sector { Id = SeedIds.SectorTurismo, Nombre = "Turismo y Hospitalidad" },
                new Sector { Id = SeedIds.SectorAgro, Nombre = "Agricultura / Agroindustria" },
                new Sector { Id = SeedIds.SectorEnergia, Nombre = "Energía" },
                new Sector { Id = SeedIds.SectorTecnologia, Nombre = "Tecnología" }
            );
        }

        private static void SeedPrefijosTelefonicos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrefijoTelefonico>().HasData(

                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoColombia,
                    Codigo = "+57",
                    Nombre = "Colombia",
                    PaisId = SeedIds.Colombia
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoUSA,
                    Codigo = "+1",
                    Nombre = "Estados Unidos",
                    PaisId = SeedIds.USA
                },

                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoArgentina,
                    Codigo = "+54",
                    Nombre = "Argentina",
                    PaisId = SeedIds.Argentina
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoBolivia,
                    Codigo = "+591",
                    Nombre = "Bolivia",
                    PaisId = SeedIds.Bolivia
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoBrasil,
                    Codigo = "+55",
                    Nombre = "Brasil",
                    PaisId = SeedIds.Brasil
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoChile,
                    Codigo = "+56",
                    Nombre = "Chile",
                    PaisId = SeedIds.Chile
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoEcuador,
                    Codigo = "+593",
                    Nombre = "Ecuador",
                    PaisId = SeedIds.Ecuador
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoGuyana,
                    Codigo = "+592",
                    Nombre = "Guyana",
                    PaisId = SeedIds.Guyana
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoParaguay,
                    Codigo = "+595",
                    Nombre = "Paraguay",
                    PaisId = SeedIds.Paraguay
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoPeru,
                    Codigo = "+51",
                    Nombre = "Perú",
                    PaisId = SeedIds.Peru
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoSurinam,
                    Codigo = "+597",
                    Nombre = "Surinam",
                    PaisId = SeedIds.Surinam
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoUruguay,
                    Codigo = "+598",
                    Nombre = "Uruguay",
                    PaisId = SeedIds.Uruguay
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoVenezuela,
                    Codigo = "+58",
                    Nombre = "Venezuela",
                    PaisId = SeedIds.Venezuela
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoMexico,
                    Codigo = "+52",
                    Nombre = "México",
                    PaisId = SeedIds.Mexico
                },
                new PrefijoTelefonico
                {
                    Id = SeedIds.PrefijoCanada,
                    Codigo = "+1",
                    Nombre = "Canadá",
                    PaisId = SeedIds.Canada
                }
            );
        }


        private static void SeedTiposActividad(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoActividad>().HasData(
                new TipoActividad
                {
                    Id = SeedIds.TipoActividadLlamada,
                    Nombre = "Llamada",
                    Descripcion = "Llamada telefónica con el cliente",
                    Activo = true
                },
                new TipoActividad
                {
                    Id = SeedIds.TipoActividadReunion,
                    Nombre = "Reunión",
                    Descripcion = "Reunión presencial o virtual",
                    Activo = true
                },
                new TipoActividad
                {
                    Id = SeedIds.TipoActividadCorreo,
                    Nombre = "Correo",
                    Descripcion = "Envío o seguimiento vía correo electrónico",
                    Activo = true
                },
                new TipoActividad
                {
                    Id = SeedIds.TipoActividadSeguimiento,
                    Nombre = "Seguimiento",
                    Descripcion = "Seguimiento comercial",
                    Activo = true
                },
                new TipoActividad
                {
                    Id = SeedIds.TipoActividadDemo,
                    Nombre = "Demo",
                    Descripcion = "Demostración de producto o servicio",
                    Activo = true
                }
            );
        }

        private static void SeedEstadosActividad(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoActividad>().HasData(
                new EstadoActividad
                {
                    Id = SeedIds.EstadoActividadProgramada,
                    Nombre = "Programada",
                    Activo = true
                },
                new EstadoActividad
                {
                    Id = SeedIds.EstadoActividadCompletada,
                    Nombre = "Completada",
                    Activo = true
                },
                new EstadoActividad
                {
                    Id = SeedIds.EstadoActividadCancelada,
                    Nombre = "Cancelada",
                    Activo = true
                }
            );
        }
        private static void SeedEmailTemplates(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplate>().HasData(
                new EmailTemplate
                {
                    Id = 1,
                    Nombre = "ActivacionCuenta",
                    TemplateHtml = @"
<!DOCTYPE html>
<html>
<head>
  <meta charset='utf-8' />
  <meta name='viewport' content='width=device-width, initial-scale=1.0' />
</head>
<body style='margin:0;padding:0;background-color:#f5f4f0;font-family:Arial,sans-serif;'>
  <table width='100%' cellpadding='0' cellspacing='0' style='background-color:#f5f4f0;padding:40px 0;'>
    <tr>
      <td align='center'>
        <table width='560' cellpadding='0' cellspacing='0' style='background-color:#ffffff;border-radius:20px;border:1px solid #e8e6e0;overflow:hidden;'>
          <!-- HEADER -->
          <tr>
            <td style='background-color:#111827;padding:32px 40px;text-align:center;'>
              <p style='margin:0;font-size:22px;font-weight:700;color:#ffffff;letter-spacing:-0.5px;'>DrakionTech CRM</p>
              <p style='margin:6px 0 0;font-size:13px;color:#9ca3af;'>Plataforma de gestión comercial</p>
            </td>
          </tr>
          <!-- ÍCONO -->
          <tr>
            <td align='center' style='padding:36px 40px 0;'>
              <div style='width:64px;height:64px;background-color:#f3f4f6;border-radius:16px;display:inline-block;text-align:center;line-height:64px;'>
                <span style='font-size:28px;color:#374151;font-weight:700;'>&#128274;</span>
              </div>
            </td>
          </tr>
          <!-- CONTENIDO -->
          <tr>
            <td style='padding:24px 40px 16px;text-align:center;'>
              <h1 style='margin:0 0 10px;font-size:24px;font-weight:700;color:#111827;letter-spacing:-0.4px;'>Hola, {{Nombre}}</h1>
              <p style='margin:0;font-size:15px;color:#6b7280;line-height:1.7;'>
                Tu cuenta en DrakionTech CRM ha sido creada.<br/>
                Haz clic en el botón para activarla y comenzar.
              </p>
            </td>
          </tr>
          <!-- BOTÓN -->
          <tr>
            <td align='center' style='padding:28px 40px;'>
              <a href='{{ActivationLink}}'
                 style='display:inline-block;background-color:#111827;color:#ffffff;text-decoration:none;font-size:15px;font-weight:600;padding:14px 36px;border-radius:12px;letter-spacing:0.01em;'>
                Activar mi cuenta &rarr;
              </a>
            </td>
          </tr>
          <!-- AVISO ENLACE -->
          <tr>
            <td style='padding:0 40px 24px;text-align:center;'>
              <p style='margin:0;font-size:12px;color:#9ca3af;line-height:1.6;'>
                Si el bot&oacute;n no funciona, copia y pega este enlace en tu navegador:<br/>
                <span style='color:#2563eb;word-break:break-all;'>{{ActivationLink}}</span>
              </p>
            </td>
          </tr>
          <!-- DIVIDER -->
          <tr>
            <td style='padding:0 40px;'>
              <div style='height:1px;background-color:#f3f4f6;'></div>
            </td>
          </tr>
          <!-- FOOTER -->
          <tr>
            <td style='padding:24px 40px;text-align:center;'>
              <p style='margin:0;font-size:12px;color:#9ca3af;line-height:1.6;'>
                Este correo fue enviado autom&aacute;ticamente por DrakionTech CRM.<br/>
                Si no solicitaste esto, puedes ignorar este mensaje.
              </p>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</body>
</html>
",
                    Activo = true
                }
            );
        }
    }
}