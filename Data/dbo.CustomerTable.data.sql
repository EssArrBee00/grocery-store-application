SET IDENTITY_INSERT [dbo].[CustomerTable] ON
INSERT INTO [dbo].[CustomerTable] ([Id], [CustomerName], [CustomerPassword], [CustomerPhnum]) VALUES (1, N'ali       ', N'123       ', 12345678)
INSERT INTO [dbo].[CustomerTable] ([Id], [CustomerName], [CustomerPassword], [CustomerPhnum]) VALUES (2, N'ayesha    ', N'456       ', 12345678)
SET IDENTITY_INSERT [dbo].[CustomerTable] OFF
