Use [Tour0Suisse];
Go



SET IDENTITY_INSERT [dbo].[Jeu] ON 
GO
INSERT [dbo].[Jeu] ([ID_Game], [Name], [DELETED]) VALUES (1, N'Autres', 0)
GO
INSERT [dbo].[Jeu] ([ID_Game], [Name], [DELETED]) VALUES (2, N'Discord', 0)
GO
INSERT [dbo].[Jeu] ([ID_Game], [Name], [DELETED]) VALUES (3, N'Hearstone', 0)
GO
INSERT [dbo].[Jeu] ([ID_Game], [Name], [DELETED]) VALUES (4, N'Magic', 0)
GO
SET IDENTITY_INSERT [dbo].[Jeu] OFF
GO



SET IDENTITY_INSERT [dbo].[Utilisateur] ON 
--GO
--INSERT [dbo].[Utilisateur] ([ID_User], [Pseudo], [Email], [Password], [Organizer], [DELETED]) VALUES (0, N'', N'Bye@Bye@Bye.bye', 0x384093F3CB2DC889AADA2F6FCF5880BC56A7FEEF25729994FE89F68F772CE85880A2BA0A9436435E03DED6722AADFC0B84D2BA9DAF9C69D175F6E4AF4A2FABB4, 0, CAST(N'2000-01-04' AS Date))
--GO
INSERT [dbo].[Utilisateur] ([ID_User], [Pseudo], [Email], [Password], [Organizer], [DELETED]) VALUES (1, N'Aedjis', N'poncelet.gregoire@gmail.com', 0x384093F3CB2DC889AADA2F6FCF5880BC56A7FEEF25729994FE89F68F772CE85880A2BA0A9436435E03DED6722AADFC0B84D2BA9DAF9C69D175F6E4AF4A2FABB4, 1, NULL)
GO
INSERT [dbo].[Utilisateur] ([ID_User], [Pseudo], [Email], [Password], [Organizer], [DELETED]) VALUES (2, N'test', N'fsd@hot.com', 0x384093F3CB2DC889AADA2F6FCF5880BC56A7FEEF25729994FE89F68F772CE85880A2BA0A9436435E03DED6722AADFC0B84D2BA9DAF9C69D175F6E4AF4A2FABB4, 0, CAST(N'2021-04-04' AS Date))
GO
DECLARE @i AS INT = 0;
WHILE (@i <100)
	BEGIN
	
		INSERT [dbo].[Utilisateur] ([ID_User], [Pseudo], [Email], [Password], [Organizer], [DELETED]) VALUES (@i+3, CONCAT(N'AutoInsertJ', @I), CONCAT(N'J', @i, N'@gmail.com'), 0x384093F3CB2DC889AADA2F6FCF5880BC56A7FEEF25729994FE89F68F772CE85880A2BA0A9436435E03DED6722AADFC0B84D2BA9DAF9C69D175F6E4AF4A2FABB4, 0, NULL)
		INSERT [dbo].[PseudoIG] ([ID_User], [ID_Game], [IG_Pseudo]) VALUES (@i+3, 1, CONCAT(N'Joueur', @i))
		INSERT [dbo].[PseudoIG] ([ID_User], [ID_Game], [IG_Pseudo]) VALUES (@i+3, 2, CONCAT(N'Joueur#220', @i))
		INSERT [dbo].[PseudoIG] ([ID_User], [ID_Game], [IG_Pseudo]) VALUES (@i+3, 3, CONCAT(N'Joueur#521', @i))
		INSERT [dbo].[PseudoIG] ([ID_User], [ID_Game], [IG_Pseudo]) VALUES (@i+3, 4, CONCAT(N'Joueur#5A1', @i))
		
		SET @i = @i+1;

	END
GO

SET IDENTITY_INSERT [dbo].[Utilisateur] OFF
GO

INSERT [dbo].[PseudoIG] ([ID_User], [ID_Game], [IG_Pseudo]) VALUES (1, 1, N'Aédjis')
GO
INSERT [dbo].[PseudoIG] ([ID_User], [ID_Game], [IG_Pseudo]) VALUES (1, 2, N'Aedjis')
GO
INSERT [dbo].[PseudoIG] ([ID_User], [ID_Game], [IG_Pseudo]) VALUES (1, 3, N'Aedjis#2241')
GO
INSERT [dbo].[PseudoIG] ([ID_User], [ID_Game], [IG_Pseudo]) VALUES (1, 4, N'Aedjis')
GO


SET IDENTITY_INSERT [dbo].[Tournoi] ON 
GO
INSERT [dbo].[Tournoi] ([ID_Tournament], [Name], [Date], [Desciption], [ID_Game], [MaxNumberPlayer], [DeckListNumber], [PPWin], [PPDraw], [PPLose], [Over], [DELETED]) VALUES (1, N'1er tournoi', CAST(N'2021-04-30T20:30:00.000' AS DateTime), N'ceci est un test pour la création auto des page razor', 3, NULL, 4, 3, 1, 0, 0, NULL)
GO
INSERT [dbo].[Tournoi] ([ID_Tournament], [Name], [Date], [Desciption], [ID_Game], [MaxNumberPlayer], [DeckListNumber], [PPWin], [PPDraw], [PPLose], [Over], [DELETED]) VALUES (2, N'Tournoi a plus de 40', CAST(N'2021-04-30T20:30:00.000' AS DateTime), N'tournoi pour la présentation de lexamen', 3, NULL, 4, 3, 1, 0, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Tournoi] OFF
GO


INSERT [dbo].[Organisateur] ([ID_Tournament], [ID_User], [Level]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Organisateur] ([ID_Tournament], [ID_User], [Level]) VALUES (2, 1, 1)
GO
INSERT [dbo].[Organisateur] ([ID_Tournament], [ID_User], [Level]) VALUES (1, 2, 1)
GO


INSERT [dbo].[Joueur] ([ID_Tournament], [ID_User], [RegisterDate], [CheckIn], [Drop]) VALUES (1, 3, CAST(N'2021-04-05T15:39:37.183' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Joueur] ([ID_Tournament], [ID_User], [RegisterDate], [CheckIn], [Drop]) VALUES (1, 4, CAST(N'2021-04-05T15:40:05.093' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Joueur] ([ID_Tournament], [ID_User], [RegisterDate], [CheckIn], [Drop]) VALUES (1, 5, CAST(N'2021-04-05T15:40:26.433' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Joueur] ([ID_Tournament], [ID_User], [RegisterDate], [CheckIn], [Drop]) VALUES (1, 6, CAST(N'2021-04-05T15:40:51.213' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Joueur] ([ID_Tournament], [ID_User], [RegisterDate], [CheckIn], [Drop]) VALUES (1, 7, CAST(N'2021-04-05T15:41:19.353' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Joueur] ([ID_Tournament], [ID_User], [RegisterDate], [CheckIn], [Drop]) VALUES (1, 8, CAST(N'2021-04-05T15:42:05.980' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Joueur] ([ID_Tournament], [ID_User], [RegisterDate], [CheckIn], [Drop]) VALUES (1, 9, CAST(N'2021-04-05T15:42:21.953' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Joueur] ([ID_Tournament], [ID_User], [RegisterDate], [CheckIn], [Drop]) VALUES (1, 11, CAST(N'2021-04-05T15:43:13.830' AS DateTime), NULL, 0)
GO



SET IDENTITY_INSERT [dbo].[Deck] ON 
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (1, N'qgregqd', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (2, N'fdsgfd', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (3, N'sdfgsdfgfsdg', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (4, N'gsdfgsdfgsd', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (5, N'esqsdf', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (6, N'fdgrgfhdfg', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (7, N'jfvgnvb', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (8, N'jgfhfrdfhdgh', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (9, N'fwdvc', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (10, N'vcxwvc', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (11, N'zqqs', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (12, N'fdqsd', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (13, N'q<zef', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (14, N'fdsw', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (15, N'fdshf bf c', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (16, N'gxf nfbcf x', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (17, N'fsn', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (18, N'xcfgnbvcx', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (19, N'dsfgd', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (20, N'gswdfxc', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (21, N' v ', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (22, N' vb v', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (23, N' vb vv bvb ', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (24, N'vb bv b n ', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (25, N'dxg', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (26, N'fds', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (27, N'ds', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (28, N'vcxweddqs', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (29, N'sbhfds', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (30, N'cvxwvcx', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (31, N'cwxvc', 3)
GO
INSERT [dbo].[Deck] ([ID_Deck], [DeckList], [ID_Game]) VALUES (32, N'vxwcvw', 3)
GO
SET IDENTITY_INSERT [dbo].[Deck] OFF
GO


INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 3, 1)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 3, 2)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 3, 3)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 3, 4)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 4, 5)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 4, 6)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 4, 7)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 4, 8)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 5, 9)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 5, 10)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 5, 11)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 5, 12)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 6, 13)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 6, 14)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 6, 15)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 6, 16)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 7, 17)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 7, 18)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 7, 19)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 7, 20)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 8, 21)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 8, 22)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 8, 23)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 8, 24)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 9, 25)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 9, 26)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 9, 27)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 9, 28)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 11, 29)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 11, 30)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 11, 31)
GO
INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (1, 11, 32)
GO


INSERT [dbo].[Round] ([ID_Tournament], [RoundNumber], [StartRound], [EndRound]) VALUES (1, 1, CAST(N'2021-04-09T13:48:19.513' AS DateTime), CAST(N'2021-04-09T13:50:14.463' AS DateTime))
GO
INSERT [dbo].[Round] ([ID_Tournament], [RoundNumber], [StartRound], [EndRound]) VALUES (1, 2, CAST(N'2021-04-09T14:12:27.300' AS DateTime), CAST(N'2021-04-09T14:34:56.360' AS DateTime))
GO
INSERT [dbo].[Round] ([ID_Tournament], [RoundNumber], [StartRound], [EndRound]) VALUES (1, 3, CAST(N'2021-04-09T15:01:10.663' AS DateTime), CAST(N'2021-04-09T15:03:08.493' AS DateTime))
GO
INSERT [dbo].[Round] ([ID_Tournament], [RoundNumber], [StartRound], [EndRound]) VALUES (1, 4, CAST(N'2021-04-09T15:03:12.000' AS DateTime), CAST(N'2021-04-09T15:05:15.693' AS DateTime))
GO
INSERT [dbo].[Round] ([ID_Tournament], [RoundNumber], [StartRound], [EndRound]) VALUES (1, 5, CAST(N'2021-04-09T15:05:18.187' AS DateTime), CAST(N'2021-04-09T15:05:59.200' AS DateTime))
GO


INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 1, 3, 8)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 1, 4, 7)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 1, 5, 11)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 1, 6, 9)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 2, 3, 4)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 2, 5, 6)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 2, 7, 8)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 2, 9, 11)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 3, 3, 9)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 3, 4, 5)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 3, 6, 8)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 3, 7, 11)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 4, 4, 9)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 4, 6, 11)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 4, 7, 3)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 4, 8, 5)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 5, 5, 3)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 5, 6, 4)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 5, 8, 11)
GO
INSERT [dbo].[Match] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo]) VALUES (1, 5, 9, 7)
GO


INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 1, 3, 8, 1, 1, 22, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 1, 4, 7, 1, 5, 17, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 1, 5, 11, 1, 9, 29, 2)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 1, 6, 9, 1, 13, 27, 2)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 2, 3, 4, 1, 1, 5, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 2, 5, 6, 1, 9, 13, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 2, 7, 8, 1, 17, 21, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 2, 9, 11, 1, 25, 29, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 3, 3, 9, 1, 1, 25, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 3, 4, 5, 1, 5, 9, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 3, 6, 8, 1, 13, 21, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 3, 7, 11, 1, 17, 30, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 4, 4, 9, 1, 5, 25, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 4, 6, 11, 1, 14, 30, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 4, 7, 3, 1, 17, 2, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 4, 8, 5, 1, 22, 10, 2)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 5, 5, 3, 1, 9, 2, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 5, 6, 4, 1, 13, 5, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 5, 8, 11, 1, 21, 30, 1)
GO
INSERT [dbo].[Partie] ([ID_Tournament], [RoundNumber], [ID_PlayerOne], [ID_PlayerTwo], [PartNumber], [ID_Deck_PlayerOne], [ID_Deck_PlayerTwo], [ResultPart]) VALUES (1, 5, 9, 7, 1, 25, 17, 1)
GO


--INSERT [dbo].[Resultat] ([ID_Tournament], [ID_User], [Rank], [Gain], [Score], [TieBreaker], [AdditionalTieBreaker], [AdditionalTieBreakerRules]) VALUES (1, 3, 2, 0, 9, 39, NULL, NULL)
--GO
--INSERT [dbo].[Resultat] ([ID_Tournament], [ID_User], [Rank], [Gain], [Score], [TieBreaker], [AdditionalTieBreaker], [AdditionalTieBreakerRules]) VALUES (1, 4, 1, 0, 9, 45, NULL, NULL)
--GO
--INSERT [dbo].[Resultat] ([ID_Tournament], [ID_User], [Rank], [Gain], [Score], [TieBreaker], [AdditionalTieBreaker], [AdditionalTieBreakerRules]) VALUES (1, 5, 4, 0, 9, 33, NULL, NULL)
--GO
--INSERT [dbo].[Resultat] ([ID_Tournament], [ID_User], [Rank], [Gain], [Score], [TieBreaker], [AdditionalTieBreaker], [AdditionalTieBreakerRules]) VALUES (1, 6, 4, 0, 9, 33, NULL, NULL)
--GO
--INSERT [dbo].[Resultat] ([ID_Tournament], [ID_User], [Rank], [Gain], [Score], [TieBreaker], [AdditionalTieBreaker], [AdditionalTieBreakerRules]) VALUES (1, 7, 4, 0, 9, 33, NULL, NULL)
--GO
--INSERT [dbo].[Resultat] ([ID_Tournament], [ID_User], [Rank], [Gain], [Score], [TieBreaker], [AdditionalTieBreaker], [AdditionalTieBreakerRules]) VALUES (1, 8, 7, 0, 3, 39, NULL, NULL)
--GO
--INSERT [dbo].[Resultat] ([ID_Tournament], [ID_User], [Rank], [Gain], [Score], [TieBreaker], [AdditionalTieBreaker], [AdditionalTieBreakerRules]) VALUES (1, 9, 2, 0, 9, 39, NULL, NULL)
--GO
--INSERT [dbo].[Resultat] ([ID_Tournament], [ID_User], [Rank], [Gain], [Score], [TieBreaker], [AdditionalTieBreaker], [AdditionalTieBreakerRules]) VALUES (1, 11, 7, 0, 3, 39, NULL, NULL)
--GO















DECLARE @y AS INT = 5;
WHILE (@y <55)
	BEGIN

		INSERT [dbo].[Joueur] ([ID_Tournament], [ID_User], [RegisterDate], [CheckIn], [Drop]) VALUES (2, @y, GETUTCDATE(), NULL, 0)

		INSERT [dbo].[Deck] ([DeckList], [ID_Game]) VALUES (CONCAT(N'DeckJoueur', @y, N'numero 1'), 3)
		INSERT [dbo].[Deck] ([DeckList], [ID_Game]) VALUES (CONCAT(N'DeckJoueur', @y, N'numero 2'), 3)
		INSERT [dbo].[Deck] ([DeckList], [ID_Game]) VALUES (CONCAT(N'DeckJoueur', @y, N'numero 3'), 3)

		INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (2, @y, (SELECT ID_Deck FROM Deck WHERE DeckList LIKE CONCAT(N'DeckJoueur', @y, N'numero 1')))
		INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (2, @y, (SELECT ID_Deck FROM Deck WHERE DeckList LIKE CONCAT(N'DeckJoueur', @y, N'numero 2')))
		INSERT [dbo].[DeckJoueur] ([ID_Tournament], [ID_User], [ID_Deck]) VALUES (2, @y, (SELECT ID_Deck FROM Deck WHERE DeckList LIKE CONCAT(N'DeckJoueur', @y, N'numero 3')))

		SET @y = @y+1;

	END
GO




Use [master]
Go




