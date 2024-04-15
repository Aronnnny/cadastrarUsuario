using CadastrarUsuario.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarUsuario.Domain.Repositories
{
    public interface IUserService
    {
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        Guid Add(string name, string password, string email, string cpf, string phoneNumber);
        bool Update(Guid id, string name, string password, string email, string cpf, string phoneNumber);
        bool Delete(Guid id);
    }
}
