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

CREATE TABLE [Student] (
    [StudentId] int NOT NULL IDENTITY,
    [StudentName] nvarchar(100) NOT NULL,
    [StudentNumber] nvarchar(100) NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([StudentId])
);
GO

CREATE TABLE [Subject] (
    [SubjectId] int NOT NULL IDENTITY,
    [SubjectName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Subject] PRIMARY KEY ([SubjectId])
);
GO

CREATE TABLE [StudentSubject] (
    [Id] int NOT NULL IDENTITY,
    [Point] float NOT NULL,
    [StudentId] int NOT NULL,
    [SubjectId] int NOT NULL,
    CONSTRAINT [PK_StudentSubject] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_StudentSubject_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([StudentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentSubject_Subject_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Subject] ([SubjectId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_StudentSubject_StudentId] ON [StudentSubject] ([StudentId]);
GO

CREATE INDEX [IX_StudentSubject_SubjectId] ON [StudentSubject] ([SubjectId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230509104219_non_fluent_api', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Subject].[SubjectId]', N'Id', N'COLUMN';
GO

EXEC sp_rename N'[Student].[StudentId]', N'Id', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230510102547_Update_Id', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [UserType] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230511050914_Add_UserTable', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [LibraryCards] (
    [Id] int NOT NULL,
    [CardId] int NOT NULL,
    [CardType] nvarchar(max) NULL,
    CONSTRAINT [PK_LibraryCards] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LibraryCards_Student_Id] FOREIGN KEY ([Id]) REFERENCES [Student] ([Id]) ON DELETE CASCADE
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230512034730_add_library_card', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LibraryCards]') AND [c].[name] = N'CardType');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [LibraryCards] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [LibraryCards] ALTER COLUMN [CardType] nvarchar(max) NOT NULL;
ALTER TABLE [LibraryCards] ADD DEFAULT N'' FOR [CardType];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230512045333_update_card', N'6.0.10');
GO

COMMIT;
GO

