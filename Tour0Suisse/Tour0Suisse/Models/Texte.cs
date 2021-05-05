using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tour0Suisse.Web.Models
{
    public interface ITexte
    {
    }


    public class TexteFr : ITexte
    {
        #region Singleton

        private static TexteFr instance = null;

        TexteFr()
        {
        }

        public static TexteFr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TexteFr();
                }

                return instance;
            }
        }

        #endregion


        #region Layout

        #region NavBar

        public readonly string Layout_NavBar_Home = "Home";
        public readonly string Layout_NavBar_TournoiListVisiteur = "Tournoi";
        public readonly string Layout_NavBar_TournoiListAdmin = "Admin";
        public readonly string Layout_NavBar_LogOff = "Déconnexion";
        public readonly string Layout_NavBar_LogIn = "Connexion";
        public readonly string Layout_NavBar_SignIn = "Inscription";

        #endregion

        #endregion

        #region Admin

        #region EndTournoi

        public readonly string Admin_EndTournoi_Submit_End = "Terminer le tournoi";
        public readonly string Admin_EndTournoi_Back = "Retour";

        #endregion

        #region Index

        public readonly string Admin_Index_Details = "Détails";
        public readonly string Admin_Index_Edit = "Modifier";
        public readonly string Admin_Index_Admin = "Admin";

        #endregion

        #region Match

        public readonly string Admin_Match_TitleDeckJ1 = "Decks du joueur 1";
        public readonly string Admin_Match_TitleDeckJ2 = "Decks du joueur 2";
        public readonly string Admin_Match_SubmitSave = "Sauvegarder";
        public readonly string Admin_Match_Back = "Retour";

        #endregion

        #region Tournoi

        public readonly string Admin_Tournoi_NbJoueur = "Nombre de joueurs";
        public readonly string Admin_Tournoi_SubmitStart = "Commencer tournoi";
        public readonly string Admin_Tournoi_DisplayDebut = "Début de ronde";
        public readonly string Admin_Tournoi_DisplayFin = "Fin de ronde";
        public readonly string Admin_Tournoi_DisplayJ1 = "Joueur 1";
        public readonly string Admin_Tournoi_DisplayJ1Pseudo = "Pseudo du joueur 1";
        public readonly string Admin_Tournoi_DisplayScore = "Score";
        public readonly string Admin_Tournoi_DisplayJ2 = "Joueur 2";
        public readonly string Admin_Tournoi_DisplayJ2Pseudo = "Pseudo du joueur 2";
        public readonly string Admin_Tournoi_SubmitPairing = "Créer les matchs";
        public readonly string Admin_Tournoi_SubmitEndRound = "Finir la ronde";
        public readonly string Admin_Tournoi_SubmitNextRound = "Créer la ronde";
        public readonly string Admin_Tournoi_SubmitEndTournoi = "Finir le tournoi";
        public readonly string Admin_Tournoi_Details = "Détails";
        public readonly string Admin_Tournoi_Index = "Retour à la iste de vos tournois";

        #endregion

        #endregion

        #region Home

        public readonly string Home_Index_Details = "Détails";

        #endregion

        #region Tournoi

        #region Create

        public readonly string Tournoi_Create_Title = "Tournoi";
        public readonly string Tournoi_Create_DotationTop = "Top";
        public readonly string Tournoi_Create_DotationGain = "Gain";
        public readonly string Tournoi_Create_DotationAdd = "Ajouter une dotation";
        public readonly string Tournoi_Create_DotationRemove = "Supprimer la dèrnière dotation";
        public readonly string Tournoi_Create_SubmitCreate = "Créer";
        public readonly string Tournoi_Create_Retour = "Retour";

        #endregion

        #region Delete

        public readonly string Tournoi_Delete_Title = "Tournoi";
        public readonly string Tournoi_Delete_Warrning = "Êtes-Vous sur de vouloir supprimer ce tournoi?";
        public readonly string Tournoi_Delete_SubmitDelete = "Supprimer";
        public readonly string Tournoi_Delete_Retour = "Retour aux détails";
        public readonly string Tournoi_Delete_Index = "Retour aux tournois";

        #endregion

        #region Details

        public readonly string Tournoi_Details_Title = "Tournoi";
        public readonly string Tournoi_Details_Listing = "Détails";
        public readonly string Tournoi_Details_ListingToggleJoueur = "Participants";
        public readonly string Tournoi_Details_ListingToggleClassement = "Classement";
        public readonly string Tournoi_Details_ListingToggleRound = "Rondes";
        public readonly string Tournoi_Details_ListingToggleResult = "Résultats";
        public readonly string Tournoi_Details_ListingToggleAdmin = "Admins";
        public readonly string Tournoi_Details_ListingToggleDotation = "Dotations";
        public readonly string Tournoi_Details_ListingJoueurDisplayNom = "Joueur";
        public readonly string Tournoi_Details_ListingJoueurDisplayPseudo = "Pseudo";
        public readonly string Tournoi_Details_ListingJoueurDisplayDate = "Date d'inscription";
        public readonly string Tournoi_Details_ListingJoueurDisplayCheckin = "Check-In";
        public readonly string Tournoi_Details_ListingJoueurDisplayDrop = "Drop";
        public readonly string Tournoi_Details_ListingClassementDisplayNom = "Joueur";
        public readonly string Tournoi_Details_ListingClassementDisplayPseudo = "Pseudo";
        public readonly string Tournoi_Details_ListingClassementDisplayScore = "Score";
        public readonly string Tournoi_Details_ListingClassementDisplayV = "Victoire";
        public readonly string Tournoi_Details_ListingClassementDisplayL = "Défaite";
        public readonly string Tournoi_Details_ListingClassementDisplayD = "Égaliter";
        public readonly string Tournoi_Details_ListingRondeToggle = "Ronde numéro";
        public readonly string Tournoi_Details_ListingRondeStart = "Début de ronde";
        public readonly string Tournoi_Details_ListingRondeEnd = "Fin de ronde";
        public readonly string Tournoi_Details_ListingRondeDisplayJ1 = "Joueur 1";
        public readonly string Tournoi_Details_ListingRondeDisplayJ1Pseudo = "Pseudo du joueur 1";
        public readonly string Tournoi_Details_ListingRondeDisplayScore = "Score";
        public readonly string Tournoi_Details_ListingRondeDisplayJ2 = "Joueur 2";
        public readonly string Tournoi_Details_ListingRondeDisplayJ2Pseudo = "Pseudo du joueur 2";
        public readonly string Tournoi_Details_ListingResultDisplayRank = "Place";
        public readonly string Tournoi_Details_ListingResultDisplayJoueur = "Joueur";
        public readonly string Tournoi_Details_ListingResultDisplayScore = "Score";
        public readonly string Tournoi_Details_ListingResultDisplayPseudo = "Pseudo du joueur";
        public readonly string Tournoi_Details_ListingResultDisplayGain = "Gain";
        public readonly string Tournoi_Details_ListingResultDisplayTB = "Tiebreaker";
        public readonly string Tournoi_Details_ListingResultDisplayTBA = "Tiebreaker additionnel";
        public readonly string Tournoi_Details_ListingResultDisplayTBR = "Régle du tiebreaker additionnel";
        public readonly string Tournoi_Details_ListingAdminDisplayName = "Admin";
        public readonly string Tournoi_Details_ListingAdminDisplayLvl = "Level";
        public readonly string Tournoi_Details_ListingAdminDisplayCnt = "Contacter";
        public readonly string Tournoi_Details_ListingDotationDisplayTop = "Top";
        public readonly string Tournoi_Details_ListingDotationDisplayGain = "Gain";
        public readonly string Tournoi_Details_Edit = "Modifier";
        public readonly string Tournoi_Details_Admin = "Admin";
        public readonly string Tournoi_Details_EditDeck = "Modifier mes decks";
        public readonly string Tournoi_Details_Unregister = "Se désinscrire";
        public readonly string Tournoi_Details_Register = "S'inscrire";
        public readonly string Tournoi_Details_Index = "Retour à la liste des tournois";

        #endregion

        #region Edit

        public readonly string Tournoi_Edit_Title = "Tournoi";
        public readonly string Tournoi_Edit_WarrningDate = "Il est déconseiller de changer la date d'un tournoi!";
        public readonly string Tournoi_Edit_DotationDisplayTop = "Top";
        public readonly string Tournoi_Edit_DotationDisplayGain = "Gain";
        public readonly string Tournoi_Edit_DotationAdd = "Ajouter une dotation";
        public readonly string Tournoi_Edit_DotationRemove = "Supprimer la dèrnière dotation";
        public readonly string Tournoi_Edit_SubmitSave = "Sauvegarder";
        public readonly string Tournoi_Edit_Retour = "Retour";

        #endregion

        #region EditDeck
        
        public readonly string Tournoi_EditDeck_SubmitSave = "Sauvegarder";
        public readonly string Tournoi_EditDeck_Retour = "Retour";

        #endregion

        #region Index

        public readonly string Tournoi_Index_BtnNew = "Créer un nouveau tournoi";
        public readonly string Tournoi_Index_Detail = "Détails";

        #endregion

        #region Match

        public readonly string Tournoi_Match_TitleDeckJ1 = "Decks du joueur 1";
        public readonly string Tournoi_Match_TitleDeckJ2 = "Decks du joueur 2";
        public readonly string Tournoi_Match_SubmitSave = "Sauvegarder";
        public readonly string Tournoi_Match_Back = "Retour";

        #endregion

        #region Register

        public readonly string Tournoi_Register_SubTitle = "Decks";
        public readonly string Tournoi_Register_SubmitCreate = "S'inscrire";
        public readonly string Tournoi_Register_Back = "Retour au tournoi";
        public readonly string Tournoi_Register_Index = "Retour à la liste des tournois";

        #endregion

        #region Unregister

        public readonly string Tournoi_Unregister_Warning = "Voulez vous vraiment vous désinscrire?";
        public readonly string Tournoi_Unregister_SubTitle = "Tournoi";
        public readonly string Tournoi_Unregister_SubmitDelete = "Se désinscrire";
        public readonly string Tournoi_Unregister_Back = "Retour au tournoi";
        public readonly string Tournoi_Unregister_Index = "Retour à la liste des tournois";

        #endregion

        #endregion

        #region User

        #region AddGamePseudo

        public readonly string User_AddGamePseudo_BtnAdd = "Sauvegarder";
        public readonly string User_AddGamePseudo_Back = "Retourner au profil";

        #endregion

        #region Connexion

        public readonly string User_Connexion_Login = "Connexion";

        #endregion

        #region Delete
        
        public readonly string User_Delete_Warrning = "Êtes-Vous sur de vouloir supprimer votre compte?";
        public readonly string User_Delete_SubmitDelete = "Supprimer";
        public readonly string User_Delete_Retour = "Retour au profil";

        #endregion

        #region Inscription

        public readonly string User_Inscription_PasswordWarning =
            "Le mot de passe doit contenir au moins : un nombre, une minuscule, une majuscule et 8 caractères!";

        public readonly string User_Inscription_PasswordWarning2 = "Les mots de passe ne concordent pas!";
        public readonly string User_Inscription_COnfPass = "Confirmation du votre mot de passe : ";
        public readonly string User_Inscription_SubmitSave = "Créer votre compte";

        #endregion

        #region InscpritionConf

        public readonly string User_InscriptionConf_Message = "Inscription réussie";

        #endregion

        #region Profil

        public readonly string User_Profil_BtnAddPseudo = "Ajouter ou modifier des pseudos";
        public readonly string User_Profil_BtnEdit = "Modifier votre profil";
        public readonly string User_Profil_Retour = "Retour à la liste des utilisateurs";

        #endregion

        #region EditProfil

        public readonly string User_EditProfil_PasswordWarning =
            "Le mot de passe doit contenir au moins : un nombre, une minuscule, une majuscule et 8 caractères!";

        public readonly string User_EditProfil_PasswordWarning2 = "Les mots de passe ne concordent pas!";
        public readonly string User_EditProfil_PasswordWarning3 = "Le nouveau mot de passe ne peut pas être l'ancien";
        public readonly string User_EditProfil_PasswordWarning4 = ", si vous ne voulez pas changer de mot de passe laisser vide!";
        public readonly string User_EditProfil_COnfPass = "Confirmation de votre mot de passe : ";
        public readonly string User_EditProfil_BtnSave = "Confirmer les modifications";

        #endregion

        #endregion
    }
}
