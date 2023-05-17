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

CREATE TABLE [Categories] (
    [CategoryId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
);
GO

CREATE TABLE [Products] (
    [ProductId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Price] float NOT NULL,
    [Description] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId])
);
GO

CREATE TABLE [ProductCategories] (
    [ProductCategoryId] int NOT NULL IDENTITY,
    [CategoryId] int NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_ProductCategories] PRIMARY KEY ([ProductCategoryId]),
    CONSTRAINT [FK_ProductCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProductCategories_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ProductCategories_CategoryId] ON [ProductCategories] ([CategoryId]);
GO

CREATE INDEX [IX_ProductCategories_ProductId] ON [ProductCategories] ([ProductId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230515143219_InitialCreate', N'6.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ProductCategories] ADD [CId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [ProductCategories] ADD [PId] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230515144103_Modify', N'6.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ProductCategories] DROP CONSTRAINT [FK_ProductCategories_Categories_CategoryId];
GO

ALTER TABLE [ProductCategories] DROP CONSTRAINT [FK_ProductCategories_Products_ProductId];
GO

DROP INDEX [IX_ProductCategories_CategoryId] ON [ProductCategories];
GO

DROP INDEX [IX_ProductCategories_ProductId] ON [ProductCategories];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductCategories]') AND [c].[name] = N'CategoryId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ProductCategories] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ProductCategories] DROP COLUMN [CategoryId];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductCategories]') AND [c].[name] = N'ProductId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProductCategories] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [ProductCategories] DROP COLUMN [ProductId];
GO

CREATE INDEX [IX_ProductCategories_CId] ON [ProductCategories] ([CId]);
GO

CREATE INDEX [IX_ProductCategories_PId] ON [ProductCategories] ([PId]);
GO

ALTER TABLE [ProductCategories] ADD CONSTRAINT [FK_ProductCategories_Categories_CId] FOREIGN KEY ([CId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE;
GO

ALTER TABLE [ProductCategories] ADD CONSTRAINT [FK_ProductCategories_Products_PId] FOREIGN KEY ([PId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230515144204_ModifyV2', N'6.0.16');
GO

COMMIT;
GO

