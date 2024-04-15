using CadastrarUsuario.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarUsuario.Domain.Models
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string PhoneNumber { get; private set; }

        public User(string name, string password, string email, string cpf, string phoneNumber)
        {
            ValidateName(name);
            ValidatePassword(password);
            ValidateEmail(email);
            ValidateCpf(cpf);
            ValidatePhoneNumber(phoneNumber);

            Name = name;
            Password = password;
            Email = email;
            Cpf = cpf;
            PhoneNumber = phoneNumber;
        }

        public void Update(string name, string password, string email, string cpf, string phoneNumber) 
        {
            Name = name;
            Password = password; 
            Email = email; 
            Cpf = cpf; 
            PhoneNumber = phoneNumber;
        }

        public void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                DomainExceptionValidation.ExceptionHandler(true, "User must have a name.");
            }
            if (name.Length > 50)
            {
                DomainExceptionValidation.ExceptionHandler(true, "User name cannot be longer than 50 characters.");
            }
        }

        public void ValidatePassword(string password)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(password), "User must have a password.");
        }

        public void ValidateEmail(string email)
        {
            DomainExceptionValidation.ExceptionHandler(string.IsNullOrEmpty(email), "User must have an email.");
        }

        public void ValidateCpf(string cpf)
        {
            if(string.IsNullOrEmpty(cpf))
            {
                DomainExceptionValidation.ExceptionHandler(true, "User must have a CPF.");
            }
            if(cpf.Length > 11)
            {
                DomainExceptionValidation.ExceptionHandler(true, "CPF cannot have more than 11 numbers.");
            }
        }

        public void ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                DomainExceptionValidation.ExceptionHandler(true, "User must have a phone number.");
            }
            if(phoneNumber.Length > 13)
            {
                DomainExceptionValidation.ExceptionHandler(true, "Phone number cannot have more than 11 numbers");
            }
        }
    }
}
