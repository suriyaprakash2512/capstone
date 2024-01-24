IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AdminInfo] (
    [AdminId] int NOT NULL IDENTITY,
    [EmailId] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_AdminInfo] PRIMARY KEY ([AdminId])
);
GO

CREATE TABLE [BlogInfo] (
    [BlogId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Subject] nvarchar(max) NULL,
    [DateOfCreation] datetime2 NOT NULL,
    [BlogUrl] nvarchar(max) NULL,
    [EmpEmailId] nvarchar(max) NULL,
    CONSTRAINT [PK_BlogInfo] PRIMARY KEY ([BlogId])
);
GO

CREATE TABLE [EmpInfo] (
    [EmpId] int NOT NULL IDENTITY,
    [EmailId] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [DOJ] datetime2 NOT NULL,
    [PassCode] int NOT NULL,
    CONSTRAINT [PK_EmpInfo] PRIMARY KEY ([EmpId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240122115209_FirstMig', N'6.0.25');
GO

COMMIT;
GO

