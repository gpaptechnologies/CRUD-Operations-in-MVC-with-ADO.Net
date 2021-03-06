USE [ADO_EXAMPLE]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteProduct]    Script Date: 12/19/2021 3:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteProduct]
(
@ProductID int
)
as
begin

	delete from dbo.tbl_ProductMaster where ProductID = @ProductID

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProducts]    Script Date: 12/19/2021 3:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetAllProducts]
as
begin

	select ProductID,ProductName,Price,qty,Remarks from dbo.tbl_ProductMaster with(nolock)

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductByID]    Script Date: 12/19/2021 3:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_GetProductByID]
(
	@ProductID int
)
as
begin

	select ProductID,ProductName,Price,qty,Remarks from dbo.tbl_ProductMaster with(nolock)
	where ProductID = @ProductID

end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertProducts]    Script Date: 12/19/2021 3:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--create procedure sp_GetAllProducts
--as
--begin

--	select ProductID,ProductName,Price,qty,Remarks from dbo.tbl_ProductMaster with(nolock)

--end

CREATE proc [dbo].[sp_InsertProducts]
(
@ProductName nvarchar(50),
@Price decimal(8,2),
@Qty int,
@Remarks nvarchar(50) = ''
)
as
begin

	insert into dbo.tbl_ProductMaster(ProductName,Price,Qty,Remarks)
	values(@ProductName,@Price,@Qty,@Remarks)

end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateProducts]    Script Date: 12/19/2021 3:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_UpdateProducts]
(
@ProductID int,
@ProductName nvarchar(50),
@Price decimal(8,2),
@Qty int,
@Remarks nvarchar(50) = ''
)
as
begin

	update dbo.tbl_ProductMaster
	set ProductName = @ProductName,
	Price = @Price,
	Qty = @Qty,
	Remarks = @Remarks
	where ProductID = @ProductID
end
GO
/****** Object:  Table [dbo].[tbl_ProductMaster]    Script Date: 12/19/2021 3:48:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ProductMaster](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
	[Qty] [int] NOT NULL,
	[Remarks] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_ProductMaster] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
