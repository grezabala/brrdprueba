using App.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructura.Interfaz
{
    public interface IPersona
    {
        bool Add(Personas entity);       
        bool Update(Personas personas);
        bool Delete(int Id);
        Personas GetById(int Id);
        List<Personas> Get();

    }
}
