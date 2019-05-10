using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SGP.Context;
using WebApi_SGP.Model;

namespace WebApi_SGP.Repository
{
    public class LancamentoRepository : IRepository<Lancamento>
    {
        protected readonly ContextEntity _context;


        public void InseriLancamento(Lancamento obj)
        {
            var sd =_context.Lancamento.Include(p => p.FolhaPonto)
                                   .Where(e => e.UsuLogin.Equals(obj.UsuLogin)).First();
        }
        public void Add(Lancamento obj)
        {
            return _context.Usuario.Include(p => p.Perfil)
                                   .Include(c => c.Cargo)
                                   .Where(e => e.UsuLogin.Equals(obj.UsuLogin)).First();


            _context.Lancamento.Add(obj);
            SaveChanges();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Lancamento obj)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
