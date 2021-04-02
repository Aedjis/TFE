using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Tour0Suisse.Model
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            PseudoIgs = new List<ViewPseudo>();
            Resultas = new List<ViewResulta>();
        }
        public int IdUser { get; set; }
        [Display(Name = "Nom")]
        public string Pseudo { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Organise des tournoi")]
        public bool Organizer { get; set; }
        [Display(Name = "Date de supression de l'utilisateur")]
        public DateTime? Deleted { get; set; }


        private byte[] _Password;

        public string Password
        {
            set
            {
                if (value != null)
                {
                    Byte[] inputBytes = Encoding.UTF8.GetBytes(value);
                    SHA512 shaM = new SHA512Managed();
                    byte[] hexa = shaM.ComputeHash(inputBytes);

                    _Password = hexa;
                }
                else
                {
                    _Password = null;
                }
            }

            get
            {
#warning rustine qui doit disparaitre
                return null;

            }
        }

        public string HexaPassword
        {
            get
            {
                if (_Password == null)
                {
                    return null;
                }
                return "0x" + BitConverter.ToString(_Password).Replace("-", ""); ;
            }
        }

        public byte[] BinaryPassword
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        [Display(Name = "Liste des pseudo en jeu")]
        public List<ViewPseudo> PseudoIgs { get; set; }
        [Display(Name = "Liste des resultas")]
        public List<ViewResulta> Resultas { get; set; }

    }
}
