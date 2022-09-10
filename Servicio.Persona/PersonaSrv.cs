using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Servicio.Persona
{
    public class PersonaSrv
    {
        AccesoDatos.Persona persona;
        public InfPersona CrearPersona(InfPersona infoPersona)
        {
            persona = new AccesoDatos.Persona();
            var response = persona.CrearPersona(ref infoPersona);
            if (response)
            {
                return infoPersona;
            }
            else
            {
                infoPersona = null;
                return infoPersona;
            }            
        }
        public List<InfPersona> ConsultarPersona()
        {
            List<InfPersona> infoPersona = new List<InfPersona>();
            persona = new AccesoDatos.Persona();
            var response = persona.ConsultarPersona(ref infoPersona);
            if (response)
            {
                return infoPersona;
            }
            else
            {
                infoPersona = null;
                return infoPersona;
            }
        }

        public List<InfPersona> ConsultarPersonaById(int IdPersona)
        {
            List<InfPersona> infoPersona = new List<InfPersona>();
            persona = new AccesoDatos.Persona();
            var response = persona.ConsultarPersona(IdPersona, ref infoPersona);
            if (response)
            {
                return infoPersona;
            }
            else
            {
                infoPersona = null;
                return infoPersona;
            }
        }

        public InfPersona ModificarPersona(InfPersona infoPersona)
        {
            persona = new AccesoDatos.Persona();
            var response = persona.ModificarPersona(ref infoPersona);
            if (response)
            {
                return infoPersona;
            }
            else
            {
                infoPersona = null;
                return infoPersona;
            }
        }
    }
}
