using CadastrarUsuario.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarUsuario.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        Guid Add(User user);
        void Update(User user);
        void Delete(Guid id);
    }
}
