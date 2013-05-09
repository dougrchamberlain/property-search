DROP TABLE WEB.STAGE.PARCEL
CREATE TABLE WEB.STAGE.PARCEL
(
PARCEL_ID VARCHAR(13),
ACCOUNT_NUMBER VARCHAR(10),
DB_YEAR VARCHAR(4),
LOAD_DT DATETIME,
--INCORPORATION VARCHAR,
SUBDIVISION_CODE VARCHAR(10) DEFAULT '',
USE_CODE VARCHAR(10) DEFAULT '',
NEIGHBORHOOD_CODE VARCHAR(10) DEFAULT '',
SECTION VARCHAR(10) DEFAULT '',
TOWNSHIP VARCHAR(10) DEFAULT '',
RANGE VARCHAR(10) DEFAULT '',
CENSUS VARCHAR(25) DEFAULT '',
ZONING VARCHAR(10) DEFAULT '',
DESCRIPTION VARCHAR(MAX) DEFAULT '',
STATUS VARCHAR(10),
SITUS_STREET_NUMBER VARCHAR(10),
SITUS_STREET VARCHAR(50),
SITUS_STREET_DIRECTION VARCHAR(10),
SITUS_STREET_UNIT VARCHAR(10),
SITUS_CITY VARCHAR(25),
SITUS_POSTAL_CODE VARCHAR(10),
SITUS_ADDRESS VARCHAR(255)
)

GO
--SITUS_ADDRESS || SITUS_ADDRESS_SEQ,LINE1, LINE2, LINE3, CITY,POSTAL_CODE
DROP TABLE WEB.STAGE.SITUS
CREATE TABLE WEB.STAGE.SITUS
(
PARCEL_ID VARCHAR(13),
CARD_NUMBER INT NOT NULL,
DB_YEAR INT DEFAULT 0,
LOAD_DT DATETIME,
LINE1 VARCHAR(50),
CITY VARCHAR(25),
POSTAL_CODE VARCHAR(10)
)
GO
--BUILDING || BLDG_SEQ,CARD_NUMBER,BLDG_TYPE,FINISHED_AREA,TOTAL_AREA,YEAR_BUILT,UNITS,STORIES,
--BEDROOMS,BATHROOMS,HALFBATHS,OTHER_ROOMS,FRAME,PRIM_EXT_WALL,ROOF_STRUCT,ROOF_COVER,HEAT_TYPE,FIREPLACES
DROP TABLE WEB.STAGE.BUILDING
CREATE TABLE WEB.STAGE.BUILDING
(
PARCEL_ID VARCHAR(13),
CARD_NUMBER INT NOT NULL,
DB_YEAR INT DEFAULT 0,
LOAD_DT DATETIME,
BUILDING_TYPE VARCHAR(5),
FINISHED_AREA INT DEFAULT 0,
TOTAL_AREA INT DEFAULT 0,
YEAR_BUILT INT DEFAULT 0,
EFFECTIVE_YEAR_BUILT INT DEFAULT 0,
UNITS INT DEFAULT 0,
STORIES INT DEFAULT 0,
BEDROOMS INT DEFAULT 0,
FULL_BATHS INT DEFAULT 0,
HALF_BATHS INT DEFAULT 0,
OTHER_ROOMS INT DEFAULT 0,
FRAME VARCHAR(5),
PRIME_EXT_WALL VARCHAR(5),
ROOF_STRUCT VARCHAR(5),
ROOF_COVER VARCHAR(5),
HEAT_TYPE VARCHAR(5),
FIREPLACES INT DEFAULT 0,
GRADE VARCHAR(5),
BUILDING_VALUE INT
)

GO
--EXTRA_FEATURE || XFOB_SEQ, XFOB_CD, YEAR_BUILT
DROP TABLE WEB.STAGE.EXTRA_FEATURE
CREATE TABLE WEB.STAGE.EXTRA_FEATURE
(
PARCEL_ID VARCHAR(13),
CARD_NUMBER INT NOT NULL,
DB_YEAR INT DEFAULT 0,
LOAD_DT DATETIME,
XFOB_CD VARCHAR(5),
YEAR_BUILT INT DEFAULT 0,
XFOB_VALUE INT
)
GO
--DISTRICT || DISTRICT_SEQ, DISTRICT_CD,MILL_RATE,NON_AD_VALOREM
DROP TABLE WEB.STAGE.DISTRICT
CREATE TABLE WEB.STAGE.DISTRICT
(
PARCEL_ID VARCHAR(13),
DB_YEAR INT DEFAULT 0,
LOAD_DT DATETIME,
DISTRICT_CD VARCHAR(5),
TAXABLE_AMOUNT INT DEFAULT 0,
DISTRICT_TAX DECIMAL(9,2) DEFAULT 0.0
--MILL_RATE DECIMAL(2,4) DEFAULT 0.0,
--NON_AD_VALOREM BIT DEFAULT 0
)
GO

--VALUE || 
DROP TABLE WEB.STAGE.VALUE
CREATE TABLE WEB.STAGE.VALUE
(
PARCEL_ID VARCHAR(13),
DB_YEAR INT DEFAULT 0,
LOAD_DT DATETIME,
FISCAL_YEAR INT,
SEQ_NUMBER INT,
CATEGORY VARCHAR(5),
JUST INT DEFAULT 0,
LAND INT DEFAULT 0,
IMPROVEMENT INT DEFAULT 0,
ASSESSED INT DEFAULT 0,
EXEMPTION INT DEFAULT 0
)
GO

--EXEMPTION || 
DROP TABLE WEB.STAGE.EXEMPTION
CREATE TABLE WEB.STAGE.EXEMPTION
(
PARCEL_ID VARCHAR(255),
DB_YEAR INT DEFAULT 0,
LOAD_DT DATETIME,
GRANT_YEAR INT,
EXEMPTION_CD VARCHAR(5),
EXEMPTION_AMOUNT INT DEFAULT 0
)
GO


--TRANSFER || TRANSFER_SEQ,TRANSFER_DATE,RECORDED_CONSIDERATION,QUAL_CD,INSTRUMENT_NUM,GRANTOR,INSTRUMENT_TYPE
DROP TABLE WEB.STAGE.TRANSFER
CREATE TABLE WEB.STAGE.TRANSFER
(
PARCEL_ID VARCHAR(13),
DB_YEAR INT DEFAULT 0,
LOAD_DT DATETIME,
TRANSFER_DATE DATETIME,
RECORDED_CONSIDERATION INT DEFAULT 0,
QUAL_CD VARCHAR(5),
INSTRUMENT_NUMBER VARCHAR(35),
GRANTOR VARCHAR(150),
INSTRUMENT_TYPE VARCHAR(10) 
)
GO


--OWNER || OWNER_SEQ,NAME,LINE1, LINE2, LINE3, CITY, PROVINCE, POSTAL_CODE, COUNTRY
DROP TABLE WEB.STAGE.OWNER
CREATE TABLE WEB.STAGE.OWNER
(
PARCEL_ID VARCHAR(13),
DB_YEAR INT DEFAULT 0,
LOAD_DT DATETIME,
OWNER_NUMBER INT,
NAME VARCHAR(100),
LINE1 VARCHAR(50),
LINE2 VARCHAR(50),
LINE3 VARCHAR(50),
CITY VARCHAR(25),
PROVINCE VARCHAR(25),
POSTAL_CODE VARCHAR(25),
COUNTRY VARCHAR(25)
)
GO


USE [WEB]
GO

CREATE NONCLUSTERED INDEX [IDX_PARCEL_PARCEL_ID_DB_YEAR] ON [STAGE].[PARCEL] 
(
	[PARCEL_ID] ASC,
	[DB_YEAR] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IDX_OWNER_PARCEL_ID_DB_YEAR] ON [STAGE].[OWNER] 
(
	[PARCEL_ID] ASC,
	[DB_YEAR] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IDX_VALUE_PARCEL_ID_DB_YEAR] ON [STAGE].[VALUE] 
(
	[PARCEL_ID] ASC,
	[DB_YEAR] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IDX_DISTRICT_PARCEL_ID_DB_YEAR] ON [STAGE].[DISTRICT] 
(
	[PARCEL_ID] ASC,
	[DB_YEAR] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IDX_BUILDING_PARCEL_ID_DB_YEAR] ON [STAGE].[BUILDING] 
(
	[PARCEL_ID] ASC,
	[DB_YEAR] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IDX_SITUS_PARCEL_ID_DB_YEAR] ON [STAGE].[SITUS] 
(
	[PARCEL_ID] ASC,
	[DB_YEAR] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IDX_EXEMPTION_PARCEL_ID_DB_YEAR] ON [STAGE].[EXEMPTION] 
(
	[PARCEL_ID] ASC,
	[DB_YEAR] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IDX_TRANSFER_PARCEL_ID_DB_YEAR] ON [STAGE].[TRANSFER] 
(
	[PARCEL_ID] ASC,
	[DB_YEAR] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IDX_EXTRA_FEATURE_PARCEL_ID_DB_YEAR] ON [STAGE].[EXTRA_FEATURE] 
(
	[PARCEL_ID] ASC,
	[DB_YEAR] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX IDX_DISTRICT_DB_YEAR
ON STAGE.DISTRICT (DB_YEAR)
INCLUDE (PARCEL_ID, DISTRICT_CD)

USE [WEB]
GO
CREATE NONCLUSTERED INDEX [IDX_VALUE_DB_YEAR]
ON [STAGE].[VALUE] ([DB_YEAR])
INCLUDE ([PARCEL_ID],[FISCAL_YEAR])


USE [WEB]
GO
CREATE NONCLUSTERED INDEX [IDX_TRANSFER_DB_YEAR]
ON [STAGE].[TRANSFER] ([DB_YEAR])
INCLUDE ([PARCEL_ID])
GO

USE [WEB]
GO
CREATE NONCLUSTERED INDEX [IDX_SITUS_DB_YEAR]
ON [STAGE].[SITUS] ([DB_YEAR])
INCLUDE ([PARCEL_ID],[CARD_NUMBER])



USE [WEB]
GO
CREATE NONCLUSTERED INDEX [IDX_OWNER_DB_YEAR]
ON [STAGE].[OWNER] ([DB_YEAR])
INCLUDE ([PARCEL_ID])