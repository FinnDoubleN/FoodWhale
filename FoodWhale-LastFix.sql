USE [master]
GO
/****** Object:  Database [FoodWhale]    Script Date: 11/12/2021 12:00:03 AM ******/
CREATE DATABASE [FoodWhale] ON  PRIMARY 
( NAME = N'FoodWhale', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\FoodWhale.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FoodWhale_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\FoodWhale_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FoodWhale] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodWhale].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodWhale] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodWhale] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodWhale] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodWhale] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodWhale] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodWhale] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FoodWhale] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodWhale] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodWhale] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodWhale] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodWhale] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodWhale] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodWhale] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodWhale] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodWhale] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FoodWhale] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodWhale] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodWhale] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodWhale] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodWhale] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodWhale] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FoodWhale] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodWhale] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FoodWhale] SET  MULTI_USER 
GO
ALTER DATABASE [FoodWhale] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodWhale] SET DB_CHAINING OFF 
GO
USE [FoodWhale]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 11/12/2021 12:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/12/2021 12:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[categoryID] [int] IDENTITY(1,1) NOT NULL,
	[cName] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[categoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 11/12/2021 12:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[inID] [int] IDENTITY(1,1) NOT NULL,
	[inName] [nvarchar](50) NOT NULL,
	[Image] [varchar](255) NOT NULL,
	[Type] [varchar](30) NOT NULL,
	[Price] [money] NOT NULL,
	[categoryID] [int] NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[guideline] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[inID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/12/2021 12:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[oID] [int] IDENTITY(1,1) NOT NULL,
	[uID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[oID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 11/12/2021 12:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[odID] [int] IDENTITY(1,1) NOT NULL,
	[oID] [int] NOT NULL,
	[inID] [int] NOT NULL,
	[Quantity] [int] NOT NULL
	PRIMARY KEY CLUSTERED 
(
	[odID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 11/12/2021 12:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe](
	[rID] [int] IDENTITY(1,1) NOT NULL,
	[rName] [nvarchar](100) NOT NULL,
	[cID] [int] NOT NULL,
	[Image] [varchar](255) NOT NULL,
	[Difficulty] [varchar](6) NOT NULL,
	[Time] [int] NOT NULL,
	[LikeCount] [int] DEFAULT '0',
	[rDescription] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[rID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipe_ingredient]    Script Date: 11/12/2021 12:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe_ingredient](
[riID] [int] IDENTITY(1,1) NOT NULL,
	[rID] [int] NOT NULL,
	[inID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[riID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipe_Like]    Script Date: 11/12/2021 12:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe_Like](
[rlID] [int] IDENTITY(1,1) NOT NULL,
	[rID] [int] not null,
	[uID] [int] NOT NULL,
	[Fav] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[rlID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/12/2021 12:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[uID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[uName] [varchar](30) NOT NULL,
	[DoB] [date] NULL,
	[Gender] [char](1) NULL,
	[Address] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Role] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[uID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ('0') FOR [Status]
GO
ALTER TABLE [dbo].[Recipe_Like] ADD  DEFAULT ('0') FOR [Fav]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ('User') FOR [Role]
GO
ALTER TABLE [dbo].[Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_Ingredient_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([categoryID])
GO
ALTER TABLE [dbo].[Ingredient] CHECK CONSTRAINT [FK_Ingredient_Category]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([uID])
REFERENCES [dbo].[User] ([uID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Ingredient] FOREIGN KEY([inID])
REFERENCES [dbo].[Ingredient] ([inID])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Ingredient]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Order] FOREIGN KEY([oID])
REFERENCES [dbo].[Order] ([oID])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Order]
GO
ALTER TABLE [dbo].[Recipe]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_Category] FOREIGN KEY([cID])
REFERENCES [dbo].[Category] ([categoryID])
GO
ALTER TABLE [dbo].[Recipe] CHECK CONSTRAINT [FK_Recipe_Category]
GO
ALTER TABLE [dbo].[Recipe_Like]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_Like_Recipe] FOREIGN KEY([rID])
REFERENCES [dbo].[Recipe] ([rID])
GO
ALTER TABLE [dbo].[Recipe_Like] CHECK CONSTRAINT [FK_Recipe_Like_Recipe]
GO
ALTER TABLE [dbo].[Recipe_Like]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_Like_User] FOREIGN KEY([uID])
REFERENCES [dbo].[User] ([uID])
GO
ALTER TABLE [dbo].[Recipe_Like] CHECK CONSTRAINT [FK_Recipe_Like_User]
GO
ALTER TABLE [dbo].[Recipe_ingredient]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_ingredient_Ingredient] FOREIGN KEY([inID])
REFERENCES [dbo].[Ingredient] ([inID])
GO
ALTER TABLE [dbo].[Recipe_ingredient] CHECK CONSTRAINT [FK_Recipe_ingredient_Ingredient]
GO
ALTER TABLE [dbo].[Recipe_ingredient]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_ingredient_Recipe] FOREIGN KEY([rID])
REFERENCES [dbo].[Recipe] ([rID])
GO
ALTER TABLE [dbo].[Recipe_ingredient] CHECK CONSTRAINT [FK_Recipe_ingredient_Recipe]
GO
USE [master]
GO
ALTER DATABASE [FoodWhale] SET  READ_WRITE 
GO

use FoodWhale
go

insert into Admin values ('admin','admin')

insert into [dbo].[User](Email, Password, uName, DoB, Gender, Address, Phone) values('hagthe153279@fpt.edu.vn','giap','Giap Tuan Ha','2001-08-20', 'M','Bac Giang', '0982765291')
insert into [dbo].[User](Email, Password, uName, DoB, Gender, Address, Phone) values('nghiahthe153608@fpt.edu.vn','nghia','Hoang Tuan Nghia','2002-11-20', 'M','Cao Bang', '0837286866')
insert into [dbo].[User](Email, Password, uName, DoB, Gender, Address, Phone) values('minhltnhe150159@fpt.edu.vn','minh','Le Tran Ngoc Minh','2001-07-13', 'M','Ha Noi', '0947722715')
insert into [dbo].[User](Email, Password, uName, DoB, Gender, Address, Phone) values('nhipnlhe151069@fpt.edu.vn','nhi','Pham Nguyen Lan Nhi','2001-07-15', 'F','Ha Noi', '0985123412')
insert into [dbo].[User](Email, Password, uName, DoB, Gender, Address, Phone) values('trung@fpt.edu.vn','trung','Dinh Thanh Trung','2021-11-12', 'M','Ha Noi', '0912345678')

select * from [dbo].[User]

insert into [dbo].[Category] values ('Beef')
insert into [dbo].[Category] values ('Pork')
insert into [dbo].[Category] values ('Seafood')
insert into [dbo].[Category] values ('Vegetables')
insert into [dbo].[Category] values ('Fruits')
insert into [dbo].[Category] values ('Poultry')
insert into [dbo].[Category] values ('Spice/Sauce')
insert into [dbo].[Category] values ('Eggs')

select * from [dbo].[Category]

insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Australian beef ribs','.Image\Ingredients\Australian_beef_ribs.jpeg', '200g', 53000, 1, 'Origin: Australia, preparation time: 20 minutes',
'Dùng ngay khi nhận hàng
Tủ đông <30 ngày
Lưu ý : - Không cấp đông thực phẩm trở lại khi đã rã đông
- Không sử dụng khi sản phẩm có dấu hiệu hư hỏng')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('American Beef Lean Shoulder','.Image\Ingredients\American_Beef_Lean_Shoulder.jpeg','350g', 129000, 1, 'Origin: America, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Australian Beef Neck Tenderloin','.Image\Ingredients\Australian_Beef_Neck_Tenderloin.jpeg','300g', 69000, 1, 'Origin: Australian, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Lean Beef Tenderloin Cu Chi','.Image\Ingredients\Lean_Beef_Tenderloin_Cu_Chi.jpeg','300g', 88000, 1, 'Origin: Cu Chi, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note: Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Sliced Australian Beef Tenderloin Roll','.Image\Ingredients\Sliced_Australian_Beef_Tenderloin_Roll.jpeg','250g', 79000, 1, 'Origin: Australia, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Beef meatballs','.Image\Ingredients\Beef_Meatballs.jpeg','300g', 89000, 1, 'Origin: HCM City, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Pork Ribs','.Image\Ingredients\Pork_Ribs.jpeg','300g', 39000, 2, 'Origin: Canada, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Pork Bacon','.Image\Ingredients\Pork_Bacon.jpeg','300g', 41000, 2, 'Origin: Dong Nai, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Minced Pork','.Image\Ingredients\Minced_Pork.jpeg','200g', 24000, 2, 'Origin: Dong Nai, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Hock Pork','.Image\Ingredients\Hock_Pork.jpeg','300g', 24000, 2, 'Origin: Viet Nam, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Pig tails','.Image\Ingredients\Pig_tails.jpeg','300g', 63000, 2, 'Origin: Dong Nai, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Tilapia Fillet','.Image\Ingredients\Tilapia_Fillet.jpeg','300g', 29000, 3, 'Origin: Dong Nai, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 15 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Ca Mau Meat Crab - Small Type','.Image\Ingredients\Ca_Mau_Meat_Crab_Small_Type.jpeg','1 Crab', 71000, 3, 'Origin: Ca Mau, preparation time: 20 minutes', 'Use immediately upon receipt
Usually <5 days
Note: Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Wild Shrimp - Large Type','.Image\Ingredients\Wild_Shrimp_Large_Type.jpeg','300g', 69000, 3, 'Origin: Viet Nam, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 15 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Sliced Clean Tuna','.Image\Ingredients\Sliced_Clean_Tuna.jpeg','350g', 29000, 3	, 'Origin: Long Hai, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 15 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Fish Balls','.Image\Ingredients\Fish_Balls.jpeg','500g', 49000, 3, 'Origin: HCM City, preparation time: 20 minutes', 'Use immediately upon receipt
Freezer < 30 days
Note :
- Do not re-freeze food once it has been defrosted
- Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Natural Dried Shrimp - Medium','.Image\Ingredients\Natural_Dried_Shrimp_Medium.jpeg','200g', 139000, 3, 'Origin: HCM City, preparation time: 20 minutes', 'Use immediately upon receipt
Refrigerator <15 days
Note: Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Black Tiger Shrimp - Medium','.Image\Ingredients\Black_Tiger_Shrimp_Medium.jpeg','200g', 59000, 3, 'Origin: HCM City, preparation time: 20 minutes', 'Use immediately upon receipt
Refrigerator <3 months
Note: Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Green Onion and Coriander','.Image\Ingredients\Green_Onion_and_Coriander.jpeg','100g', 7000, 4, 'Origin: HCM City, preparation time: 20 minutes', 'Use immediately upon receipt
Refrigerator < 7 days
Note: Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Brown Reishi Mushroom','.Image\Ingredients\Brown_Reishi_Mushroom.jpeg','125g', 19000, 4, 'Origin: Viet Nam, preparation time: 20 minutes', 'Use immediately upon receipt
Refrigerator < 7 days
Note: Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('White Reishi Mushroom','.Image\Ingredients\White_Reishi_Mushroom.jpeg','125g', 22000, 4, 'Origin: Viet Nam, preparation time: 20 minutes', 'Use immediately upon receipt
Refrigerator < 7 days
Note: Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Carrot','.Image\Ingredients\Carrot.jpeg','600g', 19000, 4, 'Origin: Viet Nam, preparation time: 20 minutes', 'Use immediately upon receipt
Refrigerator < 7 days
Note: Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Red pumpkin','.Image\Ingredients\Red_pumpkin.jpeg','600g', 13000, 4, 'Origin: Viet Nam, preparation time: 20 minutes', 'Dùng ngay khi nhận hàng
Tủ mát <15 ngày
Lưu ý : Không sử dụng khi sản phẩm có dấu hiệu hư hỏng')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Red Celestial Chilli','.Image\Ingredients\Red_Celestial_Chilli.jpeg','100g', 1000, 4, 'Origin: HCM City, preparation time: 20 minutes', 'Dùng ngay khi nhận hàng
Tủ mát <15 ngày
Lưu ý : Không sử dụng khi sản phẩm có dấu hiệu hư hỏng')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Scallion','.Image\Ingredients\Scallion.jpeg','100g', 9000, 4, 'Origin: HCM City, preparation time: 20 minutes', 'Dùng ngay khi nhận hàng
Tủ mát <5 ngày
Lưu ý : Không sử dụng khi sản phẩm có dấu hiệu hư hỏng')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Pickled cabbage','.Image\Ingredients\Pickled_cabbage.jpeg','300g', 9000, 4, 'Origin: HCM City, preparation time: 20 minutes', 'Dùng ngay khi nhận hàng
Tủ mát <15 ngày
Lưu ý : Không sử dụng khi sản phẩm có dấu hiệu hư hỏng')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('Onion','.Image\Ingredients\Onion.jpeg','600g', 26000, 4, 'Origin: Viet Nam, preparation time: 20 minutes', 'Dùng ngay khi nhận hàng
Tủ mát <10 ngày
Lưu ý : Không sử dụng khi sản phẩm có dấu hiệu hư hỏng')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('CookyMADE Stir-fry Sauce','.Image\Ingredients\CookyMADE_Stir_fry_Sauce.jpeg','400g', 36000, 7, 'Origin: Viet Nam, preparation time: 20 minutes', '15 days from production date
Cool, dry place
Avoid direct sunlight
Note: Do not use when the product shows signs of damage')
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('CookyMADE Braised Sauce','.Image\Ingredients\CookyMADE_Braised_Sauce.jpeg','400Ml', 49000, 7, 'Origin: HCM City, preparation time: 20 minutes', '15 days from production date
Cool, dry place
Avoid direct sunlight
Note: Do not use when the product shows signs of damage') 
insert into [dbo].[Ingredient](inName, Image, Type, Price, categoryID, description, guideline) values ('CookyMADE Braised Pickle Cabbage Sauce','.Image\Ingredients\CookyMADE_Braised_Pickle_Cabbage_Sauce.jpeg','400g', 34000, 7, 'Origin: HCM City, preparation time: 20 minutes', '15 days from production date
Cool, dry place
Avoid direct sunlight
Note: Do not use when the product shows signs of damage')

select * from [dbo].[Ingredient]

insert into [dbo].[Recipe](rName, cID, Image, Difficulty, Time, rDescription) values ('Stir-Fried Beef Tenderloin with Mushrooms' ,1,'.Image\Recipe\Stir_Fried_Beef_Tenderloin_with_Mushrooms.jpeg', 'Medium', 15, 'Step 1:
Wash the prepared ingredients, drain the water. Onions and coriander cut into small pieces. Finely mince purple onions, garlic. Thinly sliced ​​beef to taste.
Step 2:
Turn on the stove, put 2 tablespoons of cooking oil in the pan, wait for the oil to heat up, add minced shallot, minced garlic and fry until fragrant. Then add the beef and slowly add the seasoning packet to complete the stir-fry in the pan, stirring for about 3 minutes.
Step 3:
Next, add mushrooms and onions and saute for about 5-7 minutes. Add green onions, cilantro, and chili peppers to the island, season to taste and then turn off the heat.
Step 4:
Arrange the dish on a plate, sprinkle some ground pepper on top and enjoy. More delicious when eaten hot with white rice, dipped with chili sauce to add flavor to the dish.
* NOTE:
- The seasoning package should be poured slowly (not all of it) to taste to taste.
- Can change the amount of water and seasoning to suit the portion and taste.')
insert into [dbo].[Recipe](rName, cID, Image, Difficulty, Time, rDescription) values ('Ribeye Steak with Brown Sauce' ,1,'.Image\Recipe\Ribeye_Steak_with_Brown_Sauce.jpeg', 'Easy', 5, 'Step 1:
Wash the prepared ingredients to dry.
Marinate the meat with a little oil, if you want to have a strong taste, you can add a little pepper and salt to marinate it.
Step 2:
While marinating the meat, put the pan on the stove, add 200ml of cooking oil, wait until the oil is hot, then fry the potatoes until they are golden and crispy, drain the oil.
Step 3:
Put another pan on the stove, wait for the pan to heat up, then place the meat on the pan on both sides.
Step 4:
Reduce heat and add butter, garlic, thyme, rosemary. When the butter has melted, pour the butter continuously over the meat until the meat has reached the desired doneness.
Remove the meat to a plate, stir-fry broccoli, asparagus, cherry tomatoes until cooked.
Step 5:
Heat up the sauce, place the meat and vegetables on a platter and serve while still hot.')
insert into [dbo].[Recipe](rName, cID, Image, Difficulty, Time, rDescription) values ('Pumpkin Shrimp Soup' ,3,'.Image\Recipe\Pumpkin_Shrimp_Soup.jpeg', 'Medium', 25, 'Step 1:
Wash the prepared ingredients, drain the water. Scallions, chopped coriander, small cilantro. Pumpkin cut into bite-sized pieces. Soak dried shrimp in warm water for 10 minutes to soften, then rinse with cold water, drain. Finely chop purple onion, onion head.
Step 2:
Put the pot on the stove, add 2 tablespoons of cooking oil, wait until the oil is hot for minced purple onions, minced onion heads to fry until fragrant, then add dried shrimp and sauté for 1 minute until fragrant. Then, pour 500 ml of filtered water into the pot to boil, cook for about 3 minutes

* Tip: Regularly skim off the foam to keep the broth clear.
Step 3:
Next, add the pumpkin to cook together. Slowly add the seasoning packet to complete the vegetable soup and stir well. Cook for 8-10 minutes for the soup to boil. Put scallions, coriander, coriander on the face, season to taste and then turn off the heat.

* Recipe: Add fish sauce to bring up the aroma
Step 4:
Place the dish in a bowl, sprinkle some ground pepper on top and enjoy. The soup is more delicious when eaten hot with white rice.
* Note:
- The seasoning package should be poured slowly (not all of it) to taste to taste.
- Can change the amount of water and seasoning to suit the portion and taste.')
insert into [dbo].[Recipe](rName, cID, Image, Difficulty, Time, rDescription) values ('Braised Black Tiger Shrimp' ,3,'.Image\Recipe\Braised_Black_Tiger_Shrimp.jpeg', 'Medium', 15, 'Step 1:
Wash the prepared ingredients and drain. Sliced green onions, sliced hot peppers.
Step 2:
Finely chop onion and garlic. Turn on the stove, add 2 tablespoons of cooking oil and wait until the oil is hot for the minced onion and garlic to fry until fragrant. Next, put the shrimp in the island on medium heat for 5 minutes until the shrimp turn red.
Step 3:
When the shrimp has turned red, add the seasoning packet and stir, then add 200 ml of filtered water to the pot and cook on low heat for 15 minutes to drain the water. Season to taste and then turn off the stove.
Step 4:
Put the dish in a bowl for green onions and chili peppers on the face. Delicious when served hot with white rice.')
insert into [dbo].[Recipe](rName, cID, Image, Difficulty, Time, rDescription) values ('Braised Bacon Pork With Pickled cabbage' ,2,'.Image\Recipe\Braised_Bacon_Pork_With_Pickled_cabbage.jpeg', 'Hard', 15, 'Step 1:
Wash the prepared ingredients, drain the water. Sliced ​​ginger. Chopped green onions. Marinate the pork with the complete seasoning pack for 20 minutes.
Step 2:
Turn on the stove, put 2 tablespoons of cooking oil in the pan, mince the onion and garlic, wait for the hot oil to fry until fragrant. Then add the marinated meat mixture and stir-fry until the meat is firm, then add 200 ml of filtered water to boil.
Step 3:
Next, add the sauerkraut, onion, ginger and cook for 10 minutes over medium heat until the water thickens, add the green onions and stir well, season to taste and then turn off the heat.
Step 4:
Arrange the dish on a plate, sprinkle with ground pepper and enjoy. It is more delicious when eaten hot with white rice.
Note:
- The seasoning package should be poured slowly (not all of it) to taste to taste.
- Can change the amount of water and seasoning to suit the portion and taste.')

select * from Recipe

insert into [dbo].[Recipe_ingredient] values (1, 19)
insert into [dbo].[Recipe_ingredient] values (1, 20)
insert into [dbo].[Recipe_ingredient] values (1, 21)
insert into [dbo].[Recipe_ingredient] values (1, 22)
insert into [dbo].[Recipe_ingredient] values (1, 3)
insert into [dbo].[Recipe_ingredient] values (1, 28)
insert into [dbo].[Recipe_ingredient] values (2, 1)
insert into [dbo].[Recipe_ingredient] values (2, 25)
insert into [dbo].[Recipe_ingredient] values (2, 24)
insert into [dbo].[Recipe_ingredient] values (3, 24)
insert into [dbo].[Recipe_ingredient] values (3, 18)
insert into [dbo].[Recipe_ingredient] values (3, 29)
insert into [dbo].[Recipe_ingredient] values (4, 23)
insert into [dbo].[Recipe_ingredient] values (4, 17)
insert into [dbo].[Recipe_ingredient] values (5, 25)
insert into [dbo].[Recipe_ingredient] values (5, 27)
insert into [dbo].[Recipe_ingredient] values (5, 26)
insert into [dbo].[Recipe_ingredient] values (5, 30)

select * from Recipe_ingredient

SELECT r.LikeCount, (SELECT COUNT(*) FROM Recipe_Like rl WHERE rl.rID = r.rID) FROM Recipe r

