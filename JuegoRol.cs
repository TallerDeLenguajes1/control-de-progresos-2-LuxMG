using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Personaje{
	public enum Clases{ Guerrero, Mago, Arquero, Paladin, Clerigo, Cazador, Alien };
	public enum NombresIA{ Thor, Gandalf, Clarissa, Aloy, John, Mary, Peter, Lesley };
	public enum ApodosIA{ Dios_del_Trueno, El_Blanco, Cazador_de_Sombras, Rompecraneos, Revientahuesos, La_Bestia, Tiro_Mortal };
	public static Random random = new Random(Environment.TickCount);

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

	public Personaje(string tipo, string nombre, string apodo){
		Velocidad = random.Next(maxVelocidad) + 1;
		Destreza = random.Next(maxDestreza) + 1;
		Fuerza = random.Next(maxFuerza) + 1;
		Nivel = random.Next(maxNivel) + 1;
		Armadura = random.Next(maxArmadura) + 1;

		Tipo = tipo;
		Nombre = nombre;
		Apodo = apodo.Replace("_", " ");
		FechaNac = FechaAleatoria();
		Edad = CalcularEdad(FechaNac);
		Salud = maxSalud;
	}

	public void MostrarPersonaje(){
		Console.WriteLine("Datos:");
		Console.WriteLine("Clase: " + Tipo);
		Console.WriteLine("Nombre: " + Nombre + " \"" + Apodo + "\"");
		Console.WriteLine("Edad: " + Edad);

		Console.WriteLine("\nCaracteristicas:");
		Console.WriteLine("Velocidad: " + Velocidad);
		Console.WriteLine("Destreza: " + Destreza);
		Console.WriteLine("Fuerza: " + Fuerza);
		Console.WriteLine("Nivel: " + Nivel);
		Console.WriteLine("Armadura: " + Armadura);
	}

	public int CalcularEdad(DateTime fechanac){
		DateTime ahora = DateTime.Now;
		int edad = ahora.Year - fechaNac.Year;
		if (ahora < fechaNac.AddYears(edad)) edad--;
		return edad;
	}

	public static DateTime FechaAleatoria(){
		int anio = DateTime.Now.Year - random.Next(maxEdad+1);
		int mes = random.Next(12)+1;
		int dia = 0;
		switch(mes){
			case 2:
				dia = random.Next(28)+1;
			break;
			case 4:
			case 6:
			case 9:
			case 11:
				dia = random.Next(30)+1;
			break;
			default:
				dia = random.Next(31)+1;
			break;
		}

		DateTime fecha = new DateTime(anio, mes, dia);
		return fecha;
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
	public static List<Personaje> ListaPersonajes = new List<Personaje>();
	public static Random random = new Random(Environment.TickCount);

	public static void Main(){
		//GENERACION DE PERSONAJES
		Console.Write("Ingrese el numero de jugadores: ");
		try{
			int n = Convert.ToInt16(Console.ReadLine());
		}
		catch(System.FormatException){
			Console.Write("Asegurese de ingresar correctamente un numero de jugadores: ");
			n = Convert.ToInt16(Console.ReadLine());
		}

		Console.WriteLine("---------------------------------");
		Personaje Persona = CrearPersonaje();
		Console.WriteLine();
		Persona.MostrarPersonaje();
		ListaPersonajes.Add(Persona);

		for(int i = 0; i < n-1; i++){
			Console.WriteLine("---------------------------------");
			Personaje IA = CrearPersonajeIA();
			IA.MostrarPersonaje();
			ListaPersonajes.Add(IA);
		}

		Console.WriteLine("---------------------------------");
		Random random = new Random(Environment.TickCount);
		int cantPers = ListaPersonajes.Count;
		//EMPIEZA LA PELEA
		while(cantPers > 1){
			int aux1 = random.Next(cantPers);
			int aux2 = random.Next(cantPers);
			while(aux1 == aux2) aux2 = random.Next(cantPers);

			Combate(ListaPersonajes[aux1], ListaPersonajes[aux2]);
			Console.WriteLine("---------------------------------");
			cantPers = ListaPersonajes.Count;
			Console.ReadLine();
		}

		Persona = ListaPersonajes[0];
		Console.WriteLine("\nEl ganador de esta épica batalla fue: " + Persona.Nombre + " \"" + Persona.Apodo + "\"\nFelicidades!");

		ListaPersonajes.Clear();
	}

	//CREACION DE PERSONAJES
	public static Personaje CrearPersonaje(){
		string nombre, apodo, tipo;

		Console.WriteLine("Elija su clase: ");
		Personaje.MostrarClases();
		Console.Write("Seleccion (numero): ");
		int t = Convert.ToInt16(Console.ReadLine());
		Type clases = typeof(Personaje.Clases);
		tipo = Enum.GetNames(clases)[t];

		Console.Write("Nombre del personaje: ");
		nombre = Console.ReadLine();
		Console.Write("Apodo del personaje: ");
		apodo = Console.ReadLine();

		Personaje Personaje1 = new Personaje(tipo,nombre,apodo);
		return Personaje1;
	}

	public static Personaje CrearPersonajeIA(){
		string nombre, apodo, tipo;

		int t = random.Next(Enum.GetNames(typeof(Personaje.Clases)).Length);
		Type clases = typeof(Personaje.Clases);
		tipo = Enum.GetNames(clases)[t];

		t = random.Next(Enum.GetNames(typeof(Personaje.NombresIA)).Length);
		Type nombresIA = typeof(Personaje.NombresIA);
		nombre = Enum.GetNames(nombresIA)[t];

		t = random.Next(Enum.GetNames(typeof(Personaje.ApodosIA)).Length);
		Type apodosIA = typeof(Personaje.ApodosIA);
		apodo = Enum.GetNames(apodosIA)[t];

		Personaje PersonajeIA = new Personaje(tipo,nombre,apodo);
		return PersonajeIA;
	}

	//FUNCIONES DE COMBATE
	static public int Ataque(Personaje Atacante, Personaje Defensor){
		int PD = Atacante.Destreza * Atacante.Fuerza * Atacante.Nivel;
		int ED = random.Next(100) + 1;
		int VA = PD * ED;
		int PDEF = Defensor.Armadura * Defensor.Velocidad;

		int MDP = 50000;
		int DP = (VA * ED - PDEF) / (MDP * 100);

		if(DP <= MDP){
			return DP;
		}else{
			return MDP;
		}
	}

	static public void Combate(Personaje Pers1, Personaje Pers2){
		Console.WriteLine("Inicio del combate:");
		Console.WriteLine(Pers1.Nombre + " \"" + Pers1.Apodo + "\": " + Pers1.Salud + " HP");
		Console.WriteLine(Pers2.Nombre + " \"" + Pers2.Apodo + "\": " + Pers2.Salud + " HP");

		for(int i = 1; i <= 3; i++){// 3 rondas
			Pers2.Salud -= Ataque(Pers1, Pers2);
			Pers1.Salud -= Ataque(Pers2, Pers1);

			Console.WriteLine("\nRonda " + i + ":");
			Console.WriteLine(Pers1.Nombre + " \"" + Pers1.Apodo + "\": " + Pers1.Salud + " HP");
			Console.WriteLine(Pers2.Nombre + " \"" + Pers2.Apodo + "\": " + Pers2.Salud + " HP");

			if(Pers1.Salud<=0 || Pers2.Salud<=0) i=5;//combate termina
		}

		if(Pers1.Salud > Pers2.Salud){
			Console.WriteLine(Pers1.Nombre + " \"" + Pers1.Apodo + "\" ganó la batalla!");
			Console.Write(Pers1.Nombre + " \"" + Pers1.Apodo + "\" : ");
			OtorgarMejora(Pers1);

			if(Pers2.Salud < 0){
				Console.WriteLine("\n" + Pers2.Nombre + " \"" + Pers2.Apodo + "\" ya no puede continuar.");
			}else{
				Console.WriteLine("\n" + Pers2.Nombre + " \"" + Pers2.Apodo + "\" se retira de la batalla.");
			}

			ListaPersonajes.Remove(Pers2);
		}else if(Pers2.Salud > Pers1.Salud){
			Console.WriteLine(Pers2.Nombre + " \"" + Pers2.Apodo + "\" ganó la batalla!");
			Console.Write(Pers2.Nombre + " \"" + Pers2.Apodo + "\" : ");
			OtorgarMejora(Pers2);

			if(Pers1.Salud < 0){
				Console.WriteLine("\n" + Pers1.Nombre + " \"" + Pers1.Apodo + "\" ya no puede continuar.");
			}else{
				Console.WriteLine("\n" + Pers1.Nombre + " \"" + Pers1.Apodo + "\" se retira de la batalla.");
			}

			ListaPersonajes.Remove(Pers1);
		}else{
			Console.WriteLine("Increiblemente, hubo un empate!\nAmbos jugadores podrán seguir participando (si siguen vivos).");
			if(Pers1.Salud < 0){
				ListaPersonajes.Remove(Pers1);
				Console.WriteLine("\n" + Pers1.Nombre + " \"" + Pers1.Apodo + "\" ya no puede continuar.");
			}
			if(Pers2.Salud < 0){
				ListaPersonajes.Remove(Pers2);
				Console.WriteLine("\n" + Pers2.Nombre + " \"" + Pers2.Apodo + "\" ya no puede continuar.");
			}
		}
	}

	static public void OtorgarMejora(Personaje Pers){
		int i = random.Next(10);

		switch(i){
			default:
				Console.WriteLine("No recibiste ninguna mejora");
			break;
			case 0:
				if(Pers.Nivel < Personaje.maxNivel){
					Console.WriteLine("Felicidades! Subiste de nivel! +1 Nivel");
					Pers.Nivel += 1;
				}else{
					Console.WriteLine("No recibiste ninguna mejora");
				}
			break;
			case 2:
			case 5:
				Console.WriteLine("Te pones una curita, tu salud se ha restablecido ligeramente. +10 Salud");
				if(Pers.Salud < Personaje.maxSalud && Pers.Salud+10 <= Personaje.maxSalud){
					Pers.Salud += 10;
				}else{
					Pers.Salud = Personaje.maxSalud;
				}
			break;
			case 3:
				Console.WriteLine("Los dioses te saludan, tu salud se ha restablecido enormemente. +25 Salud");
				if(Pers.Salud < Personaje.maxSalud && Pers.Salud+25 <= Personaje.maxSalud){
					Pers.Salud += 25;
				}else{
					Pers.Salud = Personaje.maxSalud;
				}
			break;
			case 7:
			case 9:
				Console.Write("Tu buen desempeño te ha hecho incluso mejor. ");
				int aux = random.Next(4);
				switch(aux){
					case 0:
						Console.WriteLine("+1 Fuerza");
						if(Pers.Fuerza < Personaje.maxFuerza) Pers.Fuerza += 1;
					break;
					case 1:
						Console.WriteLine("+1 Armadura");
						if(Pers.Armadura < Personaje.maxArmadura) Pers.Armadura += 1;
					break;
					case 2:
						Console.WriteLine("+1 Velocidad");
						if(Pers.Velocidad < Personaje.maxVelocidad) Pers.Velocidad += 1;
					break;
					case 3:
						Console.WriteLine("+1 Destreza");
						if(Pers.Destreza < Personaje.maxDestreza) Pers.Destreza += 1;
					break;
					default:
					break;
				}
			break;
		}
	}
}