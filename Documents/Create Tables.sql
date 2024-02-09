USE TracsDb
GO

/****** Object:  Table [dbo].[RMA]    Script Date: 10/2/2018 4:22:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].RMA(
	[RMAId] int IDENTITY(1,1) NOT NULL, 
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[TrackingNumber] [char](12) NULL,
	[RMATypeId] int NULL,
	[CreditReasonId] int NULL,
	TechnicianId int NULL,
	ReturnAddressId [int] NULL,
	ServiceCallId [int] NULL,
	PartReturnId	int NULL,

	IsCorrectShipping bit NULL,
 CONSTRAINT [PK_RMAs] PRIMARY KEY CLUSTERED 
(
	[RMAId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].ReturnAddress(

	[ReturnAddressId] int IDENTITY(1,1) NOT NULL, 
	Street  varchar(100) NULL,
	City varchar(50) NULL,
	State varchar(50) NULL,
	ZipCode  varchar(10) NULL,
	[FirmId] int null
 CONSTRAINT [PK_ReturnAddress] PRIMARY KEY CLUSTERED 
(
	[ReturnAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].RMAType(

	[RMATypeId] int IDENTITY(1,1) NOT NULL, 
	[Description]  varchar(100) NULL

 CONSTRAINT [PK_RMAType] PRIMARY KEY CLUSTERED 
(
	[RMATypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].CreditReason(

	[CreditReasonId] int IDENTITY(1,1) NOT NULL, 
	[Description]  varchar(100) NULL,

 CONSTRAINT [PK_CreditReason] PRIMARY KEY CLUSTERED 
(
	[CreditReasonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].ServiceCall(

	[ServiceCallId] int IDENTITY(1,1) NOT NULL, 
	DispatchNumber  varchar(20) NULL,

 CONSTRAINT [PK_ServiceCall] PRIMARY KEY CLUSTERED 
(
	[ServiceCallId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].Part(

	[PartId] int IDENTITY(1,1) NOT NULL,
	PartNumber	varchar(20)	null,
	SerialNumber  char(6) NULL,
	PartName	varchar(50)	null,
	ManufacturingDate datetime null,
	ReworkDate datetime null

 CONSTRAINT [PK_Part] PRIMARY KEY CLUSTERED 
(
	[PartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].ReturnedPart(

	[ReturnedPartId] int IDENTITY(1,1) NOT NULL,
	[RMAId] int, 
	[PartId] int, 
	[Description] varchar(100)	null,
	RMANumber  char(6) NULL,
	ReplacementSONumber char(6) null,

 CONSTRAINT [PK_ReturnedPart] PRIMARY KEY CLUSTERED 
(
	[ReturnedPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Bank](
	[Bankid] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[LongName] [varchar](100) NULL,
	[Address] [varchar](255) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [varchar](10) NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].Firm(
	[FirmId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	ContactId [int] NULL,
 CONSTRAINT [PK_Firm] PRIMARY KEY CLUSTERED 
(
	[FirmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].ReturnedPartPicture(
	[ReturnedPartPictureId] [int] IDENTITY(1,1) NOT NULL,
	ReturnPartId int  NULL,
	[Filename] varchar(100) NULL,
 CONSTRAINT [PK_ReturnedPartPicture] PRIMARY KEY CLUSTERED 
(
	[ReturnedPartPictureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].REL_Bank_Firm(
	[REL_Bank_FirmId] [int] IDENTITY(1,1) NOT NULL,
	BankId int  NULL,
	FirmId int  NULL
 CONSTRAINT [PK_REL_Bank_Firm] PRIMARY KEY CLUSTERED 
(
	[REL_Bank_FirmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].REL_ReturnedPart_Complaint(
	[REL_ReturnedPart_ComplaintId] [int] IDENTITY(1,1) NOT NULL,
	ReturnedPartId int  NULL,
	ComplaintId int  NULL,
	Observations	varchar(255) null,
	FirmwareVersion	varchar(20) null
 CONSTRAINT [PK_REL_ReturnedPart_Complaint] PRIMARY KEY CLUSTERED 
(
	[REL_ReturnedPart_ComplaintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].Complaint(
	[ComplaintId] [int] IDENTITY(1,1) NOT NULL,
	[Description]  varchar(255) NULL

 CONSTRAINT [PK_Complaint] PRIMARY KEY CLUSTERED 
(
	[ComplaintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].Attribute(
	AttributeId [int] IDENTITY(1,1) NOT NULL,
	[Name]  varchar(50) NULL

 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	AttributeId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].REL_User_Attribute(
	[REL_User_AttributeId] [int] IDENTITY(1,1) NOT NULL,
	UserId int  NULL,
	AttributeId int  NULL,
	FirmId int  NULL
 CONSTRAINT [PK_REL_User_Attribute] PRIMARY KEY CLUSTERED 
(
	[REL_User_AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].REL_Status_Attribute(
	[REL_Status_AttributeId] [int] IDENTITY(1,1) NOT NULL,
	AttributeId int  NULL,
	StatusId int  NULL,
 CONSTRAINT [PK_REL_Status_Attribute] PRIMARY KEY CLUSTERED 
(
	[REL_Status_AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] int  NULL,
	Phone int  NULL,
	Email int  NULL,
	[Password] int  NULL
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Description] varchar(100)  NULL,
	[PublicDescription] varchar(100)  NULL,
	IsPublic bit  NULL,
	
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].REL_RMA_Status(
	[REL_RMA_StatusId] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NULL,
	Observations	varchar(255) null,
	UserId int  NULL,
	StatusId int  NULL,
	RMAId int  NULL
 CONSTRAINT [PK_REL_RMA_Status] PRIMARY KEY CLUSTERED 
(
	[REL_RMA_StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].TestResult(
	REL_ReturnedPart_ComplaintId [int] NULL,
	StartedAt [datetime] NULL,
	EndedAt	[datetime] null,
	OriginalShippedDate [datetime]  NULL,
	RMATechId int  NULL,
	IsPhisicalDamage bit  NULL,
	ReturnType int NULL,
	IsConfirmed bit  NULL
 
) 
GO

CREATE TABLE [dbo].Test_MagneticCard(
	REL_ReturnedPart_ComplaintId [int] NULL,
	MagCardRead varchar(20) NULL,
	OutOf50Swipes 	int null,
	IsPassed bit  NULL,
	Observations varchar(255) NULL
) 
GO

CREATE TABLE [dbo].PartFamily(
	PartFamilyId [int] IDENTITY(1,1) NOT NULL,
	[Description] varchar(255) NULL,
	

 CONSTRAINT [PK_PartFamily] PRIMARY KEY CLUSTERED 
(
	[PartFamilyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].Test(
	TestId [int] IDENTITY(1,1) NOT NULL,
	[Description] varchar(255) NULL,
	PartFamilyId	int	null
	
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].REL_ReturnedPart_Complaint_Test(
	[REL_ReturnedPart_Complaint_TestId] [int] IDENTITY(1,1) NOT NULL,
	[REL_ReturnedPart_ComplaintId] [int] NULL,
	TestId int  NULL,
	IsPassed bit  NULL,
	Observations varchar(255)  NULL
 CONSTRAINT [PK_REL_ReturnedPart_Complaint_Test] PRIMARY KEY CLUSTERED 
(
	[REL_ReturnedPart_Complaint_TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [RMATracker-dev]
GO

/****** Object:  Table [dbo].[BankInfo]    Script Date: 10/3/2018 10:27:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER TABLE [dbo].[BankInfo] ADD  CONSTRAINT [DF_Bank_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

