using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi_SGP.Context;
using WebApi_SGP.Model;

namespace WebApi_SGP.Repository
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        protected readonly ContextEntity _context;

        public UsuarioRepository(ContextEntity context)
        {
            _context = context;
        }

        public Usuario GetUsuarioLogin(string login)
        {
          return _context.Usuario.Include(p => p.Perfil)
                                    .Include(c => c.Cargo)
                                    .Where(e => e.UsuLogin.Equals(login)).First();
        }

        public bool Login(Usuario obj)
        {
            return _context.Usuario.Any(e => e.UsuLogin.Equals(obj.UsuLogin) && e.UsuSenha.Equals(obj.UsuSenha));
        }

        public void Add(Usuario obj)
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

        public void Update(Usuario obj)
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
