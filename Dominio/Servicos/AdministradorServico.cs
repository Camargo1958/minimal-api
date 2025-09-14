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
            return adm;
        }

        public Administrador Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();
            return administrador;
        }

        public List<Administrador> Todos(int? pagina)
        {
            var query = _contexto.Administradores.AsQueryable();

            int tamanhoPagina = 10;
            int skip;
            if (pagina != null) {
                skip = ((int)pagina - 1) * tamanhoPagina;
            }
            else {
                skip = tamanhoPagina;
            }
            return query.Skip(skip).Take(tamanhoPagina).ToList();
        }

        public Administrador? BuscaPorId(int id)
        {
            var administrador = _contexto.Administradores.Where(a => a.Id == id).FirstOrDefault();
            return administrador;
        }
    }
}   