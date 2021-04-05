using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Tour0Suisse.Model
{
    public class Utilisateur : IViewUser
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
        [Display(Name = "Organise des tournois")]
        public bool Organizer { get; set; }
        [Display(Name = "Date de supression de l'utilisateur")]
        public DateTime? Deleted { get; set; }

        [Display(Name = "Liste des pseudo en jeu")]
        public List<ViewPseudo> PseudoIgs { get; set; }
        [Display(Name = "Liste des resultas")]
        public List<ViewResulta> Resultas { get; set; }




        private byte[] _Password;


        [Display(Name = "Mot de passe")]
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
                return "0x" + BitConverter.ToString(_Password).Replace("-", ""); 
            }
        }

        public byte[] BinaryPassword
        {
            get => _Password;

            set => _Password = value;
        }

        private byte[] _OldPassword;


        [Display(Name = "Ancien mot de passe")]
        public string OldPassword
        {
            set
            {
                if (value != null)
                {
                    Byte[] inputBytes = Encoding.UTF8.GetBytes(value);
                    SHA512 shaM = new SHA512Managed();
                    byte[] hexa = shaM.ComputeHash(inputBytes);

                    _OldPassword = hexa;
                }
                else
                {
                    _OldPassword = null;
                }
            }

            get
            {
#warning rustine qui doit disparaitre
                return null;

            }
        }

        public string HexaOldPassword
        {
            get
            {
                if (_OldPassword == null)
                {
                    return null;
                }
                return "0x" + BitConverter.ToString(_OldPassword).Replace("-", ""); 
            }
        }

        public byte[] BinaryOldPassword => _OldPassword;
    }
}
