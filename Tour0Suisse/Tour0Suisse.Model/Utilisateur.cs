using System.Collections.Generic;

namespace Tour0Suisse.Model
{
    public class Utilisateur
    {
        public Utilisateur(int ID, string Pseudo, string Email, bool Orga = false)
        {
            _ID = ID;
            _Pseudo = Pseudo;
            _Email = Email;
            _Orga = Orga;
        }

        private int _ID;

        public int ID
        {
            get => _ID;
            set => _ID = value;
        }

        private string _Pseudo;

        public string Pseudo
        {
            get => _Pseudo;
            set => _Pseudo = value;
        }

        private string _Email;

        public string Email
        {
            get => _Email;
            set => _Email = value;
        }

        private bool _Orga;

        public bool Orga
        {
            get => _Orga;
            set => _Orga = value;
        }

        private Dictionary<int, string> _IGPseudo;

        public Dictionary<int, string> IGPseudo
        {
            get => _IGPseudo;
            set => _IGPseudo = value;
        }


    }
}