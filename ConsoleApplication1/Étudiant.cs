using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1CSV
{
	/// <summary>
	/// Définit un étudiant
	/// </summary>
	public class Étudiant
	{
		#region Champs

		private string _prénom;
		private string _nom;
		private string _DA;
		private byte _âge;
		private float _moyenneGénérale;
		private byte _nbrAbsences;
		private List<string> _listeCours;

		#endregion

		#region Constructeurs/Déstructeurs
		/// <summary>
		/// Constructeur par défaut
		/// </summary>
		public Étudiant()
		{
			_prénom = _nom = _DA = "";
			_âge = _nbrAbsences = 0;
			_moyenneGénérale = 0.0f;

			_listeCours = new List<string>();
		}
		/// <summary>
		/// COnstructeur à données connus
		/// </summary>
		/// <param name="prénom"></param>
		/// <param name="nom"></param>
		/// <param name="DA"></param>
		/// <param name="âge"></param>
		/// <param name="moyenneGénérale"></param>
		/// <param name="nbrAbsences"></param>
		/// <param name="listeCours"></param>
		public Étudiant(string prénom, string nom, string DA, byte âge, float moyenneGénérale, byte nbrAbsences, List<string> listeCours)
		{
			_prénom = prénom; _nom = nom; _DA = DA;
			_âge = âge; _nbrAbsences = nbrAbsences;
			_moyenneGénérale = moyenneGénérale;
			_listeCours = listeCours;
		}

		#endregion

		#region Propriétés

		public string Prénom
		{
			get { return _prénom; }
			set { _prénom = value; }
		}
		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}
		public string DA
		{
			get { return _DA; }
			set { _DA = value; }
		}
		public byte Âge
		{
			get { return _âge; }
			set { _âge = value; }
		}
		public float MoyenneGénérale
		{
			get { return _moyenneGénérale; }
			set { _moyenneGénérale = value; }
		}
		public byte NbrAbsences
		{
			get { return _nbrAbsences; }
			set { _nbrAbsences = value; }
		}
		public int NbrCours
		{
			get { return _listeCours.Count; }
		}
		public List<string> ListeCours
		{
			get { return _listeCours; }
			set { _listeCours = value; }
		}

		#endregion

		#region Méthodes
		
		/// <summary>
		/// Obtient la ligne CSV contenant les données de la classe
		/// </summary>
		/// <param name="séparateur">Le séparateur à utilisé</param>
		/// <returns>La ligne CSV à enregistrer</returns>
		public string EnregistrerCSV(char séparateur = '|')
		{
			string ligneCSV = "";

			ligneCSV += _prénom + séparateur + _nom + séparateur + _DA + séparateur + _âge + séparateur + _moyenneGénérale + séparateur + _nbrAbsences;
			foreach (string cour in _listeCours)
			{
				ligneCSV += séparateur + cour;
			}

			return ligneCSV;
		}
		/// <summary>
		/// Remplit l'objet avec les données de la ligne CSV
		/// </summary>
		/// <param name="ligneCSV">Ligne contenant les données</param>
		/// <param name="séparateur">Le séparateur utilisé pour sépararer chacune des données</param>
		public void ChargerCSV(string ligneCSV, char séparateur = '|')
		{
			string[] éléments = ligneCSV.Split(séparateur);

			_prénom = éléments[0];
			_nom = éléments[1];
			_DA = éléments[2];
			_âge = Convert.ToByte(éléments[3]);
			_moyenneGénérale = float.Parse(éléments[4]);
			_nbrAbsences = Convert.ToByte(éléments[5]);
			_listeCours = new List<string>();

			for(int i = 6; i < éléments.Length; i++)
				_listeCours.Add(éléments[i]);
		}
		/// <summary>
		/// Permet d'obtenir la version string de l'objet, affiche tout sons contenue sans retour de lignes
		/// </summary>
		/// <returns>la valeur dce type string représentant l'objet</returns>
		public override string ToString()
		{
			string valeur = "";
			valeur += "Prénom et nom: " + Prénom + ' ' + Nom + "; DA: " + DA + "; âge: " + Âge;
			valeur += " moyenne générale: " + MoyenneGénérale + "; Nombre d'absence(s):	" + NbrAbsences;
			valeur += "; Liste de cour(s): ";

			for (int i = 0; i < _listeCours.Count; i++)
			{
				if (i != 0)
					valeur += ", ";

				valeur += _listeCours[i];
			}

			return valeur;
		}
		#endregion
	}
}
