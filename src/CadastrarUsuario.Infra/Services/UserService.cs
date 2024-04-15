using CadastrarUsuario.Domain.Models;
using CadastrarUsuario.Domain.Repositories;
using CadastrarUsuario.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarUsuario.Infra.Services
{
    public class UserService(DataContext context) : IUserService
    {
        private readonly DataContext _context = context;
        public Guid Add(string name, string password, string email, string cpf, string phoneNumber)
        {
            var userToCreate = new User(name,password,email,cpf,phoneNumber);

            _context.Users.Add(userToCreate);
            _context.SaveChanges();

            return userToCreate.Id;
        }

        public bool Delete(Guid id)
        {
            var itemToDelete = _context.Users.FirstOrDefault(x => x.Id == id);

            if (itemToDelete == null)
                return false;

            _context.Users.Remove(itemToDelete);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Guid id, string name, string password, string email, string cpf, string phoneNumber)
        {
            var userToUpdate = _context.Users.FirstOrDefault(x => x.Id == id);

            if (userToUpdate == null)
                return false;

            userToUpdate.Update(name, password, email, cpf , phoneNumber);

            _context.SaveChanges();
            return true;
        }
    }
}
