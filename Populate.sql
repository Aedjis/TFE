use Tour0Suisse
GO

INSERT INTO Utilisateur ([Pseudo], [Email], [Password], [Organizer], [DELETED])
	VALUES('Aedjis', 'poncelet.gregoire@gmail.com', HASHBYTES('SHA2_512','Test@1234'), 1, null)

insert into Jeu ([Name]) 
	values ('Autres'), ('Discord'), ('Hearstone'), ('Magic');
insert into PseudoIG([ID_User], [ID_Game], [IG_Pseudo]) 
	values (1, 1, 'Aedjis'), (1, 2, 'Aedjis'), (1, 3, 'Aedjis');



GO
Use master
GO