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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220609151241_InitialCreate')
BEGIN
    CREATE TABLE [Track] (
        [Key] nvarchar(450) NOT NULL,
        [Title] nvarchar(max) NULL,
        [Subtitle] nvarchar(max) NULL,
        [Background] nvarchar(max) NULL,
        [Coverart] nvarchar(max) NULL,
        [Genres] nvarchar(max) NULL,
        [Text] nvarchar(max) NULL,
        [Footer] nvarchar(max) NULL,
        [Caption] nvarchar(max) NULL,
        [Uri] nvarchar(max) NULL,
        CONSTRAINT [PK_Track] PRIMARY KEY ([Key])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220609151241_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220609151241_InitialCreate', N'6.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220618093805_PlaylistId')
BEGIN
    ALTER TABLE [Track] ADD [PlaylistId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220618093805_PlaylistId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220618093805_PlaylistId', N'6.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220618094825_PlaylistCreate')
BEGIN
    CREATE TABLE [Playlist] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Img] nvarchar(max) NULL,
        [TracksCount] int NOT NULL,
        CONSTRAINT [PK_Playlist] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220618094825_PlaylistCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220618094825_PlaylistCreate', N'6.0.6');
END;
GO

COMMIT;
GO

