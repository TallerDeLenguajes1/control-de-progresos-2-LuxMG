using System;

class Personaje{
	class Datos {
		private static string tipo;
		private static string nombre;
		private static string apodo;
		private static string fechaNac;
		private static int edad;
		private static int salud;

		public const int maxEdad = 300;
		public const int maxSalud = 100;

		public string Tipo{get; set;};
		public string Nombre{get; set;};
		public string Apodo{get; set;};
		public string FechaNac{get; set;};
		public int Edad{get; set;};
		public int Salud{get; set;};

		public Datos(string t, string n, string a, string fn, int e, int s) {
			Tipo = t;
			Nombre = n;
			Apodo = a;
			FechaNac = fn;
			Edad = e;
			Salud = s;
		}

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

		public Caracteristicas(int v, int d, int f, int n, int a) {
			Velocidad = v;
			Destreza = d;
			Fuerza = f;
			Nivel = n;
			Armadura = a;
		}

		public void MostrarCaracteristicas() {
			Console.WriteLine("Velocidad: " + Velocidad);
			Console.WriteLine("Destreza: " + Destreza);
			Console.WriteLine("Fuerza: " + Fuerza);
			Console.WriteLine("Nivel: " + Nivel);
			Console.WriteLine("Armadura: " + Armadura);
		}
	}
}