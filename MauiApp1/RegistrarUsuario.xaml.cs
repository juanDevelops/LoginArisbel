namespace MauiApp1;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    dbLogin db = new dbLogin();


    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (db.InsertarUsuario(tbNombre.Text, tbEmail.Text, tbTelefono.Text, 'f', dpFechaNacimiento.Date, txtContraseña.Text))
        {
            await DisplayAlert("Aviso", "Registrado Correctamente", "Ok");
        }
        else
        {
            await DisplayAlert("Aviso", db.errorMessage, "Ok");
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }
}