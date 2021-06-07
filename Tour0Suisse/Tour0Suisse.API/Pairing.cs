using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour0Suisse.Model;

namespace Tour0Suisse.API
{
    public static class AlgoPairing
    {
        ///  <summary>
        /// 
        /// fonction qui va faire automatiquement le pairing entre les joueurs
        /// 
        ///  
        ///  --1 on crée des groupes basés sur le nombre de victoire 
        ///  
        ///  --pour chaque groupe (en commençant par celui avec le plus de victoire) 
        ///  --2 on les tri (ASC) en fonction du nombre d'adversaire de leur qu'ils n'ont pas déjà rencontré. S’il y a des joueurs qui ont déjà rencontré tous les autres du groupe on le report dans le groupe suivant
        ///  --3 en commençant par le joueur reporté du groupe d'avant, dans l'ordre on leur attribue un adversaire (au hasard) qu'ils n'ont pas encore rencontré, si ce n'est pas possible on met le joueur en attente
        ///  --4 s’il n'y a que 1 joueur en attente on le report au group suivant,
        ///  --sinon on cherche une paire de joueur déjà appareillé qui pourrais correspondre à des joueurs en attente. et on répète le processus jusqu'à ne plus en trouvé.
        ///  -- s’il reste encore des joueurs en attente on les reports au groupe suivant.
        ///  
        ///  --5 pour le dernier groupe s’il n'y a qu’un joueur reporté on lui donne un bail (victoire gratuite).
        ///  -- sinon on recommence depuis le début mais en commençant par le groupe avec le moins de victoire.
        ///  
        ///  </summary>
        ///  <param name="Players">Liste des joueur encore dans le tournoi</param>
        ///  <param name="Classements">classement de tout les joueurs du tournoi</param>
        ///  <param name="Matches">liste de tout les match joué dans le tournoi</param>
        ///  <param name="RoundNumber">le numero de round</param>
        ///  <returns></returns>
        public static List<PairID> Pairing(List<int> Players, List<ViewScoreClassementTemporaire> Classements, List<ViewMatch> Matches, int RoundNumber)
        {
            List<PairID> retour = new(); // crée la variable qui se verra atrivué la liste de pairing qui doit être retourné.
            retour.Clear();
            List<ViewScoreClassementTemporaire> playerClassement = Classements.Where(c => Players.Contains(c.IdUser)).ToList(); // ne prend en considération plus que les joueur encore en list


            Dictionary<int, List<int>> playerOpponentList = CreatePlayerOpponentList(Players, Matches); // création d'un dictonaire pour retrouvé a liste des adversaire d'un joueur

            if (!DescPairing(Players, playerOpponentList, playerClassement, RoundNumber, out retour))
            {
                if (!ForcePairing(Players, playerOpponentList, retour, out retour))
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
        private static bool ForcePairing(List<int> players, Dictionary<int, List<int>> playerOpponentList, List<PairID> pairing, out List<PairID> retour)
        {
            List<int> NoPairedPlayer = players.Where(pl => !pairing.Exists(pa => pa.ID1 == pl || pa.ID2 == pl)).ToList();//crée la liste de tout les joueur non pairé
            retour = pairing;

            List<int> tempOutReportedPlayer = new();
            tempOutReportedPlayer.AddRange(NoPairedPlayer);//crée un doublons de la list des joueur reporté
            foreach (var Player in tempOutReportedPlayer)//pour tout les joueur reporté
            {
                if (NoPairedPlayer.Contains(Player))//on verifie que le joueur est encore dans les joueur reporté
                {
                    foreach (var pair in retour)//pour chaque pairing dejà fait
                    {
                        if (!playerOpponentList[Player].Contains(pair.ID1))//on regard si le playerone du pairing n'est pas dans la liste des adversaire déjà rencontré
                        {
                            var ListNewOpponent = NoPairedPlayer.Except(playerOpponentList[pair.ID2]).ToList();//on crée une liste d'advaisaire potentielle sur base des joueur reporté qui serait ne serait pas dans la liste des adversaire du playertwo de la pair
                            ListNewOpponent.Remove(Player);//on retire le joueur que l'on tente de pairé de la liste des potentille nouveau adversaire du playertwo (vu que le jouer va être apparaillé au playerone)
                            if (ListNewOpponent.Any())//on regard si il reste un adversaire potentielle
                            {
                                var rng = new Random();
                                var NewOpponent = ListNewOpponent.ElementAt(rng.Next(0, ListNewOpponent.Count));//on choisie alléatoirement un adversaire parmi les adversaire potentielle

                                var pairPlayer1 = new PairID//on crée une nouveelle pair
                                {
                                    ID1 = pair.ID2,
                                    ID2 = NewOpponent//on pair le player 2 avec l'adversaire choisie aléatoirement
                                };
                                retour.Add(pairPlayer1);//on joute la nouvelle pair
                                var pairPlayer2 = new PairID//on crée une nouveelle pair
                                {
                                    ID1 = pair.ID1,
                                    ID2 = Player//on pair le player1 avec le joueur que l'on tant de pairé
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
        /// <returns>signal si le pairing est complete</returns>
        public static bool DescPairing(List<int> players, Dictionary<int, List<int>> playerOpponentList, List<ViewScoreClassementTemporaire> playerClassement, int roundNumber, out List<PairID> retour)
        {
            retour = new List<PairID>();//inisialisation de la liste de pairing qui sera retourné
            List<int> inReportedPlayers = new();//création de la liste des joueur qui sont été réporté

            if ((roundNumber - 1) == 0)
            {
                retour.AddRange(PairingInGroup(players, playerOpponentList, out List<int> outReportedPlayers, inReportedPlayers));//on fait le pairing de chaque groupe et on le rajoute au pairing existant

                inReportedPlayers.Clear();
                inReportedPlayers.AddRange(outReportedPlayers); //on transmet la liste es joueur reporté
                outReportedPlayers.Clear();
            }
            else
            {
                ////Legacy version non optimiser
                //List<int>[]
                //    GroupPlayer =
                //        new List<int>[1 + ((roundNumber - 1) *
                //                      MPP)]; //création d'un tableau pour crée les group de liste de joueur 


                //for (int i = 0;
                //    i <= (roundNumber - 1) * MPP;
                //    i++) //atribution des joueur a chaque group leur correspondant en fonction de leur parcours
                //{
                //    GroupPlayer[i] = playerClassement
                //        .Where(p => (p.Victoire * PPV + p.Egaliter * PPE + p.Defaite * PPD) == i)
                //        .Select(s => s.IdUser).ToList();
                //}
                ////fin legacy non opti
                
                //// version plus opti car ne crée que le group qui on des joueur dedans
                var groupPlayer = playerClassement.GroupBy(j => j.Score).OrderByDescending(g => g.Key);


                foreach (var Group in groupPlayer)
                {
                    retour.AddRange(PairingInGroup(Group.Select(g=>g.IdUser).ToList(), playerOpponentList, out List<int> OutReportedPlayer, //avec la nouvel version il faut faire un select sur le group puis le remmettre en list.
                        inReportedPlayers)); //on fait le pairing de chaque groupe et on le rajoute au pairing existant    
                    inReportedPlayers.Clear();
                    inReportedPlayers.AddRange(OutReportedPlayer); //on transmet la liste es joueur reporté
                    OutReportedPlayer.Clear();
                }
            }

            switch (inReportedPlayers.Count)//en fonction du nombre de joueur qui n'ont pas pu etre pairé on : 
            {
                case 0:
                    return true;//ne fait rien car ils ont tous été pairé
                case 1:
                    retour.Add(new PairID//on donne un bye au seul joueur qui n'as pas été pairé (ccela est du a un nombre de joueur impaire
                    {
                        ID1 = inReportedPlayers.ElementAt(0),
                        ID2 = 0
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
        private static List<PairID> PairingInGroup(List<int> Players, Dictionary<int, List<int>> PlayerOpponentList, out List<int> OutReportedPlayer, List<int> InReportedPlayer = null)
        {
            List<PairID> retour = new(); // crée la variable qui se verra atrivué la liste de pairing qui doit être retourné.
            OutReportedPlayer = new List<int>(); //initilaization du paramtre out OutreportedPlayer
            OutReportedPlayer.Clear();// on s'assure que le parametre out est bien vide

            List<int> AllRemainingPlayer = new();
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
                            AllRemainingPlayer.Remove(pairPlayer.ID1);
                            AllRemainingPlayer.Remove(pairPlayer.ID2);

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
                        AllRemainingPlayer.Remove(pairPlayer.ID1);
                        AllRemainingPlayer.Remove(pairPlayer.ID2);

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
                List<int> tempOutReportedPlayer = new();
                tempOutReportedPlayer.AddRange(OutReportedPlayer);//crée un doublons de la list des joueur reporté
                foreach (var Player in tempOutReportedPlayer)//pour tout les joueur reporté
                {
                    if (OutReportedPlayer.Contains(Player))//on verifie que le joueur est encore dans les joueur reporté
                    {
                        foreach (var pair in retour)//pour chaque pairing dejà fait
                        {
                            if (!PlayerOpponentList[Player].Contains(pair.ID1))//on regard si le playerone du pairing n'est pas dans la liste des adversaire déjà rencontré
                            {
                                var ListNewOpponent = OutReportedPlayer.Except(PlayerOpponentList[pair.ID2]).ToList();//on crée une liste d'advaisaire potentielle sur base des joueur reporté qui serait ne serait pas dans la liste des adversaire du playertwo de la pair
                                ListNewOpponent.Remove(Player);//on retire le joueur que l'on tente de pairé de la liste des potentille nouveau adversaire du playertwo (vu que le jouer va être apparaillé au playerone)
                                if (ListNewOpponent.Any())//on regard si il reste un adversaire potentielle
                                {
                                    var rng = new Random();
                                    var NewOpponent = ListNewOpponent.ElementAt(rng.Next(0, ListNewOpponent.Count));//on choisie alléatoirement un adversaire parmi les adversaire potentielle

                                    var pairPlayer1 = new PairID//on crée une nouveelle pair
                                    {
                                        ID1 = pair.ID2,
                                        ID2 = NewOpponent//on pair le player 2 avec l'adversaire choisie aléatoirement
                                    };
                                    retour.Add(pairPlayer1);//on joute la nouvelle pair
                                    var pairPlayer2 = new PairID//on crée une nouveelle pair
                                    {
                                        ID1 = pair.ID1,
                                        ID2 = Player//on pair le player1 avec le joueur que l'on tant de pairé
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
            out PairID pairPlayer)
        {
            pairPlayer = new PairID();//initilaisation de la varible out.
            var PossibleOpponent = AllRemainingPlayer.Except(PlayerOpponentList[Player]).ToList(); //création de la liste de tout les adversaire que le jeoueur n'as pas encore rencontré
            PossibleOpponent.Remove(Player);// on retire le joueur de la liste des ces adversaire possible.

            if (PossibleOpponent.Count == 0)//si il n'y as pas d'adversaire dans la liste d'adversaire possible le pairing est impossible
            {
                return false;//on signal que le pairinga  échoué
            }
            else
            {
                pairPlayer.ID1 = Player;//on attribue le joueur comme le playerone

                var rng = new Random();
                pairPlayer.ID2 = PossibleOpponent.ElementAt(rng.Next(0, PossibleOpponent.Count));// on atribue un adversaire de la liste au hazard comme le joueur 2;

                return true;// on signal que le pairing  a fonctionner
            }
        }

        /// <summary>
        /// on crée un liste avec tout les adversaire que le joueur a déjà rencontré
        /// </summary>
        /// <param name="Players">le joueur</param>
        /// <param name="matches">tout les match du tournoi</param>
        /// <returns></returns>
        private static Dictionary<int, List<int>> CreatePlayerOpponentList(List<int> Players, List<ViewMatch> matches)
        {
            Dictionary<int, List<int>> Retour = new(); // création d'un dictonaire pour retrouvé a liste des adversaire d'un joueur 

            Retour.Clear();
            foreach (var Player in Players)
            {
                List<int> OpponentList = new(); //Crée la list des adversaire du joueur 'player'
                OpponentList.Clear();
                OpponentList.AddRange(matches.Where(m => m.IdPlayer1 == Player).Select(m => m.IdPlayer2).ToList());//ajoute a la liste tout les adversaire que le 'player' a eu en tant que 'PlayerOne.
                OpponentList.AddRange(matches.Where(m => m.IdPlayer2 == Player).Select(m => m.IdPlayer1).ToList());//ajoute a la liste tout les adversaire que le 'player' a eu en tant que 'PlayerTwo.

                Retour.Add(Player, OpponentList); // ajoute de la liste des adveraire du joueur.
            }

            return Retour;
        }
    }
}
