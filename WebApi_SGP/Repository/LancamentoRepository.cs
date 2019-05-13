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


        public LancamentoRepository(ContextEntity context)
        {
            _context = context;
        }

        public List<Lancamento> GetListLancamento(Lancamento folhaPonto)
        {
            var resultado = _context.Lancamento.Include(f => f.FolhaPonto)
                                          .Where(f => f.FolhaPonto.FlpId == folhaPonto.FolhaPonto.FlpId);


            return resultado.ToList();
        }

        public void Add(Lancamento obj)
        {
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
