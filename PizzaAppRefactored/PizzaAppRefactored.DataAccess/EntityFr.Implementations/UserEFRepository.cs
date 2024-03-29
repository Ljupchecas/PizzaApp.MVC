﻿using PizzaAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.DataAccess.EntityFr.Implementations
{
    public class UserEFRepository : IRepository<User>
    {
        private readonly PizzaAppDbContext _pizzaAppDbContext;
        public UserEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _pizzaAppDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _pizzaAppDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
