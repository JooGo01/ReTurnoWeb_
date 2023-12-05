using Microsoft.EntityFrameworkCore;
using ReTurnoWeb.Models;


namespace ReTurnoWeb.Servicios.Contrato
{
    public interface IUsuario
    {
        Task<Usuario> GetUsuario(String mail, String pwd);
        Task<Usuario> GuardarUsuario(Usuario usr);
    }
}
