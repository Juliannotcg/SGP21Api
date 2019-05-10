using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SGP.Context;
using WebApi_SGP.Model;

namespace WebApi_SGP.Repository
{
    public class FolhaPontoRepository : IRepository<FolhaPonto>
    {
        private readonly ContextEntity _contextEntity;

        public FolhaPontoRepository(ContextEntity contextEntity)
        {
            _contextEntity = contextEntity;
        }

        public FolhaPonto GetFolhaPonto(FolhaPonto folhaPonto)
        {
            return _contextEntity.FolhaPonto
                                 .Include(u => u.Usuario)
                                 .Where(f => f.FlpData.Equals(folhaPonto.FlpData) && f.Usuario.Equals(folhaPonto.Usuario))
                                 .First();
        }

        public void Add(FolhaPonto obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(FolhaPonto obj)
        {
            throw new NotImplementedException();
        }
    }
}
