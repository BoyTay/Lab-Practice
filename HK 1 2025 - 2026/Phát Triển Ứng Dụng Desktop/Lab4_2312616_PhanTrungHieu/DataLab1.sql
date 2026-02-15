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


