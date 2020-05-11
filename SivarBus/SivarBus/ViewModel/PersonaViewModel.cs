using SivarBus.Model;
using SivarBus.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SivarBus.ViewModel
{
    class PersonaViewModel:PersonaModel
    {
        public ObservableCollection<PersonaModel> Personas { get; set; }
        PersonaService servicio = new PersonaService();
        PersonaModel modelo;

        public PersonaViewModel()
        {
            Personas = servicio.Consultar();
            GuardarCommand = new Command(async () => await Guardar(), () => !IsBusy);
            ModificarCommand = new Command(async () => await Modificar(), () => !IsBusy);
            EliminarCommand = new Command(async () => await Eliminar(), () => !IsBusy);
            LimpiarCommand = new Command(Limpiar, () => !IsBusy);
        }

        /// <summary>
        /// Los command permiten que al momento de hacer algun
        /// evento desde la vista, se ejecute desde el Viewmodel
        /// </summary>
        public Command GuardarCommand { get; set; }

        public Command ModificarCommand { get; set; }

        public Command EliminarCommand { get; set; }

        public Command LimpiarCommand { get; set; }

        private async Task Guardar()
        {
            IsBusy = true;
            Guid IdPersona = Guid.NewGuid();
            modelo = new PersonaModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = IdPersona.ToString()
            };
            servicio.Guardar(modelo);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Modificar()
        {
            IsBusy = true;
            modelo = new PersonaModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = Id
            };
            servicio.Modificar(modelo);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Eliminar()
        {
            IsBusy = true;
            servicio.Eliminar(Id);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Limpiar()
        {
            Nombre = "";
            Apellido = "";
            Edad = 0;
            Id = "";
        }

    }
}
