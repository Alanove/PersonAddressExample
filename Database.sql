
/****** Object:  Table [dbo].[Address]    Script Date: 2/16/2021 6:58:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
	[AddressLine1] [nvarchar](256) NULL,
	[AddressLine2] [nvarchar](256) NULL,
	[City] [nvarchar](150) NULL,
	[State] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[CountryCode] [char](2) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 2/16/2021 6:58:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Code] [char](2) NOT NULL,
	[Name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 2/16/2021 6:58:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](150) NULL,
	[MiddleName] [nvarchar](150) NULL,
	[LastName] [nvarchar](150) NULL,
	[MobilePhone] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AddressView]    Script Date: 2/16/2021 6:58:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[AddressView]
as
select Address.*, Person.FirstName, Person.LastName ,
Country.Name as CountryName
from Address 
inner Join Person 
on Address.PersonId =Person.PersonId
Inner Join Country on Address.CountryCode= Country.Code
GO
/****** Object:  Trigger [dbo].[Trg_Person_Delete]    Script Date: 2/16/2021 6:58:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[Trg_Person_Delete]
   ON  [dbo].[Person]
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	delete from Address where PersonId in (select PersonId from deleted)

    -- Insert statements for trigger here

END
GO
ALTER TABLE [dbo].[Person] ENABLE TRIGGER [Trg_Person_Delete]
GO
USE [master]
GO
ALTER DATABASE [ASAP] SET  READ_WRITE 
GO
