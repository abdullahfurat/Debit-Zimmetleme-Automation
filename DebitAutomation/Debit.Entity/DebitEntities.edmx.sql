
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/10/2021 13:03:50
-- Generated from EDMX file: C:\Users\a_fur\source\repos\Debit-Zimmetleme-Automation\DebitAutomation\Debit.Entity\DebitEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ddebit];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Adresses'
CREATE TABLE [dbo].[Adresses] (
    [AdressId] int IDENTITY(1,1) NOT NULL,
    [Country] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [Town] nvarchar(50)  NULL,
    [Street] nvarchar(50)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [EmployeeName] nvarchar(50)  NULL,
    [EmployeeSurName] nvarchar(50)  NULL,
    [RoleId] int  NULL,
    [Salary] decimal(19,4)  NULL,
    [Email] nvarchar(50)  NULL,
    [Password] nvarchar(20)  NULL,
    [Phone] nvarchar(11)  NULL,
    [EmployeePhoto] nvarchar(50)  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [EmployeeID] int  NULL,
    [ProductName] nvarchar(50)  NULL,
    [Brand] nvarchar(50)  NULL,
    [Description] varchar(max)  NULL,
    [ProductPhoto] nvarchar(50)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int  NOT NULL,
    [RoleName] nvarchar(50)  NULL
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

-- Creating table 'Employee_Adress'
CREATE TABLE [dbo].[Employee_Adress] (
    [Adresses_AdressId] int  NOT NULL,
    [Employees_EmployeeID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AdressId] in table 'Adresses'
ALTER TABLE [dbo].[Adresses]
ADD CONSTRAINT [PK_Adresses]
    PRIMARY KEY CLUSTERED ([AdressId] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Adresses_AdressId], [Employees_EmployeeID] in table 'Employee_Adress'
ALTER TABLE [dbo].[Employee_Adress]
ADD CONSTRAINT [PK_Employee_Adress]
    PRIMARY KEY CLUSTERED ([Adresses_AdressId], [Employees_EmployeeID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Role]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Role'
CREATE INDEX [IX_FK_Employee_Role]
ON [dbo].[Employees]
    ([RoleId]);
GO

-- Creating foreign key on [EmployeeID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Employee]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Employee'
CREATE INDEX [IX_FK_Product_Employee]
ON [dbo].[Products]
    ([EmployeeID]);
GO

-- Creating foreign key on [Adresses_AdressId] in table 'Employee_Adress'
ALTER TABLE [dbo].[Employee_Adress]
ADD CONSTRAINT [FK_Employee_Adress_Adress]
    FOREIGN KEY ([Adresses_AdressId])
    REFERENCES [dbo].[Adresses]
        ([AdressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Employees_EmployeeID] in table 'Employee_Adress'
ALTER TABLE [dbo].[Employee_Adress]
ADD CONSTRAINT [FK_Employee_Adress_Employee]
    FOREIGN KEY ([Employees_EmployeeID])
    REFERENCES [dbo].[Employees]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Adress_Employee'
CREATE INDEX [IX_FK_Employee_Adress_Employee]
ON [dbo].[Employee_Adress]
    ([Employees_EmployeeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------