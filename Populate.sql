INSERT INTO Utilisateur ([Pseudo], [Email], [Password], [Organizer], [DELETED])
	VALUES('Test', 'Test@NaN.NaN', HASHBYTES('SHA2_512','Test'), 0, null)


insert into Jeu ([Name]) values ('jeu1');
insert into PseudoIG([ID_User], [ID_Game], [IG_Pseudo]) values (1, 1, 'Aedjis');