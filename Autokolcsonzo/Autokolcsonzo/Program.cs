using System;

namespace Kolcsonzo
{
	class Program
	{
		public static void Main(string[] args)
		{

			double egyenleg = 500000.0;

			double uzemanyagAr = 437.0; // Ft/liter

			KolcsonozhetoAuto[] flotta = new KolcsonozhetoAuto[10];

			KolcsonozhetoAuto elsoAuto =
				new KolcsonozhetoAuto("ABC-123", "Suzuki", 2020, 4, 40, 5.7, 'A');

			KolcsonozhetoAuto kettoAuto =
				new KolcsonozhetoAuto("BCD-234", "BMW", 2018, 2, 30, 3.7, 'A');

			KolcsonozhetoAuto haromAuto =
				new KolcsonozhetoAuto("CDE-345", "Toyota", 2021, 5, 36, 4.1, 'A');

			flotta[0] = elsoAuto;
			flotta[1] = kettoAuto;
			flotta[2] = haromAuto;


			flotta[3] = randomUjAuto(3);
			flotta[4] = randomUjAuto(4);
			flotta[5] = randomHasznaltAuto(5);
			flotta[6] = randomHasznaltAuto(6);
           
			flotta[7] = adatBekeres();
			
			
			
			
			for (int i = 0; i <= 8; i++)
			{

				Console.Write(flotta[i].getRendszam() + " ; ");
				Console.Write(flotta[i].getGyarto() + " ; ");
				Console.Write(flotta[i].getGyartasEve() + " ; ");
				Console.Write(flotta[i].getUtasSzam() + " ; ");
				Console.Write(flotta[i].getuzemanyagMennyiseg() + " ; ");
				Console.Write(flotta[i].getFogyasztas() + " ; ");
				Console.Write(flotta[i].getMegtettKm() + " ; ");
				Console.Write(flotta[i].getBerelheto() + " ; ");
				Console.WriteLine(flotta[i].getKategoria());
			}


			for (int i = 0; i < 7; i++)
			{
				flotta[i].kategoribeallitas();
			}

			for (int i = 0; i <= 8; i++)
			{

				Console.Write(flotta[i].getRendszam() + " ; ");
				Console.Write(flotta[i].getGyarto() + " ; ");
				Console.Write(flotta[i].getGyartasEve() + " ; ");
				Console.Write(flotta[i].getUtasSzam() + " ; ");
				Console.Write(flotta[i].getuzemanyagMennyiseg() + " ; ");
				Console.Write(flotta[i].getFogyasztas() + " ; ");
				Console.Write(flotta[i].getMegtettKm() + " ; ");
				Console.Write(flotta[i].getBerelheto() + " ; ");
				Console.WriteLine(flotta[i].getKategoria());
			}













			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}




		public static KolcsonozhetoAuto randomUjAuto(int seed)
		{

			Random gen = new Random(seed);

			string[] gyartok = {
				"Maserati",
				"Jeep",
				"Ferrari",
				"Suzuki",
				"Volvo",
				"Lada"
			};


			char[] abc = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
							'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
							'X', 'Y', 'Z'};

			string abcS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			string rszam = "";

			for (int i = 0; i < 3; i++)
			{

				rszam += abcS[gen.Next(0, abcS.Length)];
			}

			rszam = rszam + "-";

			for (int i = 0; i < 3; i++)
			{

				rszam += gen.Next(0, 10).ToString();
			}


			string marka = gyartok[gen.Next(0, gyartok.Length)];
			int ev = gen.Next(1995, 2022);
			int utasok = gen.Next(2, 10);
			int tartaly = gen.Next(20, 71);
			double lpkm = 5.5 + (11 * gen.NextDouble());
			char kat = abc[gen.Next(0, 3)];

			KolcsonozhetoAuto auto =
				new KolcsonozhetoAuto(rszam, marka, ev, utasok, tartaly, lpkm, kat);

			return auto;
		}

		public static KolcsonozhetoAuto randomHasznaltAuto(int seed)
        {
			KolcsonozhetoAuto auto = randomUjAuto(seed);

			if(auto.getGyartasEve() == 2021)
            {
				auto.setGyartasiido(auto.getGyartasEve() - 4);
            }
			auto.setMegtettKm(362000);
			return auto;
        }
		public static KolcsonozhetoAuto adatBekeres()
        {
			/*string rszam, string marka, int ev,

								 int utasok, int tartaly, double lpkm,

								  char kat)
			*/
			string rszam, ujrszam;
			bool joE = false;

			do
			{
				do
				{
					Console.WriteLine("Add meg az autó rendszámát!: ");
					Console.WriteLine("A rendszám formátuma: kkk-sss. Pl.: ABC-123");

					rszam = Console.ReadLine();

				} while (rszam.Length < 7);


				ujrszam = rszam.Substring(0, 3).ToUpper() + rszam.Substring(3, 4);

				int i = 0;
				while (ujrszam[i] >= 'A' && ujrszam[i] <= 'Z')
				{
					i++;
				}

				if (i >= 3) joE = true;

				if (ujrszam[3] != '-') joE = false;


				/*
								i = 4;
								while (ujRszam[i] >= '0' && ujRszam[i] <= '9')
								{
									i++;
								}

								if (i >= 7) joE = true;
				*/

				int szamTeszt = Convert.ToInt32(ujrszam.Substring(4, 3));

			} while (!joE);

			string marka = "";
			do
			{
				Console.WriteLine("add meg az autó márkáját :");
			}

			while ( marka.Length<3  );





			int gyev=0;
			do
			{
				Console.WriteLine("add meg az autó gyártási évét :");
				gyev = Convert.ToInt32(Console.ReadLine());
			} 
			while (1999>gyev || gyev>2021);
			int utasok = 0;
			do
			{
				Console.WriteLine("add meg az utasok számát  :");
				utasok= Convert.ToInt32(Console.ReadLine());
			}
			while (2 > utasok || utasok > 9);
			int tartaly = 0;
			do
			{
				Console.WriteLine("add meg az autó tartály méretét :");
				tartaly = Convert.ToInt32(Console.ReadLine());
			}
			while (12 > tartaly || tartaly > 32);
			double fogyasztás = 0.0;
			do
			{
				Console.WriteLine("add meg az autó fogyasztást:");
				fogyasztás = Convert.ToDouble(Console.ReadLine());
			}
			while ( 4.2 > fogyasztás || fogyasztás> 10.8 );
			char kategoria = 'Z';
			do
			{
				Console.WriteLine("add meg az autó kategoriáját:");
				Console.WriteLine("Lehetséges értékek: A, B, C");
				kategoria= (Console.ReadLine().ToUpper())[0];
			}
			while ( kategoria !='A' && kategoria !='B'  && kategoria !='C' );
			KolcsonozhetoAuto auto = new KolcsonozhetoAuto(ujrszam, marka,gyev,utasok,tartaly,fogyasztás,kategoria);
			
			return auto;
		}
		

	}
}
