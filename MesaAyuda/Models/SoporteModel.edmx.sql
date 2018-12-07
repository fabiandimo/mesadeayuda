
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/27/2017 16:13:12
-- Generated from EDMX file: I:\JUlian Prado\MAyuda\MesaAyuda\Models\SoporteModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Soporte];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Incidencias_Categorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incidencias] DROP CONSTRAINT [FK_Incidencias_Categorias];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[Grados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grados];
GO
IF OBJECT_ID(N'[dbo].[Incidencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Incidencias];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Categoria] nvarchar(200)  NOT NULL,
    [EsActivo] bit  NOT NULL
);
GO

-- Creating table 'Grados'
CREATE TABLE [dbo].[Grados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Grado] nvarchar(10)  NOT NULL,
    [EsActivo] bit  NOT NULL
);
GO

-- Creating table 'Incidencias'
CREATE TABLE [dbo].[Incidencias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoriaId] int  NOT NULL,
    [Incidencia] nvarchar(200)  NOT NULL,
    [EsActivo] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Grados'
ALTER TABLE [dbo].[Grados]
ADD CONSTRAINT [PK_Grados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Incidencias'
ALTER TABLE [dbo].[Incidencias]
ADD CONSTRAINT [PK_Incidencias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoriaId] in table 'Incidencias'
ALTER TABLE [dbo].[Incidencias]
ADD CONSTRAINT [FK_Incidencias_Categorias]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Incidencias_Categorias'
CREATE INDEX [IX_FK_Incidencias_Categorias]
ON [dbo].[Incidencias]
    ([CategoriaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------