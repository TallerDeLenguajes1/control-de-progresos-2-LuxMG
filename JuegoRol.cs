using System;

class Personaje{
	class Datos {
		private static string tipo;
		private static string nombre;
		private static string apodo;
		private static DateTime fechaNac;
		private static int edad;
		private static int salud;

		public const int maxEdad = 300;
		public const int maxSalud = 100;

		public string Tipo{get; set;};
		public string Nombre{get; set;};
		public string Apodo{get; set;};
		public DateTime FechaNac{get; set;};
		public int Edad{get; set;};
		public int Salud{get; set;};

		public void MostrarDatos() {
			Console.WriteLine("Tipo: " + Tipo);
			Console.WriteLine("Nombre: " + Nombre);
			Console.WriteLine("Apodo: " + Apodo);
			Console.WriteLine("Fecha de Nacimiento: " + FechaNac);
			Console.WriteLine("Edad: " + Edad);
			Console.WriteLine("Salud: " + Salud);
		}
	}

	class Caracteristicas {
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

		public int Velocidad{get; set;};
		public int Destreza{get; set;};
		public int Fuerza{get; set;};
		public int Nivel{get; set;};
		public int Armadura{get; set;};

		public void MostrarCaracteristicas() {
			Console.WriteLine("Velocidad: " + Velocidad);
			Console.WriteLine("Destreza: " + Destreza);
			Console.WriteLine("Fuerza: " + Fuerza);
			Console.WriteLine("Nivel: " + Nivel);
			Console.WriteLine("Armadura: " + Armadura);
		}
	}

	public Personaje(string tipo, string nombre, string apodo, DateTime fechanac){
		Random random = new Random(Environment.TickCount);
		Caracteristicas.Velocidad = random.Next(Caracteristicas.maxVelocidad) + 1;
		Caracteristicas.Destreza = random.Next(Caracteristicas.maxDestreza) + 1;
		Caracteristicas.Fuerza = random.Next(Caracteristicas.maxFuerza) + 1;
		Caracteristicas.Nivel = random.Next(Caracteristicas.maxNivel) + 1;
		Caracteristicas.Armadura = random.Next(Caracteristicas.maxArmadura) + 1;

		Datos.Tipo = tipo;
		Datos.Nombre = nombre;
		Datos.Apodo = apodo;
		Datos.FechaNac = fechanac;
		Datos.Edad = CalcularEdad(fechanac);
		Datos.Salud = random.Next(Datos.maxSalud + 1);
	}
}