﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Tour0Suisse.Model;

namespace Tour0Suisse.Repository
{
    public class DBTour0SuisseLINQ
    {
        private readonly string _ConnectionString;

        public DBTour0SuisseLINQ(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }


        public List<ViewUser> ViewUsers()
        {
            return _ViewUsers();
        }

        public ViewUser GetUser(int Id)
        {
            ViewUser Retour = null;


            List<ViewUser> User = _ViewUsers("WHERE ID_User = " + Id);
            if (User.Count == 1) Retour = User.First();

            return Retour;
        }

        public ViewUser LogIn(string Email, string Password)
        {
            List<ViewUser> User = _ViewUsers("WHERE  Email = '" + Email + "' AND [Password] = " + Password)
                .Where(u => u.Deleted == null).ToList();
            if (User.Count == 1)
                return User.First();
            return new ViewUser {IdUser = -1};
        }

        private List<ViewUser> _ViewUsers(string Where = "")
        {
            List<ViewUser> Retour = new List<ViewUser>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_User, Pseudo, Email, Organizer, DELETED FROM [View_User] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Retour.Add(new ViewUser
                    {
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        Pseudo = reader["Pseudo"].ToString(),
                        Email = reader["Email"].ToString(),
                        Organizer = bool.Parse(reader["Organizer"].ToString()),
                        Deleted = DateTime.TryParse(reader["DELETED"].ToString(), out DateTime temp) ? temp : (DateTime?) null
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }

        public List<ViewDotation> ViewDotations()
        {
            return _ViewDotations();
        }

        public List<ViewDotation> GetDotationsOf(int Id)
        {
            return _ViewDotations("WHERE ID_Tournament = " + Id);
        }

        private List<ViewDotation> _ViewDotations(string Where = "")
        {
            List<ViewDotation> Retour = new List<ViewDotation>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_Tournament, [Name], Place, Gain FROM [View_Dotation] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                    Retour.Add(new ViewDotation
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        Place = int.Parse(reader["Place"].ToString()),
                        Gain = int.Parse(reader["Gain"].ToString())
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }

        public List<ViewTournament> ViewTournaments()
        {
            return _ViewTournaments();
        }

        public List<ViewTournament> ViewTournaments(IEnumerable<int> IdEnmu)
        {
            string listeId = string.Join(", ", IdEnmu);

            return _ViewTournaments("WHERE ID_Tournament in (" + listeId + ")");
        }

        public ViewTournament GetTournament(int Id)
        {
            return _ViewTournaments("WHERE ID_Tournament = " + Id).FirstOrDefault();
        }

        private List<ViewTournament> _ViewTournaments(string Where = "")
        {
            List<ViewTournament> Retour = new List<ViewTournament>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT ID_Tournament, [Name], ID_Game, [Game], Description, [Date], [MaxNumberPlayer], [DeckListNumber], [PPWin], [PPDraw], [PPLose], [Over], [Deleted] FROM [View_Tournament] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                    Retour.Add(new ViewTournament
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        IdGame = int.Parse(reader["ID_Game"].ToString()),
                        Name = reader["Name"].ToString(),
                        Game = reader["Game"].ToString(),
                        Date = DateTime.Parse(reader["Date"].ToString()),
                        MaxNumberPlayer = int.TryParse(reader["MaxNumberPlayer"].ToString(), out int o)
                            ? o
                            : (int?) null,
                        DeckListNumber = int.Parse(reader["DeckListNumber"].ToString()),
                        Ppwin = int.Parse(reader["PPWin"].ToString()),
                        Ppdraw = int.Parse(reader["PPDraw"].ToString()),
                        Pplose = int.Parse(reader["PPLose"].ToString()),
                        Description = reader["Description"].ToString(),
                        Over = bool.Parse(reader["Over"].ToString()),
                        Deleted = DateTime.TryParse(reader["Deleted"].ToString(), out DateTime d)? d:(DateTime?)null
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }

        public List<ViewPseudo> ViewPseudos()
        {
            return _ViewPseudos();
        }

        public List<ViewPseudo> GetPseudosUser(int IdUser)
        {
            return _ViewPseudos("WHERE ID_User = " + IdUser);
        }

        private List<ViewPseudo> _ViewPseudos(string Where = "")
        {
            List<ViewPseudo> Retour = new List<ViewPseudo>();

            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_User, ID_Game, Game, IG_Pseudo FROM [View_Pseudo] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                    Retour.Add(new ViewPseudo
                    {
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        IdGame = int.Parse(reader["ID_Game"].ToString()),
                        Game = reader["Game"].ToString(),
                        IgPseudo = reader["IG_Pseudo"].ToString()
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewOrga> ViewOrgas()
        {
            return _ViewOrgas();
        }

        public List<ViewOrga> ViewIdWhereOrgas(int id)
        {
            return _ViewOrgas("WHERE ID_User = " + id.ToString());
        }

        public List<ViewOrga> GetOrgasOf(int idTournoi)
        {
            return _ViewOrgas("WHERE ID_Tournament = " + idTournoi);
        }

        private List<ViewOrga> _ViewOrgas(string Where = "")
        {
            List<ViewOrga> Retour = new List<ViewOrga>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_Tournament, Name, ID_User, Pseudo, Level FROM [View_Orga] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                    Retour.Add(new ViewOrga
                    {
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        Pseudo = reader["Pseudo"].ToString(),
                        Level = int.Parse(reader["Level"].ToString())
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewParticipant> ViewParticipants()
        {
            return _ViewParticipants();
        }

        public List<ViewParticipant> GetParticipantsOf(int IdTournoi)
        {
            return _ViewParticipants("WHERE ID_Tournament = " + IdTournoi);
        }

        public ViewParticipant GetParticipant(int IDParticipant, int IdTournoi)
        {
            return _ViewParticipants("WHERE ID_Tournament = " + IdTournoi + "AND ID_User = " + IDParticipant)
                .FirstOrDefault();
        }

        private List<ViewParticipant> _ViewParticipants(string Where = "")
        {
            List<ViewParticipant> Retour = new List<ViewParticipant>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT ID_Tournament, Name, ID_User, Pseudo, IG_Pseudo, RegisterDate, CheckIn, [Drop] FROM [View_Participant] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Retour.Add(new ViewParticipant
                    {
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString(),
                        RegisterDate = DateTime.Parse(reader["RegisterDate"].ToString()),
                        CheckIn = DateTime.TryParse(reader["CheckIn"].ToString(), out DateTime temp) ? temp : (DateTime?) null,
                        Drop = bool.Parse(reader["Drop"].ToString())
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewResulta> ViewResultas()
        {
            return _ViewResultas();
        }

        public List<ViewResulta> GetResultasOfTournament(int IdTournament)
        {
            return _ViewResultas("WHERE ID_Tournament = " + IdTournament);
        }

        public List<ViewResulta> GetResultasOfUser(int IdUser)
        {
            return _ViewResultas("WHERE ID_User = " + IdUser);
        }

        private List<ViewResulta> _ViewResultas(string Where = "")
        {
            List<ViewResulta> Retour = new List<ViewResulta>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT ID_Tournament, Name, ID_User, Pseudo, IG_Pseudo, Rank, Gain, Score, TieBreaker, AdditionalTieBreaker, AdditionalTieBreakerRules From [View_Resulta] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Retour.Add(new ViewResulta
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        AdditionalTieBreaker = int.TryParse(reader["AdditionalTieBreaker"].ToString(), out int temp)
                            ? temp
                            : (int?) null,
                        AdditionalTieBreakerRules = reader["AdditionalTieBreakerRules"].ToString(),
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        Name = reader["Name"].ToString(),
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString(),
                        Gain = int.Parse(reader["Gain"].ToString()),
                        Rank = int.Parse(reader["Rank"].ToString()),
                        Score = int.Parse(reader["Score"].ToString()),
                        TieBreaker = int.Parse(reader["TieBreaker"].ToString())
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewPartie> ViewParties()
        {
            return _ViewParties();
        }

        public List<ViewPartie> ViewPartiesOfMatch(int IdTournoi, int IdPlayer, int RoundNumber = -1)
        {
            string WhereRound = RoundNumber > 0 ? RoundNumber.ToString() : WhereTopRoundOfTournament(IdTournoi);

            return _ViewParties("WHERE ID_Tournament = " + IdTournoi + "AND (ID_PlayerOne = " +
                                IdPlayer + " OR ID_PlayerTwo = " + IdPlayer +
                                " ) AND RoundNumber = " + WhereRound);
        }

        public ViewPartie ViewPartieOfMatch(int IdTournoi, int IdPlayer, int PartNumber = -1, int RoundNumber = -1)
        {
            string WhereRound = RoundNumber > 0 ? RoundNumber.ToString() : WhereTopRoundOfTournament(IdTournoi);
            string WherePart = PartNumber > 0 ? PartNumber.ToString() : WhereTopPart(IdTournoi, IdPlayer, RoundNumber);

            return _ViewParties("WHERE ID_Tournament = " + IdTournoi + "AND (ID_PlayerOne = " +
                                IdPlayer + " OR ID_PlayerTwo = " + IdPlayer +
                                " ) AND RoundNumber = " + WhereRound + "AND PartNumber = " + WherePart)
                .FirstOrDefault();
        }

        private string WhereTopPart(int IdTournoi, int IdPlayer, int RoundNumber)
        {
            string WherePart = "( SELECT max(PartNumber) FROM [View_Partie] WHERE ID_Tournament = " + IdTournoi +
                               "AND (ID_PlayerOne = " +
                               IdPlayer + " OR ID_PlayerTwo = " + IdPlayer +
                               " ) AND RoundNumber = " + RoundNumber + ")";
            return WherePart;
        }

        private List<ViewPartie> _ViewParties(string Where = "")
        {
            List<ViewPartie> Retour = new List<ViewPartie>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT [ID_Tournament], [Name], [RoundNumber], [PartNumber], [ResultPart], [ID_PlayerOne], [IGPseudoOne], [PlayerOne], [ID_Deck_PlayerOne], [DeckOne], [ID_PlayerTwo], [IGPseudoTwo], [PlayerTwo], [ID_Deck_PlayerTwo], [DeckTwo] From [View_Partie] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Retour.Add(new ViewPartie
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        PartNumber = int.Parse(reader["PartNumber"].ToString()),
                        ResultPart = byte.TryParse(reader["ResultPart"].ToString(), out byte temp) ? temp : (byte?) null,
                        IdPlayer1 = int.Parse(reader["ID_PlayerOne"].ToString()),
                        Player1 = reader["PlayerOne"].ToString(),
                        IGPseudo1 = reader["IGPseudoOne"].ToString(),
                        IdDeckPlayer1 = int.Parse(reader["ID_Deck_PlayerOne"].ToString()),
                        Deck1 = reader["DeckOne"].ToString(),
                        IdPlayer2 = int.Parse(reader["ID_PlayerTwo"].ToString()),
                        Player2 = reader["PlayerTwo"].ToString(),
                        IGPseudo2 = reader["IGPseudoTwo"].ToString(),
                        IdDeckPlayer2 = int.Parse(reader["ID_Deck_PlayerOne"].ToString()),
                        Deck2 = reader["DeckTwo"].ToString()
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewDeck> ViewDecks()
        {
            return _viewDecks();
        }

        public List<ViewDeck> GetDecksOfTournament(int Idtournament)
        {
            return _viewDecks("WHERE ID_Tournament = " + Idtournament);
        }

        public List<ViewDeck> GetDecksOfParticipant(int Idtournament, int IdUser)
        {
            return _viewDecks("WHERE ID_Tournament = " + Idtournament + " AND ID_User = " + IdUser);
        }

        private List<ViewDeck> _viewDecks(string Where = "")
        {
            List<ViewDeck> Retour = new List<ViewDeck>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT ID_Tournament, Name, ID_User, Pseudo, ID_Deck, DeckList, ID_Game, Game From [View_Deck] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                    Retour.Add(new ViewDeck
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        Pseudo = reader["Pseudo"].ToString(),
                        IdDeck = int.Parse(reader["ID_Deck"].ToString()),
                        DeckList = reader["DeckList"].ToString(),
                        IdGame = int.Parse(reader["ID_Game"].ToString()),
                        Game = reader["Game"].ToString()
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewResultPartPlayer> ViewResultPartPlayers()
        {
            return _viewResultPartPlayers();
        }

        private List<ViewResultPartPlayer> _viewResultPartPlayers(string Where = "")
        {
            List<ViewResultPartPlayer> Retour = new List<ViewResultPartPlayer>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT ID_Tournament, RoundNumber, PartNumber, ID_Player, Pseudo, IG_Pseudo, Resulta From [View_ResultPartPlayer] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Retour.Add(new ViewResultPartPlayer
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        PartNumber = int.Parse(reader["PartNumber"].ToString()),
                        IdPlayer = int.Parse(reader["ID_Player"].ToString()),
                        Resulta = int.TryParse(reader["Resulta"].ToString(), out int temp) ? temp : (int?) null,
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString()
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewMatch> ViewMatches()
        {
            return _viewMatches();
        }

        public List<ViewMatch> GetMatchesOf(int IdTournoi)
        {
            return _viewMatches("WHERE ID_Tournament = " + IdTournoi);
        }

        public List<ViewMatch> GetMatchesOfTheRound(int IdTournoi, int IdRound = -1)
        {
            string WhereRound = IdRound < 0 ? IdRound.ToString() : WhereTopRoundOfTournament(IdTournoi);


            return _viewMatches("WHERE ID_Tournament = " + IdTournoi + " AND RoundNumber = " + WhereRound);
        }

        public Match GetMatcheForPlayerOfTheRound(int IdTournoi, int IdPlayer, int IdRound = -1)
        {
            string WhereRound = IdRound > 0 ? IdRound.ToString() : WhereTopRoundOfTournament(IdTournoi);


            var m = _viewMatches("WHERE ID_Tournament = " + IdTournoi + "AND (ID_PlayerOne = " +
                                IdPlayer + " OR ID_PlayerTwo = " + IdPlayer +
                                " ) AND RoundNumber = " + WhereRound).FirstOrDefault();

            if (m != null)
            {
                Match retour = new Match
                {
                    Tournament = GetTournament(m.IdTournament),
                    RoundNumber = m.RoundNumber,
                    P1 = GetParticipant(m.IdPlayer1, m.IdTournament),
                    P2 = GetParticipant(m.IdPlayer2, m.IdTournament),
                    Parties = ViewPartiesOfMatch(m.IdTournament, m.IdPlayer1, m.RoundNumber)
                };
                return retour;
            }
            else
            {
                return new Match();
            }
        }

        private string WhereTopRoundOfTournament(int IdTournoi)
        {
            string WhereRound = "( SELECT max(RoundNumber) FROM [View_Match] WHERE ID_Tournament = " +
                                IdTournoi + ")";
            return WhereRound;
        }


        private List<ViewMatch> _viewMatches(string Where = "")
        {
            List<ViewMatch> Retour = new List<ViewMatch>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT [ID_Tournament], [RoundNumber], [ID_PlayerOne], [PlayerOne], [PseudoPlayerOne], [ID_PlayerTwo], [PlayerTwo], [PseudoPlayerTwo], ResultP1, ResultDraw, ResultP2 From [View_Match] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                    Retour.Add(new ViewMatch
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        IdPlayer1 = int.Parse(reader["ID_PlayerOne"].ToString()),
                        Player1 = reader["PlayerOne"].ToString(),
                        Pseudo1 = reader["PseudoPlayerOne"].ToString(),
                        IdPlayer2 = int.Parse(reader["ID_PlayerTwo"].ToString()),
                        Player2 = reader["PlayerTwo"].ToString(),
                        Pseudo2 = reader["PseudoPlayerTwo"].ToString(), 
                        VP1 = int.TryParse(reader["ResultP1"].ToString(), out int vp1)? vp1:0,
                        Draw = int.TryParse(reader["ResultDraw"].ToString(), out int draw) ? draw : 0,
                        VP2 = int.TryParse(reader["ResultP2"].ToString(), out int vp2) ? vp2 : 0
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewJeu> ViewJeus()
        {
            return _viewJeus();
        }

        public ViewJeu GetJeu(int id)
        {
            return _viewJeus("WHERE ID_Game = " + id).FirstOrDefault();
        }

        private List<ViewJeu> _viewJeus(string Where = "")
        {
            List<ViewJeu> Retour = new List<ViewJeu>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT  ID_Game, [Name] From [View_Jeu] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                    Retour.Add(new ViewJeu
                    {
                        IdGame = int.Parse(reader["ID_Game"].ToString()),
                        Name = reader["Name"].ToString()
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewResultMatchPlayer> ViewResultMatchPlayers()
        {
            return _viewResultMatchPlayers();
        }

        private List<ViewResultMatchPlayer> _viewResultMatchPlayers(string Where = "")
        {
            List<ViewResultMatchPlayer> Retour = new List<ViewResultMatchPlayer>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT  ID_Tournament, RoundNumber, ID_Player, Pseudo, IG_Pseudo, Resulta From [View_ResultMatchPlayer] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Retour.Add(new ViewResultMatchPlayer
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        IdPlayer = int.Parse(reader["ID_Player"].ToString()),
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString(),
                        Resulta = int.TryParse(reader["Resulta"].ToString(), out int temp) ? temp : (int?) null
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewClassementTemporaire> ViewClassementTemporaires()
        {
            return _viewClassementTemporaires();
        }

        private List<ViewClassementTemporaire> _viewClassementTemporaires(string Where = "")
        {
            List<ViewClassementTemporaire> Retour = new List<ViewClassementTemporaire>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT ID_Tournament, ID_Player, Pseudo, IG_Pseudo, Victoire, Egaliter, Defaite From [View_ClassementTemporaire] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                    Retour.Add(new ViewClassementTemporaire
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        IdPlayer = int.Parse(reader["ID_Player"].ToString()),
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString(),
                        Victoire = int.Parse(reader["Victoire"].ToString()),
                        Egaliter = int.Parse(reader["Egaliter"].ToString()),
                        Defaite = int.Parse(reader["Defaite"].ToString())
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewScoreClassementTemporaire> ViewScoreClassementTemporaires()
        {
            return _viewScoreClassementTemporaires();
        }

        public List<ViewScoreClassementTemporaire> GetScoreClassementTemporairesOfTournamnent(int IdTournamnet)
        {
            return _viewScoreClassementTemporaires("WHERE ID_Tournament = " + IdTournamnet);
        }

        private List<ViewScoreClassementTemporaire> _viewScoreClassementTemporaires(string Where = "")
        {
            List<ViewScoreClassementTemporaire> Retour = new List<ViewScoreClassementTemporaire>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry =
                    "SELECT ID_Tournament, Name, ID_Player, Pseudo, IG_Pseudo, Score, Victoire, Egaliter, Defaite From [View_ScoreClassementTemporaire] " +
                    Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                    Retour.Add(new ViewScoreClassementTemporaire
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        IdUser = int.Parse(reader["ID_Player"].ToString()),
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString(),
                        Score = int.Parse(reader["Score"].ToString()),
                        Victoire = int.Parse(reader["Victoire"].ToString()),
                        Egaliter = int.Parse(reader["Egaliter"].ToString()),
                        Defaite = int.Parse(reader["Defaite"].ToString())
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public List<ViewRound> ViewRounds()
        {
            return _viewRounds();
        }

        public List<ViewRound> GetRoundsOf(int IdTournoi)
        {
            return _viewRounds("WHERE ID_Tournament = " + IdTournoi);
        }

        public ViewRound GetRoundOf(int IdTournoi, int RoundNumber)
        {
            return _viewRounds("WHERE ID_Tournament = " + IdTournoi + " AND RoundNumber = " + RoundNumber)
                .FirstOrDefault();
        }

        private List<ViewRound> _viewRounds(string Where = "")
        {
            List<ViewRound> Retour = new List<ViewRound>();


            //DataContext db = new DataContext())


            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_Tournament, [Name], RoundNumber, StartRound, EndRound From [View_Round] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                DateTime dt = new DateTime();
                while (reader.Read())
                    Retour.Add(new ViewRound
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        StartRound = DateTime.TryParse(reader["StartRound"].ToString(), out dt)? dt : (DateTime?) null,
                        EndRound = DateTime.TryParse(reader["EndRound"].ToString(), out dt)? dt : (DateTime?) null
                    });


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

            return Retour;
        }


        public RetourAPI CreateUser(Utilisateur P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Create_User";
                cmd.Parameters.AddWithValue("@Pseudo", P.Pseudo);
                cmd.Parameters.AddWithValue("@Email", P.Email);
                cmd.Parameters.AddWithValue("@Password", P.BinaryPassword);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }

        private bool UseConfirme(Utilisateur Utilisateur)
        {
            string password = string.IsNullOrEmpty(Utilisateur.HexaOldPassword)
                ? Utilisateur.HexaPassword
                : Utilisateur.HexaOldPassword;
            if (string.IsNullOrEmpty(password) || Utilisateur.IdUser <= 0)
            {
                return false;
            }

            List<ViewUser> User = _ViewUsers("WHERE  ID_User = '" + Utilisateur.IdUser + "' AND [Password] = " +
                                             password).Where(u => u.Deleted == null).ToList();
            return User.Count != 1;
        }


        public RetourAPI EditUser(Utilisateur P)
        {
            if (UseConfirme(P)) return new RetourAPI(false, "Mauvais mot de passe");

            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EditUser";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@Organizer", P.Organizer);
                cmd.Parameters.AddWithValue("@Pseudo", P.Pseudo);
                cmd.Parameters.AddWithValue("@Email", P.Email);
                cmd.Parameters.AddWithValue("@Password", P.BinaryPassword);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();

                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeleteUser(Utilisateur P)
        {
            if (UseConfirme(P)) return new RetourAPI(false, "Mauvais mot de passe");

            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DeleteUser";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@Password", P.BinaryPassword);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI AddPseudoIG(IViewPseudo P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };

                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ADD_PseudoIG";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.AddWithValue("@PseudoIG", P.IgPseudo);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI EditPseudoIG(IViewPseudo P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };

                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDIT_PseudoIG";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.AddWithValue("@PseudoIG", P.IgPseudo);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeletePseudoIG(IViewPseudo P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };

                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Delete_PseudoIG";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI CreateTournoi(Tournoi P)
        {
            try
            {
                DataTable Dotation = new DataTable();
                Dotation.Columns.Add("ID_PlayerOne", typeof(int));
                Dotation.Columns.Add("ID_PlayerTwo", typeof(int));

                foreach (ViewDotation VD in P.Dotation) Dotation.Rows.Add(VD.Place, VD.Gain);

                DataTable Orga = new DataTable();
                Orga.Columns.Add("ID", typeof(int));

                foreach (ViewOrga O in P.Organisateurs) Orga.Rows.Add(O.IdUser);


                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter reussie = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CreateTournoi";
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.AddWithValue("@Date", P.Date);
                cmd.Parameters.AddWithValue("@ID_Game", P.jeu.IdGame);
                cmd.Parameters.AddWithValue("@Description", P.Description);
                cmd.Parameters.AddWithValue("@MaxNumberPlayer", P.MaxNumberPlayer);
                cmd.Parameters.AddWithValue("@Dotation", Dotation);
                cmd.Parameters.AddWithValue("@Orga", Orga);
                cmd.Parameters.AddWithValue("@DeckListNumber", P.DeckListNumber);
                cmd.Parameters.AddWithValue("@PPWin", P.Ppwin);
                cmd.Parameters.AddWithValue("@PPDraw", P.Ppdraw);
                cmd.Parameters.AddWithValue("@PPLose", P.Pplose);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(reussie);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(reussie.Value.ToString()), responseMessage.Value.ToString(),
                    bool.Parse(reussie.Value.ToString()) ? int.Parse(retour.Value.ToString()) : -1);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI EditTournoi(Tournoi P)
        {
            try
            {
                DataTable Dotation = new DataTable();
                Dotation.Columns.Add("ID_PlayerOne", typeof(int));
                Dotation.Columns.Add("ID_PlayerTwo", typeof(int));

                foreach (ViewDotation VD in P.Dotation) Dotation.Rows.Add(VD.Place, VD.Gain);

                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EditTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.AddWithValue("@Date", P.Date);
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.AddWithValue("@Description", P.Description);
                cmd.Parameters.AddWithValue("@MaxNumberPlayer", P.MaxNumberPlayer);
                cmd.Parameters.AddWithValue("@Dotation", Dotation);
                cmd.Parameters.AddWithValue("@DeckListNumber", P.DeckListNumber);
                cmd.Parameters.AddWithValue("@PPWin", P.Ppwin);
                cmd.Parameters.AddWithValue("@PPDraw", P.Ppdraw);
                cmd.Parameters.AddWithValue("@PPLose", P.Pplose);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeleteTournoi(Tournoi P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DeleteTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI EndTournoi(Tournoi P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EndTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI RegisterTournoi(DeckJoueur P, List<string> DeckList)
        {
            try
            {
                DataTable ListDeck = new DataTable();
                ListDeck.Columns.Add("DeckList", typeof(string));

                foreach (string deck in DeckList) ListDeck.Rows.Add(deck);


                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegisterTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ListDeck", ListDeck);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI UnregisterTournoi(Joueur J)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UnregisterTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", J.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", J.IdUser);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }

        public RetourAPI DropTournoi(Joueur J)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DropTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", J.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", J.IdUser);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI UpdateDeck(DeckJoueur P, string DeckList)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UpdateDeck";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ID_Deck", P.IdDeck);
                cmd.Parameters.AddWithValue("@DeckList", DeckList);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI AddAdmin(ViewOrga P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_AddAdmin";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@Level", P.Level);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI EditAdmin(ViewOrga P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDITAdmin";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@Level", P.Level);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeleteAdmin(ViewOrga P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETEAdmin";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI AddGame(Jeu P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_AddGame";
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI EditGame(Jeu P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDITGame";
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeleteGame(Jeu P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETEGame";
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI EditResultat(Resultat P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDITResultat";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ID_Tournament", P.IdTournament);
                cmd.Parameters.AddWithValue("@Rank", P.Rank);
                cmd.Parameters.AddWithValue("@Score", P.Score);
                cmd.Parameters.AddWithValue("@TieBreaker", P.TieBreaker);
                cmd.Parameters.AddWithValue("@AddTieBreaker", P.AdditionalTieBreaker);
                cmd.Parameters.AddWithValue("@AddTieBreakerRules", P.AdditionalTieBreakerRules);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeleteResultat(Resultat P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETEDResultat";
                cmd.Parameters.AddWithValue("@ID_Tournament", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", null);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI CreateRound(Round P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CREATE_Round";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@Start", P.StartRound);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI EditRound(Round P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Edit_Round";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@Start", P.StartRound);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }

        public RetourAPI EndRound(Round P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_End_Round";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeleteRound(Round P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETE_Round";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeleteRoundAndMatch(Round P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETE_RoundAndMatch";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI CreateMatch(ViewMatch P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CREATE_Match";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayer1);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayer2);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI CreateMatchAllParing(Round P, IEnumerable<PairID> ListPairing)
        {
            try
            {
                DataTable Pairing = new DataTable();
                Pairing.Columns.Add("ID_PlayerOne", typeof(int));
                Pairing.Columns.Add("ID_PlayerTwo", typeof(int));

                foreach (PairID Paire in ListPairing)
                {
                    Pairing.Rows.Add(Paire.ID1, Paire.ID2);
                }

                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CREATE_Match_ALLPairing";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@Pairing", Pairing);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI EditMatch(ViewMatch P, PairID NewPair)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDIT_Match";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayer1);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayer2);
                cmd.Parameters.AddWithValue("@ID_NewPone", NewPair.ID1);
                cmd.Parameters.AddWithValue("@ID_NewPTwo", NewPair.ID2);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeleteMatch(ViewMatch P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETE_Match";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayer1);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayer2);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI CreatePartie(IPartie P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CREATE_Partie";
                cmd.Parameters.AddWithValue("@ID_Tournament", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayer1);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayer2);
                cmd.Parameters.AddWithValue("@PartNumber", P.PartNumber);
                cmd.Parameters.AddWithValue("@ID_Deck_PlayerOne", P.IdDeckPlayer1);
                cmd.Parameters.AddWithValue("@ID_Deck_PlayerTwo", P.IdDeckPlayer2);
                cmd.Parameters.AddWithValue("@ResultPart", P.ResultPart);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI EditPartie(IPartie P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDIT_Partie";
                cmd.Parameters.AddWithValue("@ID_Tournament", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayer1);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayer2);
                cmd.Parameters.AddWithValue("@PartNumber", P.PartNumber);
                cmd.Parameters.AddWithValue("@ID_Deck_PlayerOne", P.IdDeckPlayer1);
                cmd.Parameters.AddWithValue("@ID_Deck_PlayerTwo", P.IdDeckPlayer2);
                cmd.Parameters.AddWithValue("@ResultPart", P.ResultPart);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }


        public RetourAPI DeletePartie(IPartie P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", SqlDbType.VarChar, 250)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter retour = new SqlParameter("@Reussie", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETE_Partie";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayer1);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayer2);
                cmd.Parameters.AddWithValue("@PartNumber", P.PartNumber);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);


                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return new RetourAPI(bool.Parse(retour.Value.ToString()), responseMessage.Value.ToString());
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
                return new RetourAPI(false, "Erreur serveur : " + ex.Message);
            }
        }
    }
}