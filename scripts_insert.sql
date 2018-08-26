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
	([MerchantId],[Brand],[Acquirer], [AcquirerMerchanId], [AcquirerMerchantKey])
VALUES
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'ABC Store'), 1, 1, 'eb1da972-c90c-4b1b-8cbd-aad8ccf1c488', '2D99E65D822CCC234821FA8BFC3DA8D0FC2B70C5'),
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'ABC Store'), 2, 2, 'c50eccfe-e2fe-47d8-8d26-e76fbb75b552', null),
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'Store XPTO'), 1, 2, '826b7ef4-2d94-42be-94a2-5598026e6a95', null),
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'Store XPTO'), 2, 1, '974ad3d5-fb84-4902-aac7-d2c52f93a138', '7D7BDBE5C8C25F000965638264B7444B9488DDC0');

INSERT INTO [AntifraudProvider]
	([Name])
VALUES
	('ClearSale');

INSERT INTO [MerchantAntifraudConfiguration]
	([MerchantId], [Provider], [IsEnabled], [ClientId], [ClientSecret])
VALUES
	((SELECT [Id] FROM [Merchant] WHERE [BillingName] = 'ABC Store'), 1, 1, '0e5639c2742263323d4274b35b5bf305b8816df4', 'aa92511f5c8c7d907ea9af66b07c81f3863058ef');

INSERT INTO [TransactionStatus]
	([Name])
VALUES
	('Undefined'),
    ('Accepted'),
    ('Rejected'),
    ('Captured'),
    ('Canceled'),
    ('Reversed'),
    ('Aborted');

INSERT INTO [PaymentType]
	([Name])
VALUES
	('CreditCard');