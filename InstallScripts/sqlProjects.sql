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
CREATE TABLE dbo.Projects
	(
	projectID uniqueidentifier NOT NULL,
	Name nvarchar(250) NOT NULL,
	Street nvarchar(250) NULL,
	Zip nvarchar(50) NULL,
	Town nvarchar(150) NULL,
	ContactID uniqueidentifier NULL,
	Phone nvarchar(50) NULL,
	Fax nvarchar(50) NULL,
	licenceID uniqueidentifier NULL,
	isActive bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Projects ADD CONSTRAINT
	DF_Projects_isActive DEFAULT 1 FOR isActive
GO
ALTER TABLE dbo.Projects ADD CONSTRAINT
	PK_Projects PRIMARY KEY CLUSTERED 
	(
	projectID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Projects SET (LOCK_ESCALATION = TABLE)
GO
COMMIT