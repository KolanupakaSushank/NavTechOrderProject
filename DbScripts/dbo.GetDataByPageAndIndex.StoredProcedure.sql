SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDataByPageAndIndex] 
	-- Add the parameters for the stored procedure here
	@Index AS INT, --Current Page Number
	@Paging AS INT --Number of rows in each page
AS
BEGIN
	--DECLARE @PageNumber AS INT, @RowspPage AS INT
	
	SELECT * FROM (
				 SELECT ROW_NUMBER() OVER(ORDER BY o.OrderDate) AS NUMBER,
						OrderId, o.OrderName, o.OrderDate,o.BillNumber, c.CustomerName 
						FROM dbo.Orders o
						inner join dbo.CustomerTable c on c.CustomerId = o.CustomerId
				   ) AS TBL
	WHERE NUMBER BETWEEN ((@Index - 1) * @Paging + 1) AND (@Index * @Paging)
	ORDER BY OrderDate
END
GO
