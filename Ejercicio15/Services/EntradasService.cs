using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ejercicio15.Repository;
using Ejercicio15.Models;

namespace Ejercicio15.Services
{
    public class EntradasService : IEntradasService
    {
        

        private IEntradasRepository entradasRepository;
        public EntradasService(IEntradasRepository _entradasRepository)
        {
            this.entradasRepository = _entradasRepository;
        }
        public Entrada Create(Entrada entrada)
        {
            using(var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entrada = entradasRepository.Create(entrada);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }catch(Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }
                   
                }
                return entrada;
            }
        }
    }
}