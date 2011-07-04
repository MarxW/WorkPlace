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
CREATE TABLE dbo.Profiles
	(
	userID uniqueidentifier NOT NULL,
	projectID uniqueidentifier NULL,
	FirstName nvarchar(50) NULL,
	LastName nvarchar(50) NULL,
	Birthdate date NULL,
	Street nvarchar(250) NULL,
	Town nvarchar(150) NULL,
	Zip nvarchar(50) NULL,
	Qualification text NULL,
	WeeklyHours decimal(18, 2) NULL,
	Holidays decimal(18, 2) NULL,
	TaxClass nvarchar(50) NULL,
	Salary decimal(18, 2) NULL,
	Image nvarchar(50) NULL,
	Phone nvarchar(50) NULL,
	Mobile nvarchar(50) NULL,
	Notes text NULL,
	StartDate date NULL,
	EndDate date NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Profiles ADD CONSTRAINT
	DF_Profiles_WeeklyHours DEFAULT 0 FOR WeeklyHours
GO
ALTER TABLE dbo.Profiles ADD CONSTRAINT
	PK_Profiles PRIMARY KEY CLUSTERED 
	(
	userID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Profiles SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
