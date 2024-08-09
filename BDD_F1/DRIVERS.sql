CREATE TABLE [dbo].[DRIVERS]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	Id_Constructeur int,
	Nom varchar(32),
	Prenom varchar(32), 
    CONSTRAINT [FK_DRIVERS_CONSTRUCTEURS] FOREIGN KEY (Id_Constructeur) REFERENCES CONSTRUCTEURS(Id),

)
