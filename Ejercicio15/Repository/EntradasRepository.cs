using Ejercicio15.Models;
using Ejercicio15.Services;
using System;
using System.Collections.Generic;
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
    }
}