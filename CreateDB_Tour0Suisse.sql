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
ID_User INT NOT NULL IDENTITY(0,1),
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
[DeckListNumber] INT NOT NULL DEFAULT(0),
[PPWin] INT NOT NULL DEFAULT(2),
[PPDraw] INT NOT NULL DEFAULT(1),
[PPLose] INT NOT NULL DEFAULT(0),
[Over] BIT NOT NULL DEFAULT(0),
[DELETED] date null DEFAULT(null),

CONSTRAINT PK_Tournament__XXXX PRIMARY KEY(ID_Tournament)
)ON Tournoi
GO

CREATE TABLE [Jeu](
ID_Game INT NOT NULL IDENTITY,
[Name] VARCHAR(50) NOT NULL,

CONSTRAINT PK_Game__XXXX PRIMARY KEY(ID_Game)
)ON Reste
GO

CREATE TABLE [Deck](
ID_Deck INT NOT NULL IDENTITY(0,1),
DeckList Text NOT NULL,
ID_Game INT NOT NULL,

CONSTRAINT PK_Deck__XXXX PRIMARY KEY(ID_Deck)
)ON Reste
GO

CREATE TABLE [Resultat](
ID_Tournament INT NOT NULL,
ID_User INT NOT NULL,
[Rank] INT NOT NULL,
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
StartRound DATETIME NOT NULL,

CONSTRAINT PK_Round__XXXX PRIMARY KEY(ID_Tournament, RoundNumber)
)ON Tournoi
GO

CREATE TABLE [Match](
ID_Tournament INT NOT NULL,
RoundNumber INT NOT NULL,
ID_PlayerOne INT NOT NULL,
ID_PlayerTwo INT NOT NULL,

CONSTRAINT PK_Match__XXXX PRIMARY KEY(ID_Tournament, RoundNumber, ID_PlayerOne, ID_PlayerTwo) -- besoin de l'id que de un joureur
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

CONSTRAINT PK_Part__XXXX PRIMARY KEY(ID_Tournament, RoundNumber, ID_PlayerOne, ID_PlayerTwo, PartNumber) -- besoin de l'id que de un joureur
)ON Tournoi
GO

CREATE TABLE [Organisateur](
ID_Tournament INT NOT NULL,
ID_User INT NOT NULL,
[Level] int default(1)

CONSTRAINT PK_Organizer__XXXX PRIMARY KEY(ID_Tournament, ID_User)
)ON Tournoi
GO

--CREATE TABLE [Joueur](  --fait doublons avec le tablme deck joueur
--ID_Tournament INT NOT NULL,
--ID_User INT NOT NULL,

--CONSTRAINT PK_Player__XXXX PRIMARY KEY(ID_Tournament, ID_User)
--)ON Tournoi
--GO

CREATE TABLE [DeckJoueur](
ID_Tournament INT NOT NULL,
ID_User INT NOT NULL,
ID_Deck INT NOT NULL,
[Drop] BIT NOT NULL DEFAULT(0),

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
ADD CONSTRAINT FK_Part_Match__XXXX	FOREIGN KEY (ID_Tournament, RoundNumber, ID_PlayerOne, ID_PlayerTwo)
									REFERENCES [Match](ID_Tournament, RoundNumber, ID_PlayerOne, ID_PlayerTwo)
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

--ALTER TABLE [Joueur]
--ADD CONSTRAINT FK_Joueur_Utilisateur__XXXX	FOREIGN KEY (ID_User)
--											REFERENCES [UTilisateur](ID_User)
--GO

--ALTER TABLE [Joueur]
--ADD CONSTRAINT FK_Joueur_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
--										REFERENCES [Tournoi](ID_Tournament)
--GO

--ALTER TABLE [DeckJoueur]
--ADD CONSTRAINT FK_DeckJoueur_Utilisateur__XXXX	FOREIGN KEY (ID_User)
--												REFERENCES [Utilisateur](ID_User)
--GO

ALTER TABLE [DeckJoueur]
ADD CONSTRAINT FK_DeckJoueur_Tournoi__XXXX	FOREIGN KEY (ID_Tournament)
											REFERENCES [Tournoi](ID_Tournament)
GO

ALTER TABLE [DeckJoueur]
ADD CONSTRAINT FK_DeckJoueur_Deck__XXXX	FOREIGN KEY (ID_Deck)
										REFERENCES [Deck](ID_Deck)
GO

--____________FIN CREATION DES LIEN ENTRE LES TABLES_________________________

--____________________________________________________

--_____________DEBUT DE CREATION D'UTILISATEUR, JEU, DECK VIDE______________________

INSERT INTO Utilisateur ([Pseudo], [Email], [Password], [Organizer], [DELETED])
	VALUES('Bye', 'NaN@NaN.NaN', HASHBYTES('SHA2_512',''), 0, GETDATE())

INSERT INTO Jeu([Name])
	VALUES('Autre')

INSERT INTO Deck([ID_Game], DeckList)
	VALUES(1, '')

GO

--_____________FIN DE CREATION D'UTILISATEUR, JEU, DECK VIDE______________________

--______________________________________________________

--____________DEBUT CREATION DES VUES________________________
CREATE VIEW [View_User] AS
SELECT ID_User, Pseudo, Email, [Password], Organizer
FROM Utilisateur
WHERE DELETED is null
GO

CREATE VIEW [View_Tournament] AS
SELECT ID_Tournament, ID_Game, [Name], [Date], [DeckListNumber], [PPWin], [PPDraw], [PPLose]
FROM Tournoi
WHERE DELETED is null
GO

CREATE VIEW [View_Orga] AS
SELECT O.ID_Tournament, t.Name, O.ID_User, U.Pseudo, O.[Level]
FROM Organisateur as O
JOIN Tournoi as T
	ON O.ID_Tournament = T.ID_Tournament
JOIN Utilisateur as U
	ON O.ID_User = u.Pseudo
GO

CREATE VIEW [View_Participant] AS
SELECT DISTINCT J.ID_Tournament, t.Name, J.ID_User, U.Pseudo
FROM DeckJoueur as J
JOIN Tournoi as T
	ON J.ID_Tournament = T.ID_Tournament
JOIN Utilisateur as U
	ON J.ID_User = u.Pseudo
GO

CREATE VIEW [View_Jeu] AS
SELECT ID_Game, [Name]
FROM Jeu
GO

CREATE VIEW [View_Resulta] AS
SELECT R.ID_Tournament, T.Name, R.ID_User, U.Pseudo, R.Rank, R.Score, R.TieBreaker, R.AdditionalTieBreaker, R.AdditionalTieBreakerRules
FROM Resultat as R
JOIN Tournoi as T
	ON T.ID_Tournament = R.ID_Tournament
JOIN Utilisateur as U
	ON U.ID_User = R.ID_User
GO

CREATE VIEW [View_Partie] AS
SELECT P.ID_Tournament, T.Name, P.RoundNumber, P.PartNumber, P.ResultPart, P.ID_PlayerOne, UOne.Pseudo AS [PlayerOne], P.ID_Deck_PlayerOne, DOne.DeckList AS [DeckOne], UTwo.Pseudo AS [PlayerTwo], P.ID_Deck_PlayerTwo, DTwo.DeckList AS [DeckTwo]
FROM Partie as P
JOIN Tournoi as T
	ON T.ID_Tournament = p.ID_Tournament
JOIN Utilisateur as UOne
	ON UOne.ID_User = P.ID_PlayerOne
JOIN Utilisateur as UTwo
	ON UTwo.ID_User = P.ID_PlayerTwo
JOIN Deck as DOne
	ON DOne.ID_Deck = P.ID_Deck_PlayerOne
JOIN Deck as DTwo
	ON DTwo.ID_Deck = P.ID_Deck_PlayerTwo
GO

CREATE VIEW[View_Deck] AS
SELECT DJ.ID_Tournament, T.Name, DJ.ID_User, U.Pseudo, DJ.ID_Deck, D.DeckList
FROM DeckJoueur AS DJ
JOIN Deck AS D
	ON D.ID_Deck = DJ.ID_Deck
JOIN Tournoi AS T
	ON T.ID_Tournament = DJ.ID_Tournament
JOIN Utilisateur AS U
	ON U.ID_User = DJ.ID_User
GO

CREATE VIEW [View_ResultPartPlayer] AS
SELECT ID_Tournament, RoundNumber, PartNumber, ID_PlayerOne AS ID_Player,	CASE ResultPart
																				WHEN 2
																				THEN -1
																				ELSE ResultPart
																			END AS Resulta
FROM Partie
WHERE ID_Tournament IN (SELECT ID_Tournament FROM Tournoi WHERE [Over] = 0)
union
SELECT ID_Tournament, RoundNumber, PartNumber, ID_PlayerTWO AS ID_Player,	CASE ResultPart
																				WHEN 2
																				THEN 1
																				WHEN null
																				THEN null
																				ELSE (0-ResultPart)
																			END AS Resulta
FROM Partie
WHERE ID_Tournament IN (SELECT ID_Tournament FROM Tournoi WHERE [Over] = 0)
GO

CREATE VIEW [View_Match] AS
SELECT [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [ID_Tournament]
FROM [Match]
GO

CREATE VIEW [View_ResultMatchPlayer] AS
SELECT ID_Tournament, RoundNumber, ID_Player,	CASE 
													WHEN SUM(Resulta) >0
													THEN 1
													WHEN SUM(Resulta) <0
													THEN -1
													WHEN SUM(Resulta) =0
													THEN 0
													ELSE null
												END AS Resulta
FROM [View_ResultPartPlayer]
GROUP BY ID_Tournament, RoundNumber, ID_Player
GO

CREATE VIEW [View_ClassementTemporaire] AS
SELECT	ID_Tournament, 
		ID_Player, 
		SUM(CASE WHEN Resulta = 1 THEN 1 ELSE 0 END) AS Victoire, 
		SUM(CASE WHEN Resulta = 0 THEN 1 ELSE 0 END) AS Egaliter, 
		SUM(CASE WHEN Resulta = 2 THEN 1 ELSE 0 END) AS Defaite
FROM [View_ResultMatchPlayer]
GROUP BY ID_Tournament, ID_Player
--ORDER BY  Victoire DESC, Egaliter DESC, Defaite ASC
GO

CREATE VIEW [View_ScoreClassementTemporaire] AS
SELECT	V.ID_Tournament, 
		ID_Player, 
		(V.Victoire * T.PPWin + V.Egaliter * T.PPDraw + V.Defaite * T.PPLose) AS Score,
		Victoire, 
		Egaliter, 
		Defaite
FROM [View_ClassementTemporaire] as V
JOIN Tournoi as T
	ON T.ID_Tournament = V.ID_Tournament
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

CREATE PROCEDURE SP_Create_User
	@Pseudo VARCHAR(50), 
	@Email VARCHAR(256),
	@Password BINARY(64), --soit varcahr(50) si passé en claire soit binary (64) si haché
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	
	SET @responseMessage = '';	

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
			ROLLBACK;
		END CATCH

	if(@responseMessage ='' and (SELECT COUNT(*) FROM Utilisateur WHERE @Pseudo = Pseudo and @Email = Email)=1)
	BEGIN
		SET @responseMessage = 'Création de l utilisateur '+@Pseudo+' avec comme adresse email '+@Email;
	END

END
GO


CREATE PROCEDURE SP_EditUser
	@ID_User INT ,
	@Organizer BIT=NULL,
	@Pseudo VARCHAR(50) =NULL, 
	@Email VARCHAR(256)=NULL,
	@Password BINARY(64)=NULL, --soit varcahr(50) si passé en claire soit binary (64) si haché
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN

	BEGIN TRANSACTION;
		BEGIN TRY
			if( @ID_User IS NULL OR @ID_User <=0)
				Begin
					RAISERROR('Le ID user est invalide',16,1);
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
			--else
			--	BEGIN
			--		SET @HMDP =  HASHBYTES('SHA2_512', @Password);
			--	END
			-- legacy si le mot de passe était en claire

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

			SET @responseMessage='utilisateur mis a jour';

		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			ROLLBACK;
		END CATCH

END
GO

CREATE PROCEDURE SP_DeleteUser
	@ID_User INT ,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le utilisateur est introuvable',16,1);
				End

			UPDATE Utilisateur
			SET DELETED = CAST( GETDATE() AS Date )
			WHERE ID_User = @ID_User
			
			COMMIT;

			SET @responseMessage='l utilisateur a été supprimer';

		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_CreateTournoi
	@Name VARCHAR(50),
	@Date DATETIME,
	@ID_Game INT,
	@Description TEXT,
	@DeckListNumber INT =0,
	@PPWin INT =2,
	@PPDraw INT =1,
	@PPLose INT =0,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			if(@Name IS NULL OR (TRIM(@Name)) ='')
				BEGIN
					RAISERROR('Le nom du tournoi est vide',16,1);
				END
			if(@Date IS NULL OR @Date < GETDATE())
				BEGIN
					RAISERROR('La date du tournoi est incorrect',16,1);
				END
			if(@ID_Game IS NULL OR (SELECT COUNT(*) FROM Jeu WHERE @ID_Game = ID_Game) <> 1)
				BEGIN
					RAISERROR('Le jeu du tournoi est introuvable',16,1);
				END
			if(@DeckListNumber IS NULL)
				BEGIN
					SET @DeckListNumber = 0;
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

				INSERT INTO Tournoi ([Name], [Date], [ID_Game], [Desciption], [DeckListNumber], [PPWin], [PPDraw], [PPLose])
					VALUES(@Name, @Date, @ID_Game, @Description, @DeckListNumber, @PPWin, @PPDraw, @PPLose) 

				SET @responseMessage='le tournoi a été creer';
			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
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
	@DeckListNumber INT =NULL,
	@PPWin INT =NULL,
	@PPDraw INT =NULL,
	@PPLose INT =NULL,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) = 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End
			if(@Name IS NULL OR (TRIM(@Name)) ='')
				BEGIN
					SET @Name = NULL;
				END
			if(@Date < GETDATE())
				BEGIN
					RAISERROR('La date du tournoi est incorrect',16,1);
				END
			if((SELECT COUNT(*) FROM Jeu WHERE @ID_Game = ID_Game) <> 1)
				BEGIN
					RAISERROR('Le jeu du tournoi est introuvable',16,1);
				END

			

			if(@Name is null and @Date is null and @ID_Game is null and @PPWin is null and @PPDraw is null and @PPLose is null and @DeckListNumber is null and @Description is null)
				BEGIN
					RAISERROR('Aucune update',16,1);
				END

			UPDATE Tournoi
			SET	[Name] = ISNULL(@Name, [Name]),
				[Date] = ISNULL(@Date, [Date]),
				[ID_Game] = ISNULL(@ID_Game, [ID_Game]),
				[Desciption] = ISNULL(@Description, [Desciption]),
				[DeckListNumber] = ISNULL(@DeckListNumber, [DeckListNumber]),
				[PPWin] = ISNULL(@PPWin, [PPWin]),
				[PPDraw] = ISNULL(@PPDraw, [PPDraw]),
				[PPLose] = ISNULL(@PPLose, [PPLose])
			WHERE @ID_Tournoi = ID_Tournament

				SET @responseMessage='le tournoi a été mis a jour';
			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_EndTournoi
	@ID_Tournoi INT ,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
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

			--inseré ici la création des résulta du tournoi ou faire un triggeur pour le faire sur le changement de over a 1


			INSERT INTO Resultat ([ID_Tournament], [ID_User], [Score], [TieBreaker], [Rank])
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
			ORDER BY [Rank]

			UPDATE Tournoi
			SET [Over] = 1
			WHERE ID_Tournament = @ID_Tournoi
			
			COMMIT;

			SET @responseMessage='le tournoi a été fini, le classement a été généré';

		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_DeleteTournoi
	@ID_Tournoi INT ,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null)) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End

			UPDATE Tournoi
			SET DELETED = CAST( GETDATE() AS Date )
			WHERE ID_Tournament = @ID_Tournoi
			
			COMMIT;

			SET @responseMessage='le tournoi a été supprimer';

		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_RegisterTournoi
	@ID_Tournoi INT,
	@ID_User INT,
	@ListDeck List_Deck READONLY,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	DECLARE @DeckID INT = null
	DECLARE @IDGame INT;
	DECLARE @ListID ID_List;
	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null and [Date]> GETDATE())) <> 1)
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
			ELSE
				BEGIN
					INSERT INTO DeckJoueur ([ID_Tournament], [ID_User], [ID_Deck])
						VALUES(@ID_Tournoi, @ID_User, 0)
				END

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_UnregisterTournoi
	@ID_Tournoi INT,
	@ID_User INT,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and [Date]> GETDATE())) <> 1)
				Begin
					RAISERROR('Le tournoi est introuvable',16,1);
				End
			if( @ID_User IS NULL OR (SELECT COUNT(*) FROM Utilisateur WHERE (ID_User = @ID_User)) <> 1)
				Begin
					RAISERROR('L utilisateur est introuvable',16,1);
				End
			
			DELETE DeckJoueur
			WHERE [ID_Tournament] = @ID_Tournoi AND [ID_User] = @ID_User

			COMMIT;
		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE();
			ROLLBACK;
		END CATCH
END
GO

CREATE PROCEDURE SP_UpdateDeck
	@ID_Tournoi INT,
	@ID_User INT,
	@ID_Deck INT,
	@DeckList TEXT,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
	DECLARE @IDGame INT
	DECLARE @IDDeck INT
	DECLARE @ListID ID_List
	BEGIN TRY
		if( @ID_Tournoi IS NULL OR (SELECT COUNT(*) FROM Tournoi WHERE (ID_Tournament = @ID_Tournoi and DELETED is null and [Date]> GETDATE())) <> 1)
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
		ROLLBACK;
	END CATCH
END
GO

CREATE PROCEDURE SP_AddAdmin
	@ID_Tournoi INT,
	@ID_User INT,
	@Level INT = 1,
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
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
		ROLLBACK;
	END CATCH
END
GO

CREATE PROCEDURE SP_AddGame
	@Name VARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
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
		ROLLBACK;
	END CATCH
END
GO
--faire la procédure pairing 

--____________________FIN CREATION STORED PROCEDURE____________________________