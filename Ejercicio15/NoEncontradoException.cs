﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio15
{
    public class NoEncontradoException : Exception
    {
        public NoEncontradoException() :base ()
        {

        }

        public NoEncontradoException(String mensaje) :base(mensaje)
        {

        }

        public NoEncontradoException(string mensaje,Exception InnerException) : base(mensaje, InnerException)
        {

        }
    }
}