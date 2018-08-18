
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/18/2018 00:59:52
-- Generated from EDMX file: C:\C#\HelpDesk\HelpDeskDB\HelpDeskModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HelpDeskDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Perfiles_Estados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_Perfiles_Estados];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_Departamentos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_Departamentos];
GO
IF OBJECT_ID(N'[dbo].[FK_Persona_Estados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_Persona_Estados];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuarios_Perfiles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_Usuarios_Perfiles];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuarios_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_Usuarios_Persona];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Departamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamentos];
GO
IF OBJECT_ID(N'[dbo].[Estados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estados];
GO
IF OBJECT_ID(N'[dbo].[Perfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfiles];
GO
IF OBJECT_ID(N'[dbo].[Persona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persona];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departamentos'
CREATE TABLE [dbo].[Departamentos] (
    [codigo] int  NOT NULL,
    [Nombre] varchar(50)  NOT NULL
);
GO

-- Creating table 'Estados'
CREATE TABLE [dbo].[Estados] (
    [codigo] int  NOT NULL,
    [Estado] nchar(10)  NULL
);
GO

-- Creating table 'Persona'
CREATE TABLE [dbo].[Persona] (
    [codigo] int  NOT NULL,
    [Nombre] varchar(20)  NOT NULL,
    [Apellido] varchar(20)  NOT NULL,
    [Departamento] int  NOT NULL,
    [Estado] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Perfiles'
CREATE TABLE [dbo].[Perfiles] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(20)  NOT NULL,
    [Estado] int  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [CodPersona] int  NOT NULL,
    [Usuario] varchar(20)  NULL,
    [Pass] varchar(20)  NULL,
    [IdPerfil] int  NULL,
    [estado] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [codigo] in table 'Departamentos'
ALTER TABLE [dbo].[Departamentos]
ADD CONSTRAINT [PK_Departamentos]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [PK_Estados]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [codigo] in table 'Persona'
ALTER TABLE [dbo].[Persona]
ADD CONSTRAINT [PK_Persona]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Codigo] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [PK_Perfiles]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Departamento] in table 'Persona'
ALTER TABLE [dbo].[Persona]
ADD CONSTRAINT [FK_Persona_Departamentos]
    FOREIGN KEY ([Departamento])
    REFERENCES [dbo].[Departamentos]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_Departamentos'
CREATE INDEX [IX_FK_Persona_Departamentos]
ON [dbo].[Persona]
    ([Departamento]);
GO

-- Creating foreign key on [Estado] in table 'Persona'
ALTER TABLE [dbo].[Persona]
ADD CONSTRAINT [FK_Persona_Estados]
    FOREIGN KEY ([Estado])
    REFERENCES [dbo].[Estados]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_Estados'
CREATE INDEX [IX_FK_Persona_Estados]
ON [dbo].[Persona]
    ([Estado]);
GO

-- Creating foreign key on [Estado] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_Perfiles_Estados]
    FOREIGN KEY ([Estado])
    REFERENCES [dbo].[Estados]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Perfiles_Estados'
CREATE INDEX [IX_FK_Perfiles_Estados]
ON [dbo].[Perfiles]
    ([Estado]);
GO

-- Creating foreign key on [IdPerfil] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_Usuarios_Perfiles]
    FOREIGN KEY ([IdPerfil])
    REFERENCES [dbo].[Perfiles]
        ([Codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuarios_Perfiles'
CREATE INDEX [IX_FK_Usuarios_Perfiles]
ON [dbo].[Usuarios]
    ([IdPerfil]);
GO

-- Creating foreign key on [CodPersona] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_Usuarios_Persona]
    FOREIGN KEY ([CodPersona])
    REFERENCES [dbo].[Persona]
        ([codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuarios_Persona'
CREATE INDEX [IX_FK_Usuarios_Persona]
ON [dbo].[Usuarios]
    ([CodPersona]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------