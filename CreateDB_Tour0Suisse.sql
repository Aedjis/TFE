use master;
Go

--_________Drop la db si elle existe___________
IF EXISTS (
  SELECT * 
    FROM sys.databases 
   WHERE name = N'Tour0Suisse'
)
  DROP DATABASE [Tour0Suisse]
GO
--________________

--___________DEBUT CREATION DB_______________
CREATE DATABASE [Tour0Suisse]
ON PRIMARY
	(NAME = 'Utilisateur',
	  FILENAME = N'E:\AllDB\Tour0Suisse\Data\Tour0Suisse.mdf',
          SIZE = 5MB,          
          FILEGROWTH = 10MB),
FILEGROUP Reservation
	( NAME = 'Tournoi',
	  FILENAME = N'E:\AllDB\Tour0Suisse\Data\Reservation.ndf',
          SIZE = 50MB,          
          FILEGROWTH = 20%),
FILEGROUP RESTE
	( NAME = 'Reste',
	  FILENAME = N'E:\AllDB\Tour0Suisse\Data\Reste.ndf',
          SIZE = 10MB,
          MAXSIZE = 250MB,
          FILEGROWTH = 50MB)
LOG ON
	( NAME = 'Tour0Suisse_Log',
	  FILENAME = N'E:\AllDB\Tour0Suisse\Log\Tour0Suisse_Log.ldf',
          SIZE = 10MB,
          FILEGROWTH = 10MB)
GO
--________________FIN CREATION DB________________

--___________________________________________________

--______________UTILISER LA DB____________
Use [Tour0Suisse];
Go
--_____________________________________


--______________________DEBUT DE CREATION DE TYPE_______________________________

--______________________FIN DE CREATION DE TYPE_______________________________
--____________________________________________________________________________________________

--_____________DEBUT CREATION TABLE_______________________

CREATE TABLE [Utilisateur] (
ID_User INT NOT NULL IDENTITY,
Pseudo VARCHAR(50) NOT NULL, 
Email VARCHAR(256) NOT NULL,
[Password] VARCHAR(50) NOT NULL,
Organizer BIT NOT NULL DEFAULT(0),

CONSTRAINT PK_User__XXXX PRIMARY KEY(ID_User)
) ON Utilisateur
GO;

CREATE TABLE [PseudoIG] (
ID_User INT NOT NULL,
ID_Game INT NOT NULL,
IG_Pseudo VARCHAR(50) NOT NULL,

CONSTRAINT PK_PseudoIG__XXXX PRIMARY KEY(ID_User, ID_Game)
) ON Utilisateur
GO;

CREATE TABLE [Tournoi] (
ID_Tournament INT NOT NULL IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[Date] DATETIME NOT NULL,
ID_Game INT NOT NULL,

CONSTRAINT PK_Tournament__XXXX PRIMARY KEY(ID_Tournament)
)ON Tournoi
GO;

CREATE TABLE [Jeu](
ID_Game INT NOT NULL IDENTITY,
[Name] VARCHAR(50) NOT NULL,

CONSTRAINT PK_Game__XXXX PRIMARY KEY(ID_Game)
)ON Reste
GO;

CREATE TABLE [Deck](
ID_Deck INT NOT NULL IDENTITY,
DeckList Text NOT NULL,
ID_Game INT NOT NULL,

CONSTRAINT PK_Deck__XXXX PRIMARY KEY(ID_Deck)
)ON Reste
GO;

CREATE TABLE [Resultat](
ID_Tournament INT NOT NULL,
ID_User INT NOT NULL,
[Rank] INT NOT NULL,
Score INT NOT NULL,
FirstTieBreake INT NOT NULL,
SecondTieBreake INT NOT NULL,
ThirdTieBreake INT NOT NULL,
LastTieBreake INT NULL,
LastTieBreakeRules VARCHAR(50) NULL,

CONSTRAINT PK_Result__XXXX PRIMARY KEY(ID_Tournament, ID_User)
)ON Tournoi
GO;

CREATE TABLE [Round](
ID_Tournament INT NOT NULL,
RoundNumber INT NOT NULL,
StartRound DATETIME NOT NULL,

CONSTRAINT PK_Round__XXXX PRIMARY KEY(ID_Tournament, RoundNumber)
)ON Tournoi
GO;

CREATE TABLE [Match](
ID_Tournament INT NOT NULL,
RoundNumber INT NOT NULL,
ID_PlayerOne INT NOT NULL,
ID_PlayerTwo INT NOT NULL,

CONSTRAINT PK_Match__XXXX PRIMARY KEY(ID_Tournament, RoundNumber, ID_PlayerOne, ID_PlayerTwo) -- besoin de l'id que de un joureur
)ON Tournoi
GO;

CREATE TABLE [Partie](
ID_Tournament INT NOT NULL,
RoundNumber INT NOT NULL,
ID_PlayerOne INT NOT NULL,
ID_PlayerTwo INT NOT NULL,
PartNumber INT NOT NULL,
ID_Deck_PlayerOne INT NOT NULL,
ID_Deck_PlayerTwo INT NOT NULL,
ResultPart INT NULL,

CONSTRAINT PK_Part__XXXX PRIMARY KEY(ID_Tournament, RoundNumber, ID_PlayerOne, ID_PlayerTwo, PartNumber) -- besoin de l'id que de un joureur
)ON Tournoi
GO;

CREATE TABLE [Organisateur](
ID_Tournoi INT NOT NULL,
ID_User INT NOT NULL,

CONSTRAINT PK_Organizer__XXXX PRIMARY KEY(ID_Tournoi, ID_User)
)ON Tournoi
GO;

CREATE TABLE [Joueur](
ID_Tournoi INT NOT NULL,
ID_User INT NOT NULL,

CONSTRAINT PK_Player__XXXX PRIMARY KEY(ID_Tournoi, ID_User)
)ON Tournoi
GO;

CREATE TABLE [DeckJoueur](
ID_Tournoi INT NOT NULL,
ID_User INT NOT NULL,
ID_Deck INT NOT NULL,

CONSTRAINT PK_Organizer__XXXX PRIMARY KEY(ID_Tournoi, ID_User, ID_Deck)
)ON Tournoi
GO;
--____________FIN CREATION TABLE_________________________

--____________________________________________________________________________

--_____________DEBUT CREATION DES LIENS ENTRE LES TABLES________

ALTER TABLE [PseudoIG]
ADD CONSTRAINT FK_PseudoIG_Utilisateur__XXXX	FOREIGN KEY (ID_User)
												REFERENCES [Utilisateur](ID_User)
GO;

ALTER TABLE [PseudoIG]
ADD CONSTRAINT FK_PseudoIG_Jeu__XXXX	FOREIGN KEY (ID_Game)
										REFERENCES [Jeu](ID_Game)
GO;

ALTER TABLE [Tournoi]
ADD CONSTRAINT FK_Tournoi_Jeu__XXXX	FOREIGN KEY (ID_Game)
									REFERENCES [Jeu](ID_Game)
GO;

ALTER TABLE [Deck]
ADD CONSTRAINT FK_Deck_Jeu__XXXX	FOREIGN KEY (ID_Game)
									REFERENCES [Jeu](ID_Game)
GO;

ALTER TABLE [Resulta]
ADD CONSTRAINT FK_Resulat_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
										REFERENCES [Tournoi](ID_Tournament)
GO;

ALTER TABLE [Resulta]
ADD CONSTRAINT FK_Resulat_Utilisateur__XXXX	FOREIGN KEY (ID_User)
											REFERENCES [Utilisateur](ID_User)
GO;

ALTER TABLE [Round]
ADD CONSTRAINT FK_Round_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
										REFERENCES [Tournoi](ID_Tournament)
GO;

ALTER TABLE [Match]
ADD CONSTRAINT FK_Match_Round__XXXX	FOREIGN KEY (ID_Tournament, RoundNumber)
									REFERENCES [Round](ID_Tournament, RoundNumber)
GO;

ALTER TABLE [Match]
ADD CONSTRAINT FK_Match_Utilisateur__1XXXX	FOREIGN KEY (ID_User)
											REFERENCES [Utilisateur](ID_User)
GO;

ALTER TABLE [Match]
ADD CONSTRAINT FK_Match_Utilisateur__2XXXX	FOREIGN KEY (ID_User)
											REFERENCES [Utilisateur](ID_User)
GO;

ALTER TABLE [Partie]
ADD CONSTRAINT FK_Part_Match__XXXX	FOREIGN KEY (ID_Tournament, RoundNumber, ID_PlayerOne, ID_PlayerTwo)
									REFERENCES [Match](ID_Tournament, RoundNumber, ID_PlayerOne, ID_PlayerTwo)
GO;

ALTER TABLE [Partie]
ADD CONSTRAINT FK_Part_Deck__1XXXX	FOREIGN KEY (ID_Deck)
									REFERENCES [Deck](ID_Deck)
GO;

ALTER TABLE [Partie]
ADD CONSTRAINT FK_Part_Deck__2XXXX	FOREIGN KEY (ID_Deck)
									REFERENCES [Deck](ID_Deck)
GO;

ALTER TABLE [Organisateur]
ADD CONSTRAINT FK_Organisateur_Utilisateur__XXXX	FOREIGN KEY (ID_User)
											REFERENCES [User](ID_User)
GO;

ALTER TABLE [Organisateur]
ADD CONSTRAINT FK_Organisateur_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
												REFERENCES [Tournoi](ID_Tournament)
GO;

ALTER TABLE [Joueur]
ADD CONSTRAINT FK_Joueur_Utilisateur__XXXX	FOREIGN KEY (ID_User)
											REFERENCES [User](ID_User)
GO;

ALTER TABLE [Joueur]
ADD CONSTRAINT FK_Joueur_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
										REFERENCES [Tournoi](ID_Tournament)
GO;

ALTER TABLE [DeckJoueur]
ADD CONSTRAINT FK_DeckJoueur_Utilisateur__XXXX	FOREIGN KEY (ID_User)
												REFERENCES [User](ID_User)
GO;

ALTER TABLE [[DeckJoueur]
ADD CONSTRAINT FK_DeckJoueur_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
											REFERENCES [Tournoi](ID_Tournament)
GO;

ALTER TABLE [[DeckJoueur]
ADD CONSTRAINT FK_DeckJoueur_Deck__XXXX	FOREIGN KEY (ID_Deck)
										REFERENCES [Deck](ID_Deck)
GO;