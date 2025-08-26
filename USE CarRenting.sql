USE CarRenting

CREATE TABLE [dbo].[Brands]
(
    [Id] INT IDENTITY (1, 1) NOT NULL
        CONSTRAINT PK_Brand PRIMARY KEY CLUSTERED,

    [Name]   NVARCHAR
    (100) NOT NULL
    CONSTRAINT UQ_Brand_Name UNIQUE,
);
GO

    CREATE TABLE [dbo].[Colors] (
    [Id] INT IDENTITY (1,1) NOT NULL
    CONSTRAINT PK_Color PRIMARY KEY CLUSTERED,
    [Name] NVARCHAR (100) NOT NULL CONSTRAINT UQ_Color_Name UNIQUE,
)
GO

USE CarRenting
DROP TABLE dbo.Cars
GO


    CREATE TABLE [dbo].[Cars]
    (
        [Id] INT IDENTITY (1, 1) NOT NULL,
        [BrandId] INT NOT NULL,
        [ColorId] INT NOT NULL,
        [CarName] NVARCHAR (255) NOT NULL,
        [ModelYear] NVARCHAR (255) NOT NULL,
        [DailyPrice] DECIMAL (18) NOT NULL,
        [Description] NVARCHAR (500) NULL,
        CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([Id] ASC),

        CONSTRAINT [FK_Cars_Brand]
        FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands]([Id]),
        CONSTRAINT [FK_Cars_Color]
        FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors]([Id])

    );
GO

