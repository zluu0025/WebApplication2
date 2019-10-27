
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/28/2019 00:13:03
-- Generated from EDMX file: C:\Users\PX Hao\source\repos\Fit5032_week03_Studio\Fit5032_week03_Studio\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-WebApplication2-20191027090516];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------
IF OBJECT_ID(N'[dbo].[FK_CarCarRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarRatingSet] DROP CONSTRAINT [FK_CarCarRating];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingSet] DROP CONSTRAINT [FK_LocationBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_CarBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingSet] DROP CONSTRAINT [FK_CarBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderLineCarRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderLineSet] DROP CONSTRAINT [FK_OrderLineCarRating];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingOrderLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderLineSet] DROP CONSTRAINT [FK_BookingOrderLine];
GO
-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LocationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationSet];
GO
IF OBJECT_ID(N'[dbo].[BookingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingSet];
GO
IF OBJECT_ID(N'[dbo].[CarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarSet];
GO
IF OBJECT_ID(N'[dbo].[CarRatingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarRatingSet];
GO
IF OBJECT_ID(N'[dbo].[OrderLineSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderLineSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LocationSet'
CREATE TABLE [dbo].[LocationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Latitude] NUMERIC (10, 8)NOT NULL,
    [Longitude] NUMERIC (11, 8)  NOT NULL,
CONSTRAINT [CK_Latitude] CHECK ([Latitude]>=(-90) AND [Latitude]<=(90)),
CONSTRAINT [CK_Longtitude] CHECK ([Longitude]>=(-180) AND [Longitude]<=(180))
);
GO

-- Creating table 'BookingSet'
CREATE TABLE [dbo].[BookingSet] (
    [BookingID] int IDENTITY(1,1) NOT NULL,
    [BookingTime] datetime NOT NULL,
    [RengtingStart] datetime  NOT NULL,
    [RentingEnd] datetime  NOT NULL,
    [Contact_PhonbeNumber] nvarchar(max)  NOT NULL,
    [LocationId] int  NOT NULL,
    [CarId] int  NOT NULL,
    [UserID] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CarSet'
CREATE TABLE [dbo].[CarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CarVin] nvarchar(max)  NOT NULL,
    [CarMark] nvarchar(max)  NOT NULL,
    [CarModel] nvarchar(max)  NOT NULL,
    [CarType] nvarchar(max)  NOT NULL,
    [CarPrice] float  NOT NULL,
    [CarRegisterDate] datetime  NOT NULL
);
GO

-- Creating table 'CarRatingSet'
CREATE TABLE [dbo].[CarRatingSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CarId] int  NOT NULL,
    [Rating] varchar(max)  NOT NULL,
    [Comment] varchar(max)  NOT NULL
);
GO

-- Creating table 'OrderLineSet'
CREATE TABLE [dbo].[OrderLineSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ConfirmStartTime] datetime  NOT NULL,
    [ConfirmEndTime] datetime  NOT NULL,
    [ReturnStatus] nvarchar(max)  NOT NULL,
    [BookingBookingID1] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'LocationSet'
ALTER TABLE [dbo].[LocationSet]
ADD CONSTRAINT [PK_LocationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BookingID] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [PK_BookingSet]
    PRIMARY KEY CLUSTERED ([BookingID] ASC);
GO

-- Creating primary key on [Id] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [PK_CarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CarRatingSet'
ALTER TABLE [dbo].[CarRatingSet]
ADD CONSTRAINT [PK_CarRatingSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderLineSet'
ALTER TABLE [dbo].[OrderLineSet]
ADD CONSTRAINT [PK_OrderLineSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarId] in table 'CarRatingSet'
ALTER TABLE [dbo].[CarRatingSet]
ADD CONSTRAINT [FK_CarCarRating]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[CarSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarCarRating'
CREATE INDEX [IX_FK_CarCarRating]
ON [dbo].[CarRatingSet]
    ([CarId]);
GO

-- Creating foreign key on [LocationId] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [FK_LocationBooking]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[LocationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationBooking'
CREATE INDEX [IX_FK_LocationBooking]
ON [dbo].[BookingSet]
    ([LocationId]);
GO

-- Creating foreign key on [CarId] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [FK_CarBooking]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[CarSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarBooking'
CREATE INDEX [IX_FK_CarBooking]
ON [dbo].[BookingSet]
    ([CarId]);
GO

-- Creating foreign key on [BookingBookingID1] in table 'OrderLineSet'
ALTER TABLE [dbo].[OrderLineSet]
ADD CONSTRAINT [FK_BookingOrderLine]
    FOREIGN KEY ([BookingBookingID1])
    REFERENCES [dbo].[BookingSet]
        ([BookingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingOrderLine'
CREATE INDEX [IX_FK_BookingOrderLine]
ON [dbo].[OrderLineSet]
    ([BookingBookingID1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------