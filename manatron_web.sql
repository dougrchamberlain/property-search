--drop database web
/****** Object:  UserDefinedFunction [dbo].[Splitter]    Script Date: 03/15/2013 09:35:16 ******/
USE WEB
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if object_id('dbo.trim') is not null
begin
drop function trim
end

GO

CREATE FUNCTION [dbo].[trim](@text nvarchar(max)) 
RETURNS nvarchar(max)
AS 
BEGIN

declare @trimmed_string nvarchar(max)

set @trimmed_string = ltrim(rtrim(@text))

return @trimmed_string
end

GO

if object_id('dbo.Splitter') is not null
begin
  drop FUNCTION splitter
end

GO

CREATE FUNCTION [dbo].[Splitter](@text nvarchar(max),@separator_list varchar(50)) 
RETURNS @result TABLE (i int, value nvarchar(max)) 
AS 
BEGIN
 
    DECLARE @i int 
    DECLARE @offset int
    DECLARE @length_of_separator int
    DECLARE @separator_item varchar(10)
    
    
    WHILE LEN(@separator_list) > 1
    BEGIN
    set @separator_item = LEFT(@separator_list, 1)
    --PRINT @separator_item 
    set @text = replace(@text,@separator_item,' ')
    SET @separator_list = SUBSTRING(@separator_list, 2, LEN(@separator_list))
    END
    
    --PRINT @separator_list
    --PRINT @text
    
    set @text = LTRIM(RTRIM(replace(replace(replace(@text,' ','<>'),'><',''),'<>',' ')))
    --PRINT @text 
    SET @i = 0 
    --truncate table #result
    WHILE @text IS NOT NULL 
    BEGIN 
        SET @i = @i + 1 
        SET @offset = charindex(' ', @text) 
        INSERT INTO @result select @i item, CASE WHEN @offset > 0 THEN LEFT(@text, @offset - 1) ELSE @text END value         
        SET @text = CASE WHEN @offset > 0 THEN SUBSTRING(@text, @offset + 1, LEN(@text)) END 
    END 
    RETURN
END    


GO


GO
DROP TABLE LEGAL_LN
SELECT p1.strap,
 
       stuff( (SELECT ','+dscr 

               FROM r_prod.dbo.legal_ln p2
 
               WHERE p2.strap = p1.strap
 
               ORDER BY strap,num
 
               FOR XML PATH(''), TYPE).value('.', 'varchar(max)')
 
            ,1,1,'')
 
       AS legals
		into LEGAL_LN
      FROM r_prod.dbo.legal_ln p1
 
      GROUP BY strap
GO

USE WEB


EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
GO

EXEC sp_msforeachtable "DELETE FROM ? where '?' <> 'LEGAL_LN'"

GO

--if object_id('dbo.STAGE_PARCEL') is null
--begin
--	SELECT * INTO STAGE_PARCEL FROM r_prod.dbo.parcel where strap not in (select strap FROM r_prod.dbo.strap_idx where conf_flg = 'Y') order by newid() 
--end

--GO


--if object_id('dbo.STAGE_PARCEL') is not null
--BEGIN
--INSERT INTO STAGE_PARCEL select * from r_prod.dbo.parcel where strap not in (select strap FROM r_prod.dbo.strap_idx where conf_flg = 'Y') order by newid() 
--END
--SELECT STRAP,'CONFIDENTIAL' INTO #CONFIDENTIAL_PARCELS FROM r_prod.dbo.strap_idx where conf_flg = 'Y'


--DELETE FROM WEB.DBO.STAGE_PARCELS WHERE DOR_CD = 'INFO'

--SELECT * FROM WEB.DBO.STAGE_PARCELS 

GO

INSERT INTO WEB.DBO.PARCELS (STRAP,PROPERTY_USE,LAND_AREA,
SUBDIVISION,SEC_TWP_RGE,CENSUS,SITUS,ZIP_CODE,MAILING_ADDRESS,ASSESSMENT_DESCRIPTION,WATERFRONT)

select web.dbo.trim(t1.STRAP),t1.PROPERTY_USE,t1.LAND_AREA,t1.SUBDIVISION,t1.SEC_TWP_RGE,t1.CENSUS,t2.SITUS,t2.ZIP_CODE,t4.MAILING_ADDRESS,NULL,ISNULL(t5.WATERFRONT,'N/A') from 
(
select d.strap,f.dor_cd + ' - ' + f.dscr PROPERTY_USE,sqft LAND_AREA,g.id + ' - ' + g.dscr SUBDIVISION,web.dbo.trim(SECTION)+'-'+web.dbo.trim(township) + '-' + web.dbo.trim(range) SEC_TWP_RGE,ct_cd CENSUS from r_prod.dbo.detail d
join (select * from r_prod.dbo.parcel) e
on 
d.strap = e.strap
left outer join
r_prod.dbo.lu_dor f
on f.dor_cd = e.dor_cd
left outer join
r_prod.dbo.lu_sub g
on
d.sub = g.id
) t1
left outer join
(
select d.strap,
RTRIM(ISNULL(CAST(str_num AS VARCHAR(10))+ ' ','') + ISNULL(NULLIF(str_pfx,'') + ' ','') + ISNULL(str + ' ','') + ISNULL(str_sfx + ' ','') + ISNULL(str_sfx_dir + ' ','') + ISNULL(str_unit + ' ','')) + ', ' + city + ', FL, ' + zip SITUS, zip ZIP_CODE
from r_prod.dbo.site d
where d.bld_num = 1
and d.ln_num = 1
) t2
on
t1.strap = t2.strap
left outer join
(
select strap, ISNULL(addr_1 +CHAR(10) + CHAR(13),'')  + ISNULL(addr_2 +CHAR(10) + CHAR(13),'')  + city + ', ' + state + ', ' + zip MAILING_ADDRESS
from r_prod.dbo.mail d
) t4
on
t1.strap = t4.strap
left outer join
(
SELECT d.strap,e.tp WATERFRONT
  FROM r_prod.dbo.[pchar] d
  join
  r_prod.dbo.lu_pchar_tp e
  on 
  d.tp = e.tp
  where d.cat  = 'GB') t5
 on
 t1.strap = t5.strap     
GO




delete from WEB..PARCELS WHERE STRAP IN (select strap from r_prod.dbo.strap_idx where conf_flg = 'Y')

update WEB..PARCELS set Waterfront = 'N/A' where WATERFRONT is NULL

GO
--update web..PARCELS set PROPERTY_ID  = LEFT(strap,4) + '-' + SUBSTRING(strap,5,2) + '-' + RIGHT(strap,4) 


--load up incorporation
UPDATE TARGET
SET target.MUNICIPALITY_CODE = source.cd,
target.MUNICIPALITY_NAME = source.name
from 
(select b.strap,c.cd,c.name from r_prod..lu_tax_dist c
join (
select strap,max(round(b.tax_dist,-2,1)) cd from r_prod..parcel_tax b
where b.tax_dist <= '0500'
group by b.strap
) b
on 
c.cd = b.cd
and
icd IN ('MUN','COU')
) source
join (select * from WEB.dbo.PARCELS) target
on 
source.strap = target.strap


--Recontstruct Legal lines

UPDATE target
set ASSESSMENT_DESCRIPTION = LEGALS 
FROM 
(select * from WEB.DBO.LEGAL_LN) source
join
(select * from WEB.DBO.PARCELS) target
on
source.strap = target.strap

--INSERT into LEGAL_LN select web.dbo.trim(STRAP) STRAP, edw.dbo.fn_reconstructLegal(strap) DSCR  from r_prod.dbo.legal_ln d where num = 1 

-- Get Parcel Additional Characteristcs


INSERT INTO WEB.DBO.CHARACTERISTICS
select web.dbo.trim(d.strap),e.cat CAT_CD,f.tp TP,e.dscr CAT,f.dscr DSCR 
from web.dbo.parcels c
join r_prod.dbo.pchar d
on c.strap = d.strap
join r_prod.dbo.lu_pchar_cat e
on
d.cat = e.cat
join r_prod.dbo.lu_pchar_tp f
on 
d.tp = f.tp
where e.CAT = 'DD'


GO

--get Owners
INSERT INTO WEB.DBO.OWNERS 
select web.dbo.trim(d.strap),ln_num,name
from r_prod.dbo.Owner d
join web.dbo.parcels e
on e.strap = d.strap
where d.NAME <> '' 

GO
--get basic building information


INSERT INTO WEB.DBO.BUILDINGS
select web.dbo.trim(d.strap),d.num,t2.SITUS,
web.dbo.trim(e.tp) + ' - ' + e.dscr,
web.dbo.trim(f.cd) + ' - ' + f.dscr,
0 beds,0 baths,0 halfbaths,0 rooms,0 livunits,
act,
gross_ar,heat_ar,0
from r_prod.dbo.bld d
join
r_prod.dbo.lu_impr e
on e.tp = d.impr_tp
join 
r_prod.dbo.lu_impr_mdl f
on f.cd = d.impr_mdl_cd
join
r_prod.dbo.lu_impr_class g
on g.class = d.class
join
(
select ROW_NUMBER() OVER (PARTITION BY d.strap,d.bld_num ORDER BY d.strap,d.bld_num,d.ln_num) new_row, d.strap,d.bld_num,
RTRIM(ISNULL(CAST(str_num AS VARCHAR(10))+ ' ','') + ISNULL(NULLIF(str_pfx,'') + ' ','') + ISNULL(str + ' ','') + ISNULL(str_sfx + ' ','') + ISNULL(str_sfx_dir + ' ','') + ISNULL(str_unit + ' ','')) + ', ' + city + ', FL, ' + zip SITUS
from r_prod.dbo.site d
) t2
on
d.strap = t2.strap
and 
d.num = t2.bld_num
where t2.new_row = 1
and d.strap in (select strap from web.dbo.PARCELS)

GO

INSERT INTO WEB.DBO.EXTRA_FEATURES
select web.dbo.trim(c.STRAP),
c.bld_num,
c.ln_num,
d.cd + ' - ' + l_dscr,
uts,
unit_prc,
yr_blt,
d.cd,
d.unit_tp
 from r_prod.dbo.xfob c join
r_prod.dbo.lu_xfob d
on c.cd = d.cd
and strap in (select strap from web.dbo.PARCELS)

GO

--Most of these are being loaded into the building table so remove them from here.
INSERT INTO WEB.DBO.STRUCTURAL_ELEMENTS
--Get Strucural Elements
select DISTINCT web.dbo.trim(strap),
c.bld_num,
c.ln_num,
'CODED',
e.dscr,
CAST(d.cd AS VARCHAR(4)) + ' - ' + d.dscr VALUE from r_prod.dbo.bld_cd_se c
join
r_prod.dbo.lu_strct_el d
on c.cd = d.cd
and
c.tp = d.tp
join r_prod.dbo.lu_strct_el_tp e
on
c.tp = e.tp
where strap in (select strap from web.dbo.PARCELS) and  d.tp IN('BATH','BED','EWAL','FPL','FRME','HBAT','HGHT','HTAC','LVUT','ROFM','ROFS','ROOM','STHT')

GO

INSERT INTO WEB.DBO.STRUCTURAL_ELEMENTS
--Get Unit based Strucural Elements
select web.dbo.trim(c.strap),c.bld_num,c.ln_num,d.tp,d.dscr,CAST(uts AS int) from r_prod.dbo.bld_ut_se c
join r_prod.dbo.lu_strct_el_tp d
on
c.tp = d.tp
where icat is not null and d.tp IN('BATH','BED','EWAL','FPL','FRME','HBAT','HGHT','HTAC','LVUT','ROFM','ROFS','ROOM','STHT')
and strap in (select strap from web.dbo.PARCELS) 

GO


INSERT INTO WEB.DBO.EXEMPTIONS 
select web.dbo.trim(strap),num,e.cd,grant_dt, e.cd + ' - ' + e.dscr, val from r_prod.dbo.personal_x d
join r_prod.dbo.lu_personal_x e
on 
d.cd = e.cd
and strap in (select strap from web.dbo.PARCELS) 
order by num

GO


INSERT INTO WEB.DBO.TRANSFERS
select 
web.dbo.trim(strap),
dos,
price,
doc_num,
rea_cd,
grantor,
trns_cd
 from r_prod.dbo.sales d
 where d.strap in (select strap from web.dbo.PARCELS)
 GO
  

INSERT INTO WEB.DBO.SUB_AREAS
select web.dbo.trim(STRAP),bld_num,ln_num,e.sar_cd, e.sar_cd + ' - ' + e.dscr,gross_ar,ms_val from 
r_prod.dbo.bld_sar d
join
r_prod.dbo.lu_sar e
on
d.sar_cd = e.sar_cd
and strap in (select strap from web.dbo.PARCELS)
GO

TRUNCATE TABLE PARCEL_VALUES
INSERT INTO WEB.DBO.PARCEL_VALUES
--select web.dbo.trim(STRAP),2012,tot_lnd_val,tot_bld_val,tot_xf_val,jst_val,soh_val,ex_val,tax_val select * from r_prod.dbo.parcel   where strap in (select strap from web.dbo.PARCELS)
--UNION
select replace(b.Parcelid,'-','') strap,
c.fiscalyear [year],
ISNULL(c.TaxableLand,0) tot_lnd_val,
ISNULL(c.TaxableBuilding,0) tot_bld_val,
ISNULL(c.TaxableSFYI,0) tot_xf_val,
ISNULL(c.TotalValue,0) jst_val,
ISNULL(c.TaxableTotal,0) soh_val,
ISNULL(c.ValueExemption,0) ex_val,
ISNULL(c.TaxableTotal,0) - isnull(c.ValueExemption,0) tax_val
from 
[10.140.47.14].AssessPro.dbo.DataProperty b
join
[10.140.47.14].AssessPro.dbo.DataPreassesGeneral c
on
b.accountNumber = c.AccountNumber
and 
b.cardnumber = c.cardnumber
where c.category = 'FV'
GO



INSERT INTO WEB.DBO.AD_VALOREMS
select web.dbo.trim(strap),cd,dscr,curr from r_prod.dbo.parcel_tax b
join r_prod.dbo.lu_tax_dist c
on b.tax_dist = c.cd
and strap in (select strap from web.dbo.PARCELS)
GO


INSERT INTO WEB.DBO.NON_AD_VALOREMS
select web.dbo.trim(STRAP),b.tax_dist,dscr from r_prod.dbo.p_spcl_dist b
join r_prod.dbo.lu_tax_spcl_dist c
on b.tax_dist = c.tax_dist
and b.strap in (select strap from web.dbo.PARCELS)

GO
--INSERT INTO WEB.DBO.KEYWORD_SEARCH 
--select d.strap,x.value from WEB.DBO.OWNERS d
--CROSS APPLY
--(select * from WEB.DBO.Splitter(d.NAME,'''~`!@#$%^&*()_+=-{}|\][:";<>?/., ')) x
--where LEN(x.value) > 2


--MERGE INTO WEB.DBO.KEYWORD_SEARCH Target
--USING  (select d.strap,x.value from WEB.DBO.PARCELS d
--CROSS APPLY
--(select * from WEB.DBO.Splitter(d.SITUS,'''~`!@#$%^&*()_+=-{}|\][:";<>?/., ')) x
--where LEN(x.value) > 2) as Source
--on Target.Strap = Source.Strap
--and
--Target.KEYWORD = Source.VALUE
--when Not Matched then 
--insert (STRAP,KEYWORD) values (SOURCE.STRAP,SOURCE.VALUE);

--DELETE FROM WEB.DBO.KEYWORD_SEARCH
--WHERE STRAP NOT IN (SELECT STRAP FROM WEB.DBO.PARCELS);

--DROP DATABASE WEB

update target
set target.HALF_BATHS = source.HALF_BATH
from (select SUM(CASE WHEN CATEGORY = 'HBAT' THEN CAST(VALUE AS DECIMAL(5,2)) ELSE 0 END) HALF_BATH ,strap,building_num from web.dbo.structural_elements where CATEGORY IN ('HBAT') group by strap,building_num) source
join
(select * from web.dbo.buildings) target
on 
source.strap = target.strap
and
source.building_num = target.num

GO

update target
set target.BATHS = source.BATH
from (select SUM(CASE WHEN CATEGORY = 'BATH' THEN CAST(VALUE AS DECIMAL(5,2)) ELSE 0 END) BATH  ,strap,building_num from web.dbo.structural_elements where CATEGORY IN ('BATH') group by strap,building_num) source
join
(select * from web.dbo.buildings) target
on 
source.strap = target.strap
and
source.building_num = target.num

GO

update target
set target.LIVING_UNITS = source.LVUT
from (select SUM(CAST(VALUE AS decimal(6,2))) LVUT,strap,building_num from web.dbo.structural_elements where category = 'LVUT' group by strap,building_num) source
join
(select * from web.dbo.buildings) target
on 
source.strap = target.strap
and
source.building_num = target.num

GO


update target
set target.ROOMS = source.ROOM
from (select SUM(CAST(VALUE AS decimal(6,2))) ROOM,strap,building_num from web.dbo.structural_elements where category = 'ROOM' group by strap,building_num) source
join
(select * from web.dbo.buildings) target
on 
source.strap = target.strap
and
source.building_num = target.num

GO

update target
set target.BEDS = source.BED
from (select SUM(CAST(VALUE AS decimal(4,2))) BED,strap,building_num from web.dbo.structural_elements where category = 'BED' group by strap,building_num) source
join
(select * from web.dbo.buildings) target
on 
source.strap = target.strap
and
source.building_num = target.num

GO


update target
set target.STORY_NUM = source.STORY
from (select SUM(CAST(VALUE AS int)) STORY ,strap,building_num from web.dbo.structural_elements where category = 'STHT' group by STRAP,BUILDING_NUM ) source
join
(select * from web.dbo.buildings) target
on 
source.strap = target.strap
and
source.building_num = target.num

GO

update target
set target.STATUS = source.DSCR
from (select b.STRAP,c.DSCR from r_prod..parcel b join r_prod..lu_parcel_status c on b.status_cd = c.status_cd  ) source
join
(select * from web.dbo.PARCELS) target
on 
source.strap = target.strap

GO


select distinct status from web..PARCELS




--INSERT INTO TANGIBLE 
--select web.dbo.trim(b.acct) acct,f.SITUS,b.strap,c.name,e.cd + ' - ' + e.dscr,g.taxno,d.MAILING_ADDRESS,b.rec_dt,CASE WHEN b.act_cd = 'X' THEN 1 else 0 end
--from t_prod.dbo.tangible b
--join t_prod.dbo.owner c
--on b.acct = c.acct
--and c.role_cd = 'OW'
--join
--(select web.dbo.trim(acct) acct, ISNULL(addr_1 +CHAR(10) + CHAR(13),'')  + ISNULL(addr_2 +CHAR(10) + CHAR(13),'')  + city + ', ' + state + ', ' + zip MAILING_ADDRESS
--from t_prod.dbo.mail) d
--on
--b.acct = d.acct
--join 
--t_prod.dbo.lu_naics e
--on e.cd = b.sic
--join
--(select acct,
--RTRIM(ISNULL(CAST(str_num AS VARCHAR(10))+ ' ','') + ISNULL(NULLIF(str_pfx,'') + ' ','') + ISNULL(str + ' ','') + ISNULL(str_sfx + ' ','') + ISNULL(str_sfx_dir + ' ','') + ISNULL(str_unit + ' ','')) + ', ' + city + ', FL, ' + zip SITUS, zip ZIP_CODE
--from t_prod.dbo.site d
--where d.ln_num = 1) f
--on b.acct = f.acct
--join
--(select acct,val taxno from t_prod.dbo.flag where flg_tp = 'TC') g
--on b.acct = g.acct
--where act_cd <> 'C' AND conf_flg <> 'Y'
update target
set target.LAST_UPDATED = source.tod
from 
web.dbo.parcels target
join
(select distinct strap,max(tod) tod from r_prod..edit group by strap) source
on
target.strap = source.strap

UPDATE PARCELS 
SET SITUS = 'UNKNOWN'
WHERE SITUS IS NULL

EXEC sp_msforeachtable "select count(*),'?' FROM ?"

exec sp_msforeachtable @command1="print '?'", @command2="ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"


EXEC sp_MSForEachTable 'Print "Rebuild index on: ?"; ALTER INDEX ALL ON ? REBUILD WITH (FILLFACTOR = 80);'

 

