using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payment_api.Models
{
    public class Salesman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }

        public Salesman(int id, string name, string cpf, string numberPhone, string email)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            NumberPhone = numberPhone;
            Email = email;
        }
    }
}