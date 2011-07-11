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
CREATE TABLE dbo.Teams
	(
	teamID uniqueidentifier NOT NULL,
	projectID uniqueidentifier NOT NULL,
	TeamName nvarchar(250) NOT NULL,
	Street nvarchar(150) NULL,
	Town nvarchar(150) NULL,
	Zip nvarchar(50) NULL,
	Phone nvarchar(50) NULL,
	Patient_Firstname nvarchar(150) NULL,
	Patient_LastName nvarchar(150) NULL,
	Patient_Birthdate date NULL,
	Patient_Medicare nvarchar(150) NULL,
	HoursPerDay decimal(18, 2) NULL,
	ContractStart date NULL,
	ContractEnd date NULL,
	Notes text NULL,
	Analysis nvarchar(250) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Teams ADD CONSTRAINT
	PK_Teams PRIMARY KEY CLUSTERED 
	(
	teamID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Teams SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
