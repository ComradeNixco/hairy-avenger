using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	/// <summary>
	/// Définit un étudiant
	/// </summary>
	private class Étudiant
	{
		#region Champs

		private string _prénom;
		private string _nom;
		private string _DA;
		private byte _âge;
		private float _moyenneGénérale;
		private byte _nbrAbsences;
		private List<string> listeCours;

		#endregion

		#region Constructeurs/Déstructeurs
		/// <summary>
		/// Constructeur par défaut
		/// </summary>
		Étudiant()
		{

		}

		#endregion
	}
}
