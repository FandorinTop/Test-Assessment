IF db_id('TestDb') IS NULL 
	CREATE DATABASE TestDb;
GO

USE TestDb
GO

CREATE TABLE TestDb.dbo.[TaxiTrips] (
    [Id] int NOT NULL IDENTITY,
    [TpepPickupDatetime] datetime2 NULL,
    [TpepDropoffDatetime] datetime2 NULL,
    [PassengerCount] int NULL,
    [TripDistance] float NULL,
    [StoreAndFwdFlag] nvarchar(3) NULL,
    [PULocationID] int NULL,
    [DOLocationID] int NULL,
    [FareAmount] decimal(18,2) NULL,
    [TipAmount] decimal(18,2) NULL,
    [CreationTime] datetime2 NOT NULL,
    CONSTRAINT [PK_TaxiTrips] PRIMARY KEY ([Id])
);

CREATE INDEX [IX_TaxiTrips_PULocationID] ON [TaxiTrips] ([PULocationID]);
CREATE INDEX [IX_TaxiTrips_TpepDropoffDatetime_TpepPickupDatetime] ON [TaxiTrips] ([TpepDropoffDatetime], [TpepPickupDatetime]);
CREATE INDEX [IX_TaxiTrips_TripDistance] ON [TaxiTrips] ([TripDistance]);
