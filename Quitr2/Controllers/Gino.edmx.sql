
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/16/2017 19:48:58
-- Generated from EDMX file: C:\Users\magnu\documents\visual studio 2017\Projects\Quitr2\Quitr2\Controllers\Gino.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gino];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__deviation__userp__398D8EEE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[deviations] DROP CONSTRAINT [FK__deviation__userp__398D8EEE];
GO
IF OBJECT_ID(N'[dbo].[FK__mood__userprefid__6FE99F9F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[mood] DROP CONSTRAINT [FK__mood__userprefid__6FE99F9F];
GO
IF OBJECT_ID(N'[dbo].[FK__productco__Produ__571DF1D5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productcontents] DROP CONSTRAINT [FK__productco__Produ__571DF1D5];
GO
IF OBJECT_ID(N'[dbo].[FK__productco__produ__628FA481]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productcontents] DROP CONSTRAINT [FK__productco__produ__628FA481];
GO
IF OBJECT_ID(N'[dbo].[FK__products__Produc__5165187F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK__products__Produc__5165187F];
GO
IF OBJECT_ID(N'[dbo].[FK__substitut__subst__5EBF139D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[substitutestat] DROP CONSTRAINT [FK__substitut__subst__5EBF139D];
GO
IF OBJECT_ID(N'[dbo].[FK__substitut__userp__5FB337D6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[substitute] DROP CONSTRAINT [FK__substitut__userp__5FB337D6];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[addictiontypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[addictiontypes];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[deviations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[deviations];
GO
IF OBJECT_ID(N'[dbo].[mood]', 'U') IS NOT NULL
    DROP TABLE [dbo].[mood];
GO
IF OBJECT_ID(N'[dbo].[productcontents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productcontents];
GO
IF OBJECT_ID(N'[dbo].[productcontenttype]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productcontenttype];
GO
IF OBJECT_ID(N'[dbo].[products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[products];
GO
IF OBJECT_ID(N'[dbo].[substitute]', 'U') IS NOT NULL
    DROP TABLE [dbo].[substitute];
GO
IF OBJECT_ID(N'[dbo].[substitutestat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[substitutestat];
GO
IF OBJECT_ID(N'[dbo].[userprefs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[userprefs];
GO
IF OBJECT_ID(N'[ginoModelStoreContainer].[nicotine_per_day]', 'U') IS NOT NULL
    DROP TABLE [ginoModelStoreContainer].[nicotine_per_day];
GO
IF OBJECT_ID(N'[ginoModelStoreContainer].[substitute_nicotine_per_day]', 'U') IS NOT NULL
    DROP TABLE [ginoModelStoreContainer].[substitute_nicotine_per_day];
GO
IF OBJECT_ID(N'[ginoModelStoreContainer].[substitute_nicotine_today]', 'U') IS NOT NULL
    DROP TABLE [ginoModelStoreContainer].[substitute_nicotine_today];
GO
IF OBJECT_ID(N'[ginoModelStoreContainer].[database_firewall_rules]', 'U') IS NOT NULL
    DROP TABLE [ginoModelStoreContainer].[database_firewall_rules];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'addictiontypes'
CREATE TABLE [dbo].[addictiontypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'deviations'
CREATE TABLE [dbo].[deviations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userprefid] int  NOT NULL,
    [deviation_start] datetime  NULL,
    [deviation_end] datetime  NULL,
    [Deleted] bit  NULL
);
GO

-- Creating table 'mood'
CREATE TABLE [dbo].[mood] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TS] datetime  NOT NULL,
    [Mood1] int  NOT NULL,
    [userprefid] int  NULL
);
GO

-- Creating table 'userprefs'
CREATE TABLE [dbo].[userprefs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Deleted] bit  NULL,
    [stopDate] datetime  NULL,
    [addictiontype] int  NOT NULL,
    [userId] nvarchar(128)  NULL,
    [cost] int  NULL,
    [units] int  NULL,
    [addictionproducttype] int  NULL,
    [deleteDate] datetime  NULL,
    [sharing] bit  NULL,
    [substituteUser] bit  NULL
);
GO

-- Creating table 'database_firewall_rules'
CREATE TABLE [dbo].[database_firewall_rules] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(128)  NOT NULL,
    [start_ip_address] varchar(45)  NOT NULL,
    [end_ip_address] varchar(45)  NOT NULL,
    [create_date] datetime  NOT NULL,
    [modify_date] datetime  NOT NULL
);
GO

-- Creating table 'productcontents'
CREATE TABLE [dbo].[productcontents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [Amount] decimal(6,3)  NULL,
    [Unit] varchar(16)  NULL,
    [productcontenttypeId] int  NULL
);
GO

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Producttype] int  NULL,
    [Name] varchar(128)  NULL,
    [deleted] bit  NULL
);
GO

-- Creating table 'substitute'
CREATE TABLE [dbo].[substitute] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userprefId] int  NOT NULL,
    [updated] datetime  NOT NULL,
    [amount] int  NOT NULL,
    [unit] varchar(16)  NOT NULL,
    [deleted] bit  NULL
);
GO

-- Creating table 'substitutestat'
CREATE TABLE [dbo].[substitutestat] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [substituteId] int  NOT NULL,
    [TS] datetime  NOT NULL
);
GO

-- Creating table 'productcontenttype'
CREATE TABLE [dbo].[productcontenttype] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(64)  NOT NULL
);
GO

-- Creating table 'nicotine_per_day'
CREATE TABLE [dbo].[nicotine_per_day] (
    [userprefid] int  NOT NULL,
    [nic_per_day] decimal(17,3)  NULL
);
GO

-- Creating table 'substitute_nicotine_today'
CREATE TABLE [dbo].[substitute_nicotine_today] (
    [userprefid] int  NOT NULL,
    [today_amount] int  NULL,
    [unit] varchar(16)  NOT NULL
);
GO

-- Creating table 'substitute_nicotine_per_day'
CREATE TABLE [dbo].[substitute_nicotine_per_day] (
    [userprefid] int  NOT NULL,
    [year] int  NULL,
    [month] int  NULL,
    [day] int  NULL,
    [substitute_sum] int  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'addictiontypes'
ALTER TABLE [dbo].[addictiontypes]
ADD CONSTRAINT [PK_addictiontypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'deviations'
ALTER TABLE [dbo].[deviations]
ADD CONSTRAINT [PK_deviations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'mood'
ALTER TABLE [dbo].[mood]
ADD CONSTRAINT [PK_mood]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'userprefs'
ALTER TABLE [dbo].[userprefs]
ADD CONSTRAINT [PK_userprefs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id], [name], [start_ip_address], [end_ip_address], [create_date], [modify_date] in table 'database_firewall_rules'
ALTER TABLE [dbo].[database_firewall_rules]
ADD CONSTRAINT [PK_database_firewall_rules]
    PRIMARY KEY CLUSTERED ([id], [name], [start_ip_address], [end_ip_address], [create_date], [modify_date] ASC);
GO

-- Creating primary key on [Id] in table 'productcontents'
ALTER TABLE [dbo].[productcontents]
ADD CONSTRAINT [PK_productcontents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'substitute'
ALTER TABLE [dbo].[substitute]
ADD CONSTRAINT [PK_substitute]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'substitutestat'
ALTER TABLE [dbo].[substitutestat]
ADD CONSTRAINT [PK_substitutestat]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'productcontenttype'
ALTER TABLE [dbo].[productcontenttype]
ADD CONSTRAINT [PK_productcontenttype]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [userprefid] in table 'nicotine_per_day'
ALTER TABLE [dbo].[nicotine_per_day]
ADD CONSTRAINT [PK_nicotine_per_day]
    PRIMARY KEY CLUSTERED ([userprefid] ASC);
GO

-- Creating primary key on [userprefid], [unit] in table 'substitute_nicotine_today'
ALTER TABLE [dbo].[substitute_nicotine_today]
ADD CONSTRAINT [PK_substitute_nicotine_today]
    PRIMARY KEY CLUSTERED ([userprefid], [unit] ASC);
GO

-- Creating primary key on [userprefid] in table 'substitute_nicotine_per_day'
ALTER TABLE [dbo].[substitute_nicotine_per_day]
ADD CONSTRAINT [PK_substitute_nicotine_per_day]
    PRIMARY KEY CLUSTERED ([userprefid] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [userId] in table 'userprefs'
ALTER TABLE [dbo].[userprefs]
ADD CONSTRAINT [FK__userprefs__userI__4CA06362]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__userprefs__userI__4CA06362'
CREATE INDEX [IX_FK__userprefs__userI__4CA06362]
ON [dbo].[userprefs]
    ([userId]);
GO

-- Creating foreign key on [userprefid] in table 'deviations'
ALTER TABLE [dbo].[deviations]
ADD CONSTRAINT [FK__deviation__userp__398D8EEE]
    FOREIGN KEY ([userprefid])
    REFERENCES [dbo].[userprefs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__deviation__userp__398D8EEE'
CREATE INDEX [IX_FK__deviation__userp__398D8EEE]
ON [dbo].[deviations]
    ([userprefid]);
GO

-- Creating foreign key on [userprefid] in table 'mood'
ALTER TABLE [dbo].[mood]
ADD CONSTRAINT [FK__mood__userprefid__4F7CD00D]
    FOREIGN KEY ([userprefid])
    REFERENCES [dbo].[userprefs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__mood__userprefid__4F7CD00D'
CREATE INDEX [IX_FK__mood__userprefid__4F7CD00D]
ON [dbo].[mood]
    ([userprefid]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [Producttype] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK__products__Produc__5165187F]
    FOREIGN KEY ([Producttype])
    REFERENCES [dbo].[addictiontypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__products__Produc__5165187F'
CREATE INDEX [IX_FK__products__Produc__5165187F]
ON [dbo].[products]
    ([Producttype]);
GO

-- Creating foreign key on [ProductId] in table 'productcontents'
ALTER TABLE [dbo].[productcontents]
ADD CONSTRAINT [FK__productco__Produ__571DF1D5]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__productco__Produ__571DF1D5'
CREATE INDEX [IX_FK__productco__Produ__571DF1D5]
ON [dbo].[productcontents]
    ([ProductId]);
GO

-- Creating foreign key on [substituteId] in table 'substitutestat'
ALTER TABLE [dbo].[substitutestat]
ADD CONSTRAINT [FK__substitut__subst__5EBF139D]
    FOREIGN KEY ([substituteId])
    REFERENCES [dbo].[substitute]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__substitut__subst__5EBF139D'
CREATE INDEX [IX_FK__substitut__subst__5EBF139D]
ON [dbo].[substitutestat]
    ([substituteId]);
GO

-- Creating foreign key on [userprefId] in table 'substitute'
ALTER TABLE [dbo].[substitute]
ADD CONSTRAINT [FK__substitut__userp__5FB337D6]
    FOREIGN KEY ([userprefId])
    REFERENCES [dbo].[userprefs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__substitut__userp__5FB337D6'
CREATE INDEX [IX_FK__substitut__userp__5FB337D6]
ON [dbo].[substitute]
    ([userprefId]);
GO

-- Creating foreign key on [productcontenttypeId] in table 'productcontents'
ALTER TABLE [dbo].[productcontents]
ADD CONSTRAINT [FK__productco__produ__628FA481]
    FOREIGN KEY ([productcontenttypeId])
    REFERENCES [dbo].[productcontenttype]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__productco__produ__628FA481'
CREATE INDEX [IX_FK__productco__produ__628FA481]
ON [dbo].[productcontents]
    ([productcontenttypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------