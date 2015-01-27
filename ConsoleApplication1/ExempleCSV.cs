using System;
using System.Collections.Generic;
using System.IO;

namespace TP1CSV
{
    class ExempleCSV
    {
        private static char SÉPARATEUR_PAR_DÉFAUT = '|';

        public void PointDEntrée(string[] args)
        {
			// declaration/initialisation
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
					Console.WriteLine(temporaire.ToString());	// Appelle temporaire.ToString() hérité de Object.ToString()
				}
			}

			//Ajout de nouveaux élèves à la liste ?
			Console.WriteLine("Voulez-vous rajouter un ou des élève(s)? (o/n)");
			if(Console.ReadLine().ToUpper()[0] == 'O')	// Oui
			{
				bool ajoutsTerminé = false;
				while(!ajoutsTerminé)
				{
					Étudiant temporaire = new Étudiant();

					Console.Write("Prénom: ");
					temporaire.Prénom = Console.ReadLine();
					Console.Write("Nom: ");
					temporaire.Nom = Console.ReadLine();
					Console.Write("DA: ");
					temporaire.DA = Console.ReadLine();
					Console.Write("Âge: ");
					temporaire.Âge = byte.Parse(Console.ReadLine());
					Console.Write("Moyenne générale: ");
					try
					{
						temporaire.MoyenneGénérale = float.Parse(Console.ReadLine());
					}
					catch (FormatException)
					{
						Console.WriteLine("Mauvais format, veuillez, s'il-vous-plait utiliser la virgule ',' et nom le point '.'\nVeuillez recommencez\nMoyenne générale");
						temporaire.MoyenneGénérale = float.Parse(Console.ReadLine());
					}
					Console.Write("Nombre d'Absence(s): ");
					temporaire.NbrAbsences = byte.Parse(Console.ReadLine());

					string nomDuCours;
					Console.Write("Nom du cours à ajouter (vide si aucun autre cours): ");
					while((nomDuCours=Console.ReadLine())!="")
					{
						temporaire.ListeCours.Add(nomDuCours);
						Console.Write("Nom du cours à ajouter (vide si aucun autre cours): ");
					}

					listeÉtudiants.Add(temporaire);
					Console.WriteLine("Ajout de l'Étudiant " + temporaire.Prénom + ' ' + temporaire.Nom + " (" + temporaire.DA + ") terminé!");
					Console.WriteLine("Voulez-vous ajouter un autre élève? (o/n)");
					if (Console.ReadLine().ToUpper()[0] != 'O')	// Non
						ajoutsTerminé = true;
				}
			}

			Console.WriteLine("Sauvegarde des données des Étudiants...");

			// Écriture des données dans le fichier CSV
			fichierÉcriture = new StreamWriter(nomDeFichier, false);	// Ouvre le fichier, mais efface son contenu, on repart a neuf

			foreach(Étudiant enCours in listeÉtudiants)
				fichierÉcriture.WriteLine(enCours.EnregistrerCSV('|'));

			fichierÉcriture.Flush();
			fichierÉcriture.Close();

			Console.WriteLine("Sauvegarde terminée!\nL'application va maintenant quitter");
			Console.ReadKey(false);
        }
    }
}
