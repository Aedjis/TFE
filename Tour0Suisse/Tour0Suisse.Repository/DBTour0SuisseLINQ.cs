using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Web;
using Tour0Suisse.Model;
using System.Security.Cryptography;
using System.Text;


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

            
            var User = _ViewUsers("WHERE ID_User = " +Id.ToString());
            if (User.Count == 1)
            {
                Retour = User.First();
            }

            return Retour;
        }

        public int LogIn(string Email, string Password)
        {
            int Retour = -1;

            if (!Password.StartsWith("0x"))
            {
                Password = "0x" + Password;
            }

            //string hex = "0x"+ BitConverter.ToString(Password).Replace("-", "");

            var User =  _ViewUsers("WHERE  Email = '" + Email +  "' AND [Password] = "+ Password.Replace("-", ""));
            if (User.Count == 1)
            {
                Retour = User.First().IdUser;
            }

            return Retour;
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
                    DateTime temp;

                    Retour.Add(new ViewUser
                    {
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        Pseudo = reader["Pseudo"].ToString(),
                        Email = reader["Email"].ToString(),
                        Organizer = bool.Parse(reader["Organizer"].ToString()),
                        Deleted = DateTime.TryParse(reader["DELETED"].ToString(), out temp)? temp: (DateTime?)null
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }

        public List<ViewTournament> ViewTournaments()
        {
            return _ViewTournaments();
        }
        public ViewTournament GetTournament(int Id)
        {
            return _ViewTournaments("WHERE ID_Tournament = " + Id.ToString()).FirstOrDefault();
        }

        private List<ViewTournament> _ViewTournaments(string Where = "")
        {
            List<ViewTournament> Retour = new List<ViewTournament>();


            //DataContext db = new DataContext())



            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_Tournament, [Name], ID_Game, [Game], [Date], [MaxNumberPlayer], [DeckListNumber], [PPWin], [PPDraw], [PPLose] FROM [View_Tournament] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                   
                    Retour.Add(new ViewTournament
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        IdGame = int.Parse(reader["ID_Game"].ToString()),
                        Name = reader["Name"].ToString(),
                        Game = reader["Game"].ToString(),
                        Date = DateTime.Parse(reader["Date"].ToString()),
                        MaxNumberPlayer = int.Parse(reader["MaxNumberPlayer"].ToString()),
                        DeckListNumber = int.Parse(reader["DeckListNumber"].ToString()),
                        Ppwin = int.Parse(reader["PPWin"].ToString()),
                        Ppdraw = int.Parse(reader["PPDraw"].ToString()),
                        Pplose = int.Parse(reader["PPLose"].ToString()),
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }

        public List<ViewPseudo> ViewPseudos()
        {
            return _ViewPseudos();
        }

        public List<ViewPseudo> GetPseudosUser(int IdUser)
        {
            return _ViewPseudos("WHERE ID_User = "+IdUser.ToString());
        }

        private List<ViewPseudo> _ViewPseudos(string Where="")
        {
            List<ViewPseudo> Retour = new List<ViewPseudo>();


            //DataContext db = new DataContext())



            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_User, ID_Game, Game, IG_Pseudo FROM [View_Pseudo] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    Retour.Add(new ViewPseudo
                    {
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        IdGame = int.Parse(reader["ID_Game"].ToString()),
                        Game = reader["Game"].ToString(),
                        IgPseudo = reader["IG_Pseudo"].ToString()
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }


        public List<ViewOrga> ViewOrgas()
        {
            return _ViewOrgas();
        }

        public List<ViewOrga> GetOrgasOf(int idTournoi)
        {
            return _ViewOrgas("WHERE ID_Tournament = "+ idTournoi.ToString());
        }

        private List<ViewOrga> _ViewOrgas(string Where="")
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
                {

                    Retour.Add(new ViewOrga
                    {
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        Pseudo = reader["Pseudo"].ToString(),
                        Level = int.Parse(reader["Level"].ToString())
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }


        public List<ViewParticipant> ViewParticipants()
        {
            return _ViewParticipants();
        }

        public List<ViewParticipant> GetParticipantsOf(int IDTournoi)
        {
            return _ViewParticipants("WHERE ID_Tournament = " +IDTournoi.ToString());
        }

        private List<ViewParticipant> _ViewParticipants(string Where="")
        {
            List<ViewParticipant> Retour = new List<ViewParticipant>();


            //DataContext db = new DataContext())



            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_Tournament, Name, ID_User, Pseudo, IG_Pseudo, RegisterDate, CheckIn, [Drop] FROM [View_Participant] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    DateTime temp = new DateTime();
                    Retour.Add(new ViewParticipant
                    {
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString(),
                        RegisterDate = DateTime.Parse(reader["RegisterDate"].ToString()),
                        CheckIn = (DateTime.TryParse(reader["CheckIn"].ToString(), out temp))? temp : (DateTime?)null ,
                        Drop = bool.Parse(reader["Drop"].ToString())
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }


        public List<ViewResulta> ViewResultas()
        {
            return _ViewResultas();
        }

        public List<ViewResulta> GetResultasOfTournament(int IdTournament)
        {
            return _ViewResultas("WHERE ID_Tournament = "+IdTournament.ToString());
        }

        private List<ViewResulta> _ViewResultas(string Where="")
        {
            List<ViewResulta> Retour = new List<ViewResulta>();


            //DataContext db = new DataContext())



            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_Tournament, Name, ID_User, Pseudo, IG_Pseudo, Rank, Score, TieBreaker, AdditionalTieBreaker, AdditionalTieBreakerRules From [View_Resulta] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    var temp = new int();
                    Retour.Add(new ViewResulta
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        AdditionalTieBreaker = int.TryParse(reader["AdditionalTieBreaker"].ToString(), out temp)? temp:(int?)null, 
                        AdditionalTieBreakerRules = reader["AdditionalTieBreakerRules"].ToString(),
                        IdUser = int.Parse(reader["ID_User"].ToString()),
                        Name = reader["Name"].ToString(),
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString(),
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
                throw ex;
            }

            return Retour;
        }


        public List<ViewPartie> ViewParties()
        {
            return _ViewParties();
        }

        private List<ViewPartie> _ViewParties(string Where = "")
        {
            List<ViewPartie> Retour = new List<ViewPartie>();


            //DataContext db = new DataContext())



            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT [ID_Tournament], [Name], [RoundNumber], [PartNumber], [ResultPart], [ID_PlayerOne], [IGPseudoOne], [PlayerOne], [ID_Deck_PlayerOne], [DeckOne], [ID_PlayerTwo], [IGPseudoTwo], [PlayerTwo], [ID_Deck_PlayerTwo], [DeckTwo] From [View_Partie] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    var temp = new byte();
                    Retour.Add(new ViewPartie
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        PartNumber = int.Parse(reader["PartNumber"].ToString()),
                        ResultPart = byte.TryParse(reader["ResultPart"].ToString(), out temp)? temp: (byte?)null,
                        IdPlayerOne = int.Parse(reader["ID_PlayerOne"].ToString()),
                        PlayerOne = reader["PlayerOne"].ToString(),
                        IGPseudoOne = reader["IGPseudoOne"].ToString(),
                        IdDeckPlayerOne = int.Parse(reader["ID_Deck_PlayerOne"].ToString()),
                        DeckOne = reader["DeckOne"].ToString(),
                        IdPlayerTwo = int.Parse(reader["ID_PlayerTwo"].ToString()),
                        PlayerTwo = reader["PlayerTwo"].ToString(),
                        IGPseudoTwo = reader["IGPseudoTwo"].ToString(),
                        IdDeckPlayerTwo = int.Parse(reader["ID_Deck_PlayerOne"].ToString()),
                        DeckTwo = reader["DeckTwo"].ToString()
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }



        public List<ViewDeck> ViewDecks()
        {
            return _viewDecks();
        }

        private List<ViewDeck> _viewDecks(string Where = "")
        {
            List<ViewDeck> Retour = new List<ViewDeck>();


            //DataContext db = new DataContext())



            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_Tournament, Name, ID_User, Pseudo, ID_Deck, DeckList, ID_Game, Game From [View_Deck] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
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
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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

                string querry = "SELECT ID_Tournament, RoundNumber, PartNumber, ID_Player, Pseudo, IG_Pseudo, Resulta From [View_ResultPartPlayer] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    var temp = new int();
                    Retour.Add(new ViewResultPartPlayer
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        PartNumber = int.Parse(reader["PartNumber"].ToString()),
                        IdPlayer = int.Parse(reader["ID_Player"].ToString()),
                        Resulta = int.TryParse(reader["Resulta"].ToString(), out temp)? temp:(int?)null,
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString()
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }



        public List<ViewMatch> ViewMatches()
        {
            return _viewMatches();
        }

        private List<ViewMatch> _viewMatches(string Where = "")
        {
            List<ViewMatch> Retour = new List<ViewMatch>();


            //DataContext db = new DataContext())



            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT [ID_Tournament], [RoundNumber], [ID_PlayerOne], [PlayerOne], [PseudoPlayerOne], [ID_PlayerTwo], [PlayerTow], [PseudoPlayerTow] From [View_Match] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Retour.Add(new ViewMatch
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        IdPlayerOne = int.Parse(reader["ID_PlayerOne"].ToString()),
                        PlayerOne = reader["PlayerOne"].ToString(),
                        PseudoOne = reader["PseudoPlayerOne"].ToString(),
                        IdPlayerTwo = int.Parse(reader["ID_PlayerTwo"].ToString()),
                        PlayerTow = reader["PlayerTow"].ToString(),
                        PseudoTow = reader["PseudoPlayerTow"].ToString()
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }



        public List<ViewJeu> ViewJeus()
        {
            return _viewJeus();
        }

        public ViewJeu GetJeu(int id)
        {
            return _viewJeus("WHERE ID_Game = "+id.ToString()).FirstOrDefault();
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
                {
                    Retour.Add(new ViewJeu()
                    {
                        IdGame = int.Parse(reader["ID_Game"].ToString()),
                        Name = reader["Name"].ToString()
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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

                string querry = "SELECT  ID_Tournament, RoundNumber, ID_Player, Pseudo, IG_Pseudo, Resulta From [View_ResultMatchPlayer] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    var temp = new int();
                    Retour.Add(new ViewResultMatchPlayer
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        IdPlayer = int.Parse(reader["ID_Player"].ToString()),
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString(),
                        Resulta = int.TryParse(reader["Resulta"].ToString(), out temp)? temp : (int?)null
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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

                string querry = "SELECT ID_Tournament, ID_Player, Pseudo, IG_Pseudo, Victoire, Egaliter, Defaite From [View_ClassementTemporaire] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
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
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }



        public List<ViewScoreClassementTemporaire> ViewScoreClassementTemporaires()
        {
            return _viewScoreClassementTemporaires();
        }

        public List<ViewScoreClassementTemporaire> GetScoreClassementTemporairesOfTournamnent(int IdTournamnet)
        {
            return _viewScoreClassementTemporaires("WHERE ID_Tournament = "+IdTournamnet.ToString());
        }

        private List<ViewScoreClassementTemporaire> _viewScoreClassementTemporaires(string Where = "")
        {
            List<ViewScoreClassementTemporaire> Retour = new List<ViewScoreClassementTemporaire>();


            //DataContext db = new DataContext())



            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_Tournament, Name, ID_Player, Pseudo, IG_Pseudo, Score, Victoire, Egaliter, Defaite From [View_ScoreClassementTemporaire] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Retour.Add(new ViewScoreClassementTemporaire
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Tournament = reader["Name"].ToString(),
                        IdPlayer = int.Parse(reader["ID_Player"].ToString()),
                        Pseudo = reader["Pseudo"].ToString(),
                        IGPseudo = reader["IG_Pseudo"].ToString(),
                        Score = int.Parse(reader["Score"].ToString()),
                        Victoire = int.Parse(reader["Victoire"].ToString()),
                        Egaliter = int.Parse(reader["Egaliter"].ToString()),
                        Defaite = int.Parse(reader["Defaite"].ToString())
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }



        public List<ViewRound> ViewRounds()
        {
            return _viewRounds();
        }

        private List<ViewRound> _viewRounds(string Where = "")
        {
            List<ViewRound> Retour = new List<ViewRound>();


            //DataContext db = new DataContext())



            try
            {
                SqlConnection db = new SqlConnection(_ConnectionString);

                string querry = "SELECT ID_Tournament, [Name], RoundNumber, StartRound From [View_Round] " + Where;

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = querry;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Retour.Add(new ViewRound
                    {
                        IdTournament = int.Parse(reader["ID_Tournament"].ToString()),
                        Name = reader["Name"].ToString(),
                        RoundNumber = int.Parse(reader["RoundNumber"].ToString()),
                        StartRound = DateTime.Parse(reader["Victoire"].ToString())
                    });
                }


                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retour;
        }


        public bool CreateUser(Utilisateur P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_Create_User";
                cmd.Parameters.AddWithValue("@Pseudo", P.Pseudo);
                cmd.Parameters.AddWithValue("@Email", P.Email);
                cmd.Parameters.AddWithValue("@Password", P.HashPassword);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            
            return true;
        }


        public bool EditUser(Utilisateur P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_EditUser";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@Organizer", P.Organizer);
                cmd.Parameters.AddWithValue("@Pseudo", P.Pseudo);
                cmd.Parameters.AddWithValue("@Email", P.Email);
                cmd.Parameters.AddWithValue("@Password", P.HashPassword);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool DeleteUser(Utilisateur P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DeleteUser";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@Password", P.HashPassword);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool AddPseudoIG(PseudoIg P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_ADD_PseudoIG";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.AddWithValue("@PseudoIG", P.IgPseudo);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool EditPseudoIG(PseudoIg P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDIT_PseudoIG";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.AddWithValue("@PseudoIG", P.IgPseudo);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool DeletePseudoIG(PseudoIg P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_Delete_PseudoIG";
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool CreateTournoi(Tournoi P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_CreateTournoi";
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.AddWithValue("@Date", P.Date);
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.AddWithValue("@Description", P.Desciption);
                cmd.Parameters.AddWithValue("@MaxNumberPlayer", P.MaxNumberPlayer);
                cmd.Parameters.AddWithValue("@DeckListNumber", P.DeckListNumber);
                cmd.Parameters.AddWithValue("@PPWin", P.Ppwin);
                cmd.Parameters.AddWithValue("@PPDraw", P.Ppdraw);
                cmd.Parameters.AddWithValue("@PPLose", P.Pplose);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool EditTournoi(Tournoi P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_EditTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.AddWithValue("@Date", P.Date);
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.AddWithValue("@Description", P.Desciption);
                cmd.Parameters.AddWithValue("@MaxNumberPlayer", P.MaxNumberPlayer);
                cmd.Parameters.AddWithValue("@DeckListNumber", P.DeckListNumber);
                cmd.Parameters.AddWithValue("@PPWin", P.Ppwin);
                cmd.Parameters.AddWithValue("@PPDraw", P.Ppdraw);
                cmd.Parameters.AddWithValue("@PPLose", P.Pplose);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool DeleteTournoi(Tournoi P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DeleteTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool EndTournoi(Tournoi P)
        {
            try
            {
                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_EndTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool RegisterTournoi(DeckJoueur P, List<string>DeckList)
        {
            try
            {
                DataTable ListDeck = new DataTable();
                ListDeck.Columns.Add("DeckList", typeof(string));

                foreach (string deck in DeckList)
                {
                    ListDeck.Rows.Add(deck);
                }


                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegisterTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@ListDeck", ListDeck);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool UnregisterTournoi(DeckJoueur P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_UnregisterTournoi";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool UpdateDeck(DeckJoueur P, string DeckList)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool AddAdmin(Organisateur P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_AddAdmin";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@Level", P.Level);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool EditAdmin(Organisateur P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDITAdmin";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.AddWithValue("@Level", P.Level);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }


        public bool DeleteAdmin(Organisateur P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETEAdmin";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", P.IdUser);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool AddGame(Jeu P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_AddGame";
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool EditGame(Jeu P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDITGame";
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.AddWithValue("@Name", P.Name);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool DeleteGame(Jeu P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETEGame";
                cmd.Parameters.AddWithValue("@ID_Game", P.IdGame);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool EditResultat(Resultat P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool DeleteResultat(Resultat P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETEDResultat";
                cmd.Parameters.AddWithValue("@ID_Tournament", P.IdTournament);
                cmd.Parameters.AddWithValue("@ID_User", (int?)null);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool CreateRound(Round P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_CREATE_Round";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@Start", P.StartRound);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool DeleteRound(Round P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETE_Round";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool DeleteRoundAndMatch(Round P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETE_RoundAndMatch";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool CreateMatch(Match P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_CREATE_Match";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayerOne);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayerTwo);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool CreateMatchAllParing(Round P, List<PairID> ListPairing)
        {
            try
            {
                DataTable Pairing = new DataTable();
                Pairing.Columns.Add("ID_PlayerOne", typeof(Int32));
                Pairing.Columns.Add("ID_PlayerTwo", typeof(Int32));

                foreach (var Paire in ListPairing)
                {
                    Pairing.Rows.Add(Paire.IDOne, Paire.IDTwo);
                }

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_CREATE_Match_ALLPairing";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@Pairing", Pairing);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool EditMatch(Match P, PairID NewPair)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDIT_Match";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayerOne);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayerTwo);
                cmd.Parameters.AddWithValue("@ID_NewPone", NewPair.IDOne);
                cmd.Parameters.AddWithValue("@ID_NewPTwo", NewPair.IDTwo);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool DeleteMatch(Match P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETE_Match";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayerOne);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayerTwo);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool CreatePartie(Partie P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_CREATE_Partie";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayerOne);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayerTwo);
                cmd.Parameters.AddWithValue("@PartNumber", P.PartNumber);
                cmd.Parameters.AddWithValue("@ID_Deck_PlayerOne", P.IdDeckPlayerOne);
                cmd.Parameters.AddWithValue("@ID_Deck_PlayerTwo", P.IdDeckPlayerTwo);
                cmd.Parameters.AddWithValue("@ResultPart", P.ResultPart);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool EditPartie(Partie P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_EDIT_Partie";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayerOne);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayerTwo);
                cmd.Parameters.AddWithValue("@PartNumber", P.PartNumber);
                cmd.Parameters.AddWithValue("@ID_Deck_PlayerOne", P.IdDeckPlayerOne);
                cmd.Parameters.AddWithValue("@ID_Deck_PlayerTwo", P.IdDeckPlayerTwo);
                cmd.Parameters.AddWithValue("@ResultPart", P.ResultPart);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }




        public bool DeletePartie(Partie P)
        {
            try
            {

                SqlParameter responseMessage = new SqlParameter("@responseMessage", DbType.String);
                responseMessage.Direction = System.Data.ParameterDirection.Output;

                SqlParameter retour = new SqlParameter("@responseMessage", DbType.Boolean);
                responseMessage.Direction = System.Data.ParameterDirection.Output;


                SqlConnection db = new SqlConnection(_ConnectionString);

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETE_Partie";
                cmd.Parameters.AddWithValue("@ID_Tournoi", P.IdTournament);
                cmd.Parameters.AddWithValue("@RoundNumber", P.RoundNumber);
                cmd.Parameters.AddWithValue("@ID_PlayerOne", P.IdPlayerOne);
                cmd.Parameters.AddWithValue("@ID_PlayerTwo", P.IdPlayerTwo);
                cmd.Parameters.AddWithValue("@PartNumber", P.PartNumber);
                cmd.Parameters.Add(responseMessage);
                cmd.Parameters.Add(retour);



                db.Open();

                Console.WriteLine(cmd.ExecuteNonQuery() + " ligne affecté");


                db.Close();
                return bool.Parse(retour.Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
            return true;
        }
    }
}
