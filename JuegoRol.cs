using System;
using System.Text.RegularExpressions;

class Personaje{
	public enum Clases{ Guerrero, Mago, Arquero, Paladin, Clerigo, Cazador };
	//DATOS:
	private static string tipo;
	private static string nombre;
	private static string apodo;
	private static DateTime fechaNac;
	private static int edad;
	private static int salud;

	public const int maxEdad = 300;
	public const int maxSalud = 100;

	public string Tipo {get => tipo; set => tipo = value;}
	public string Nombre {get => nombre; set => nombre = value;}
	public string Apodo {get => apodo; set => apodo = value;}
	public DateTime FechaNac {get => fechaNac; set => fechaNac = value;}
	public int Edad {get => edad; set => edad = value;}
	public int Salud {get => salud; set => salud = value;}

	public void MostrarDatos() {
		Console.WriteLine("Tipo: " + Tipo);
		Console.WriteLine("Nombre: " + Nombre);
		Console.WriteLine("Apodo: " + Apodo);
		Console.WriteLine("Fecha de Nacimiento: " + FechaNac.ToString("dd/MM/yyyy"));
		Console.WriteLine("Edad: " + Edad);
		Console.WriteLine("Salud: " + Salud);
	}

	//CARACTERISTICAS:
	public const int maxVelocidad = 10;
	public const int maxDestreza = 5;
	public const int maxFuerza = 10;
	public const int maxNivel = 10;
	public const int maxArmadura = 10;

	private static int velocidad;
	private static int destreza;
	private static int fuerza;
	private static int nivel;
	private static int armadura;

	public int Velocidad{get => velocidad; set => velocidad = value;}
	public int Destreza{get => destreza; set => destreza = value;}
	public int Fuerza{get => fuerza; set => fuerza = value;}
	public int Nivel{get => nivel; set => nivel = value;}
	public int Armadura{get => armadura; set => armadura = value;}

	public void MostrarCaracteristicas() {
		Console.WriteLine("Velocidad: " + Velocidad);
		Console.WriteLine("Destreza: " + Destreza);
		Console.WriteLine("Fuerza: " + Fuerza);
		Console.WriteLine("Nivel: " + Nivel);
		Console.WriteLine("Armadura: " + Armadura);
	}

	public Personaje(string tipo, string nombre, string apodo, DateTime fechanac){
		Random random = new Random(Environment.TickCount);

		Velocidad = random.Next(maxVelocidad) + 1;
		Destreza = random.Next(maxDestreza) + 1;
		Fuerza = random.Next(maxFuerza) + 1;
		Nivel = random.Next(maxNivel) + 1;
		Armadura = random.Next(maxArmadura) + 1;

		Tipo = tipo;
		Nombre = nombre;
		Apodo = apodo;
		FechaNac = fechanac;
		Edad = CalcularEdad(fechanac);
		Salud = maxSalud;
	}

	public void MostrarPersonaje(){
		Console.WriteLine("\nDatos:");
		MostrarDatos();
		Console.WriteLine("\nCaracteristicas:");
		MostrarCaracteristicas();
	}

	public int CalcularEdad(DateTime fechanac){
		DateTime ahora = DateTime.Now;
		int edad = ahora.Year - fechaNac.Year;
		if (ahora < fechaNac.AddYears(edad)) edad--;
		return edad;
	}

	public static void MostrarClases() {
		Type clases = typeof(Clases);
		int i = 0;
		foreach(string s in Enum.GetNames(clases)){
			Console.WriteLine("{0}. {1}", i, s);
			i++;
		}
	}
}

class MainClass{
	public static void Main(){
		Personaje Personaje1 = CrearPersonaje();
		Personaje1.MostrarPersonaje();
	}

	public static Personaje CrearPersonaje(){
		DateTime fecha;
		int t;
		string tipo;
		string nombre, apodo, fec;
		string pattern = @"(\d+)(/)(\d+)(/)(\d+)";

		Console.WriteLine("Elija su clase: ");
		Personaje.MostrarClases();
		Console.Write("Seleccion (numero): ");
		t = Convert.ToInt16(Console.ReadLine());
		Type clases = typeof(Personaje.Clases);
		tipo = Enum.GetNames(clases)[t];

		Console.Write("Nombre del personaje: ");
		nombre = Console.ReadLine();
		Console.Write("Apodo del personaje: ");
		apodo = Console.ReadLine();

		Console.Write("Fecha de nacimiento (dd/mm/año): ");
		fec = Console.ReadLine();

		Match fechanac = System.Text.RegularExpressions.Regex.Match(fec, pattern);
		if(fechanac.Success){
			int dia = Convert.ToInt16(fechanac.Groups[1].Value);
			int mes = Convert.ToInt16(fechanac.Groups[3].Value);
			int anio = Convert.ToInt16(fechanac.Groups[5].Value);

			fecha = new DateTime(anio,mes,dia);
		}else{
			fecha = DateTime.Now;
		}

		Personaje Personaje1 = new Personaje(tipo,nombre,apodo,fecha);
		return Personaje1;
	}
}