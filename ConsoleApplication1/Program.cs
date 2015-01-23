using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static Char SÉPARATEUR_PAR_DÉFAUT = ',';

        static void Main(string[] args)
        {
            const char DEFAULT_CHAR = default(char);
            Console.WriteLine((DEFAULT_CHAR == '\x00').ToString());
            Console.ReadKey(false);
            const int LONGUEUR = 15;
            const int HAUTEUR = 10;
            // ne doit PAS être une valeur numérique (lol)
            char SÉPARATEUR = (args.Any() ? args.First().FirstOrDefault() : SÉPARATEUR_PAR_DÉFAUT);
            uint[,] tableau = new uint[HAUTEUR,LONGUEUR];
            const string NOMDEFICHIER = "Tableau.csv";
            System.IO.StreamWriter fichierÉcriture = new System.IO.StreamWriter(NOMDEFICHIER);
            System.IO.StreamReader fichierLecture;
            // création des données
            for (uint j = 0; j < tableau.GetLength(0); j++)
                for (uint i = 0; i < tableau.GetLength(1); i++)
                    tableau[j, i] = (i + 1) * (j + 1);

            // Enregistrement des données du tableau
            for (int y = 0; y < tableau.GetLength(0); y++)
            {
                for (int x = 0; x < tableau.GetLength(1); x++)
                {
                    if (x != 0)  // Si on n'est pas le premier élément de la ligne...
                        fichierÉcriture.Write(SÉPARATEUR);

                    fichierÉcriture.Write(tableau[y,x]);
                }
                fichierÉcriture.Write(Environment.NewLine);
            }
            fichierÉcriture.Close();

            // Afficher le fichier comme un tableau dans la console
            int[,] tableauEnregistré = new int[HAUTEUR, LONGUEUR];
            fichierLecture = new System.IO.StreamReader(NOMDEFICHIER);

            for (int j = 0; j < tableau.GetLength(0); j++)
            {
                string ligne = fichierLecture.ReadLine();
                string[] éléments = ligne.Split(SÉPARATEUR);
                for (int i = 0; i < tableau.GetLength(1); i++)
                {
                    tableauEnregistré[j,i] = Convert.ToInt32(éléments[i]);
                    Console.Write(tableauEnregistré[j, i].ToString().PadRight(5));
                }
                Console.Write("\n");
            }
            Console.WriteLine("Veuillez appuyer sur touche svp.");
            Console.ReadKey();
        }
    }
}
