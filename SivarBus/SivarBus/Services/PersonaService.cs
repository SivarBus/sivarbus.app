using SivarBus.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SivarBus.Services
{
  public  class PersonaService
    {
        public ObservableCollection<PersonaModel> personas { get; set; }

        public PersonaService()
        {
            if (personas == null)
            {
                personas = new ObservableCollection<PersonaModel>();
            }
        }


        /// <summary>
        ///  Metodo de consultar personas guardadas
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<PersonaModel> Consultar()
        {
            return personas;
        }

        /// <summary>
        /// Metodo para guardar 
        /// </summary>
        /// <param name="modelo"></param>
        public void Guardar(PersonaModel modelo)
        {
            personas.Add(modelo);
        }

        /// <summary>
        /// Metodo para modificar
        /// </summary>
        /// <param name="modelo"></param>
        public void Modificar(PersonaModel modelo)
        {
            for (int i = 0; i < personas.Count; i++)
            {
                if (personas[i].Id == modelo.Id)
                {
                    personas[i] = modelo;
                }
            }
        }

        /// <summary>
        /// Metodo para eliminar
        /// </summary>
        /// <param name="idPersona"></param>
        public void Eliminar(string idPersona)
        {
            PersonaModel modelo = personas.FirstOrDefault(p => p.Id == idPersona);
            personas.Remove(modelo);
        }

    }
}
