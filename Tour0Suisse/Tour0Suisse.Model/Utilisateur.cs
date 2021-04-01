using System;
using System.Collections.Generic;
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
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public bool Organizer { get; set; }
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

        public List<ViewPseudo> PseudoIgs { get; set; }
        public List<ViewResulta> Resultas { get; set; }

    }
}
