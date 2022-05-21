using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using App.Dominio.Entidades;
using App.Infraestructura.Interfaz;

namespace App.Infraestructura.Repositorio
{
    public class PersonaRepositorio: IPersona
    {

        //Llamada al DbContext
        private readonly AplicacionDbContext Db;

        public PersonaRepositorio(AplicacionDbContext dbContext)
        {
            this.Db = dbContext;
        }

        public bool Add(Personas entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Error! La persona no fue registrada");

                Db.Set<Personas>().Add(entity);
                return Db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Delete(int Id)
        {

            try
            {
                var delete = GetById(Id);

                Db.Set<Personas>().Remove(delete);

                return Db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Personas> Get()
        {

            try
            {
                return Db.Set<Personas>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Personas GetById(int Id)
        {

            try
            {
                return Db.Set<Personas>().Find(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public bool Update(Personas personas)
        {

            try
            {
                var entityActualizar =  GetById(personas.ID) as Personas;

                if (entityActualizar == null)
                    throw new ArgumentNullException("Error!" + "La persona no pudo ser actualizada");

                entityActualizar.Nombre = personas.Nombre;
                entityActualizar.FechaDeNacimiento = personas.FechaDeNacimiento;

                Db.Entry(entityActualizar).State = EntityState.Modified;

                return Db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
