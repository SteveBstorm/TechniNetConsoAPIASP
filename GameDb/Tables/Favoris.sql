﻿CREATE TABLE [dbo].[Favoris]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	IdGame INT NOT NULL,
	IdUser INT NOT NULL,
	CONSTRAINT UK_Favoris UNIQUE (IdGame, IdUser),
	CONSTRAINT FK_Favoris_Game FOREIGN KEY (IdGame) REFERENCES Game(Id),
	CONSTRAINT FK_Favoris_User FOREIGN KEY (IdUser) REFERENCES Users(Id)

)
