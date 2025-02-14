using Ofelia_Sara.Formularios.General.Mensajes;
using System.Windows.Forms;
using Ofelia_Sara.Formularios.Oficial_de_servicio.Agregar_Componentes;
using Ofelia_Sara.Formularios.Oficial_de_servicio.Registro_de_personal;
using Ofelia_Sara.Formularios.Oficial_de_servicio;


namespace Ofelia_Sara.Controles.Barra_Busqueda

{/// <summary>
/// CLASE PARA CREAR INSTANCIAS DE FORMULARIOS DESDE BARRA DE BUSQUEDA DE MENU PRINCIPAL
/// </summary>
    public class AbrirFormularios_BarraBusqueda
    {
        public static void AbrirFormulario(string nombreFormulario)
        {
            Form formulario = null;

            // Dependiendo del nombre, instanciar el formulario correspondiente
            switch (nombreFormulario)
            {
                case "Agregar Instructor":
                      formulario = new NuevoInstructor();
                    break;

                case "Agregar Secretario":
                       formulario = new NuevoSecretario();
                    break;

                case "Agregar Dependencia":
                      formulario = new NuevaDependencia();
                    break;

                case "Agregar Sellos":
                    formulario = new SellosDependencia();
                    break;

                case "Agregar Personal Policial":
                       formulario = new NuevoPersonal();
                    break;

                case "Actuaciones sumariales IPP":
                     formulario = new InicioCierre();
                    break;

                case "Contravensiones":
                      formulario = new Contravenciones();
                    break;

                case "Expedientes":
                      formulario = new Expedientes();
                    break;

                case "Leyes y decretos":
                     formulario = new LeyesForm();
                    break;

                default:
                    MensajeGeneral.Mostrar("No se encontró el formulario correspondiente.", MensajeGeneral.TipoMensaje.Error);
                    return;
            }

            // Muestra el formulario
            formulario.Show();
        }
    }
}
/*         
        "Buscar por IPP",
        "Buscar por Imputado",
        "Buscar por Victima",
        "Buscar por Instructor",
        "Buscar por Secretario",
        "Buscar por Dependencia",
        "Buscar por Fecha",
        "Codigo Procesal Penal",
        "Codigo Penal",
        "Codigo Contravencional",
        "Ley 13982",
        "Decreto 1050/09",
        "Ratificacion Policial",
        "Declaracion testimonial",
        "Denuncia rueda auxilio",
        "Denuncia telefono celular",
        "Caratula",
        "Decreto inicio",
        "Decreto cierre",
        "Nota elevacion",
        "Notificacion art 60",
        "Nota ingreso obito",
        "Nota egreso obito",
        "Nota entrega obito",
        "Nota pericia bomberos",
        "Formulario stud peritos",
        "Cadena custodia secuestro estandar",
        "Cadena custodia celulares",
        "Cargo",
        "Legajo detenido",
        "Legajo vehiculo",
        "Solictud plana y pertenencia vehiculo",
        "Solicitud plana ciudadano",
        "Inspeccion ocular",
        "Señor Instructor",
        "Producir informe",
        "Nota GTO",
        "Nota DDI",
        "Nota I2",
        "Nota camaras Monitoreo",
        "Nota camaras Particulares"*/