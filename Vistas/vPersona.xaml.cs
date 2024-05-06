using candinoS5AC.Models;

namespace candinoS5AC.Vistas;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;
        App.personaRepo.AddNewPerson(txtName.Text);
        lblStatus.Text = App.personaRepo.StatusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;
        List<Persona> people = App.personaRepo.GetAllPeople();
        ListaPersona.ItemsSource = people;
        lblStatus.Text = App.personaRepo.StatusMessage;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        Button boton = (Button)sender;
        Grid grid = (Grid)boton.Parent;
        Entry idEntry = (Entry)grid.Children[0];
        Entry nameEntry = (Entry)grid.Children[1];
        int id = Convert.ToInt32(idEntry.Text);
        string nombre = nameEntry.Text;

        lblStatus.Text = string.Empty;
        App.personaRepo.UpdatePerson(id, nombre);
        lblStatus.Text = App.personaRepo.StatusMessage;
        btnObtener_Clicked(sender, e);
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        Button boton = (Button)sender;
        Grid grid = (Grid)boton.Parent;
        Entry idEntry = (Entry)grid.Children[0];
        int id = Convert.ToInt32(idEntry.Text);

        lblStatus.Text = string.Empty;
        App.personaRepo.DeletePerson(id);
        lblStatus.Text = App.personaRepo.StatusMessage;
        btnObtener_Clicked(sender, e);
    }

}