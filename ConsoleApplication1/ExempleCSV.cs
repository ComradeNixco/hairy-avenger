using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP1CSV
{
    class ExempleCSV
    {
        private static char SÉPARATEUR_PAR_DÉFAUT = '|';

        public void PointDEntrée(string[] args)
        {
			// declaration/initialisation
			bool ajoutsTerminé = false;
			const string nomDeFichier = "ListeDÉtudiants.csv";
			List<string> lignesCSV = new List<string>();
			List<Étudiant> listeÉtudiants = new List<Étudiant>();
			StreamReader fichierLecture = new StreamReader(nomDeFichier);
			StreamWriter fichierÉcriture;

			// Lecture du fichier
			while(!fichierLecture.EndOfStream)
				lignesCSV.Add(fichierLecture.ReadLine());
			fichierLecture.Close();

			// onstruction de la liste et Affichage
			if(lignesCSV.Count == 0 || (lignesCSV.Count == 1 && lignesCSV[0].Split(SÉPARATEUR_PAR_DÉFAUT).Length < 2))
			{
				Console.WriteLine("ERREUR: le fichier \"" + nomDeFichier + "\" est vide!\nRien à afficher!");
				Console.ReadKey(true);
			}
			else
			{
				Console.WriteLine("Liste d'étudiant(s): ");
				foreach (string ligne in lignesCSV)
				{
					Étudiant temporaire = new Étudiant();

					temporaire.ChargerCSV(ligne, SÉPARATEUR_PAR_DÉFAUT);
					listeÉtudiants.Add(temporaire);
					Console.WriteLine(temporaire);	// Appelle temporaire.ToString() hérité de Object.ToString()
				}
			}

			//Ajout de nouveaux élèves à la liste ?
			Console.WriteLine("Voulez-vous rajouter un ou des élève(s)? (o/n)");
			if(Console.ReadLine().ToUpper()[0] == 'O')	// Oui
			{
				while(!ajoutsTerminé)
				{
					Étudiant temporaire = new Étudiant();
					string ligne = "";

					Console.Write("Prénom: ");
					temporaire.Prénom = Console.ReadLine();
					Console.Write("Nom: ");
					temporaire.Nom = Console.ReadLine();
					Console.Write("DA: ");
					temporaire.DA = Console.ReadLine();
					Console.Write("Âge: ");
					temporaire.Âge = byte.Parse(Console.ReadLine());
					Console.Write("Moyenne générale: ");
					temporaire.MoyenneGénérale = float.Parse(Console.ReadLine());
					Console.Write("Nombre d'Absence(s): ");
					temporaire.NbrAbsences = byte.Parse(Console.ReadLine());

					string nomDuCours;
					Console.Write("Nom du cours à ajouter (vide si aucun autre cours): ");
					while((nomDuCours=Console.ReadLine())!="")
					{
						temporaire.ListeCours.Add(nomDuCours);
						Console.Write("Nom du cours à ajouter (vide si aucun autre cours): ");
					}

					Console.WriteLine("Ajout de l'Étudiant " + temporaire.Prénom + ' ' + temporaire.Nom + " (" + temporaire.DA + ") terminé!");
					Console.WriteLine("Voulez-vous ajouter un autre élève? (o/n)");
					if (Console.ReadLine().ToUpper()[0] != 'O')	// Non
						ajoutsTerminé = true;
				}
			}
        }
    }
}
