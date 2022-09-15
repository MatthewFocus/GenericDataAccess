using GenericDataAccess.Data.Database;
using GenericDataAccess.Data.Implementations;
using GenericDataAccess.Data.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDataAccess.Data.Data
{
    public class CustomerManager
    {
        private readonly RepositoryEF<Customer, DataContext> _context;

        public CustomerManager(RepositoryEF<Customer, DataContext> context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAll()
        {
            try
            {
                var result = await _context.GetAll();
                return result.ToList<Customer>();
            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}
