CREATE TABLE [dbo].[PROJECTSETTINGS]
(
	[SETTINGID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PROJECTID] INT NOT NULL, 
    [GPS_ASSET_SEARCH] BIT NULL,  -- Enable/Disable GPS Asset Search
    [MAPS] BIT NULL,              -- Enable/Disable Maps
    [LOCATION_TRACKING] BIT NULL, -- Enable/Disable Location Tracking
    [MAX_DISTANCE_FROM_ASSET] INT NULL, -- Max distance from asset (in meters)
    [TRACKING_START_TIME] TIME NULL, -- Tracking Start Time
    [TRACKING_END_TIME] TIME NULL,   -- Tracking End Time
    FOREIGN KEY ([PROJECTID]) REFERENCES [dbo].[PROJECT]([PROJECTID])
)
