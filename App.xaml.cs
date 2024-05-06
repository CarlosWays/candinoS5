namespace candinoS5AC;

public partial class App : Application
{
	public static PersonaRepository personaRepo { get; set; }
	public App(PersonaRepository personRepository)
	{
		InitializeComponent();

		MainPage = new Vistas.vPersona();
		personaRepo = personRepository;

    }
}
