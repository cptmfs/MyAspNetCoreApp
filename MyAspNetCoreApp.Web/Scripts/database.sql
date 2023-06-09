USE [master]
GO
/****** Object:  Database [TurkcellDb]    Script Date: 15.04.2023 01:55:42 ******/
CREATE DATABASE [TurkcellDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TurkcellDb', FILENAME = N'C:\Users\Kaptan\TurkcellDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TurkcellDb_log', FILENAME = N'C:\Users\Kaptan\TurkcellDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TurkcellDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TurkcellDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TurkcellDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TurkcellDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TurkcellDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TurkcellDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TurkcellDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TurkcellDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TurkcellDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TurkcellDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TurkcellDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TurkcellDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TurkcellDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TurkcellDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TurkcellDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TurkcellDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TurkcellDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TurkcellDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TurkcellDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TurkcellDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TurkcellDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TurkcellDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TurkcellDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TurkcellDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TurkcellDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TurkcellDb] SET  MULTI_USER 
GO
ALTER DATABASE [TurkcellDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TurkcellDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TurkcellDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TurkcellDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TurkcellDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TurkcellDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TurkcellDb] SET QUERY_STORE = OFF
GO
USE [TurkcellDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15.04.2023 01:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 15.04.2023 01:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Color] [nvarchar](max) NULL,
	[IsPublish] [bit] NOT NULL,
	[Discount] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[PublishDate] [datetime2](7) NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 15.04.2023 01:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Experiences] [nvarchar](max) NOT NULL,
	[Skills] [nvarchar](max) NOT NULL,
	[GitHub] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[LinkedIn] [nvarchar](max) NOT NULL,
	[PlaceOfBirth] [nvarchar](max) NOT NULL,
	[Twitter] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visitors]    Script Date: 15.04.2023 01:55:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Visitors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230325110449_initial', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230325112503_RemoveWidthAndHeightForProducts', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230401175338_AddIsPublishForProduct', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230401194154_AddDiscountForProduct', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230401200709_AddDescriptionForProduct', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230403061841_AddPublishDateForProduct', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230406063531_AddVisitor', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230406103624_AddStudent', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230407094034_AddImageForStudent', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230413195047_AddImagePathForProduct', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230414053959_UpdateImagePathForProduct', N'7.0.4')
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (1, N'Iphone 13 256gb', CAST(31000.00 AS Decimal(18, 2)), 10, N'Dark Blue', 0, 0, N'', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (2, N'Iphone 13 Pro Max 1TB', CAST(44000.00 AS Decimal(18, 2)), 15, N'Red', 0, 0, N'', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (3, N'Iphone 14 Pro Max 1TB', CAST(54000.00 AS Decimal(18, 2)), 30, N'White', 1, 15, N'', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (4, N'Thinkpad T480', CAST(22000.00 AS Decimal(18, 2)), 15, N'Black', 0, 0, N'ThinkPad T480 · Yükselen performansla sizi şaşırtır. Önceki nesilden daha yüksek ve daha hızlı performansıyla yeni 8. nesil Intel® Core™ i7 işlemci', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (5, N'Thinkpad X1 Yoga Gen 8', CAST(38000.00 AS Decimal(18, 2)), 5, N'Grey', 0, 0, N'', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (6, N'Asus ROG Strix GeForce RTX 4090', CAST(60000.00 AS Decimal(18, 2)), 25, N'RGB', 0, 0, N' ROG Strix GeForce RTX® 4090 24GB GDDR6X listelerin zirvesinde yer alan termal performans ile güçlendirilmiş', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (7, N'Intel Core i9-13900K', CAST(14500.00 AS Decimal(18, 2)), 25, N'Silver', 1, 15, N'', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (8, N'Logitech G-300S', CAST(455.00 AS Decimal(18, 2)), 200, N'Black', 1, 30, N'Logitech G300s Kablolu Oyuncu Mouse, 2,5K DPI Sensör, USB bağlantısı, RGB aydınlatma, 9 programlanabilir düğme, DPI değiştirme düğmesi', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (9, N'Samsung 27" Curved Full HD', CAST(4800.00 AS Decimal(18, 2)), 10, N'Black', 0, 0, N'', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (10, N'Lenovo Thinkpad X1 Carbon 3rd Gen', CAST(6500.00 AS Decimal(18, 2)), 1, N'Black Carbon', 1, 10, N'', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (12, N'Samsung QE 65QN700B 65inc 163 cm 8K UHD Smart QLED TV', CAST(54999.00 AS Decimal(18, 2)), 10, N'Siyah', 1, 10, N'', NULL, N'')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (13, N'Playstation 5 White ', CAST(22499.00 AS Decimal(18, 2)), 54, N'White', 1, 20, N'Sony PS5 Playstation 5 Oyun Konsolu ( Sony Eurasia Garantili )
Dijital oyun dünyasını yakından takip ediyor, en güncel oyunları, 8K (4320p) çözünürlüğe varan değerlerde deneyimlemeyi hedefliyor, aynı zamanda Sony’nin exclusive olarak nitelendirilen platforma özel oyunlarını oynamayı arzu ediyorsanız, PlayStation 5, size hitap ediyor. Sony’nin, dokuzuncu nesil oyun konsolu olma özelliğini taşıyan ve aynı zamanda, şimdiye kadar geliştirilen en yüksek performanslı ', CAST(N'2023-04-07T19:00:00.0000000' AS DateTime2), N'2f72b739-6126-485f-934f-f5c12ff9f07d.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (14, N'LS05B The Sero QLED 4K Smart TV', CAST(26669.00 AS Decimal(18, 2)), 15, N'Black', 1, 15, N'Mobil eğlence TV’de daha güzel
* Görüntüler ve videolar örnek amaçlı olup yalnızca görsel olarak açıklamak amacıyla sunulmuştur.', CAST(N'2023-04-14T00:00:00.0000000' AS DateTime2), N'Samsung-TV.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Stock], [Color], [IsPublish], [Discount], [Description], [PublishDate], [ImagePath]) VALUES (15, N'Apple Watch Ultra ', CAST(27999.00 AS Decimal(18, 2)), 185, N'Black', 1, 0, N'49 mm

100 m suya dayanıklı tasarım dipnot⁵

Yüzerken kullanıma ve 40 metreye kadar rekreasyonel dalışa uygun dipnot⁵

EN13319 sertifikasına sahip dipnot¹¹

Su sıcaklığı sensörüne sahip derinlik göstergesi

IP6X toza dayanıklılık derecesi

MIL-STD 810H sertifikası dipnot⁶

Kişiselleştirilebilen Eylem Düğmesi

Hep Açık Retina ekran
2000 nite kadar parlaklık

Kanda Oksijen uygulaması

EKG uygulaması dipnot⁵

Yüksek ve düşük kalp atış hızı bildirimleri', CAST(N'2023-04-14T01:10:00.0000000' AS DateTime2), N'9d6e27ca-f493-466a-bc5c-7986fe7c8fa7.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [DateOfBirth], [Title], [Experiences], [Skills], [GitHub], [Image], [LinkedIn], [PlaceOfBirth], [Twitter]) VALUES (1, N'Muhammed Ferit', N'Şimşek', CAST(N'1993-06-06T05:35:00.0000000' AS DateTime2), N'Jr.Software Developer', N'Gemi Kaptanlığı', N'Asp.Net Core', N'https://github.com/cptmfs', N'https://ichef.bbci.co.uk/news/640/cpsprodpb/16FA9/production/_92712149_gettyimages-480164327.jpg', N'https://www.linkedin.com/in/muhammed-ferit-simsek-119550217/', N'A', N'https://www.linkedin.com/in/muhammed-ferit-simsek-119550217/')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [DateOfBirth], [Title], [Experiences], [Skills], [GitHub], [Image], [LinkedIn], [PlaceOfBirth], [Twitter]) VALUES (2, N'Ertuğrul', N'Dağlı', CAST(N'1998-04-04T10:00:00.0000000' AS DateTime2), N'Jr.Software Developer', N'Yazılım Test Uzmanlığı', N'C#,SQL,JAVA', N'https://github.com/cptmfs', N'https://ichef.bbci.co.uk/news/640/cpsprodpb/16FA9/production/_92712149_gettyimages-480164327.jpg', N'https://www.linkedin.com/in/muhammed-ferit-simsek-119550217/https://www.linkedin.com/in/muhammed-ferit-simsek-119550217/', N'B', N'https://www.linkedin.com/in/muhammed-ferit-simsek-119550217/')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName], [DateOfBirth], [Title], [Experiences], [Skills], [GitHub], [Image], [LinkedIn], [PlaceOfBirth], [Twitter]) VALUES (4, N'Şeyma', N'Şimşek', CAST(N'1996-07-22T07:30:00.0000000' AS DateTime2), N'Üretim Mühendisi', N'Chen Solar - Üretim Mühendisi , HT Solar - Kalite Kontrol', N'Production , Software , NFT , Collabrator', N'https://github.com/cptmfs', N'https://ichef.bbci.co.uk/news/640/cpsprodpb/16FA9/production/_92712149_gettyimages-480164327.jpg', N'https://www.linkedin.com/in/muhammed-ferit-simsek-119550217/', N'Pendik', N'https://twitter.com/seysimsek')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Visitors] ON 

INSERT [dbo].[Visitors] ([Id], [Name], [Comment], [Created]) VALUES (1, N'Şeyma Şimşek', N'Çok Güzel bir sitedir efendim', CAST(N'2023-04-06T18:07:51.5073352' AS DateTime2))
INSERT [dbo].[Visitors] ([Id], [Name], [Comment], [Created]) VALUES (2, N'Ferit Şimşek', N'Teşekkürler Şeyma Hanım <3', CAST(N'2023-04-06T18:08:05.7220472' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Visitors] OFF
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF__Products__IsPubl__6FE99F9F]  DEFAULT (CONVERT([bit],(0))) FOR [IsPublish]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF__Products__Discou__5AEE82B9]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF__Products__Descri__6EF57B66]  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (N'') FOR [GitHub]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (N'') FOR [Image]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (N'') FOR [LinkedIn]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (N'') FOR [PlaceOfBirth]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (N'') FOR [Twitter]
GO
USE [master]
GO
ALTER DATABASE [TurkcellDb] SET  READ_WRITE 
GO
