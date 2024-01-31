CREATE TABLE [dbo].[Courses]
(
  [Id] INT NOT NULL IDENTITY,
  [Title] NVARCHAR(100) NOT NULL,
  [Description] TEXT NULL,
  [ImagePath] NVARCHAR(100) NULL,
  [Author] NVARCHAR(100) NOT NULL,
  [Email] NVARCHAR(100) NULL,
  [Rating] REAL DEFAULT((0)) NOT NULL,
  [FullPrice_Amount] DECIMAL(6, 2) DEFAULT((0)) NOT NULL,
  [FullPrice_Currency] NVARCHAR(3) DEFAULT('EUR') NOT NULL,
  [CurrentPrice_Amount] DECIMAL(6, 2) DEFAULT((0)) NOT NULL,
  [CurrentPrice_Currency] NVARCHAR(3) DEFAULT('EUR') NOT NULL,
  CONSTRAINT PK_Courses_Id PRIMARY KEY(Id)
);

GO
