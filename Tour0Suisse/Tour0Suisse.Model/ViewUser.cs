using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Tour0Suisse.Model
{
    public partial class ViewUser
    {
        public int IdUser { get; set; }
        public string Pseudo { get; set; }
        private  string Password { get; set; }
        public string Email { get; set; }
        public bool Organizer { get; set; }
        public DateTime? Deleted { get; set; }


        public string HexHashPassword
        {
            get
            {
                Byte[] inputBytes = Encoding.UTF8.GetBytes(Password);
                SHA512 shaM = new SHA512Managed();
                byte[] retour = shaM.ComputeHash(inputBytes);

                return "0x" + BitConverter.ToString(retour).Replace("-", "");
            }
        }

    }
}
