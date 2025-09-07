using MinimalApi.Dominio.Entidades;
using MinimalAPI.DTOs;

namespace minimal_api.Dominio.Interfacess

{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}