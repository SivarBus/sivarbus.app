using SivarBus.Model;
using SivarBus.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SivarBus.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonasPage : ContentPage
    {
        PersonaViewModel contexto = new PersonaViewModel();

        public PersonasPage()
        {
            InitializeComponent();
            BindingContext = contexto;
            //LvPersonas.ItemSelected += LvPeronas_ItemSelected;

            LvPerson.ItemSelected += LvPerson_ItemSelected;
        }

        private void LvPerson_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                PersonaModel modelo = (PersonaModel)e.SelectedItem;

                Navigation.PushAsync(new DetallePage(modelo));

                contexto.Nombre = modelo.Nombre;
                contexto.Apellido = modelo.Apellido;
                contexto.Edad = modelo.Edad;
                contexto.Id = modelo.Id;


            }
        }





    }
}