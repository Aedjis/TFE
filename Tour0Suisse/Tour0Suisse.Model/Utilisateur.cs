using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Tour0Suisse.Model
{
    public partial class Utilisateur
    {

        public int IdUser { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public bool Organizer { get; set; }
        public DateTime? Deleted { get; set; }


        private string _hexaPassword;

        public string Password
        {
            set
            {
                Byte[] inputBytes = Encoding.UTF8.GetBytes(value);
                SHA512 shaM = new SHA512Managed();
                byte[] hexa = shaM.ComputeHash(inputBytes);

                _hexaPassword = "0x" + BitConverter.ToString(hexa).Replace("-", "");
            }
        }

        public string HexaPassword
        {
            get
            {
                return _hexaPassword;
            }
            set
            {
                _hexaPassword = value;
            }
        }

        public List<ViewPseudo> PseudoIgs { get; set; }
        public List<ViewResulta> Resultas { get; set; }

    }
}
