
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/07/2022 10:59:14
-- Generated from EDMX file: C:\Users\User\Desktop\BookStoreDBFirst\BookStoreDBFirst\POSModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BookstoreDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Book__Author_id__4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK__Book__Author_id__4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK__Book__Category_i__4BAC3F29]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK__Book__Category_i__4BAC3F29];
GO
IF OBJECT_ID(N'[dbo].[FK__Book__Publisher___4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK__Book__Publisher___4D94879B];
GO
IF OBJECT_ID(N'[dbo].[FK__Purchase___Book___534D60F1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchase_detail] DROP CONSTRAINT [FK__Purchase___Book___534D60F1];
GO
IF OBJECT_ID(N'[dbo].[FK__Sale_deta__Book___5070F446]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sale_detail] DROP CONSTRAINT [FK__Sale_deta__Book___5070F446];
GO
IF OBJECT_ID(N'[dbo].[FK__Sale__Customer_i__2C3393D0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK__Sale__Customer_i__2C3393D0];
GO
IF OBJECT_ID(N'[dbo].[FK__Purchase___Emplo__30F848ED]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchase_order] DROP CONSTRAINT [FK__Purchase___Emplo__30F848ED];
GO
IF OBJECT_ID(N'[dbo].[FK__Sale__Employee_i__2D27B809]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK__Sale__Employee_i__2D27B809];
GO
IF OBJECT_ID(N'[dbo].[FK__Purchase___Suppl__31EC6D26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchase_order] DROP CONSTRAINT [FK__Purchase___Suppl__31EC6D26];
GO
IF OBJECT_ID(N'[dbo].[FK__Stock__Book_id__0E6E26BF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stocks] DROP CONSTRAINT [FK__Stock__Book_id__0E6E26BF];
GO
IF OBJECT_ID(N'[dbo].[FK_Flash_sale_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Flash_sale] DROP CONSTRAINT [FK_Flash_sale_Book];
GO
IF OBJECT_ID(N'[dbo].[FK__Sale_deta__Book___66603565]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sale_detail] DROP CONSTRAINT [FK__Sale_deta__Book___66603565];
GO
IF OBJECT_ID(N'[dbo].[FK__Purchase___Book___693CA210]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchase_detail] DROP CONSTRAINT [FK__Purchase___Book___693CA210];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Flash_sale]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Flash_sale];
GO
IF OBJECT_ID(N'[dbo].[Publishers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publishers];
GO
IF OBJECT_ID(N'[dbo].[Purchase_detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchase_detail];
GO
IF OBJECT_ID(N'[dbo].[Purchase_order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchase_order];
GO
IF OBJECT_ID(N'[dbo].[Sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sales];
GO
IF OBJECT_ID(N'[dbo].[Sale_detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sale_detail];
GO
IF OBJECT_ID(N'[dbo].[Stocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stocks];
GO
IF OBJECT_ID(N'[dbo].[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suppliers];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[frmReports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[frmReports];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Number_of_page] int  NOT NULL,
    [Description] varchar(500)  NOT NULL,
    [Category_id] int  NOT NULL,
    [Author_id] int  NOT NULL,
    [Publisher_id] int  NOT NULL,
    [Selling_price] decimal(19,4)  NULL,
    [Cost_price] decimal(19,4)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int  NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Phone_number] varchar(50)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Address] varchar(100)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Role] varchar(50)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [Phone_number] varchar(50)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Address] varchar(100)  NOT NULL
);
GO

-- Creating table 'Flash_sale'
CREATE TABLE [dbo].[Flash_sale] (
    [Id] int  NOT NULL,
    [Discount] tinyint  NULL,
    [Start_date] datetime  NULL,
    [End_date] datetime  NULL,
    [Book_id] int  NULL
);
GO

-- Creating table 'Publishers'
CREATE TABLE [dbo].[Publishers] (
    [Id] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Date_of_publishing] datetime  NULL
);
GO

-- Creating table 'Purchase_detail'
CREATE TABLE [dbo].[Purchase_detail] (
    [Id] int  NOT NULL,
    [Quantity] int  NOT NULL,
    [Book_id] int  NULL,
    [Total_price] decimal(19,4)  NOT NULL,
    [Purchase_order_Id] int  NULL
);
GO

-- Creating table 'Purchase_order'
CREATE TABLE [dbo].[Purchase_order] (
    [Id] int  NOT NULL,
    [Total_price] decimal(19,4)  NOT NULL,
    [Total_paid] decimal(19,4)  NOT NULL,
    [Total_remain] decimal(19,4)  NOT NULL,
    [Employee_id] int  NOT NULL,
    [Supplier_id] int  NOT NULL
);
GO

-- Creating table 'Sales'
CREATE TABLE [dbo].[Sales] (
    [Id] int  NOT NULL,
    [Total_price] decimal(19,4)  NOT NULL,
    [Total_paid] decimal(19,4)  NOT NULL,
    [Total_remain] decimal(19,4)  NOT NULL,
    [Customer_id] int  NOT NULL,
    [Employee_id] int  NOT NULL
);
GO

-- Creating table 'Sale_detail'
CREATE TABLE [dbo].[Sale_detail] (
    [Id] int  NOT NULL,
    [Quantity] int  NOT NULL,
    [Book_id] int  NULL,
    [Total_price] decimal(19,4)  NOT NULL,
    [Sale_id] int  NULL
);
GO

-- Creating table 'Stocks'
CREATE TABLE [dbo].[Stocks] (
    [Id] int  NOT NULL,
    [Quantity] int  NOT NULL,
    [Book_id] int  NOT NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Phone_number] varchar(50)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Address] varchar(100)  NOT NULL
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

-- Creating table 'frmReports'
CREATE TABLE [dbo].[frmReports] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Flash_sale'
ALTER TABLE [dbo].[Flash_sale]
ADD CONSTRAINT [PK_Flash_sale]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Publishers'
ALTER TABLE [dbo].[Publishers]
ADD CONSTRAINT [PK_Publishers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Purchase_detail'
ALTER TABLE [dbo].[Purchase_detail]
ADD CONSTRAINT [PK_Purchase_detail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Purchase_order'
ALTER TABLE [dbo].[Purchase_order]
ADD CONSTRAINT [PK_Purchase_order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [PK_Sales]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sale_detail'
ALTER TABLE [dbo].[Sale_detail]
ADD CONSTRAINT [PK_Sale_detail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [PK_Stocks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'frmReports'
ALTER TABLE [dbo].[frmReports]
ADD CONSTRAINT [PK_frmReports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Author_id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Book__Author_id__4CA06362]
    FOREIGN KEY ([Author_id])
    REFERENCES [dbo].[Authors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Book__Author_id__4CA06362'
CREATE INDEX [IX_FK__Book__Author_id__4CA06362]
ON [dbo].[Books]
    ([Author_id]);
GO

-- Creating foreign key on [Category_id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Book__Category_i__4BAC3F29]
    FOREIGN KEY ([Category_id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Book__Category_i__4BAC3F29'
CREATE INDEX [IX_FK__Book__Category_i__4BAC3F29]
ON [dbo].[Books]
    ([Category_id]);
GO

-- Creating foreign key on [Publisher_id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Book__Publisher___4D94879B]
    FOREIGN KEY ([Publisher_id])
    REFERENCES [dbo].[Publishers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Book__Publisher___4D94879B'
CREATE INDEX [IX_FK__Book__Publisher___4D94879B]
ON [dbo].[Books]
    ([Publisher_id]);
GO

-- Creating foreign key on [Book_id] in table 'Purchase_detail'
ALTER TABLE [dbo].[Purchase_detail]
ADD CONSTRAINT [FK__Purchase___Book___534D60F1]
    FOREIGN KEY ([Book_id])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Purchase___Book___534D60F1'
CREATE INDEX [IX_FK__Purchase___Book___534D60F1]
ON [dbo].[Purchase_detail]
    ([Book_id]);
GO

-- Creating foreign key on [Book_id] in table 'Sale_detail'
ALTER TABLE [dbo].[Sale_detail]
ADD CONSTRAINT [FK__Sale_deta__Book___5070F446]
    FOREIGN KEY ([Book_id])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Sale_deta__Book___5070F446'
CREATE INDEX [IX_FK__Sale_deta__Book___5070F446]
ON [dbo].[Sale_detail]
    ([Book_id]);
GO

-- Creating foreign key on [Customer_id] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK__Sale__Customer_i__2C3393D0]
    FOREIGN KEY ([Customer_id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Sale__Customer_i__2C3393D0'
CREATE INDEX [IX_FK__Sale__Customer_i__2C3393D0]
ON [dbo].[Sales]
    ([Customer_id]);
GO

-- Creating foreign key on [Employee_id] in table 'Purchase_order'
ALTER TABLE [dbo].[Purchase_order]
ADD CONSTRAINT [FK__Purchase___Emplo__30F848ED]
    FOREIGN KEY ([Employee_id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Purchase___Emplo__30F848ED'
CREATE INDEX [IX_FK__Purchase___Emplo__30F848ED]
ON [dbo].[Purchase_order]
    ([Employee_id]);
GO

-- Creating foreign key on [Employee_id] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK__Sale__Employee_i__2D27B809]
    FOREIGN KEY ([Employee_id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Sale__Employee_i__2D27B809'
CREATE INDEX [IX_FK__Sale__Employee_i__2D27B809]
ON [dbo].[Sales]
    ([Employee_id]);
GO

-- Creating foreign key on [Supplier_id] in table 'Purchase_order'
ALTER TABLE [dbo].[Purchase_order]
ADD CONSTRAINT [FK__Purchase___Suppl__31EC6D26]
    FOREIGN KEY ([Supplier_id])
    REFERENCES [dbo].[Suppliers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Purchase___Suppl__31EC6D26'
CREATE INDEX [IX_FK__Purchase___Suppl__31EC6D26]
ON [dbo].[Purchase_order]
    ([Supplier_id]);
GO

-- Creating foreign key on [Book_id] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [FK__Stock__Book_id__0E6E26BF]
    FOREIGN KEY ([Book_id])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Stock__Book_id__0E6E26BF'
CREATE INDEX [IX_FK__Stock__Book_id__0E6E26BF]
ON [dbo].[Stocks]
    ([Book_id]);
GO

-- Creating foreign key on [Book_id] in table 'Flash_sale'
ALTER TABLE [dbo].[Flash_sale]
ADD CONSTRAINT [FK_Flash_sale_Book]
    FOREIGN KEY ([Book_id])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Flash_sale_Book'
CREATE INDEX [IX_FK_Flash_sale_Book]
ON [dbo].[Flash_sale]
    ([Book_id]);
GO

-- Creating foreign key on [Sale_id] in table 'Sale_detail'
ALTER TABLE [dbo].[Sale_detail]
ADD CONSTRAINT [FK__Sale_deta__Book___66603565]
    FOREIGN KEY ([Sale_id])
    REFERENCES [dbo].[Sales]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Sale_deta__Book___66603565'
CREATE INDEX [IX_FK__Sale_deta__Book___66603565]
ON [dbo].[Sale_detail]
    ([Sale_id]);
GO

-- Creating foreign key on [Purchase_order_Id] in table 'Purchase_detail'
ALTER TABLE [dbo].[Purchase_detail]
ADD CONSTRAINT [FK__Purchase___Book___693CA210]
    FOREIGN KEY ([Purchase_order_Id])
    REFERENCES [dbo].[Purchase_order]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Purchase___Book___693CA210'
CREATE INDEX [IX_FK__Purchase___Book___693CA210]
ON [dbo].[Purchase_detail]
    ([Purchase_order_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------