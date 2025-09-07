using System.Data.Common;
using minimal_api.Dominio.Interfacess;
using MinimalApi.Dominio.Entidades;
using MinimalAPI.DTOs;
using MinimalAPI.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos

{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;        }
    }
}   