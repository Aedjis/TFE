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


--___________création des dossier si inexistant_________________________

drop table if exists #ResultSet;
CREATE  TABLE #ResultSet (Directory varchar(200))

 INSERT INTO #ResultSet
 EXEC master.dbo.xp_subdirs 'E:\AllDB\'

 if not exists(Select * FROM #ResultSet where Directory = 'Tour0Suisse')
EXEC master.sys.xp_create_subdir 'E:\AllDB\Tour0Suisse' ;

 INSERT INTO #ResultSet
 EXEC master.dbo.xp_subdirs 'E:\AllDB\Tour0Suisse\'
 if not exists(Select * FROM #ResultSet where Directory = 'Data')
EXEC master.sys.xp_create_subdir 'E:\AllDB\Tour0Suisse\Data';
 if not exists(Select * FROM #ResultSet where Directory = 'Log')
EXEC master.sys.xp_create_subdir 'E:\AllDB\Tour0Suisse\Log';

GO
--_____________________________


--___________DEBUT CREATION DB_______________
CREATE DATABASE [Tour0Suisse]
ON PRIMARY
	(NAME = 'Utilisateur',
	  FILENAME = N'E:\AllDB\Tour0Suisse\Data\Tour0Suisse.mdf',
          SIZE = 5MB,          
          FILEGROWTH = 10MB),
FILEGROUP Tournoi
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

CREATE TYPE ID_List AS TABLE(
ID INT NOT NULL PRIMARY KEY
);
GO

CREATE TYPE List_Deck AS TABLE(
DeckList TEXT NOT NULL
);
GO

CREATE TYPE List_Pairing AS TABLE(
ID_PlayerOne INT,
ID_PlayerTwo INT
);
GO

--______________________FIN DE CREATION DE TYPE_______________________________
--____________________________________________________________________________________________

--_____________DEBUT CREATION TABLE_______________________

CREATE TABLE [Utilisateur] (
ID_User INT NOT NULL IDENTITY(1,1),
Pseudo VARCHAR(50) NOT NULL, 
Email VARCHAR(256) NOT NULL,
[Password] BINARY(64) NOT NULL, -- le mot de passe est haché en SHA2_512 (HASHBYTES('SHA2_512', @pPassword))
Organizer BIT NOT NULL DEFAULT(0),
[DELETED] date null DEFAULT(null),

CONSTRAINT PK_User__XXXX PRIMARY KEY(ID_User)
)
GO

CREATE TABLE [PseudoIG] (
ID_User INT NOT NULL,
ID_Game INT NOT NULL,
IG_Pseudo VARCHAR(50) NOT NULL,

CONSTRAINT PK_PseudoIG__XXXX PRIMARY KEY(ID_User, ID_Game)
)
GO

CREATE TABLE [Tournoi] (
ID_Tournament INT NOT NULL IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
[Date] DATETIME NOT NULL,
[Desciption] TEXT NULL,
ID_Game INT NOT NULL,
[MaxNumberPlayer] INT NULL DEFAULT(NULL),
[DeckListNumber] INT NOT NULL DEFAULT(3),
[PPWin] INT NOT NULL DEFAULT(2),
[PPDraw] INT NOT NULL DEFAULT(1),
[PPLose] INT NOT NULL DEFAULT(0),
[Over] BIT NOT NULL DEFAULT(0),
[DELETED] date null DEFAULT(null),

CONSTRAINT PK_Tournament__XXXX PRIMARY KEY(ID_Tournament)
)ON Tournoi
GO



CREATE TABLE [Dotation] (
ID_Tournament INT NOT NULL,
Place INT NOT NULL,
Gain INT NOT NULL DEFAULT(0)

CONSTRAINT PK_Dotationt__XXXX PRIMARY KEY(ID_Tournament)
)ON Tournoi
GO

CREATE TABLE [Jeu](
ID_Game INT NOT NULL IDENTITY,
[Name] VARCHAR(50) NOT NULL,
DELETED BIT DEFAULT(0),

CONSTRAINT PK_Game__XXXX PRIMARY KEY(ID_Game)
)ON Reste
GO

CREATE TABLE [Deck](
ID_Deck INT NOT NULL IDENTITY(1,1),
DeckList Text NOT NULL,
ID_Game INT NOT NULL,

CONSTRAINT PK_Deck__XXXX PRIMARY KEY(ID_Deck)
)ON Reste
GO

CREATE TABLE [Resultat](
ID_Tournament INT NOT NULL,
ID_User INT NOT NULL,
[Rank] INT NOT NULL,
Gain INT NOT NULL DEFAULT(0),
Score INT NOT NULL,
TieBreaker INT NOT NULL,
AdditionalTieBreaker INT NULL,
AdditionalTieBreakerRules VARCHAR(50) NULL,

CONSTRAINT PK_Result__XXXX PRIMARY KEY(ID_Tournament, ID_User)
)ON Tournoi
GO

CREATE TABLE [Round](
ID_Tournament INT NOT NULL,
RoundNumber INT NOT NULL,
StartRound DATETIME NULL,
EndRound DATETIME NULL,

CONSTRAINT PK_Round__XXXX PRIMARY KEY(ID_Tournament, RoundNumber)
)ON Tournoi
GO

CREATE TABLE [Match](
ID_Tournament INT NOT NULL,
RoundNumber INT NOT NULL,
ID_PlayerOne INT NOT NULL,
ID_PlayerTwo INT NULL,

CONSTRAINT PK_Match__XXXX PRIMARY KEY(ID_Tournament, RoundNumber, ID_PlayerOne) -- besoin de l'id que de un joureur
)ON Tournoi
GO

CREATE TABLE [Partie](
ID_Tournament INT NOT NULL,
RoundNumber INT NOT NULL,
ID_PlayerOne INT NOT NULL,
ID_PlayerTwo INT NOT NULL,
PartNumber INT NOT NULL,
ID_Deck_PlayerOne INT NOT NULL,
ID_Deck_PlayerTwo INT NOT NULL,
ResultPart TINYINT NULL,

CONSTRAINT PK_Part__XXXX PRIMARY KEY(ID_Tournament, RoundNumber, ID_PlayerOne, PartNumber) -- besoin de l'id que de un joureur
)ON Tournoi
GO

CREATE TABLE [Organisateur](
ID_Tournament INT NOT NULL,
ID_User INT NOT NULL,
[Level] int default(1)

CONSTRAINT PK_Organizer__XXXX PRIMARY KEY(ID_Tournament, ID_User)
)ON Tournoi
GO

CREATE TABLE [Joueur](  --fait doublons avec le tablme deck joueur
ID_Tournament INT NOT NULL,
ID_User INT NOT NULL,
RegisterDate DateTime DEFAULT(GETUTCDATE()),
CheckIn DateTime NULL,
[Drop] BIT NOT NULL DEFAULT(0),

CONSTRAINT PK_Player__XXXX PRIMARY KEY(ID_Tournament, ID_User)
)ON Tournoi
GO

CREATE TABLE [DeckJoueur](
ID_Tournament INT NOT NULL,
ID_User INT NOT NULL,
ID_Deck INT NOT NULL,

CONSTRAINT PK_DeckPlayer__XXXX PRIMARY KEY(ID_Tournament, ID_User, ID_Deck)
)ON Tournoi
GO
--____________FIN CREATION TABLE_________________________

--____________________________________________________________________________

--____________DEBUT CREATION CONTRAINT_____________________

ALTER TABLE [Utilisateur]
ADD CONSTRAINT CK_Utilisateur_EmailValid__XXXX	CHECK (Email LIKE '%_@__%.__%')
GO

ALTER TABLE [Utilisateur]
ADD CONSTRAINT UK_Utilisateur_EmailUnique__XXXX	UNIQUE (Email)
GO

--____________FIN CREATION CONTRAINT_________________________

--____________________________________________________________________________

--_____________DEBUT CREATION DES LIENS ENTRE LES TABLES________

ALTER TABLE [PseudoIG]
ADD CONSTRAINT FK_PseudoIG_Utilisateur__XXXX	FOREIGN KEY (ID_User)
												REFERENCES [Utilisateur](ID_User)
GO

ALTER TABLE [PseudoIG]
ADD CONSTRAINT FK_PseudoIG_Jeu__XXXX	FOREIGN KEY (ID_Game)
										REFERENCES [Jeu](ID_Game)
GO

ALTER TABLE [Tournoi]
ADD CONSTRAINT FK_Tournoi_Jeu__XXXX	FOREIGN KEY (ID_Game)
									REFERENCES [Jeu](ID_Game)
GO

ALTER TABLE [Dotation]
ADD CONSTRAINT FK_Dotation_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
											REFERENCES [Tournoi](ID_Tournament)
GO

ALTER TABLE [Deck]
ADD CONSTRAINT FK_Deck_Jeu__XXXX	FOREIGN KEY (ID_Game)
									REFERENCES [Jeu](ID_Game)
GO

ALTER TABLE [Resultat]
ADD CONSTRAINT FK_Resulat_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
										REFERENCES [Tournoi](ID_Tournament)
GO

ALTER TABLE [Resultat]
ADD CONSTRAINT FK_Resulat_Utilisateur__XXXX	FOREIGN KEY (ID_User)
											REFERENCES [Utilisateur](ID_User)
GO

ALTER TABLE [Round]
ADD CONSTRAINT FK_Round_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
										REFERENCES [Tournoi](ID_Tournament)
GO

ALTER TABLE [Match]
ADD CONSTRAINT FK_Match_Round__XXXX	FOREIGN KEY (ID_Tournament, RoundNumber)
									REFERENCES [Round](ID_Tournament, RoundNumber)
GO

ALTER TABLE [Match]
ADD CONSTRAINT FK_Match_Utilisateur__1XXXX	FOREIGN KEY (ID_PlayerOne)
											REFERENCES [Utilisateur](ID_User)
GO

ALTER TABLE [Match]
ADD CONSTRAINT FK_Match_Utilisateur__2XXXX	FOREIGN KEY (ID_PlayerTwo)
											REFERENCES [Utilisateur](ID_User)
GO

ALTER TABLE [Partie]
ADD CONSTRAINT FK_Part_Match__XXXX	FOREIGN KEY (ID_Tournament, RoundNumber, ID_PlayerOne)
									REFERENCES [Match](ID_Tournament, RoundNumber, ID_PlayerOne)
GO

ALTER TABLE [Partie]
ADD CONSTRAINT FK_Part_Deck__1XXXX	FOREIGN KEY (ID_Deck_PlayerOne)
									REFERENCES [Deck](ID_Deck)
GO

ALTER TABLE [Partie]
ADD CONSTRAINT FK_Part_Deck__2XXXX	FOREIGN KEY (ID_Deck_PlayerTwo)
									REFERENCES [Deck](ID_Deck)
GO

ALTER TABLE [Organisateur]
ADD CONSTRAINT FK_Organisateur_Utilisateur__XXXX	FOREIGN KEY (ID_User)
											REFERENCES [Utilisateur](ID_User)
GO

ALTER TABLE [Organisateur]
ADD CONSTRAINT FK_Organisateur_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
												REFERENCES [Tournoi](ID_Tournament)
GO

ALTER TABLE [Joueur]
ADD CONSTRAINT FK_Joueur_Utilisateur__XXXX	FOREIGN KEY (ID_User)
											REFERENCES [UTilisateur](ID_User)
GO

ALTER TABLE [Joueur]
ADD CONSTRAINT FK_Joueur_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
										REFERENCES [Tournoi](ID_Tournament)
GO

ALTER TABLE [DeckJoueur]
ADD CONSTRAINT FK_DeckJoueur_Utilisateur__XXXX	FOREIGN KEY (ID_User)
												REFERENCES [Utilisateur](ID_User)
GO

ALTER TABLE [DeckJoueur]
ADD CONSTRAINT FK_DeckJoueur_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
											REFERENCES [Tournoi](ID_Tournament)
GO

ALTER TABLE [DeckJoueur]
ADD CONSTRAINT FK_DeckJoueur_Deck__XXXX	FOREIGN KEY (ID_Deck)
										REFERENCES [Deck](ID_Deck)
GO



ALTER TABLE [Tournoi]
ADD CONSTRAINT CK_Tournoi_Deck__XXX1	CHECK (DeckListNumber >=3)
GO

ALTER TABLE [Tournoi]
ADD CONSTRAINT CK_Tournoi_Deck__XXX2	CHECK (DeckListNumber <=5)
GO

--____________FIN CREATION DES LIEN ENTRE LES TABLES_________________________

--____________________________________________________

--_____________DEBUT DE CREATION D'UTILISATEUR, JEU, DECK VIDE______________________

--INSERT INTO Utilisateur ([Pseudo], [Email], [Password], [Organizer], [DELETED])
--	VALUES('Bye', '0@00.00', HASHBYTES('SHA2_512',''), 0, GETUTCDATE())

--INSERT INTO Jeu([Name])
--GO

--_____________FIN DE CREATION D'UTILISATEUR, JEU, DECK VIDE______________________

--______________________________________________________

--____________DEBUT CREATION DES VUES________________________
CREATE VIEW [View_User] AS
SELECT ID_User, Pseudo, Email, [Password], Organizer, DELETED
FROM Utilisateur
GO

CREATE VIEW [View_Pseudo] AS
SELECT U.ID_User AS ID_User, U.Pseudo AS Pseudo, P.ID_Game AS ID_Game, J.[Name] AS [Game], IG_Pseudo
FROM Utilisateur AS U
JOIN PseudoIG AS P
	ON P.ID_User = U.ID_User
JOIN Jeu AS J
	ON P.ID_Game = J.ID_Game
GO

CREATE VIEW [View_Tournament] AS
SELECT ID_Tournament, T.[Name] AS [Name], T.ID_Game AS ID_Game, J.[Name] AS [Game], T.Desciption as [Description], [Date], [MaxNumberPlayer], [DeckListNumber], [PPWin], [PPDraw], [PPLose], T.DELETED
FROM Tournoi AS T
JOIN Jeu AS J
	ON T.ID_Game = J.ID_Game
GO

CREATE VIEW [View_Orga] AS
SELECT O.ID_Tournament, t.[Name], O.ID_User, U.Pseudo, O.[Level]
FROM Organisateur as O
JOIN Tournoi as T
	ON O.ID_Tournament = T.ID_Tournament
JOIN Utilisateur as U
	ON O.ID_User = u.ID_User
GO

CREATE VIEW [View_Participant] AS 
SELECT J.ID_Tournament, t.[Name], J.ID_User, U.Pseudo, P.IG_Pseudo, J.RegisterDate, J.CheckIn, J.[Drop]
FROM Joueur as J
JOIN Tournoi as T
	ON J.ID_Tournament = T.ID_Tournament
JOIN Utilisateur AS U
	ON U.ID_User = J.ID_User
LEFT JOIN PseudoIG AS P
	ON P.ID_User = U.ID_User AND P.ID_Game = T.ID_Game
GO

CREATE VIEW [View_Jeu] AS
SELECT ID_Game, [Name], DELETED
FROM Jeu 
GO

CREATE VIEW [View_Round] AS
SELECT R.ID_Tournament, T.[Name], R.RoundNumber, R.StartRound, R.EndRound
FROM [Round] AS R
JOIN Tournoi AS T
	ON R.ID_Tournament = T.ID_Tournament
GO

CREATE VIEW [View_Resulta] AS 
SELECT R.ID_Tournament, T.Name, R.ID_User, U.Pseudo, P.IG_Pseudo, R.Rank, R.Gain, R.Score, R.TieBreaker, R.AdditionalTieBreaker, R.AdditionalTieBreakerRules
FROM Resultat as R
JOIN Tournoi as T
	ON T.ID_Tournament = R.ID_Tournament
JOIN Utilisateur AS U
	ON U.ID_User = R.ID_User
LEFT JOIN PseudoIG AS P
	ON P.ID_User = U.ID_User AND P.ID_Game = T.ID_Game
GO

CREATE VIEW [View_Partie] AS 
SELECT P.ID_Tournament, T.Name, P.RoundNumber, P.PartNumber, P.ResultPart, P.ID_PlayerOne, U1.Pseudo AS [PlayerOne], P1.IG_Pseudo AS[IGPseudoOne], P.ID_Deck_PlayerOne, DOne.DeckList AS [DeckOne], P.ID_PlayerTwo, U2.Pseudo AS [PlayerTwo], P2.IG_Pseudo AS[IGPseudoTwo], P.ID_Deck_PlayerTwo, DTwo.DeckList AS [DeckTwo]
FROM Partie as P
JOIN Tournoi as T
	ON T.ID_Tournament = p.ID_Tournament
JOIN Deck as DOne
	ON DOne.ID_Deck = P.ID_Deck_PlayerOne
JOIN Deck as DTwo
	ON DTwo.ID_Deck = P.ID_Deck_PlayerTwo
JOIN Utilisateur AS U1
	ON U1.ID_User = P.ID_PlayerOne
LEFT JOIN PseudoIG AS P1
	ON P1.ID_User = U1.ID_User AND P1.ID_Game = T.ID_Game
JOIN Utilisateur AS U2
	ON U2.ID_User = P.ID_PlayerTwo
LEFT JOIN PseudoIG AS P2
	ON P2.ID_User = U2.ID_User AND P2.ID_Game = T.ID_Game
GO

CREATE VIEW[View_Deck] AS
SELECT DJ.ID_Tournament, T.Name, DJ.ID_User, U.Pseudo, DJ.ID_Deck, D.DeckList, J.ID_Game, J.Name AS [Game]
FROM DeckJoueur AS DJ
JOIN Deck AS D
	ON D.ID_Deck = DJ.ID_Deck
JOIN Tournoi AS T
	ON T.ID_Tournament = DJ.ID_Tournament
JOIN Utilisateur AS U
	ON U.ID_User = DJ.ID_User
JOIN Jeu AS J
	ON J.ID_Game = D.ID_Game
GO

CREATE VIEW [View_ResultPartPlayer] AS
SELECT P.ID_Tournament, RoundNumber, PartNumber, ID_PlayerOne AS ID_Player, U.Pseudo, Ps.IG_Pseudo,	CASE ResultPart
																											WHEN 2
																											THEN -1
																											ELSE ResultPart
																										END AS Resulta
FROM Partie AS P
JOIN Tournoi AS T
	ON T.ID_Tournament = P.ID_Tournament
JOIN Utilisateur AS U
	ON U.ID_User = P.ID_PlayerOne
LEFT JOIN PseudoIG AS Ps
	ON Ps.ID_User = U.ID_User AND Ps.ID_Game = T.ID_Game
WHERE P.ID_Tournament IN (SELECT ID_Tournament FROM Tournoi WHERE [Over] = 0)
union
SELECT P.ID_Tournament, RoundNumber, PartNumber, ID_PlayerTWO AS ID_Player, U.Pseudo, Ps.IG_Pseudo,	CASE ResultPart
																											WHEN 2
																											THEN 1
																											WHEN null
																											THEN null
																											ELSE (0-ResultPart)
																										END AS Resulta
FROM Partie AS P
JOIN Tournoi AS T
	ON T.ID_Tournament = P.ID_Tournament
JOIN Utilisateur AS U
	ON U.ID_User = P.ID_PlayerTwo
LEFT JOIN PseudoIG AS Ps
	ON Ps.ID_User = U.ID_User AND Ps.ID_Game = T.ID_Game
WHERE P.ID_Tournament IN (SELECT ID_Tournament FROM Tournoi WHERE [Over] = 0)
GO

CREATE VIEW [View_Match] AS
SELECT M.[ID_Tournament], M.[RoundNumber], R.StartRound, [ID_PlayerOne], U1.Pseudo AS [PlayerOne], P1.IG_Pseudo AS [PseudoPlayerOne], [ID_PlayerTwo], U2.Pseudo AS [PlayerTwo], P2.IG_Pseudo AS [PseudoPlayerTwo]
FROM [Match] AS M
JOIN Tournoi AS T
	ON T.ID_Tournament = M.ID_Tournament
JOIN [Round] AS R
	ON R.ID_Tournament = M.ID_Tournament AND R.RoundNumber = M.RoundNumber
JOIN Utilisateur AS U1
	ON U1.ID_User = M.ID_PlayerOne
LEFT JOIN PseudoIG AS P1
	ON P1.ID_User = U1.ID_User AND P1.ID_Game = T.ID_Game
LEFT JOIN Utilisateur AS U2
	ON U2.ID_User = M.ID_PlayerTwo
LEFT JOIN PseudoIG AS P2
	ON P2.ID_User = U2.ID_User AND P2.ID_Game = T.ID_Game
GO

CREATE VIEW [View_ResultMatchPlayer] AS
SELECT ID_Tournament, RoundNumber, ID_Player, Pseudo, IG_Pseudo, 	CASE 
																		WHEN count(Resulta) =0
																		THEN null
																		WHEN SUM(Resulta) >0
																		THEN 1
																		WHEN SUM(Resulta) <0
																		THEN -1
																		WHEN SUM(Resulta) =0
																		THEN 0
																		ELSE null
																	END AS Resulta
FROM [View_ResultPartPlayer]
GROUP BY ID_Tournament, RoundNumber, ID_Player, Pseudo, IG_Pseudo
UNION
SELECT ID_Tournament, RoundNumber, ID_PlayerOne AS ID_Player, [PlayerOne] AS Pseudo, [PseudoPlayerOne] AS IG_Pseudo ,	1 AS Resulta
FROM [View_Match]
WHERE ID_PlayerTwo IS NULL
GROUP BY ID_Tournament, RoundNumber, ID_PlayerOne, [PlayerOne], [PseudoPlayerOne]
GO

CREATE VIEW [View_ClassementTemporaire] AS
SELECT	ID_Tournament, 
		ID_Player, 
		Pseudo, 
		IG_Pseudo,
		SUM(CASE WHEN Resulta = 1 THEN 1 ELSE 0 END) AS Victoire, 
		SUM(CASE WHEN Resulta = 0 THEN 1 ELSE 0 END) AS Egaliter, 
		SUM(CASE WHEN Resulta = 2 THEN 1 ELSE 0 END) AS Defaite
FROM [View_ResultMatchPlayer]
GROUP BY ID_Tournament, ID_Player, Pseudo, IG_Pseudo
--ORDER BY  Victoire DESC, Egaliter DESC, Defaite ASC
GO

CREATE VIEW [View_ScoreClassementTemporaire] AS
SELECT	V.ID_Tournament, 
		T.Name,
		ID_Player, 
		Pseudo, 
		IG_Pseudo,
		(V.Victoire * T.PPWin + V.Egaliter * T.PPDraw + V.Defaite * T.PPLose) AS Score,
		Victoire, 
		Egaliter, 
		Defaite
FROM [View_ClassementTemporaire] as V
JOIN Tournoi as T
	ON T.ID_Tournament = V.ID_Tournament
GO

CREATE VIEW [View_Dotation] AS
SELECT D.ID_Tournament, T.[Name], D.Place, D.Gain
FROM [Dotation] AS D
JOIN Tournoi AS T
	ON D.ID_Tournament = T.ID_Tournament
GO
--____________FIN CREATION DES VUES________________________
--______________________________________________________________


--_______________DEBUT CREATION TRIGGER___________________________________

--CREATE TRIGGER OnEndTournament
--ON Tournoi
--AFTER INSERT, UPDATE
--AS
--	-- create result tournoi
--GO

----pour le moment en attente car pas sur que ça soit une bonne idée de le mettre en trigeur

--_______________DEBUT CREATION TRIGGER___________________________________
--___________________________________________

--____________________DEBUT CREATION STORED PROCEDURE____________________________

--CREATE PROCEDURE SP_Pairing 
--	@ID_Tournament INT, 
--	@RoundNumber INT
--AS
--BEGIN
--	Declare @ID_Player INT;
--	Declare @Victoire INT;
--	Declare @Egaliter INT;
--	Declare @Defaite INT;


--	--1 on crée des groupes basés sur le nombre de victoire 

--	--pour chaque groupe (en commençant par celui avec le plus de victoire) 
--	--2 on les tri (ASC) en fonction du nombre d'adversaire de leur qu'ils n'ont pas déjà rencontré. S’il y a des joueurs qui ont déjà rencontré tous les autres du groupe on le report dans le groupe suivant
--	--3 en commençant par le joueur reporté du groupe d'avant, dans l'ordre on leur attribue un adversaire (au hasard) qu'ils n'ont pas encore rencontré, si ce n'est pas possible on met le joueur en attente
--	--4 s’il n'y a que 1 joueur en attente on le report au group suivant,
--	--sinon on cherche une paire de joueur déjà appareillé qui pourrais correspondre à des joueurs en attente. et on répète le processus jusqu'à ne plus en trouvé.
--	-- s’il reste encore des joueurs en attente on les reports au groupe suivant.

--	--5 pour le dernier groupe s’il n'y a qu’un joueur reporté on lui donne un bail (victoire gratuite).
--	-- sinon on recommence depuis le début mais en commençant par le groupe avec le moins de victoire.


--	--Declare Cursor_ClassementTemporaire Cursor For
--	--	Select ID_Player, Victoire, Egaliter, Defaite 
--	--	from View_ClassementTemporaire
--	--	where ID_Tournament = @ID_Tournament;

--	--Open Cursor_ClassementTemporaire;

--	--Fetch Cursor_ClassementTemporaire into ;
--	--while @@FETCH_STATUS = 0
--	--Begin
			
			

--	--	Fetch Cursor_ClassementTemporaire into ;

--	--End
		
--	--close Cursor_ClassementTemporaire;
--	--Deallocate Cursor_ClassementTemporaire;
--END
--GO

CREATE PROCEDURE SP_ADD_PseudoIG
	@ID_User INT,
	@ID_Game INT,
	@PseudoIG VARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN
	
	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le utilisateur est introuvable',16,1);
				End

			if( @ID_Game IS NULL OR (SELECT COUNT(*) FROM Jeu WHERE (ID_Game = @ID_Game)) <> 1)
				Begin
					RAISERROR('Le utilisateur est introuvable',16,1);
				End

			if( @PseudoIG IS NULL OR (TRIM(@PseudoIG)) ='')
				Begin
					RAISERROR('Le Pseudo est vide',16,1);
				End

			INSERT INTO PseudoIG (ID_User, ID_Game, IG_Pseudo)
				VALUES (@ID_User, @ID_Game, @PseudoIG)
			COMMIT
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE() ;
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_EDIT_PseudoIG
	@ID_User INT,
	@ID_Game INT,
	@PseudoIG VARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN
	
	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le utilisateur est introuvable',16,1);
				End

			if( @ID_Game IS NULL OR (SELECT COUNT(*) FROM Jeu WHERE (ID_Game = @ID_Game)) <> 1)
				Begin
					RAISERROR('Le utilisateur est introuvable',16,1);
				End

			if( @PseudoIG IS NULL OR (TRIM(@PseudoIG)) ='')
				Begin
					RAISERROR('Le Pseudo est vide',16,1);
				End

			UPDATE PseudoIG
				SET IG_Pseudo = @PseudoIG
				WHERE ID_User = @ID_User AND ID_Game = @ID_Game
			COMMIT
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE() ;
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_Delete_PseudoIG
	@ID_User INT,
	@ID_Game INT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN
	
	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le utilisateur est introuvable',16,1);
				End

			if( @ID_Game IS NULL OR (SELECT COUNT(*) FROM Jeu WHERE (ID_Game = @ID_Game)) <> 1)
				Begin
					RAISERROR('Le utilisateur est introuvable',16,1);
				End

			DELETE PseudoIG
				WHERE ID_User = @ID_User AND ID_Game = @ID_Game
			COMMIT
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE() ;
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_Create_User
	@Pseudo VARCHAR(50), 
	@Email VARCHAR(256),
	@Password BINARY(64), --soit varcahr(50) si passé en claire soit binary (64) si haché
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN
	
	SET @responseMessage = '';	
	SET @Reussie = 1;

	BEGIN TRANSACTION;
		BEGIN TRY
			

			if( @Pseudo IS NULL OR (TRIM(@Pseudo)) ='')
				Begin
					RAISERROR('Le Pseudo est vide',16,1);
				End

			if( @Password IS NULL OR (TRIM(@Password)) ='')
				Begin
					RAISERROR('Le mot de passe est vide',16,1);
				End
	
			if( @Email IS NULL OR (@Email NOT LIKE '%_@__%.__%'))
				Begin
					RAISERROR('Le Email est invalide',16,1);
				End

			else if( (SELECT count(*) FROM Utilisateur WHERE @Email = Email)<>0)
				Begin
					RAISERROR('Le Email est déjà utiliser',16,1);
				End


			INSERT INTO Utilisateur (Pseudo, Email, [Password])
			VALUES (@Pseudo, @Email, @Password)
			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE() ;
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO


CREATE PROCEDURE SP_EditUser
	@ID_User INT ,
	@Organizer BIT=NULL,
	@Pseudo VARCHAR(50) =NULL, 
	@Email VARCHAR(256)=NULL,
	@Password BINARY(64)=NULL, --soit varcahr(50) si passé en claire soit binary (64) si haché
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;
	BEGIN TRANSACTION;
		BEGIN TRY
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le utilisateur est introuvable',16,1);
				End

			DECLARE @HMDP BINARY(64) = null;
			if( @Pseudo IS NULL OR (TRIM(@Pseudo)) ='')
				Begin
					SET @Pseudo = NULL
				End

			if( @Password IS NULL OR (TRIM(@Password)) ='')
				Begin
					SET @Password = NULL
				End

			if( @Email IS NULL OR (@Email NOT LIKE '%_@__%.__%'))
				Begin
					SET @Email = NULL
				End

			if(@Pseudo is null and @Password is null and @Email is null and @Organizer is null)
				BEGIN
					RAISERROR('Aucune update',16,1);
				END

			UPDATE Utilisateur
			SET Pseudo = ISNULL(@Pseudo, Pseudo),
				[Password] = ISNULL(@Password, [Password]),
				Email = ISNULL(@Email, Email),
				Organizer = ISNULL(@Organizer, Organizer)
			WHERE ID_User = @ID_User

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH

END
GO

CREATE PROCEDURE SP_DeleteUser
	@ID_User INT ,
	@Password BINARY(64), --soit varcahr(50) si passé en claire soit binary (64) si haché
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le utilisateur est introuvable',16,1);
				End
			if( (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and Password = @Password and DELETED is null)) <> 1)
				Begin
					RAISERROR('Mauvais mot de passe',16,1);
				End

			UPDATE Utilisateur
			SET DELETED = CAST( GETUTCDATE() AS Date )
			WHERE ID_User = @ID_User AND Password = @Password
			
			COMMIT;

			SET @responseMessage='l utilisateur a été supprimer';

		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_CreateTournoi
	@Name VARCHAR(50),
	@Date DATETIME,
	@ID_Game INT,
	@Description TEXT,
	@MaxNumberPlayer INT = null,
	@Dotation List_Pairing readonly,
	@Orga ID_List readonly,
	@DeckListNumber INT =3,
	@PPWin INT =2,
	@PPDraw INT =1,
	@PPLose INT =0,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT,
	@ID INT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @MaxNumberPlayer is null or @MaxNumberPlayer = 0)
				BEGIN
					SET @MaxNumberPlayer = NULL;
				END
			if(@Name IS NULL OR (TRIM(@Name)) ='')
				BEGIN
					RAISERROR('Le nom du tournoi est vide',16,1);
				END
			if(@Date IS NULL OR @Date < GETUTCDATE())
				BEGIN
					RAISERROR('La date du tournoi est incorrect',16,1);
				END
			if(@ID_Game IS NULL OR (SELECT COUNT(*) FROM Jeu WHERE @ID_Game = ID_Game) <> 1)
				BEGIN
					RAISERROR('Le jeu du tournoi est introuvable',16,1);
				END
			if((SELECT COUNT(*) FROM @Orga) <=0)
				BEGIN
					RAISERROR('pas de créateur de tournoi enregistré',16,1);
				END
			if(@MaxNumberPlayer = 0)
				BEGIN
					SET @MaxNumberPlayer = NULL;
				END
			if(@PPWin IS NULL)
				BEGIN
					SET @PPWin = 2;
				END
			if(@PPDraw IS NULL)
				BEGIN
					SET @PPDraw = 1;
				END
			if(@PPLose IS NULL)
				BEGIN
					SET @PPLose = 0;
				END
				
			DECLARE @OP table(id int);
				INSERT INTO Tournoi ([Name], [Date], [ID_Game], [Desciption], [MaxNumberPlayer], [DeckListNumber], [PPWin], [PPDraw], [PPLose])
					OUTPUT inserted.ID_Tournament INTO @OP
					VALUES(@Name, @Date, @ID_Game, @Description, @MaxNumberPlayer, @DeckListNumber, @PPWin, @PPDraw, @PPLose) 
					
				SELECT @ID = id FROM @OP;


				INSERT INTO Organisateur (ID_Tournament, ID_User)
					SELECT @ID, ID FROM @Orga

				INSERT INTO Dotation(ID_Tournament, Place, Gain)
					SELECT @ID, ID_PlayerOne, ID_PlayerTwo FROM @Dotation


				SET @responseMessage='le tournoi a été creer';
			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_EditTournoi
	@ID_Tournoi INT,
	@Date DATETIME =NULL,
	@Name VARCHAR(50) =NULL,
	@ID_Game INT =NULL,
	@Description TEXT = NULL,
	@MaxNumberPlayer INT =NULL,
	@Dotation List_Pairing readonly,
	@DeckListNumber INT =NULL,
	@PPWin INT =NULL,
	@PPDraw INT =NULL,
	@PPLose INT =NULL,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @MaxNumberPlayer is null or @MaxNumberPlayer = 0)
				BEGIN
					SET @MaxNumberPlayer = NULL;
				END
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End
			if(@Name IS NULL OR (TRIM(@Name)) ='')
				BEGIN
					SET @Name = NULL;
				END
			if(@Date < GETUTCDATE())
				BEGIN
					RAISERROR('La date du tournoi est incorrect',16,1);
				END
			if((SELECT COUNT(*) FROM Jeu WHERE @ID_Game = ID_Game) <> 1)
				BEGIN
					RAISERROR('Le jeu du tournoi est introuvable',16,1);
				END
			if((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi)) > 0)
				BEGIN
					RAISERROR('Le tournoi a déjà commencé',16,1);
				END
			

			if(@Name is null and @Date is null and @ID_Game is null and @PPWin is null and @PPDraw is null and @PPLose is null and @DeckListNumber is null and @Description is null and @MaxNumberPlayer is null AND 0<(SELECT COUNT(*) FROM @Dotation))
				BEGIN
					RAISERROR('Aucune update',16,1);
				END

			UPDATE Tournoi
			SET	[Name] = ISNULL(@Name, [Name]),
				[Date] = ISNULL(@Date, [Date]),
				[ID_Game] = ISNULL(@ID_Game, [ID_Game]),
				[Desciption] = ISNULL(@Description, [Desciption]),
				[MaxNumberPlayer] = @MaxNumberPlayer,
				[DeckListNumber] = ISNULL(@DeckListNumber, [DeckListNumber]),
				[PPWin] = ISNULL(@PPWin, [PPWin]),
				[PPDraw] = ISNULL(@PPDraw, [PPDraw]),
				[PPLose] = ISNULL(@PPLose, [PPLose])
			WHERE @ID_Tournoi = ID_Tournament

			if(0<(SELECT COUNT(*) FROM @Dotation))
			BEGIN
				if(0<(SELECT COUNT(*) FROM Dotation WHERE ID_Tournament = @ID_Tournoi))
					BEGIN
						DELETE Dotation
							WHERE ID_Tournament = @ID_Tournoi AND Place IN (SELECT ID_PlayerOne FROM @Dotation)
					END
				
				INSERT INTO Dotation(ID_Tournament, Place, Gain)
					SELECT @ID_Tournoi, ID_PlayerOne, ID_PlayerTwo FROM @Dotation

			END

				SET @responseMessage='le tournoi a été mis a jour';
			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_EndTournoi
	@ID_Tournoi INT ,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if((SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and [Over] =1)) <> 0) 
				BEGIN
					RAISERROR('Le tournoi est déjà fini',16,1);
				END
				
			if((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi)) = 0)
				BEGIN
					RAISERROR('Le tournoi n a pas encore commencé supprimer le au lieu de le terminer',16,1);
				END

			if((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi and EndRound IS NULL AND StartRound IS NOT NULL)) > 0)
				BEGIN
					RAISERROR('La derniere round du tournoi n a pas encore fini, terminer la avant de finir le tournoi',16,1);
				END
			--(inseré ici la création des résulta du tournoi ou faire un triggeur pour le faire sur le changement de over a 1)


			INSERT INTO Resultat ([ID_Tournament], [ID_User], [Score], [Gain], [TieBreaker], [Rank])
			SELECT D.ID_Tournament, ID_Player, Score, D.Gain, TieBreaker, [Rank]
			FROM
				(
				SELECT VSCT.ID_Tournament, VSCT.ID_Player, VSCT.Score, SUM(tb.opponentScore) AS TieBreaker, RANK() OVER(ORDER BY VSCT.Score,SUM(tb.opponentScore))  AS [Rank]
				FROM	(
							SELECT VM.ID_Tournament, VM.ID_PlayerOne AS player, VM.ID_PlayerTwo AS opponent, VSCT.Score AS opponentScore
							FROM [View_Match] AS VM
							JOIN [View_ScoreClassementTemporaire] AS VSCT
								ON VSCT.ID_Tournament = VM.ID_Tournament and vsct.ID_Player = VM.ID_PlayerTwo
							WHERE VM.ID_Tournament = @ID_Tournoi
							union
							SELECT VM.ID_Tournament, VM.ID_PlayerTwo AS player, VM.ID_PlayerOne AS opponent, VSCT.Score AS opponentScore
							FROM [View_Match] AS VM
							JOIN [View_ScoreClassementTemporaire] AS VSCT
								ON VSCT.ID_Tournament = VM.ID_Tournament and vsct.ID_Player = VM.ID_PlayerOne
							WHERE VM.ID_Tournament = @ID_Tournoi
						) AS TB
				JOIN [View_ScoreClassementTemporaire] AS VSCT
					ON TB.ID_Tournament = VSCT.ID_Tournament and TB.player = VSCT.ID_Player
				GROUP BY VSCT.ID_Tournament, VSCT.ID_Player, VSCT.Score
				) AS RSG
			JOIN Dotation AS D
				ON D.ID_Tournament = RSG.ID_Tournament AND D.Place = RSG.[Rank]
			ORDER BY [Rank]

			UPDATE Tournoi
			SET [Over] = 1
			WHERE ID_Tournament = @ID_Tournoi
			
			COMMIT;

			SET @responseMessage='le tournoi a été fini, le classement a été généré';

		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_DeleteTournoi
	@ID_Tournoi INT ,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			UPDATE Tournoi
			SET DELETED = CAST( GETUTCDATE() AS Date )
			WHERE ID_Tournament = @ID_Tournoi
			
			COMMIT;

			SET @responseMessage='le tournoi a été supprimer';

		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_RegisterTournoi
	@ID_Tournoi INT,
	@ID_User INT,
	@ListDeck List_Deck READONLY,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN
	DECLARE @DeckID INT = null
	DECLARE @IDGame INT;
	DECLARE @ListID ID_List;

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null and [Date]> GETUTCDATE())) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('L utilisateur est introuvable',16,1);
				End
			if((SELECT COUNT(*) FROM @ListDeck) > (SELECT [DeckListNumber] FROM Tournoi WHERE ID_Tournament = @ID_Tournoi))
				Begin
					RAISERROR('trop de deck on été soumis',16,1);
				End
			if((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi)) > 0)
				BEGIN
					RAISERROR('Le tournoi a déjà commencé, vous ne pouvez plus vous inscrire',16,1);
				END

			SELECT @IDGame = [ID_Game] 
			FROM Tournoi
			WHERE ID_Tournament = @ID_Tournoi

			if((SELECT COUNT(*) FROM @ListDeck) > 0)
				BEGIN

					INSERT INTO Deck ([DeckList], [ID_Game])
						OUTPUT inserted.ID_Deck INTO @ListID
						SELECT DeckList, @IDGame
						FROM @ListDeck

			
					DECLARE ListDeckCursor CURSOR FOR
									SELECT ID FROM @ListID;

					OPEN ListDeckCursor;

					FETCH ListDeckCursor INTO @DeckID;
					WHILE @@FETCH_STATUS = 0
					BEGIN
						INSERT INTO DeckJoueur ([ID_Tournament], [ID_User], [ID_Deck])
							VALUES(@ID_Tournoi, @ID_User, @DeckID)

						FETCH ListDeckCursor INTO @DeckID;
					END

					
					CLOSE ListDeckCursor;
					DEALLOCATE ListDeckCursor;
				END

			INSERT INTO Joueur ([ID_Tournament], [ID_User])
				VALUES(@ID_Tournoi, @ID_User)
				

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_UnregisterTournoi
	@ID_Tournoi INT,
	@ID_User INT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and [Date]> GETUTCDATE())) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User)) <> 1)
				Begin
					RAISERROR('L utilisateur est introuvable',16,1);
				End
			if((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi)) > 0)
				BEGIN
					RAISERROR('Le tournoi n a commencé abandonné plutot que de ce désinscrire',16,1);
				END
			
			DELETE DeckJoueur
			WHERE [ID_Tournament] = @ID_Tournoi AND [ID_User] = @ID_User
			DELETE Joueur
			WHERE [ID_Tournament] = @ID_Tournoi AND [ID_User] = @ID_User

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_UpdateDeck
	@ID_Tournoi INT,
	@ID_User INT,
	@ID_Deck INT,
	@DeckList TEXT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN
	DECLARE @IDGame INT
	DECLARE @IDDeck INT
	DECLARE @ListID ID_List

	SET @responseMessage = '';
	SET @Reussie = 1;
	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null and [Date]> GETUTCDATE())) <> 1)
					Begin
						RAISERROR('Le tournoi est introuvable',16,1);
					End
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('L utilisateur est introuvable',16,1);
				End
			if( @ID_Deck IS NULL OR (SELECT COUNT(*) FROM Deck WHERE (ID_Deck = @ID_Deck )) <> 1)
				Begin
					RAISERROR('Le deck est introuvable',16,1);
				End
			if(GETUTCDATE() > (SELECT Date FROM Tournoi WHERE ID_Tournament = @ID_Tournoi))
				BEGIN
					RAISERROR('Le tournoi a déjà commencé les decks ne peuvent plus être modifié',16,1);
				END

			if(@ID_Deck <> 0)
				BEGIN
					DELETE DeckJoueur
					WHERE [ID_Tournament] = @ID_Tournoi AND [ID_User] = @ID_User  AND [ID_Deck] = @ID_Deck
				END
			ELSE IF ((SELECT COUNT(*) FROM DeckJoueur WHERE ID_Tournament = @ID_Tournoi and ID_User = @ID_User) >= (SELECT [DeckListNumber] FROM Tournoi WHERE ID_Tournament = @ID_Tournoi))
				BEGIN
					RAISERROR('trop de deck on été soumis',16,1);
				END
		
			SELECT @IDGame = [ID_Game] 
				FROM Tournoi
				WHERE ID_Tournament = @ID_Tournoi

			INSERT INTO Deck ([DeckList], [ID_Game])
				OUTPUT inserted.ID_Deck INTO @ListID
				VALUES(@DeckList, @IDGame)

			SELECT ID = @IDDeck 
				FROM @ListID
		
			INSERT INTO DeckJoueur ([ID_Tournament], [ID_User], [ID_Deck])
				VALUES(@ID_Tournoi, @ID_User, @IDDeck)

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_AddAdmin
	@ID_Tournoi INT,
	@ID_User INT,
	@Level INT = 1,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
					Begin
						RAISERROR('Le tournoi est introuvable',16,1);
					End
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('L utilisateur est introuvable',16,1);
				End
		
			INSERT INTO Organisateur ([ID_Tournament], [ID_User], [Level])
				VALUES(@ID_Tournoi, @ID_User, @Level)

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_EDITAdmin
	@ID_Tournoi INT,
	@ID_User INT,
	@Level INT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;
	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
					Begin
						RAISERROR('Le tournoi est introuvable',16,1);
					End
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('L utilisateur est introuvable',16,1);
				End

			if(@Level is null or @Level <0)
				BEGIN
					RAISERROR('Niveau d admin incorrecte',16,1);
				END
		
			UPDATE Organisateur
				SET [Level] = @Level
				WHERE [ID_User] = @ID_User AND [ID_Tournament] = @ID_Tournoi

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_DELETEAdmin
	@ID_Tournoi INT,
	@ID_User INT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
					Begin
						RAISERROR('Le tournoi est introuvable',16,1);
					End
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('L utilisateur est introuvable',16,1);
				END

			DELETE Organisateur
				WHERE [ID_User] = @ID_User AND [ID_Tournament] = @ID_Tournoi

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_AddGame
	@Name VARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1;

	BEGIN TRANSACTION
		BEGIN TRY
			if( @Name IS NULL OR TRIM(@Name) ='')
					Begin
						RAISERROR('Le Nom du jeu est vide',16,1);
					End

		
			INSERT INTO Jeu ([Name])
				VALUES(@Name)

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_EDITGame
	@ID_Game INT,
	@Name VARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Game IS NULL OR (SELECT COUNT(*) FROM Jeu WHERE (ID_Game = @ID_Game)) <> 1)
					Begin
						RAISERROR('Le Nom du jeu est vide',16,1);
					End

			if( @Name IS NULL OR TRIM(@Name) ='')
					Begin
						RAISERROR('Le Nom du jeu est vide',16,1);
					End

		
			UPDATE  Jeu 
				SET [Name] = (@Name)
				WHERE ID_Game = @ID_Game

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_DELETEGame
	@ID_Game INT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Game IS NULL OR (SELECT COUNT(*) FROM Jeu WHERE (ID_Game = @ID_Game)) <> 1)
					Begin
						RAISERROR('Le Nom du jeu est vide',16,1);
					End


		
			UPDATE  Jeu 
				SET DELETED = 1
				WHERE ID_Game = @ID_Game

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_EDITResultat
	@ID_User INT,
	@ID_Tournament INT,
	@Rank INT = null,
	@Score INT = NULL,
	@TieBreaker INT = NULL,
	@AddTieBreaker INT = NULL,
	@AddTieBreakerRules VARCHAR(50) = NULL,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_User IS NULL )
				Begin
					RAISERROR('Le champs  utilisateur est vide',16,1);
				End

			if( @ID_Tournament IS NULL)
				Begin
					RAISERROR('Le champs tournoi est vide',16,1);
				End

			if ((SELECT COUNT(*) FROM Resultat WHERE (ID_User = @ID_User AND ID_Tournament = @ID_Tournament)) <> 1)
				BEGIN
					RAISERROR('La combinaison tournoi utilisateur est invalide',16,1);
				END

			if( @Rank is null AND @Score is null AND @TieBreaker is null AND @AddTieBreaker is null AND @AddTieBreakerRules is null)
				BEGIN
					RAISERROR('Aucune modification', 16, 1)
				END

		
			UPDATE  Resultat 
				SET [Rank] = ISNULL(@Rank, [Rank]),
					[Score] = ISNULL(@Score, [Score]),
					[TieBreaker] = ISNULL(@TieBreaker, [TieBreaker]),
					[AdditionalTieBreakerRules] = ISNULL(@AddTieBreakerRules, [AdditionalTieBreakerRules]),
					[AdditionalTieBreaker] = ISNULL(@AddTieBreaker, [AdditionalTieBreaker])
				WHERE ID_Tournament = @ID_Tournament AND ID_User = @ID_User
				

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie = 0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_DELETEDResultat
	@ID_Tournament INT,
	@ID_User INT = null,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournament IS NULL)
				Begin
					RAISERROR('Le champs tournoi est vide',16,1);
				End

			if ( @ID_User IS NOT NULL AND (SELECT COUNT(*) FROM Resultat WHERE (ID_User = @ID_User AND ID_Tournament = @ID_Tournament)) <> 1)
				BEGIN
					RAISERROR('La combinaison tournoi utilisateur est invalide',16,1);
				END
			if(@ID_User IS NOT NULL)
				BEGIN
					DELETE  Resultat 
						WHERE ID_Tournament = @ID_Tournament AND ID_User = @ID_User
				END
			else
				BEGIN
					DELETE  Resultat 
						WHERE ID_Tournament = @ID_Tournament
				END
				

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_CREATE_Round
	@ID_Tournoi INT,
	@RoundNumber INT = null,
	@Start DateTime,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi and @RoundNumber = RoundNumber)) >0))
				BEGIN
					RAISERROR('la round existe déjà', 16, 1);
				END

			if(@Start is null or @Start < DATEADD(MINUTE, -5, GETUTCDATE()))
				BEGIN
					RAISERROR('la date de début est incorrecte', 16, 1);
				END

			if(@RoundNumber IS null or @RoundNumber <1)
				BEGIN
					select @RoundNumber = (Max(RoundNumber) +1) from [Round] WHERE [ID_Tournament] = @ID_Tournoi
				END
		
			INSERT INTO [Round]([ID_Tournament], [RoundNumber], [StartRound])
				VALUES(@ID_Tournoi, @RoundNumber, @Start)

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO



CREATE PROCEDURE SP_Edit_Round
	@ID_Tournoi INT,
	@RoundNumber INT,
	@Start DateTime,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(@RoundNumber IS null or ((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi and @RoundNumber = RoundNumber)) =1))
				BEGIN
					RAISERROR('la round n existe pas déjà', 16, 1);
				END

			if(@Start is null or @Start < GETUTCDATE())
				BEGIN
					RAISERROR('la date de début est incorrecte', 16, 1);
				END

		
			INSERT INTO [Round]([ID_Tournament], [RoundNumber], [StartRound])
				VALUES(@ID_Tournoi, @RoundNumber, @Start)

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_DELETE_Round
	@ID_Tournoi INT,
	@RoundNumber INT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(@RoundNumber IS null or ((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi and @RoundNumber = RoundNumber)) <>1))
				BEGIN
					RAISERROR('la round n existe pas', 16, 1);
				END

			IF((SELECT COUNT(*) FROM [Match] WHERE (ID_Tournament = @ID_Tournoi and @RoundNumber = RoundNumber)) >0)
				BEGIN
					RAISERROR('Il existe des match pour cette round', 16, 1);
				END
		
			DELETE [Round]
				WHERE [ID_Tournament] = @ID_Tournoi and [RoundNumber] = @RoundNumber

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_DELETE_RoundAndMatch
	@ID_Tournoi INT,
	@RoundNumber INT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(@RoundNumber IS null or ((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi and @RoundNumber = RoundNumber)) <>1))
				BEGIN
					RAISERROR('la round n existe pas', 16, 1);
				END

			--IF((SELECT COUNT(*) FROM [Match] WHERE (ID_Tournament = @ID_Tournoi and @RoundNumber = RoundNumber)) =0)
			--	BEGIN
			--		RAISERROR('Il n existe pas match pour cette round', 16, 1);
			--	END

			DELETE [Match] 
				WHERE [ID_Tournament] = @ID_Tournoi and [RoundNumber] = @RoundNumber
		
			DELETE [Round]
				WHERE [ID_Tournament] = @ID_Tournoi and [RoundNumber] = @RoundNumber

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_CREATE_Match
	@ID_Tournoi INT,
	@RoundNumber INT,
	@ID_PlayerOne INT,
	@ID_PlayerTwo INT = 0,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(@RoundNumber IS null or ((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi and @RoundNumber = RoundNumber)) >0))
				BEGIN
					RAISERROR('la round existe déjà', 16, 1);
				END

			if(@ID_PlayerOne is null or (SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournoi and ID_User = @ID_PlayerOne)) <> 1 )
				BEGIN
					RAISERROR('la le joueur 1 nest pas trouvé parli les participant', 16, 1);
				END

			if(@ID_PlayerTwo is null or @ID_PlayerTwo = 0)
				BEGIN
					SET @ID_PlayerTwo = null;
				END
			else if((SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournoi and ID_User = @ID_PlayerTwo)) <> 1 )
				BEGIN
					RAISERROR('la le joueur 2 nest pas trouvé parli les participant', 16, 1);
				END
		
			INSERT INTO [Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo])
				VALUES(@ID_Tournoi, @RoundNumber, @ID_PlayerOne, @ID_PlayerTwo)
			


			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie=0;
			ROLLBACK;
		END CATCH
END
GO



CREATE PROCEDURE SP_CREATE_Match_ALLPairing
	@ID_Tournoi INT,
	@RoundNumber INT,
	@Pairing List_Pairing READONLY,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if((SELECT COUNT(*) FROM @Pairing) =0)
				BEGIN
					RAISERROR('le pairing est vide', 16, 1);
				END

			if	(
					CEILING((SELECT COUNT(distinct [ID_User])
					FROM Joueur
					WHERE [ID_Tournament] = @ID_Tournoi and [Drop] = 0)
					*0.5)
					!=
					(SELECT COUNT(*)
					FROM @Pairing)
				)
				BEGIN
					RAISERROR('le pairing est incorrect, le nombre de joueur ne correspond pas par rapport au nombre de match' , 16, 1);
				END

			if	(
					(SELECT count(distinct [ID_User])
					FROM Joueur
					WHERE [ID_Tournament] = @ID_Tournoi and [Drop] = 0 AND  EXISTS(	SELECT ID_PlayerOne
																					FROM @Pairing
																					UNION
																					SELECT ID_PlayerTwo
																					FROM @Pairing))
					!=
					(SELECT count(distinct [ID_User])
					FROM Joueur
					WHERE [ID_Tournament] = @ID_Tournoi and [Drop] = 0 )
				)
				BEGIN
					RAISERROR('le pairing est incorrect, le nombre de joueur ne correspond pas', 16, 1);
				END


			INSERT INTO [Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo])
				SELECT @ID_Tournoi, @RoundNumber, ID_PlayerOne, CASE WHEN ID_PlayerTwo = 0 THEN NULL ELSE ID_PlayerTwo END
				FROM @Pairing

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_EDIT_Match
	@ID_Tournoi INT,
	@RoundNumber INT,
	@ID_PlayerOne INT,
	@ID_PlayerTwo INT ,
	@ID_NewPone INT null,
	@ID_NewPTwo INT null,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(@RoundNumber IS null or ((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi and @RoundNumber = RoundNumber)) >0))
				BEGIN
					RAISERROR('la round existe déjà', 16, 1);
				END

			if(@ID_PlayerOne is null or (SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournoi and ID_User = @ID_PlayerOne)) <> 1 )
				BEGIN
					RAISERROR('la le joueur 1 nest pas trouvé parli les participant', 16, 1);
				END

			if((SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournoi and ID_User = @ID_PlayerTwo)) <> 1 )
				BEGIN
					RAISERROR('la le joueur 2 nest pas trouvé parli les participant', 16, 1);
				END

			if((SELECT COUNT(*) FROM [Match] WHERE (ID_Tournament = @ID_Tournoi and RoundNumber = @RoundNumber and ID_PlayerOne = @ID_PlayerOne)) <> 1)
				BEGIN
					RAISERROR('le match est introuvable', 16, 1);
				END

			if(@ID_NewPone is null and @ID_NewPTwo is null)
				BEGIN
					RAISERROR('pas de modification', 16, 1);
				END

			UPDATE [Match]
				SET ID_PlayerOne = ISNULL(@ID_NewPone, ID_PlayerOne),
					ID_PlayerTwo = ISNULL(@ID_NewPTwo, ID_PlayerTwo)
				WHERE [ID_Tournament] = @ID_Tournoi and [RoundNumber] = @RoundNumber and [ID_PlayerOne] = @ID_PlayerOne


			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_DELETE_Match
	@ID_Tournoi INT,
	@RoundNumber INT,
	@ID_PlayerOne INT,
	@ID_PlayerTwo INT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(@RoundNumber IS null or ((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournoi and @RoundNumber = RoundNumber)) >0))
				BEGIN
					RAISERROR('la round existe déjà', 16, 1);
				END

			if((SELECT COUNT(*) FROM [Match] WHERE (ID_Tournament = @ID_Tournoi and RoundNumber = @RoundNumber and ID_PlayerOne = @ID_PlayerOne)) <> 1)
				BEGIN
					RAISERROR('le match est introuvable', 16, 1);
				END


			DELETE [Match]
				WHERE [ID_Tournament] = @ID_Tournoi and [RoundNumber] = @RoundNumber and [ID_PlayerOne] = @ID_PlayerOne 


			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO


CREATE PROCEDURE SP_CREATE_Partie
	@ID_Tournament INT,
	@RoundNumber INT,
	@ID_PlayerOne INT,
	@ID_PlayerTwo INT,
	@PartNumber INT,
	@ID_Deck_PlayerOne INT,
	@ID_Deck_PlayerTwo INT,
	@ResultPart TINYINT = NULL,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournament IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournament and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(@RoundNumber IS null or ((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournament and @RoundNumber = RoundNumber)) <> 1))
				BEGIN
					RAISERROR('la round n existe pas', 16, 1);
				END

			if(@ID_PlayerOne is null or (SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournament and ID_User = @ID_PlayerOne)) <> 1 )
				BEGIN
					RAISERROR('la le joueur 1 nest pas trouvé parli les participant', 16, 1);
				END

			if((@ID_PlayerTwo is null or (SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournament and ID_User = @ID_PlayerTwo)) <> 1) AND (@ID_PlayerTwo <>0) )
				BEGIN
					RAISERROR('la le joueur 2 nest pas trouvé parli les participant', 16, 1);
				END

			if(@ID_Deck_PlayerOne is null or (SELECT COUNT(*) FROM [DeckJoueur] WHERE (ID_Deck = @ID_Deck_PlayerOne and ID_User = @ID_PlayerOne and ID_Tournament = @ID_Tournament))>0)
				BEGIN
					RAISERROR('le deck1 nes pas bon', 16, 1);
				END

			if(@ID_Deck_PlayerTwo is null or (SELECT COUNT(*) FROM [DeckJoueur] WHERE (ID_Deck = @ID_Deck_PlayerTwo and ID_User = @ID_PlayerTwo and ID_Tournament = @ID_Tournament))>0)
				BEGIN
					RAISERROR('le deck2 nes pas bon', 16, 1);
				END
			if(@ResultPart is not null AND(@ResultPart <0 or @ResultPart > 2))
				BEGIN
					RAISERROR('le resulta est incorect', 16, 1);
				END

			INSERT INTO [Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart])
				VALUES(@ID_Tournament, @RoundNumber, @ID_PlayerOne, @ID_PlayerTwo, @PartNumber, @ID_Deck_PlayerOne, @ID_Deck_PlayerTwo, @ResultPart)

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO




CREATE PROCEDURE SP_EDIT_Partie
	@ID_Tournament INT,
	@RoundNumber INT,
	@ID_PlayerOne INT,
	@ID_PlayerTwo INT,
	@PartNumber INT,
	@ID_Deck_PlayerOne INT,
	@ID_Deck_PlayerTwo INT,
	@ResultPart TINYINT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournament IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournament and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(@RoundNumber IS null or ((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournament and @RoundNumber = RoundNumber)) <> 1))
				BEGIN
					RAISERROR('la round n existe pas', 16, 1);
				END

			if(@ID_PlayerOne is null or (SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournament and ID_User = @ID_PlayerOne)) <> 1 )
				BEGIN
					RAISERROR('la le joueur 1 nest pas trouvé parli les participant', 16, 1);
				END

			if((@ID_PlayerTwo is null or (SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournament and ID_User = @ID_PlayerTwo)) <> 1) AND (@ID_PlayerTwo <>0) )
				BEGIN
					RAISERROR('la le joueur 2 nest pas trouvé parli les participant', 16, 1);
				END

			if(@ID_Deck_PlayerOne is null or (SELECT COUNT(*) FROM [DeckJoueur] WHERE (ID_Deck = @ID_Deck_PlayerOne and ID_User = @ID_PlayerOne and ID_Tournament = @ID_Tournament))>0)
				BEGIN
					RAISERROR('le deck1 nes pas bon', 16, 1);
				END

			if(@ID_Deck_PlayerTwo is null or (SELECT COUNT(*) FROM [DeckJoueur] WHERE (ID_Deck = @ID_Deck_PlayerTwo and ID_User = @ID_PlayerTwo and ID_Tournament = @ID_Tournament))>0)
				BEGIN
					RAISERROR('le deck2 nes pas bon', 16, 1);
				END
			if(@ResultPart IS NULL OR (@ResultPart <0 or @ResultPart > 2))
				BEGIN
					RAISERROR('le resulta est incorect', 16, 1);
				END
			if((SELECT COUNT(*) FROM [Partie] WHERE ([ID_Tournament] = @ID_Tournament AND [RoundNumber] = @RoundNumber AND [ID_PlayerOne] = @ID_PlayerOne AND [ID_PlayerTwo] = @ID_PlayerTwo AND [PartNumber] = @PartNumber)) <> 1)
				BEGIN
					RAISERROR('Partie introuvable', 16, 1);
				END

			UPDATE [Partie]
				SET [ResultPart] = @ResultPart,
					[ID_Deck_PlayerOne] = @ID_Deck_PlayerOne,
					[ID_Deck_PlayerTwo] = @ID_Deck_PlayerTwo
				WHERE ([ID_Tournament] = @ID_Tournament AND [RoundNumber] = @RoundNumber AND [ID_PlayerOne] = @ID_PlayerOne AND [ID_PlayerTwo] = @ID_PlayerTwo AND [PartNumber] = @PartNumber)
		
			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_DELETE_Partie
	@ID_Tournament INT,
	@RoundNumber INT,
	@ID_PlayerOne INT,
	@ID_PlayerTwo INT,
	@PartNumber INT,
	@responseMessage NVARCHAR(250) OUTPUT,
	@Reussie BIT OUTPUT
AS
BEGIN

	SET @responseMessage = '';
	SET @Reussie = 1; 

	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournament IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournament and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			if(@RoundNumber IS null or ((SELECT COUNT(*) FROM [Round] WHERE (ID_Tournament = @ID_Tournament and @RoundNumber = RoundNumber)) <> 1))
				BEGIN
					RAISERROR('la round n existe pas', 16, 1);
				END

			if(@ID_PlayerOne is null or (SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournament and ID_User = @ID_PlayerOne)) <> 1 )
				BEGIN
					RAISERROR('la le joueur 1 nest pas trouvé parli les participant', 16, 1);
				END

			if((@ID_PlayerTwo is null or (SELECT COUNT(*) FROM [Joueur] WHERE (ID_Tournament = @ID_Tournament and ID_User = @ID_PlayerTwo)) <> 1) AND (@ID_PlayerTwo <>0) )
				BEGIN
					RAISERROR('la le joueur 2 nest pas trouvé parli les participant', 16, 1);
				END

			DELETE [Partie]
				WHERE ([ID_Tournament] = @ID_Tournament AND [RoundNumber] = @RoundNumber AND [ID_PlayerOne] = @ID_PlayerOne AND [ID_PlayerTwo] = @ID_PlayerTwo AND [PartNumber] = @PartNumber)
		
			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			SET @Reussie =0;
			ROLLBACK;
		END CATCH
END
GO



--faire la procédure pairing 

--____________________FIN CREATION STORED PROCEDURE____________________________



--________________DEBUT CREATION DES LOGIN_______________________________________________


--Add Login API
if not exists(select * from sys.sql_logins where name = 'API_User')
	Create Login [API_User]
	With Password = '1234@Test',
	Default_Database = [Tour0Suisse]	
Go

Create User [API_User]
	For Login [API_User]
Go



--________________FIN CREATION DES LOGIN_______________________________________________

--___________________DEBUT AUTORISATION_______________________________________________


GRANT VIEW DEFINITION ON TYPE::[dbo].[ID_List]   To [API_User]
GO

GRANT CONTROL ON TYPE::[dbo].[ID_List]       To [API_User]
GO



GRANT VIEW DEFINITION ON TYPE::[dbo].[List_Deck]   To [API_User]
GO

GRANT CONTROL ON TYPE::[dbo].[List_Deck]       To [API_User]
GO



GRANT VIEW DEFINITION ON TYPE::[dbo].[List_Pairing]   To [API_User]
GO

GRANT CONTROL ON TYPE::[dbo].[List_Pairing]       To [API_User]
GO


Grant execute 
	on [dbo].[SP_ADD_PseudoIG] To [API_User]
GO
Grant execute 
	on [dbo].[SP_AddAdmin] To [API_User]
GO
Grant execute 
	on [dbo].[SP_AddGame] To [API_User]
GO
Grant execute 
	on [dbo].[SP_CREATE_Match] To [API_User]
GO
Grant execute 
	on [dbo].[SP_CREATE_Match_ALLPairing] To [API_User]
GO
Grant execute 
	on [dbo].[SP_CREATE_Partie] To [API_User]
GO
Grant execute 
	on [dbo].[SP_CREATE_Round] To [API_User]
GO
Grant execute 
	on [dbo].[SP_Edit_Round] To [API_User]
GO
Grant execute 
	on [dbo].[SP_Create_User] To [API_User]
GO
Grant execute 
	on [dbo].[SP_CreateTournoi] To [API_User]
GO
Grant execute 
	on [dbo].[SP_DELETE_Match] To [API_User]
GO
Grant execute 
	on [dbo].[SP_DELETE_Partie] To [API_User]
GO
Grant execute 
	on [dbo].[SP_Delete_PseudoIG] To [API_User]
GO
Grant execute 
	on [dbo].[SP_DELETE_Round] To [API_User]
GO
Grant execute 
	on [dbo].[SP_DELETE_RoundAndMatch] To [API_User]
GO
Grant execute 
	on [dbo].[SP_DELETEAdmin] To [API_User]
GO
Grant execute 
	on [dbo].[SP_DELETEDResultat] To [API_User]
GO
Grant execute 
	on [dbo].[SP_DELETEGame] To [API_User]
GO
Grant execute 
	on [dbo].[SP_DeleteTournoi] To [API_User]
GO
Grant execute 
	on [dbo].[SP_DeleteUser] To [API_User]
GO
Grant execute 
	on [dbo].[SP_EDIT_Match] To [API_User]
GO
Grant execute 
	on [dbo].[SP_EDIT_Partie] To [API_User]
GO
Grant execute 
	on [dbo].[SP_EDIT_PseudoIG] To [API_User]
GO
Grant execute 
	on [dbo].[SP_EDITAdmin] To [API_User]
GO
Grant execute 
	on [dbo].[SP_EDITGame] To [API_User]
GO
Grant execute 
	on [dbo].[SP_EDITResultat] To [API_User]
GO
Grant execute 
	on [dbo].[SP_EditTournoi] To [API_User]
GO
Grant execute 
	on [dbo].[SP_EditUser] To [API_User]
GO
Grant execute 
	on [dbo].[SP_EndTournoi] To [API_User]
GO
Grant execute 
	on [dbo].[SP_RegisterTournoi] To [API_User]
GO
Grant execute 
	on [dbo].[SP_UnregisterTournoi] To [API_User]
GO
Grant execute 
	on [dbo].[SP_UpdateDeck] To [API_User]
GO




GRANT VIEW DEFINITION ON [dbo].[View_ClassementTemporaire] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_ClassementTemporaire] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_ClassementTemporaire] TO [API_User]
GO


GRANT VIEW DEFINITION ON [dbo].[View_Deck] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Deck] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Deck] TO [API_User]
GO






GRANT VIEW DEFINITION ON [dbo].[View_Jeu] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Jeu] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Jeu] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_Match] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Match] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Match] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_Orga] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Orga] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Orga] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_Participant] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Participant] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Participant] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_Partie] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Partie] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Partie] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_Pseudo] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Pseudo] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Pseudo] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_Resulta] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Resulta] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Resulta] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_ResultMatchPlayer] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_ResultMatchPlayer] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_ResultMatchPlayer] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_ResultPartPlayer] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_ResultPartPlayer] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_ResultPartPlayer] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_Round] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Round] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Round] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_ScoreClassementTemporaire] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_ScoreClassementTemporaire] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_ScoreClassementTemporaire] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_Tournament] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Tournament] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Tournament] TO [API_User]
GO



GRANT VIEW DEFINITION ON [dbo].[View_User] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_User] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_User] TO [API_User]
GO


GRANT VIEW DEFINITION ON [dbo].[View_Dotation] TO [API_User]
GO

GRANT REFERENCES ON [dbo].[View_Dotation] TO [API_User]
GO

GRANT SELECT ON [dbo].[View_Dotation] TO [API_User]
GO


--___________________FIN AUTORISATION_______________________________________________


use master
GO