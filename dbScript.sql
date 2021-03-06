USE [GalmAppDB]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Address1] [nvarchar](256) NULL,
	[Address2] [nvarchar](256) NULL,
	[DeviceType] [nvarchar](50) NULL,
	[DeviceToken] [text] NULL,
	[RegisterOn] [datetime] NULL,
	[LastLogOn] [datetime] NULL,
	[LocationId] [int] NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[BookingDate] [datetime] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FAQ]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQ](
	[FQAId] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](1000) NULL,
	[Answer] [text] NULL,
	[AddedOn] [datetime] NULL,
 CONSTRAINT [PK_FAQ] PRIMARY KEY CLUSTERED 
(
	[FQAId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](256) NULL,
	[CountryCode] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[AddedOn] [datetime] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Package]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[PackageId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Duration] [nvarchar](256) NULL,
	[PackageName] [nvarchar](256) NULL,
	[Currency] [varchar](50) NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[PackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PackagePrice]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackagePrice](
	[PackagePriceId] [int] IDENTITY(1,1) NOT NULL,
	[PackageId] [int] NULL,
	[LocationId] [int] NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_PackagePrice] PRIMARY KEY CLUSTERED 
(
	[PackagePriceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 17-Jul-17 9:42:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Description] [text] NULL,
	[Image] [nvarchar](1000) NULL,
	[ThumbImg] [nvarchar](1000) NULL,
	[BackgroundImg] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Address1], [Address2], [DeviceType], [DeviceToken], [RegisterOn], [LastLogOn], [LocationId]) VALUES (N'c4f032e0-ddf0-4e21-b5b3-31f287967cc6', N'devnagar@Live.com', 0, N'ACTWzgwYLqm6PcIwnrJmFUQ95GUexk/V+qFC+6d3gd9bvRdxktWUj9SzKt+MBYosvQ==', N'83734e6e-f8ba-4b05-a477-77e757771688', N'98936916054', 0, 0, NULL, 0, 0, N'dev', N'sample string 6', N'sample string 7', N'sample string 3', N'sample string 4', CAST(N'2017-07-16T00:00:00.000' AS DateTime), CAST(N'2017-07-16T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationId], [LocationName], [CountryCode], [Country], [AddedOn]) VALUES (1, N'Indore', N'91', N'INDIA', NULL)
INSERT [dbo].[Location] ([LocationId], [LocationName], [CountryCode], [Country], [AddedOn]) VALUES (2, N'Bhopal', N'21', N'India', NULL)
SET IDENTITY_INSERT [dbo].[Location] OFF
SET IDENTITY_INSERT [dbo].[Package] ON 

INSERT [dbo].[Package] ([PackageId], [ServiceId], [Duration], [PackageName], [Currency], [Amount]) VALUES (1, 1, N'1 Month', N'P1', N'INR', 100.0000)
INSERT [dbo].[Package] ([PackageId], [ServiceId], [Duration], [PackageName], [Currency], [Amount]) VALUES (2, 1, N'2 Month', N'P2', N'USD', 200.0000)
INSERT [dbo].[Package] ([PackageId], [ServiceId], [Duration], [PackageName], [Currency], [Amount]) VALUES (3, 2, N'3', N'P3', N'INR', 200.0000)
INSERT [dbo].[Package] ([PackageId], [ServiceId], [Duration], [PackageName], [Currency], [Amount]) VALUES (4, 2, N'4 Month', N'P4', N'INR', 200.0000)
SET IDENTITY_INSERT [dbo].[Package] OFF
SET IDENTITY_INSERT [dbo].[PackagePrice] ON 

INSERT [dbo].[PackagePrice] ([PackagePriceId], [PackageId], [LocationId], [Amount]) VALUES (1, 1, 1, 100.0000)
INSERT [dbo].[PackagePrice] ([PackagePriceId], [PackageId], [LocationId], [Amount]) VALUES (2, 1, 2, 200.0000)
INSERT [dbo].[PackagePrice] ([PackagePriceId], [PackageId], [LocationId], [Amount]) VALUES (3, 2, 2, 19.0000)
INSERT [dbo].[PackagePrice] ([PackagePriceId], [PackageId], [LocationId], [Amount]) VALUES (4, 2, 1, 10.0000)
SET IDENTITY_INSERT [dbo].[PackagePrice] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ServiceId], [Name], [Description], [Image], [ThumbImg], [BackgroundImg]) VALUES (1, N'S1', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ServiceId], [Name], [Description], [Image], [ThumbImg], [BackgroundImg]) VALUES (2, N'S2', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Service] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([ServiceId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Service]
GO
ALTER TABLE [dbo].[Package]  WITH CHECK ADD  CONSTRAINT [FK_Package_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([ServiceId])
GO
ALTER TABLE [dbo].[Package] CHECK CONSTRAINT [FK_Package_Service]
GO
ALTER TABLE [dbo].[PackagePrice]  WITH CHECK ADD  CONSTRAINT [FK_PackagePrice_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO
ALTER TABLE [dbo].[PackagePrice] CHECK CONSTRAINT [FK_PackagePrice_Location]
GO
ALTER TABLE [dbo].[PackagePrice]  WITH CHECK ADD  CONSTRAINT [FK_PackagePrice_Package] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Package] ([PackageId])
GO
ALTER TABLE [dbo].[PackagePrice] CHECK CONSTRAINT [FK_PackagePrice_Package]
GO
