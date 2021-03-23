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
        public string Password { get; set; }

        public byte[] HashPassword
        {
            get
            {
                Byte[] inputBytes = Encoding.UTF8.GetBytes(Password);
                SHA512 shaM = new SHA512Managed();
                byte[] retour = shaM.ComputeHash(inputBytes);
                return retour;
            }
        }

        public bool Organizer { get; set; }
        public DateTime? Deleted { get; set; }

    }
}
