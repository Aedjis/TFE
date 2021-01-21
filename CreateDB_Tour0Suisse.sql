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