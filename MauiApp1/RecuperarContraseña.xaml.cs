namespace MauiApp1;

public partial class RecuperarContraseña : ContentPage
{
	public RecuperarContraseña()
	{
		InitializeComponent();
	}

	dbLogin db = new dbLogin();

    private async void btnRecuperar_Clicked(object sender, EventArgs e)
    {
		if (tbPassword.Text != tbRepetirPassword.Text)
		{
            await DisplayAlert("Aviso", "Las contraseñas no coinciden.", "Ok");
			return;
        }
		if (db.ActualizarContraseña(tbUser.Text, tbEmail.Text, tbPassword.Text))
		{
            await DisplayAlert("Aviso", "Contraseña ha sido actualizada.", "Ok");
        }
		else
		{
            await DisplayAlert("Aviso", "Hubo un error.", "Ok");
            await DisplayAlert("Aviso", db.errorMessage, "Ok");
        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}