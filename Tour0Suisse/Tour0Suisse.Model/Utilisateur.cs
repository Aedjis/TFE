using System;
using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public partial class Utilisateur
    {

        public int IdUser { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public bool Organizer { get; set; }
        public DateTime? Deleted { get; set; }

    }
}
