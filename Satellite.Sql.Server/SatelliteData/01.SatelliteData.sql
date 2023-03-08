CREATE TABLE [dbo].[SatelliteData] (
    NumberID INT NOT NULL PRIMARY KEY,
    SatelliteType NVARCHAR(255) NOT NULL,
    SatelliteArea NVARCHAR(255) NOT NULL,
    FileCreateDate DATETIME Default(GetDate()) NULL,
    FilePath NVARCHAR(255) NOT NULL,
    UserID NVARCHAR(100) NOT NULL
);
GO
