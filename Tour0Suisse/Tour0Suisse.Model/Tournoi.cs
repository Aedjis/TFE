using System;

namespace Tour0Suisse.Model
{
    public class Tournoi
    {
        public Tournoi( int ID, string Nom, DateTime Date, string Description, Jeu Game, int NombreDeck, int PpWin = 2, int PpDraw = 1, int PpLose = 0, bool Over = false)
        {
            _ID = ID;
            _Date = Date;
            _Description = Description;
            _Game = Game;
            _NombreDeck = NombreDeck;
            _PPWin = PpWin;
            _PPDraw = PpDraw;
            _PPLose = PpLose;
            _Over = Over;
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

        private DateTime _Date;

        public DateTime Date
        {
            get => _Date;
            set => _Date = value;
        }

        private string _Description;

        public string Description
        {
            get => _Description;
            set => _Description = value;
        }

        private Jeu _Game;

        public Jeu Game
        {
            get => _Game;
            set => _Game = value;
        }

        private int _PPWin;

        public int PPWin
        {
            get => _PPWin;
            set => _PPWin = value;
        }

        private int _PPLose;

        public int PPLose
        {
            get => _PPLose;
            set => _PPLose = value;
        }

        private int _PPDraw;

        public int PPDraw
        {
            get => _PPDraw;
            set => _PPDraw = value;
        }

        private bool _Over;

        public bool Over
        {
            get => _Over;
            set => _Over = value;
        }

        private int _NombreDeck;

        public int NombreDeck
        {
            get => _NombreDeck;
            set => _NombreDeck = value;
        }

    }
}