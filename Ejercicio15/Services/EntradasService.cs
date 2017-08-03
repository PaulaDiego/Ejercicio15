using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ejercicio15.Repository;
using Ejercicio15.Models;
using System.Data.Entity.Infrastructure;

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
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entrada = entradasRepository.Create(entrada);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return entrada;
            }
        }

        public IQueryable<Entrada> ReadEntradas()
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Entrada> entradas;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entradas = entradasRepository.ReadEntradas();
                        //context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                ApplicationDbContext.applicationDbContext = null;
                return entradas;
            }
        }

        public Entrada GetEntrada(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                Entrada entrada;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entrada = entradasRepository.Read(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return entrada;
            }
        }

        public void PutEntrada(Entrada entrada)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        entradasRepository.PutEntrada(entrada);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (DbUpdateConcurrencyException dbu)
                    {
                        if (entradasRepository.Read(entrada.Id) == null)
                        {
                            throw new NoEncontradoException("No he encontrado la entidad", dbu);
                        }
                        else
                        {
                            throw;
                        }
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }


                }
            }
        }

        public Entrada Delete(Entrada entrada)
        {
            Entrada resultado;
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        resultado = entradasRepository.Delete(entrada);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
            }
            return resultado;
        }

        
    }
}