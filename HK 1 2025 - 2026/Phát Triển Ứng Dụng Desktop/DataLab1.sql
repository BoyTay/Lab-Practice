use [Restaurant Management]

select * from Food
select * from Bills
select * from BillDetails
select * from Category
select * from Food
select * from [Table]
select * from Role
select * from RoleAccount
select * from Account

UPDATE Account
SET Tell = '0912901180',
    DateCreated='2025-10-06'
WHERE AccountName='ttplinh'

Delete  from Account
Where AccountName='pthieu'

Delete  from RoleAccount
Where RoleID=2
delete from [Table]
delete from Bills



SET IDENTITY_INSERT [dbo].[Bills] ON
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (1, N'Hóa đơn thanh toán', 5, 150000, 0.05, 0, 1,'2025-10-03', N'tdquy')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (2, N'Hóa đơn thanh toán', 2, 200000, 0.15, 0.3, 1, '2025-10-05', N'pttnga')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (3, N'Hóa đơn thanh toán', 1, 300000, 0.05, 0.1, 0, '2025-10-04', N'ttplinh')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (4, N'Hóa đơn thanh toán', 4, 150000, 0.25 , 0.2, 1, '2025-10-06', N'pttnga')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (5, N'Hóa đơn thanh toán', 3, 250000, 0.25 , 0.15, 0, '2025-10-06', N'pttnga')
SET IDENTITY_INSERT [dbo].[Bills] OFF
DELETE FROM Account

DELETE FROM BillDetails


SET IDENTITY_INSERT [dbo].[BillDetails] ON 
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (1, 1, 3, 2)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (2, 2, 1, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (3, 3, 2, 2)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (4, 4, 4, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (5, 5, 6, 1)
SET IDENTITY_INSERT [dbo].[BillDetails] OFF


INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (1, N'01', 0, 4)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (2, N'02', 0, 4)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (3, N'03', 0, 4)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (4, N'04', 0, 6)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (5, N'05', 0, 8)

CREATE PROCEDURE [InsertFood]
 @ID int output,
 @Name nvarchar(1000),
 @Unit nvarchar(100),
 @FoodCategoryID int,
 @Price int,
 @Notes nvarchar(3000)
AS
INSERT INTO [FOOD]
([Name],[Unit],[FoodCategoryID],[Price],[Notes])
VALUES (@Name,@Unit,@FoodCategoryID,@Price,@Notes)

SELECT @ID= SCOPE_IDENTITY();
GO

CREATE PROCEDURE [UpdateFood]
 @ID int,
 @Name nvarchar(1000),
 @Unit nvarchar(100),
 @FoodCategoryID int,
 @Price int,
 @Notes nvarchar(3000)
AS
UPDATE [FOOD]
SET 
    [Name] = @Name,
    [Unit] = @Unit,
    [FoodCategoryID] = @FoodCategoryID,
    [Price] = @Price,
    [Notes] = @Notes

WHERE ID=@ID

IF @@ERROR <>0
RETURN 0
ELSE
RETURN 1

GO

CREATE PROCEDURE [InsertCategory]
 @ID int output,
 @Name nvarchar(1000),
 @Type int
AS 
INSERT INTO [Category]([Name],[Type])
VALUES (@Name,@Type)

SELECT @ID= SCOPE_IDENTITY();
GO

-- Thủ tục lấy tất cả dữ liệu bảng Category
CREATE PROCEDURE [dbo].[Category_GetAll]
AS
    SELECT * FROM Category

--------------------------------------------

CREATE PROCEDURE [dbo].[Food_GetAll]
AS
BEGIN
    SELECT * FROM Food
END
GO
--Thủ tục lấy tất cả dữ liệu bảng Food
ALTER PROCEDURE [dbo].[Food_GetAll]
AS
    SELECT * FROM Food

-------------------------------------------

--Thủ tục thêm, xóa, sửa bảng Category
CREATE PROCEDURE [dbo].[Category_InsertUpdateDelete]
    @ID int output, -- Biến ID tự tăng, khi thêm xong phải lấy ra
    @Name nvarchar(200),
    @Type int,
    @Action int -- Biến cho biết thêm, xóa, hay sửa
AS
-- Nếu Action = 0, thực hiện thêm dữ liệu
IF @Action = 0
    BEGIN
        INSERT INTO [Category] ([Name],[Type])
        VALUES (@Name,@Type)
        SET @ID = @@IDENTITY -- Thiết lập ID tự tăng
    END
-- Nếu Action = 1, thực hiện cập nhật dữ liệu
ELSE IF @Action = 1
    BEGIN   
        UPDATE [Category] SET [Name] = @Name, [Type]= @Type
        WHERE [ID]=@ID
    END
-- Nếu Action = 2, thực hiện xóa dữ liệu
ELSE IF @Action = 2
    BEGIN
        DELETE FROM [Category] WHERE [ID]= @ID
    END

-------------------------------------------------

-- Thủ tục thêm, xóa, sửa bảng Food
CREATE PROCEDURE [dbo].[Food_InsertUpdateDelete]
    @ID int output, -- Biến ID tự tăng, khi thêm xong phải lấy ra
    @Name nvarchar(1000),
    @Unit nvarchar(100),
    @FoodCategoryID int,
    @Price int,
    @Notes nvarchar(3000),
    @Action int --Biến cho biết thêm, xóa, sửa
AS
IF @Action = 0 -- Nếu Action = 0 , thêm dữ liệu
    BEGIN
        INSERT INTO [Food]
        ([Name],[Unit],[FoodCategoryID],[Price],[Notes])
        VALUES (@Name,@Unit,@FoodCategoryID,@Price,@Notes)
        SET @ID = @@IDENTITY -- Thiết lập ID tự tăng
    END
ELSE IF @Action = 1 -- Nếu Action = 1 ,Cập nhật dữ liệu
    BEGIN
        UPDATE [Food]
        SET [Name]=@Name,[Unit]=@Unit,[FoodCategoryID]=@FoodCategoryID,[Price]=@Price,[Notes]= @Notes
        WHERE [ID]=@ID
    END
ELSE IF @Action = 2 -- Nếu Action = 2, xóa dữ liệu
    BEGIN
        DELETE FROM [Food] WHERE [ID] =@ID
    END

-- Thủ tục lấy hết dữ liệu bảng role
CREATE PROCEDURE [dbo].[Role_GetAll]
AS
    SELECT * FROM Role;
GO
-- Thủ tục thêm sửa xóa bảng role
CREATE PROCEDURE [dbo].[Role_InsertUpdateDelete]
    @ID INT OUTPUT,
    @RoleName NVARCHAR(1000),
    @Path NVARCHAR(3000) = NULL,
    @Notes NVARCHAR(3000) = NULL,
    @Action INT
AS
IF (@Action = 0)
BEGIN
    INSERT INTO [Role](RoleName, [Path], Notes)
    VALUES (@RoleName, @Path, @Notes);
    SET @ID = @@IDENTITY;
END
ELSE IF (@Action = 1)
BEGIN
    UPDATE [Role]
    SET RoleName = @RoleName, [Path] = @Path, Notes = @Notes
    WHERE ID = @ID;
END
ELSE IF (@Action = 2)
BEGIN
    DELETE FROM [Role] WHERE ID = @ID;
END
GO

--Thủ tục lấy hết dữ liệu bảng Account
CREATE PROCEDURE [dbo].[Account_GetAll]
AS
    SELECT * FROM Account
    ORDER BY DateCreated ASC;
GO

--Thủ tục thêm sửa xóa bảng Account
CREATE PROCEDURE [dbo].[Account_InsertUpdateDelete]
    @AccountName NVARCHAR(100),
    @Password NVARCHAR(200),
    @FullName NVARCHAR(1000) = NULL,
    @Email NVARCHAR(1000) = NULL,
    @Tell NVARCHAR(200) = NULL,
    @DateCreated SMALLDATETIME = NULL,
    @Action INT
AS
IF (@Action = 0)
BEGIN
    INSERT INTO [Account](AccountName, [Password], FullName, Email, Tell, DateCreated)
    VALUES (@AccountName, @Password, @FullName, @Email, @Tell, ISNULL(@DateCreated, GETDATE()));
END
ELSE IF (@Action = 1)
BEGIN
    UPDATE [Account]
    SET [Password]=@Password, FullName=@FullName, Email=@Email, Tell=@Tell, DateCreated=@DateCreated
    WHERE AccountName=@AccountName;
END
ELSE IF (@Action = 2)
BEGIN
    DELETE FROM [Account] WHERE AccountName=@AccountName;
END
GO

--Thủ tục lấy dữ liệu bảng RoleAccount
CREATE PROCEDURE [dbo].[RoleAccount_GetAll]
AS
    SELECT * FROM RoleAccount;
GO

--Thủ tục thêm sửa xóa bảng RoleAccount
CREATE PROCEDURE [dbo].[RoleAccount_InsertUpdateDelete]
    @RoleID INT,
    @AccountName PRIMARY KEY NVARCHAR(100),
    @Actived BIT,
    @Notes NVARCHAR(3000)=NULL,
    @Action INT
AS
IF (@Action = 0)
BEGIN
    INSERT INTO RoleAccount(RoleID, AccountName, Actived, Notes)
    VALUES (@RoleID, @AccountName, @Actived, @Notes);
END
ELSE IF (@Action = 1)
BEGIN
    UPDATE RoleAccount
    SET Actived=@Actived, Notes=@Notes
    WHERE RoleID=@RoleID AND AccountName=@AccountName;
END
ELSE IF (@Action = 2)
BEGIN
    DELETE FROM RoleAccount WHERE RoleID=@RoleID AND AccountName=@AccountName;
END
GO
--Thủ tục lấy dữ liệu bảng Table
CREATE PROCEDURE [dbo].[Table_GetAll]
AS
    SELECT * FROM [Table];
GO

--Thủ tục thêm sửa xóa bảng Table
CREATE OR ALTER PROCEDURE [dbo].[Table_InsertUpdateDelete]
    @ID INT OUTPUT,
    @Name NVARCHAR(1000),
    @Status INT = NULL,
    @Capacity INT = NULL,
    @Action INT
AS
IF (@Action = 0)
BEGIN
    INSERT INTO [Table]([Name], [Status], Capacity)
    VALUES (@Name, @Status, @Capacity);
    SET @ID = @@IDENTITY;
END
ELSE IF (@Action = 1)
BEGIN
    UPDATE [Table] SET [Name]=@Name, [Status]=@Status, Capacity=@Capacity WHERE ID=@ID;
END
ELSE IF (@Action = 2)
BEGIN
    DELETE FROM [Table] WHERE ID=@ID;
END
GO

--Thủ tục lấy dữ liệu bảng Bills
CREATE PROCEDURE [dbo].[Bill_GetAll]
AS
    SELECT *
    FROM Bills;
GO
--Thủ tục thêm sửa xóa bảng bills
CREATE PROCEDURE [dbo].[Bill_InsertUpdateDelete]
    @ID INT OUTPUT,
    @Name NVARCHAR(1000)=NULL,
    @TableID INT,
    @Amount INT,
    @Discount FLOAT = NULL,
    @Tax FLOAT = NULL,
    @Status BIT = NULL,
    @CheckoutDate SMALLDATETIME = NULL,
    @Account NVARCHAR(100) = NULL,
    @Action INT
AS
IF (@Action = 0)
BEGIN
    INSERT INTO [Bills]([Name], TableID, Amount, Discount, Tax, [Status], CheckoutDate, [Account])
    VALUES (@Name, @TableID, @Amount, @Discount, @Tax, @Status, @CheckoutDate, @Account);
    SET @ID = @@IDENTITY;
END
ELSE IF (@Action = 1)
BEGIN
    UPDATE [Bills]
    SET [Name]=@Name, TableID=@TableID, Amount=@Amount, Discount=@Discount, Tax=@Tax,
        [Status]=@Status, CheckoutDate=@CheckoutDate, [Account]=@Account
    WHERE ID=@ID;
END
ELSE IF (@Action = 2)
BEGIN
    DELETE FROM [Bills] WHERE ID=@ID;
END
GO
--Thủ tục lấy hết dữ liệu bảng BillDetails
CREATE PROCEDURE [dbo].[BillDetail_GetAll]
AS
    SELECT * FROM BillDetails;
GO

--Thủ tục thêm sửa xóa bảng BillDetails
CREATE PROCEDURE [dbo].[BillDetail_InsertUpdateDelete]
    @ID INT OUTPUT,
    @InvoiceID INT,
    @FoodID INT,
    @Quantity INT,
    @Action INT
AS
IF (@Action = 0)
BEGIN
    INSERT INTO [BillDetails](InvoiceID, FoodID, Quantity)
    VALUES (@InvoiceID, @FoodID, @Quantity);
    SET @ID = @@IDENTITY;
END
ELSE IF (@Action = 1)
BEGIN
    UPDATE [BillDetails] SET InvoiceID=@InvoiceID, FoodID=@FoodID, Quantity=@Quantity WHERE ID=@ID;
END
ELSE IF (@Action = 2)
BEGIN
    DELETE FROM [BillDetails] WHERE ID=@ID;
END
GO

-- Seed các vai trò 
IF NOT EXISTS (SELECT 1 FROM [Role] WHERE RoleName = N'Administrator')
    INSERT INTO [Role](RoleName, [Path], Notes) VALUES (N'Administrator', NULL, NULL);
IF NOT EXISTS (SELECT 1 FROM [Role] WHERE RoleName = N'Quản lý')
    INSERT INTO [Role](RoleName, [Path], Notes) VALUES (N'Quản lý', NULL, NULL);
IF NOT EXISTS (SELECT 1 FROM [Role] WHERE RoleName = N'Kế toán')
    INSERT INTO [Role](RoleName, [Path], Notes) VALUES (N'Kế toán', NULL, NULL);
IF NOT EXISTS (SELECT 1 FROM [Role] WHERE RoleName = N'Nhân viên')
    INSERT INTO [Role](RoleName, [Path], Notes) VALUES (N'Nhân viên', NULL, NULL);
GO

-- Lấy danh sách vai trò đang kích hoạt theo tài khoản
CREATE PROCEDURE [dbo].[Role_GetByAccountName]
    @AccountName NVARCHAR(100)
AS
    SELECT r.ID, r.RoleName, r.[Path], r.Notes
    FROM [Role] r
    INNER JOIN RoleAccount ra ON ra.RoleID = r.ID
    WHERE ra.AccountName = @AccountName AND ra.Actived = 1;
GO

CREATE PROCEDURE Account_Validate
    @AccountName NVARCHAR(100),
    @Password NVARCHAR(200)
AS
    SELECT AccountName
    FROM [Account]
    WHERE AccountName=@AccountName AND [Password]=@Password;