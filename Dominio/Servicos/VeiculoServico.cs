using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Interfacess;
using MinimalApi.Dominio.Entidades;
using MinimalAPI.DTOs;
using MinimalAPI.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos

{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly DbContexto _contexto;
        public VeiculoServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo? BuscaPorId(int id)
        {
            var veiculo = _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
            return veiculo;
        }

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> Todos(int pagina = 1, string? nome = null, string? marca = null)
        {
            var query = _contexto.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome}%"));
            }

            // if (!string.IsNullOrEmpty(marca))
            // {
            //     query = query.Where(v => v.Marca.Contains(marca));
            // }

            int tamanhoPagina = 10;
            int skip = (pagina - 1) * tamanhoPagina;

            return query.Skip(skip).Take(tamanhoPagina).ToList();
        }
    }
}   