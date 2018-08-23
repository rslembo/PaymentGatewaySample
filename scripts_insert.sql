INSERT INTO [Merchant] 
	([Key], [BillingName])
VALUES
	('68257879AA3D8F70F2391AB9F0A5C94FF7AE7544', 'ABC Store'),
	('1110448DBFC8F697B6FFB534A265178174888666', 'Store XPTO');

INSERT INTO [Brand]
	([Name])
VALUES
	('Master'),
	('Visa');

INSERT INTO [Acquirer]
	([Name])
VALUES
	('Cielo'),
	('Stone');

INSERT INTO [MerchantPaymentConfiguration]
	([MerchantId],[Brand],[Acquirer])
VALUES
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'ABC Store'), 1, 1),
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'ABC Store'), 2, 2),
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'Store XPTO'), 1, 2),
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'Store XPTO'), 2, 1);

INSERT INTO [AntifraudProvider]
	([Name])
VALUES
	('ClearSale');

INSERT INTO [MerchantAntifraudConfiguration]
	([MerchantId], [AntifraudProvider], [IsEnabled], [ClientId], [ClientSecret])
VALUES
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'ABC Store'), 1, 1, '0e5639c2742263323d4274b35b5bf305b8816df4', 'aa92511f5c8c7d907ea9af66b07c81f3863058ef');