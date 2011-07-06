/* Überprüfen Sie das Skript gründlich, bevor Sie es außerhalb des Datenbank-Designer-Kontexts ausführen, um potenzielle Datenverluste zu vermeiden.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Licences
	(
	licenceID uniqueidentifier NOT NULL,
	Name nvarchar(50) NULL,
	MaxTeams int NULL,
	MaxUsers int NULL,
	NettoPrice decimal(18, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Licences ADD CONSTRAINT
	DF_Licences_MaxTeams DEFAULT 1 FOR MaxTeams
GO
ALTER TABLE dbo.Licences ADD CONSTRAINT
	DF_Licences_MaxUsers DEFAULT 1 FOR MaxUsers
GO
ALTER TABLE dbo.Licences ADD CONSTRAINT
	DF_Licences_NettoPrice DEFAULT 0 FOR NettoPrice
GO
ALTER TABLE dbo.Licences ADD CONSTRAINT
	PK_Licences PRIMARY KEY CLUSTERED 
	(
	licenceID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Licences SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

INSERT INTO [workplace].[dbo].[Licences]
           ([licenceID]
           ,[Name]
           ,[MaxTeams]
           ,[MaxUsers]
           ,[NettoPrice])
     VALUES
           ('00000000-0000-0000-0000-000000000000',
           'Keine',
           0,
           0,
           0)
GO
COMMIT
