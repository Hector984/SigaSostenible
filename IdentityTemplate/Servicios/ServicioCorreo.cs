using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace IdentityTemplate.Servicios
{

    public interface IServicioCorreo
    {
        Task EnviarCorreoAsync(string receptor, string asunto, string cuerpoMensaje);
    }

    public class ServicioCorreo : IServicioCorreo
    {
        private readonly IOptions<ConfiguracionCorreo> _configuracionCorreo;

        public ServicioCorreo(IOptions<ConfiguracionCorreo> configuracionCorreo)
        {
            _configuracionCorreo = configuracionCorreo;
        }

        public async Task EnviarCorreoAsync(string receptor, string asunto, string cuerpoMensaje)
        {
            var mensaje = new MailMessage(_configuracionCorreo.Value.Usuario, receptor,
                asunto,
                cuerpoMensaje);

            using (var cliente = new SmtpClient(_configuracionCorreo.Value.Host, _configuracionCorreo.Value.Puerto))
            {
                cliente.Credentials = new NetworkCredential(
                    _configuracionCorreo.Value.Usuario,
                    _configuracionCorreo.Value.Contraseña);

                await cliente.SendMailAsync(mensaje);
            }
        }
    }
}
