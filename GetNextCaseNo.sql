USE [RMATracker]
GO

/****** Object:  UserDefinedFunction [dbo].[GetNextCaseANo]    Script Date: 7/6/2018 4:26:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetNextCaseANo]
(
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar int

	  

;WITH BASE_TABLE
AS (
  SELECT 
         *, 
         RowNumber = ROW_NUMBER() OVER( ORDER BY case_no ASC )
      FROM RmaBase )
	  select @ResultVar = 
	  (case when isnull(min_case,0)>0 then min_case else 
	  (select max(case_no) from RmaBase) end ) +1

	  from (SELECT min(isnull(a.case_no,0)) min_case, max(isnull(a.case_no,0)) max_case  from BASE_TABLE a inner join BASE_TABLE b on a.RowNumber=b.RowNumber-1
   where isnull(b.case_no,0)-isnull(a.case_no,0)>1) query

	RETURN @ResultVar

END
GO

