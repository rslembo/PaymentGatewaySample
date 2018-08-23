CREATE TABLE [Merchant] (
	[Id] [UNIQUEIDENTIFIER] DEFAULT NEWID() PRIMARY KEY,
	[Key] [varchar](40) NOT NULL,
	[BillingName] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [Brand] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL
);

CREATE TABLE [Acquirer] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL
);

CREATE TABLE [MerchantPaymentConfiguration] (
	[Id] [UNIQUEIDENTIFIER] DEFAULT NEWID() PRIMARY KEY,
	[MerchantId] [UNIQUEIDENTIFIER] FOREIGN KEY REFERENCES [Merchant](Id),
	[Brand] [int] FOREIGN KEY REFERENCES [Brand](Id),
	[Acquirer] [int] FOREIGN KEY REFERENCES [Acquirer](Id),
	[CreatedDate] [datetime] NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [AntifraudProvider] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL
);

CREATE TABLE [MerchantAntifraudConfiguration] (
	[Id] [UNIQUEIDENTIFIER] DEFAULT NEWID() PRIMARY KEY,
	[MerchantId] [UNIQUEIDENTIFIER] FOREIGN KEY REFERENCES [Merchant](Id),
	[AntifraudProvider] [int] FOREIGN KEY REFERENCES [AntifraudProvider](Id),
	[IsEnabled] [bit] NOT NULL DEFAULT 0,
	[ClientId] [varchar](255) NOT NULL,
	[ClientSecret] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT GETDATE()
);