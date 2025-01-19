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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241205153620_InitialDB'
)
BEGIN
    CREATE TABLE [Product] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [CategoryId] int NULL,
        [ExpiredDate] datetime NULL,
        [CreatedDate] datetime NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedDate] datetime NULL,
        [UpdatedBy] int NULL,
        [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
        CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241205153620_InitialDB'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241205153620_InitialDB', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241207155207_addTableCategory'
)
BEGIN
    CREATE TABLE [Category] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Level] int NOT NULL,
        [ParentId] int NULL,
        [CreatedDate] datetime NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedDate] datetime NULL,
        [UpdatedBy] int NULL,
        [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
        CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241207155207_addTableCategory'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Level', N'Name', N'ParentId', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Category]'))
        SET IDENTITY_INSERT [Category] ON;
    EXEC(N'INSERT INTO [Category] ([Id], [CreatedBy], [CreatedDate], [Level], [Name], [ParentId], [UpdatedBy], [UpdatedDate])
    VALUES (1, 0, ''2024-12-07T15:52:07.267'', 0, N''Food & Beverage'', NULL, NULL, ''2024-12-07T15:52:07.267''),
    (2, 0, ''2024-12-07T15:52:07.267'', 0, N''Agriculture'', NULL, NULL, ''2024-12-07T15:52:07.267''),
    (3, 0, ''2024-12-07T15:52:07.267'', 0, N''Apparel & Accessories'', NULL, NULL, ''2024-12-07T15:52:07.267'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Level', N'Name', N'ParentId', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Category]'))
        SET IDENTITY_INSERT [Category] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241207155207_addTableCategory'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241207155207_addTableCategory', N'8.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250119132740_AddMediaIdOnCategoryTbl'
)
BEGIN
    ALTER TABLE [Category] ADD [MediaId] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250119132740_AddMediaIdOnCategoryTbl'
)
BEGIN
    EXEC(N'UPDATE [Category] SET [CreatedDate] = ''2025-01-19T13:27:39.783'', [MediaId] = NULL, [UpdatedDate] = ''2025-01-19T13:27:39.783''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250119132740_AddMediaIdOnCategoryTbl'
)
BEGIN
    EXEC(N'UPDATE [Category] SET [CreatedDate] = ''2025-01-19T13:27:39.783'', [MediaId] = NULL, [UpdatedDate] = ''2025-01-19T13:27:39.783''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250119132740_AddMediaIdOnCategoryTbl'
)
BEGIN
    EXEC(N'UPDATE [Category] SET [CreatedDate] = ''2025-01-19T13:27:39.783'', [MediaId] = NULL, [UpdatedDate] = ''2025-01-19T13:27:39.783''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250119132740_AddMediaIdOnCategoryTbl'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250119132740_AddMediaIdOnCategoryTbl', N'8.0.11');
END;
GO

COMMIT;
GO

