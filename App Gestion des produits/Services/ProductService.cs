using App_Gestion_des_produits.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App_Gestion_des_produits.Services
{
    class ProductService
    {
        private DatabaseContext getContext()
        {
            return new DatabaseContext();
        }

        public async Task<List<Products>> GetProducts()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Products.ToListAsync();
            return res;
        }

        public async Task<int> UpdateProduct(Products prd)
        {
            var _dbContext = getContext();
            _dbContext.Products.Update(prd);
            int prdc = await _dbContext.SaveChangesAsync();
            return prdc;
        }

        public int InsertProduct(Products prd)
        {
            var _dbContext = getContext();
            _dbContext.Products.Add(prd);
            int prdc = _dbContext.SaveChanges();
            return prdc;
        }

        public int DeleteEmployee(Products prd)
        {
            var _dbContext = getContext();
            _dbContext.Products.Remove(prd);
            int prdc = _dbContext.SaveChanges();
            return prdc;
        }
    }
}
