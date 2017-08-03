using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio15.Repository
{
    public interface IEntradasRepository
    {
        Entrada Create(Entrada _entrada);
        IQueryable<Entrada> ReadEntradas();
        Entrada Read(long id);
        Entrada Delete(Entrada entrada);
        void PutEntrada(Entrada entrada);
    }
}
