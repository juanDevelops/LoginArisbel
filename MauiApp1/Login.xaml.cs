using static System.Net.Mime.MediaTypeNames;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        dbLogin db = new dbLogin();

        private void OnCounterClicked(object sender, EventArgs e)
        {
           
        }



        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            if (db.ConsultarUsuario(User.Text, ePassword.Text))
            {
                await DisplayAlert("Aviso", "Bienvenido " + User.Text, "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Usuario o contraseña incorrectos.", "Ok");
            }
        }


        private async void btnCancelar_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPage1());
        }

        private async void btnRecuperarContraseña_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecuperarContraseña());
        }
    }

}
