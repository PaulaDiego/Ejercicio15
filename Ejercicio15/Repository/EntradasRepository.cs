using Ejercicio15.Models;
using Ejercicio15.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ejercicio15.Repository
{
    public class EntradasRepository : IEntradasRepository
    {
        public Entrada Create(Entrada _entrada)
        {

            return ApplicationDbContext.applicationDbContext.Entradas.Add(_entrada);
        }

        public IQueryable<Entrada> ReadEntradas()
        {
            IList<Entrada> lista = new List<Entrada>(ApplicationDbContext.applicationDbContext.Entradas);
            return lista.AsQueryable();
        }

        public Entrada Read(long id)
        {

            return ApplicationDbContext.applicationDbContext.Entradas.Find(id);
        }

        public Entrada Delete(Entrada entrada)
        {

            ApplicationDbContext.applicationDbContext.Entradas.Remove(entrada);
            return
        }

        public void PutEntrada(Entrada entrada)
        {

            ApplicationDbContext.applicationDbContext.Entry(entrada).State = EntityState.Modified;

        }
    }
}