using System;
using System.Collections.Generic;

namespace Tour0Suisse.Repository
{
    public partial class ViewDeletedUser
    {
        public int IdUser { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public bool Organizer { get; set; }
    }
}
