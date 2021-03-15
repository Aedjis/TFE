namespace Tour0Suisse.Model
{
    public class Jeu
    {

        public Jeu(int ID, string Nom)
        {
            _Nom = Nom;
            _ID = ID;
        }


        private int _ID;

        public int ID
        {
            get => _ID;
            set => _ID = value;
        }

        private string _Nom;

        public string Nom
        {
            get => _Nom;
            set => _Nom = value;
        }

    }
}