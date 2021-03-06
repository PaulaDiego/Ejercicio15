﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio15.Services
{
    public interface IEntradasService
    {
        Entrada Create(Entrada entrada);
        IQueryable<Entrada> ReadEntradas();
        Entrada GetEntrada(long id);
        void PutEntrada(Entrada entrada);
        Entrada Delete(Entrada entrada);
    }
}
