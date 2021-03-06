using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Pairing_Console_Test
{
    internal class Program
    {
        //au 7ieme roud sur 9maximun théorique parfois le pairing échoue même si il est possible
        //aucun probleme sur le 8 et la 9
        private static void Main(string[] Args)
        {
            List<int> players = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                players.Add(i);
            }
            // le pairing ne fonction plus car on a atteint le nombre limite de round
            //debut de zone de création de donnée pour les test
            List<Classement> classements = new List<Classement>();
            classements.Add(new Classement { ID_Player = 1, Defaite = 2, Egaliter = 0, Victoire = 7 });
            classements.Add(new Classement { ID_Player = 2, Defaite = 4, Egaliter = 1, Victoire = 4 });
            classements.Add(new Classement { ID_Player = 3, Defaite = 3, Egaliter = 0, Victoire = 6 });
            classements.Add(new Classement { ID_Player = 4, Defaite = 3, Egaliter = 1, Victoire = 5 });
            classements.Add(new Classement { ID_Player = 5, Defaite = 4, Egaliter = 1, Victoire = 4 });
            classements.Add(new Classement { ID_Player = 6, Defaite = 6, Egaliter = 0, Victoire = 3 });
            classements.Add(new Classement { ID_Player = 7, Defaite = 6, Egaliter = 0, Victoire = 3 });
            classements.Add(new Classement { ID_Player = 8, Defaite = 6, Egaliter = 0, Victoire = 3 });
            classements.Add(new Classement { ID_Player = 9, Defaite = 5, Egaliter = 1, Victoire = 3 });
            classements.Add(new Classement { ID_Player = 10, Defaite = 3, Egaliter = 0, Victoire = 6 });

            var matches = new List<Match>();
            matches.Add(new Match { PlayerOne = 1, PlayerTwo = 10 });
            matches.Add(new Match { PlayerOne = 1, PlayerTwo = 3 });
            matches.Add(new Match { PlayerOne = 2, PlayerTwo = 6 });
            matches.Add(new Match { PlayerOne = 2, PlayerTwo = 9 });
            matches.Add(new Match { PlayerOne = 3, PlayerTwo = 8 });

            matches.Add(new Match { PlayerOne = 4, PlayerTwo = 5 });
            matches.Add(new Match { PlayerOne = 9, PlayerTwo = 5 });
            matches.Add(new Match { PlayerOne = 10, PlayerTwo = 4 });
            matches.Add(new Match { PlayerOne = 6, PlayerTwo = 7 });
            matches.Add(new Match { PlayerOne = 7, PlayerTwo = 8 });

            matches.Add(new Match { PlayerOne = 10, PlayerTwo = 9 });
            matches.Add(new Match { PlayerOne = 3, PlayerTwo = 7 });
            matches.Add(new Match { PlayerOne = 6, PlayerTwo = 8 });
            matches.Add(new Match { PlayerOne = 2, PlayerTwo = 4 });
            matches.Add(new Match { PlayerOne = 5, PlayerTwo = 1 });

            matches.Add(new Match { PlayerOne = 10, PlayerTwo = 6 });
            matches.Add(new Match { PlayerOne = 2, PlayerTwo = 5 });
            matches.Add(new Match { PlayerOne = 3, PlayerTwo = 9 });
            matches.Add(new Match { PlayerOne = 7, PlayerTwo = 4 });
            matches.Add(new Match { PlayerOne = 8, PlayerTwo = 1 });

            matches.Add(new Match { PlayerOne = 6, PlayerTwo = 9 });
            matches.Add(new Match { PlayerOne = 10, PlayerTwo = 5 });
            matches.Add(new Match { PlayerOne = 3, PlayerTwo = 2 });
            matches.Add(new Match { PlayerOne = 4, PlayerTwo = 8 });
            matches.Add(new Match { PlayerOne = 7, PlayerTwo = 1 });

            matches.Add(new Match { PlayerOne = 10, PlayerTwo = 2 });
            matches.Add(new Match { PlayerOne = 9, PlayerTwo = 7 });
            matches.Add(new Match { PlayerOne = 3, PlayerTwo = 4 });
            matches.Add(new Match { PlayerOne = 6, PlayerTwo = 1 });
            matches.Add(new Match { PlayerOne = 5, PlayerTwo = 8 });

            matches.Add(new Match { PlayerOne = 7, PlayerTwo = 2 });
            matches.Add(new Match { PlayerOne = 5, PlayerTwo = 6 });
            matches.Add(new Match { PlayerOne = 9, PlayerTwo = 8 });
            matches.Add(new Match { PlayerOne = 10, PlayerTwo = 3 });
            matches.Add(new Match { PlayerOne = 4, PlayerTwo = 1 });

            matches.Add(new Match { PlayerOne = 6, PlayerTwo = 4 });
            matches.Add(new Match { PlayerOne = 8, PlayerTwo = 2 });
            matches.Add(new Match { PlayerOne = 9, PlayerTwo = 1 });
            matches.Add(new Match { PlayerOne = 5, PlayerTwo = 3 });
            matches.Add(new Match { PlayerOne = 7, PlayerTwo = 10 });

            matches.Add(new Match { PlayerOne = 1, PlayerTwo = 2 });
            matches.Add(new Match { PlayerOne = 5, PlayerTwo = 7 });
            matches.Add(new Match { PlayerOne = 9, PlayerTwo = 4 });
            matches.Add(new Match { PlayerOne = 6, PlayerTwo = 3 });
            matches.Add(new Match { PlayerOne = 8, PlayerTwo = 10 });

            //fin de zone de création de donné pour les test

            List<Classement> classplayer = classements.Where(C => players.Contains(C.ID_Player)).ToList();

            var orderedclass = classplayer.OrderByDescending(o=>o.Victoire*2+o.Egaliter);
            foreach (var v in orderedclass)
            {
                Console.WriteLine(v.ID_Player.ToString() + ", v : " + v.Victoire.ToString()+ ", e : "+ v.Egaliter.ToString() +", d :"+ v.Defaite.ToString());
            }
            
            Console.ReadLine();//affichage du classement ordonnée

            Console.WriteLine("--------------------------------");
            var test = Pairing(players, classements, matches, 10);
            foreach (var pair in test)
            {
                Console.WriteLine(pair.PlayerOne + " - " + pair.PlayerTwo);
            }
            Console.WriteLine("--------------------------------");//affichage de la 1er simulation de pairing

            var test2 = Pairing(players, classements, matches, 10);
            foreach (var pair in test2)
            {
                Console.WriteLine(pair.PlayerOne + " - " + pair.PlayerTwo);
            }
            Console.WriteLine("--------------------------------");//affichage de la 2ieme simulation de pairing

            var test3 = Pairing(players, classements, matches, 10);
            foreach (var pair in test3)
            {
                Console.WriteLine(pair.PlayerOne + " - " + pair.PlayerTwo);
            }
            Console.WriteLine("--------------------------------");//affichage de la 3ieme simulation de pairing
            Console.ReadLine();
        }

        private struct PairPlayer
        {
            public int PlayerOne;
            public int PlayerTwo;
        }

        private struct  Match
        {
            public int PlayerOne;
            public int PlayerTwo;
        }

        private struct Classement
        {
            public int ID_Player;
            public int Victoire;
            public int Egaliter;
            public int Defaite;
        }

        /// <summary>
        ///
        ///fonction qui va faire automatiquement le pairing entre les joueurs
        ///
        /// 
        /// --1 on crée des groupes basés sur le nombre de victoire 
        /// 
        /// --pour chaque groupe (en commençant par celui avec le plus de victoire) 
        /// --2 on les tri (ASC) en fonction du nombre d'adversaire de leur qu'ils n'ont pas déjà rencontré. S’il y a des joueurs qui ont déjà rencontré tous les autres du groupe on le report dans le groupe suivant
        /// --3 en commençant par le joueur reporté du groupe d'avant, dans l'ordre on leur attribue un adversaire (au hasard) qu'ils n'ont pas encore rencontré, si ce n'est pas possible on met le joueur en attente
        /// --4 s’il n'y a que 1 joueur en attente on le report au group suivant,
        /// --sinon on cherche une paire de joueur déjà appareillé qui pourrais correspondre à des joueurs en attente. et on répète le processus jusqu'à ne plus en trouvé.
        /// -- s’il reste encore des joueurs en attente on les reports au groupe suivant.
        /// 
        /// --5 pour le dernier groupe s’il n'y a qu’un joueur reporté on lui donne un bail (victoire gratuite).
        /// -- sinon on recommence depuis le début mais en commençant par le groupe avec le moins de victoire.
        /// 
        /// </summary>
        /// <param name="Players">Liste des joueur encore dans le tournoi</param>
        /// <param name="classements">classement de tout les joueurs du tournoi</param>
        /// <param name="matches">liste de tout les match joué dans le tournoi</param>
        /// <returns></returns>
        private static List<PairPlayer> Pairing(List<int> Players, List<Classement> classements, List<Match> matches, int RoundNumber, int PPV = 2, int PPE = 1, int PPD = 0)
        {
            List<PairPlayer> retour = new List<PairPlayer>(); // crée la variable qui se verra atrivué la liste de pairing qui doit être retourné.
            retour.Clear();
            List<Classement> PlayerClassement = classements.Where(c => Players.Contains(c.ID_Player)).ToList(); // ne prend en considération plus que les joueur encore en list


            Dictionary<int, List<int>> PlayerOpponentList = CreatePlayerOpponentList(Players, matches); // création d'un dictonaire pour retrouvé a liste des adversaire d'un joueur

            if (!DescPairing(Players, PlayerOpponentList, PlayerClassement, RoundNumber, out retour, PPV, PPE, PPD))
            {

                if (!ForcePairing(Players, PlayerOpponentList, retour, out retour))
                {
                    retour.Clear();
                }
            }


            return retour; // retourné le pairing 
        }
        /// <summary>
        /// fonction qui force le pairing sans faire attention au classement
        /// </summary>
        /// <param name="players">liste des joueur qui doivent avoir un paring</param>
        /// <param name="playerOpponentList">dictionnaire de list d'adversaire déjà rencontré par chaque adversaire</param>
        /// <param name="pairing">liste de pairing actuelle</param>
        /// <param name="retour">variable qui contiendra le pairing final</param>
        /// <returns>signal si le pairing est complete</returns>
        private static bool ForcePairing(List<int> players, Dictionary<int, List<int>> playerOpponentList, List<PairPlayer> pairing, out List<PairPlayer> retour)
        {
            List<int> NoPairedPlayer = players.Where(pl => !pairing.Exists(pa=> pa.PlayerOne==pl || pa.PlayerTwo==pl)).ToList();//crée la liste de tout les joueur non pairé
            retour = pairing;

            List<int> tempOutReportedPlayer = new List<int>();
            tempOutReportedPlayer.AddRange(NoPairedPlayer);//crée un doublons de la list des joueur reporté
            foreach (var Player in tempOutReportedPlayer)//pour tout les joueur reporté
            {
                if (NoPairedPlayer.Contains(Player))//on verifie que le joueur est encore dans les joueur reporté
                {
                    foreach (var pair in retour)//pour chaque pairing dejà fait
                    {

                        if (!playerOpponentList[Player].Contains(pair.PlayerOne))//on regard si le playerone du pairing n'est pas dans la liste des adversaire déjà rencontré
                        {
                            var ListNewOpponent = NoPairedPlayer.Except(playerOpponentList[pair.PlayerTwo]).ToList();//on crée une liste d'advaisaire potentielle sur base des joueur reporté qui serait ne serait pas dans la liste des adversaire du playertwo de la pair
                            ListNewOpponent.Remove(Player);//on retire le joueur que l'on tente de pairé de la liste des potentille nouveau adversaire du playertwo (vu que le jouer va être apparaillé au playerone)
                            if (ListNewOpponent.Any())//on regard si il reste un adversaire potentielle
                            {
                                var rng = new Random();
                                var NewOpponent = ListNewOpponent.ElementAt(rng.Next(0, ListNewOpponent.Count()));//on choisie alléatoirement un adversaire parmi les adversaire potentielle

                                var pairPlayer1 = new PairPlayer//on crée une nouveelle pair
                                {
                                    PlayerOne = pair.PlayerTwo,
                                    PlayerTwo = NewOpponent//on pair le player 2 avec l'adversaire choisie aléatoirement
                                };
                                retour.Add(pairPlayer1);//on joute la nouvelle pair
                                var pairPlayer2 = new PairPlayer//on crée une nouveelle pair
                                {
                                    PlayerOne = pair.PlayerOne,
                                    PlayerTwo = Player//on pair le player1 avec le joueur que l'on tant de pairé
                                };
                                retour.Add(pairPlayer2);//on joute la nouvelle pair

                                retour.Remove(pair);//on supprime l'ancienne pair
                                NoPairedPlayer.Remove(NewOpponent);//on retire l'adversaire choisie au hazard des joueur reporté
                                NoPairedPlayer.Remove(Player);//on retire joueur des joueur reporté

                                break;
                            }
                        }
                    }
                }
            }

            return !NoPairedPlayer.Any();

        }
        /// <summary>
        /// fonction qui fait du pairing en partant du haut du classement puis le descent
        /// </summary>
        /// <param name="players">liste de joueur a pairé</param>
        /// <param name="playerOpponentList">dictionnaire de list d'adversaire déjà rencontré par chaque adversaire</param>
        /// <param name="playerClassement">statisitque de chaque joueur</param>
        /// <param name="roundNumber">numero de la round</param>
        /// <param name="retour">liste des pairing effectué</param>
        /// <param name="PPV">point par victoire pour le classement</param>
        /// <param name="PPE">point par egalité pour le classement</param>
        /// <param name="PPD">point par defaite pour le classment</param>
        /// <returns>signal si le pairing est complete</returns>
        private static bool DescPairing(List<int> players, Dictionary<int, List<int>> playerOpponentList, List<Classement> playerClassement, int roundNumber, out List<PairPlayer> retour, int PPV = 2, int PPE=1, int PPD=0)
        {
            retour = new List<PairPlayer>();//inisialisation de la liste de pairing qui sera retourné
            List<int>[] GroupPlayer = new List<int>[roundNumber*PPV];//création d'un tableau pour crée les group de liste de joueur 

            for (int i = 0; i < roundNumber*PPV; i++)//atribution des joueur a chaque group leur correspondant en fonction de leur parcours
            {
                GroupPlayer[i] = playerClassement.Where(p => (p.Victoire*PPV + p.Egaliter*PPE + p.Defaite*PPD) == i).Select(s => s.ID_Player).ToList();
            }


            List<int> InReportedPlayer = new List<int>();//création de la liste des joueur qui sont été réporté
            List<int> OutReportedPlayer = new List<int>();//création de la liste des jouer qui vont être reporté
            foreach (var Group in GroupPlayer)
            {
                retour.AddRange(PairingInGroup(Group, playerOpponentList, out OutReportedPlayer, InReportedPlayer));//on fait le pairing de chaque groupe et on le rajoute au pairing existant
                InReportedPlayer.Clear();
                InReportedPlayer.AddRange(OutReportedPlayer);//on transmet la liste es joueur reporté
                OutReportedPlayer.Clear();
            }

            switch (InReportedPlayer.Count)//en fonction du nombre de joueur qui n'ont pas pu etre pairé on : 
            {
                case 0:
                    return true;//ne fait rien car ils ont tous été pairé
                case 1:
                    retour.Add(new PairPlayer//on donne un bye au seul joueur qui n'as pas été pairé (ccela est du a un nombre de joueur impaire
                    {
                        PlayerOne = InReportedPlayer.ElementAt(0),
                        PlayerTwo = 0
                    });
                    return true;
                default:
                    return false;//on signal que le pairing n'est pas complet et dois être refait ou retravaillé
            }
        }


        /// <summary>
        /// Fonction qui fait le paring des joueur qui ce strouve dans un même regroupement fait sur base du classement
        /// 
        /// il peu y avoir des joueur d'un autre groupe 
        /// </summary>
        /// <param name="Players">liste des joueur a pairé</param>
        /// <param name="PlayerOpponentList">dictonnaire des adversaire pour chaque joueur</param>
        /// <param name="OutReportedPlayer"> paramttre qui va listé les joueur qui sont reporté car impossible de pairé dans ce groupe</param>
        /// <param name="InReportedPlayer">liste de joueur qui sont rajouté a ce groupe car il n'ont pas pu être pairé dans celui d'avant</param>
        /// <returns>liste de pairing de joueur effectué pour ce groupe</returns>
        private static List<PairPlayer> PairingInGroup(List<int> Players, Dictionary<int, List<int>> PlayerOpponentList, out List<int> OutReportedPlayer, List<int> InReportedPlayer = null)
        {
            List<PairPlayer> retour = new List<PairPlayer>(); // crée la variable qui se verra atrivué la liste de pairing qui doit être retourné.
            OutReportedPlayer = new List<int>(); //initilaization du paramtre out OutreportedPlayer
            OutReportedPlayer.Clear();// on s'assure que le parametre out est bien vide

            List<int> AllRemainingPlayer = new List<int>();
            AllRemainingPlayer.Clear();
            AllRemainingPlayer.AddRange(Players);

            if (InReportedPlayer != null && InReportedPlayer.Count > 0)//on verfie si il y a des joueur reporté
            {
                AllRemainingPlayer.AddRange(InReportedPlayer);// on ajoute les joueur reporté a la liste des joueur restant a appareillé

                foreach (var Player in InReportedPlayer)//pour chaque joueur reporté a appareillé
                {
                    if (AllRemainingPlayer.Contains(Player))//on verifie que le joueur est toujours dans la liste des joueur a appareillé
                    {
                        if (PairAPlayer(Player, PlayerOpponentList, AllRemainingPlayer, out var pairPlayer)
                        ) // on essaye de l'appareillé
                        {
                            // si on réussie on affect l'appareillement
                            AllRemainingPlayer.Remove(pairPlayer.PlayerOne);
                            AllRemainingPlayer.Remove(pairPlayer.PlayerTwo);

                            retour.Add(pairPlayer);
                        }
                        else //si on ne reussie pas on rajoute le joueur ala liste des joueur a reporté
                        {
                            OutReportedPlayer.Add(Player);
                        }
                    }
                }
            }

            foreach (var player in Players)//pour chaque joueur a appareillé
            {
                if (AllRemainingPlayer.Contains(player))//on verifie que le joueur est toujours dans la liste des joueur a appareillé
                {
                    if (PairAPlayer(player, PlayerOpponentList, AllRemainingPlayer, out var pairPlayer)
                    ) // on essaye de l'appareillé
                    {
                        // si on réussie on affect l'appareillement et retrie les joueuer appareillé
                        AllRemainingPlayer.Remove(pairPlayer.PlayerOne);
                        AllRemainingPlayer.Remove(pairPlayer.PlayerTwo);

                        retour.Add(pairPlayer);
                    }
                    else //si on ne reussie pas on rajoute le joueur ala liste des joueur a reporté
                    {
                        OutReportedPlayer.Add(player);
                    }
                }
            }

            if (OutReportedPlayer.Count > 1)// si il y a plus d'un joueur reporté on verifie que en faisant des permutation on ne peu pas les appareillé quand même
            {
                List<int> tempOutReportedPlayer = new List<int>();
                tempOutReportedPlayer.AddRange(OutReportedPlayer);//crée un doublons de la list des joueur reporté
                foreach (var Player in tempOutReportedPlayer)//pour tout les joueur reporté
                {
                    if (OutReportedPlayer.Contains(Player))//on verifie que le joueur est encore dans les joueur reporté
                    {
                        foreach (var pair in retour)//pour chaque pairing dejà fait
                        {
                         
                            if (!PlayerOpponentList[Player].Contains(pair.PlayerOne))//on regard si le playerone du pairing n'est pas dans la liste des adversaire déjà rencontré
                            {
                                var ListNewOpponent = OutReportedPlayer.Except(PlayerOpponentList[pair.PlayerTwo]).ToList();//on crée une liste d'advaisaire potentielle sur base des joueur reporté qui serait ne serait pas dans la liste des adversaire du playertwo de la pair
                                ListNewOpponent.Remove(Player);//on retire le joueur que l'on tente de pairé de la liste des potentille nouveau adversaire du playertwo (vu que le jouer va être apparaillé au playerone)
                                if (ListNewOpponent.Any())//on regard si il reste un adversaire potentielle
                                {
                                    var rng = new Random();
                                    var NewOpponent = ListNewOpponent.ElementAt(rng.Next(0, ListNewOpponent.Count()));//on choisie alléatoirement un adversaire parmi les adversaire potentielle

                                    var pairPlayer1 = new PairPlayer//on crée une nouveelle pair
                                    {
                                        PlayerOne = pair.PlayerTwo, PlayerTwo = NewOpponent//on pair le player 2 avec l'adversaire choisie aléatoirement
                                    };
                                    retour.Add(pairPlayer1);//on joute la nouvelle pair
                                    var pairPlayer2 = new PairPlayer//on crée une nouveelle pair
                                    {
                                        PlayerOne = pair.PlayerOne, PlayerTwo = Player//on pair le player1 avec le joueur que l'on tant de pairé
                                    };
                                    retour.Add(pairPlayer2);//on joute la nouvelle pair

                                    retour.Remove(pair);//on supprime l'ancienne pair
                                    OutReportedPlayer.Remove(NewOpponent);//on retire l'adversaire choisie au hazard des joueur reporté
                                    OutReportedPlayer.Remove(Player);//on retire joueur des joueur reporté

                                    break;
                                }
                            }
                        }
                    }
                }
            }



            return retour;
        }
        /// <summary>
        /// cherche et attribue un adversaire a un joueur
        /// </summary>
        /// <param name="Player">le joueur a qui on doit attribué un adversaire</param>
        /// <param name="PlayerOpponentList"> la liste des adversaire que le joueur a déjà affronté</param>
        /// <param name="AllRemainingPlayer"> la liste de tout les joueur restant a appareillé</param>
        /// <param name="pairPlayer"> le paramettre qui servirait a donné la paire de joueur crée</param>
        /// <returns>dit si un paire de joueur a pu être crée</returns>
        private static bool PairAPlayer(int Player, Dictionary<int, List<int>> PlayerOpponentList, List<int> AllRemainingPlayer,
            out PairPlayer pairPlayer)
        {
            pairPlayer = new PairPlayer();//initilaisation de la varible out.
            var PossibleOpponent = AllRemainingPlayer.Except(PlayerOpponentList[Player]).ToList(); //création de la liste de tout les adversaire que le jeoueur n'as pas encore rencontré
            PossibleOpponent.Remove(Player);// on retire le joueur de la liste des ces adversaire possible.

            if (PossibleOpponent.Count == 0)//si il n'y as pas d'adversaire dans la liste d'adversaire possible le pairing est impossible
            {
                return false;//on signal que le pairinga  échoué
            }
            else
            {
                pairPlayer.PlayerOne = Player;//on attribue le joueur comme le playerone

                var rng = new Random();
                pairPlayer.PlayerTwo = PossibleOpponent.ElementAt(rng.Next(0, PossibleOpponent.Count));// on atribue un adversaire de la liste au hazard comme le joueur 2;

                return true;// on signal que le pairing  a fonctionner
            }
        }

        /// <summary>
        /// on crée un liste avec tout les adversaire que le joueur a déjà rencontré
        /// </summary>
        /// <param name="Players">le joueur</param>
        /// <param name="matches">tout les match du tournoi</param>
        /// <returns></returns>
        private static Dictionary<int, List<int>> CreatePlayerOpponentList(List<int> Players, List<Match> matches)
        {
            Dictionary<int, List<int>> Retour = new Dictionary<int, List<int>>(); // création d'un dictonaire pour retrouvé a liste des adversaire d'un joueur 

            Retour.Clear();
            foreach (var Player in Players)
            {
                List<int> OpponentList = new List<int>(); //Crée la list des adversaire du joueur 'player'
                OpponentList.Clear();
                OpponentList.AddRange(matches.Where(m => m.PlayerOne == Player).Select(m => m.PlayerTwo).ToList());//ajoute a la liste tout les adversaire que le 'player' a eu en tant que 'PlayerOne.
                OpponentList.AddRange(matches.Where(m => m.PlayerTwo == Player).Select(m => m.PlayerOne).ToList());//ajoute a la liste tout les adversaire que le 'player' a eu en tant que 'PlayerTwo.

                Retour.Add(Player, OpponentList); // ajoute de la liste des adveraire du joueur.
            }

            return Retour;
        }
    }
}
