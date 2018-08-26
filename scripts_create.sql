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
	[MerchantId] [UNIQUEIDENTIFIER] NOT NULL FOREIGN KEY REFERENCES [Merchant](Id),
	[Brand] [int] NOT NULL FOREIGN KEY REFERENCES [Brand](Id),
	[Acquirer] [int] NOT NULL FOREIGN KEY REFERENCES [Acquirer](Id),
	[AcquirerMerchantId] [UNIQUEIDENTIFIER] NOT NULL,
	[AcquirerMerchantKey] [varchar](100),
	[CreatedDate] [datetime] NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [AntifraudProvider] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL
);

CREATE TABLE [MerchantAntifraudConfiguration] (
	[Id] [UNIQUEIDENTIFIER] DEFAULT NEWID() PRIMARY KEY,
	[MerchantId] [UNIQUEIDENTIFIER] NOT NULL FOREIGN KEY REFERENCES [Merchant](Id),
	[Provider] [int] NOT NULL FOREIGN KEY REFERENCES [AntifraudProvider](Id),
	[IsEnabled] [bit] NOT NULL DEFAULT 0,
	[ClientId] [varchar](255) NOT NULL,
	[ClientSecret] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [TransactionStatus] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL
);

CREATE TABLE [Transaction] (
	[Id] [UNIQUEIDENTIFIER] DEFAULT NEWID() PRIMARY KEY,
	[RequestId] [UNIQUEIDENTIFIER],
	[MerchantOrderId] [varchar](50),
	[Status] [int] NOT NULL FOREIGN KEY REFERENCES [TransactionStatus](Id),
	[ProofOfSale] [varchar](20),
	[AcquirerTransactionKey] [varchar](100),
	[AuthorizationCode] [varchar](20),
	[AcquirerTransactionId] [UNIQUEIDENTIFIER],
	[ReturnCode] [varchar](5),
	[ReturnMessage] [varchar](100),
	[MerchantId] [UNIQUEIDENTIFIER] NOT NULL FOREIGN KEY REFERENCES [Merchant](Id),
	[CreatedDate] [datetime] NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [PaymentType] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL
);

CREATE TABLE [Payment] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Amount] [bigint],
	[Currency] [varchar](20),
	[Installments] [tinyint],
	[SoftDescriptor] [varchar](20),
	[Type] [int] NOT NULL FOREIGN KEY REFERENCES [PaymentType](Id),
	[TransactionId] [UNIQUEIDENTIFIER] NOT NULL FOREIGN KEY REFERENCES [Transaction](Id)
);

CREATE TABLE [CreditCard] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Number] [varchar](19),
	[Holder] [varchar](50),
	[ExpirationMonth] [varchar](2),
	[ExpirationYear] [varchar](4),
	[SecurityCode] [varchar](3),
	[Brand] [int] NOT NULL FOREIGN KEY REFERENCES [Brand](Id),
	[PaymentId] [int] FOREIGN KEY REFERENCES [Payment](Id),
);

CREATE TABLE [FraudAnalysis] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[ProviderId] [int],
	[Status] [varchar](3),
	[Score] [int],
	[TransactionId] [UNIQUEIDENTIFIER] NOT NULL FOREIGN KEY REFERENCES [Transaction](Id)
);