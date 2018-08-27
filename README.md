# PaymentGatewaySample

A payment Gateway sample.<br/> 
Built using netcore 2.0 and Azure SQL Server database.

## Running the Application
Clone or download this repository, and execute the following commands on the API folder.<br/>
PaymentGatewaySample > PaymentGatewaySample:
>dotnet build<br/> 
dotnet run

The application will start listening on `http://localhost:51425`
To start testing the application, you should follow the steps below.

## Available Merchants

### ABC Store
##### Credentials
> ID: 408E5197-D468-45A9-B0B2-B0B513481D3A<br/> 
Key: 68257879AA3D8F70F2391AB9F0A5C94FF7AE7544<br/> 
Antifraud Enabled: true
##### Payment Configurations
| Card Brand | Acquirer |
|--|--|
| Visa| Stone|
| Master| Cielo|



### Store XPTO
> ID: 881443DF-B87D-496F-A79A-A7D43A580BEE<br/> 
Key: 1110448DBFC8F697B6FFB534A265178174888666<br/> 
Antifraud Enabled: false

##### Payment Configurations
| Card Brand | Acquirer |
|--|--|
| Visa| Cielo|
| Master| Stone|


## Send a Sale Transaction

#### URL
>POST http://localhost:51425/api/sale/

#### Header
> MerchantId<br/> 
MerchantKey

#### Body
##### Minimum Request

    {  
       "MerchantOrderId":"2014111701",
       "Payment":{  
          "Type":"CreditCard",
          "Amount":15700,
          "Currency":"BRL",
          "Installments":1,
          "SoftDescriptor":"tst",
          "CreditCard":{  
             "Number":"1234123412341231",
             "Holder":"HolderName",
             "ExpirationYear":"2021",
             "ExpirationMonth":"12",
             "SecurityCode":"123",
             "Brand":"Master"
          }
       }
    }

##### Full request
    {  
       "RequestId":"be205a21-14b2-43c0-925c-44e0ad79f6be",
       "MerchantOrderId":"2014111701",
       "Customer":{  
          "Name":"Comprador Teste",
          "Identity":"11225468954",
          "IdentityType":"CPF",
          "Email":"compradorteste@teste.com",
          "IpAddress":"127.0.0.1",
          "PhoneAreaCode":"55",
          "PhoneNumber":"999999999",
          "Birthdate":"1991-01-02",
          "BillingAddress":{  
             "Street":"Rua Teste",
             "Number":"123",
             "Complement":"AP 123",
             "ZipCode":"12345987",
             "City":"Rio de Janeiro",
             "State":"RJ",
             "Country":"BRA"
          },
          "ShippingAddress":{  
             "Street":"Rua Teste",
             "Number":"123",
             "Complement":"AP 123",
             "ZipCode":"12345987",
             "City":"Rio de Janeiro",
             "State":"RJ",
             "Country":"BRA"
          }
       },
       "Payment":{  
          "Type":"CreditCard",
          "Amount":15700,
          "Currency":"BRL",
          "Installments":1,
          "SoftDescriptor":"tst",
          "CreditCard":{  
             "Number":"1234123412341231",
             "Holder":"HolderName",
             "ExpirationYear":"2021",
             "ExpirationMonth":"12",
             "SecurityCode":"123",
             "Brand":"Master"
          }
       }
    }
#### Response
> Status: 401 - Unauthorized

or

> Status: 400 - Bad Request

    {
        "MerchantOrderId": [
            "The MerchantOrderId field is required."
        ]
    }

or

>Status: 201 - Created

    {
        "id": "636b6509-25c6-433c-253c-08d60c5dc3a1",
        "requestId": "be205a21-14b2-43c0-925c-44e0ad79f6be",
        "merchantOrderId": "2014111701",
        "status": "Captured",
        "customer": {
            "name": "Comprador Teste",
            "identity": "11225468954",
            "identityType": "CPF",
            "email": "compradorteste@teste.com",
            "ipAddress": "127.0.0.1",
            "phoneAreaCode": "55",
            "phoneNumber": "999999999",
            "birthDate": "1991-01-02T00:00:00",
            "shippingAddress": {
                "street": "Rua Teste",
                "number": "123",
                "complement": "AP 123",
                "zipCode": "12345987",
                "city": "Rio de Janeiro",
                "state": "RJ",
                "country": "BRA"
            },
            "billingAddress": {
                "street": "Rua Teste",
                "number": "123",
                "complement": "AP 123",
                "zipCode": "12345987",
                "city": "Rio de Janeiro",
                "state": "RJ",
                "country": "BRA"
            }
        },
        "payment": {
            "type": "CreditCard",
            "amount": 15700,
            "creditCard": {
                "number": "1234123412341231",
                "expirationMonth": "12",
                "expirationYear": "2021",
                "brand": "Master"
            }
        },
        "fraudAnalysis": {
            "providerId": "34a0a486-27c5-4cc0-ae51-ddb03b944cf0",
            "status": "APA",
            "score": 5
        },
        "createdDate": "2018-08-27T20:45:28.21",
        "proofOfSale": "123",
        "acquirerTransactionKey": "123456",
        "authorizationCode": "123456",
        "acquirerTransactionId": "4756d183-e483-43bf-a8f0-0c506beae8da",
        "returnCode": "4",
        "returnMessage": "Operação realizada com sucesso",
        "links": [
            {
                "method": "GET",
                "rel": "self",
                "href": "http://localhost:51425/api/sale/636b6509-25c6-433c-253c-08d60c5dc3a1"
            }
        ]
    }

## Retrieve a Sale Transaction

#### URL
>GET http://localhost:51425/api/sale/{id}

#### Header
> MerchantId<br/> 
MerchantKey

#### Response
> Status: 401 - Unauthorized

or

> Status: 404 - Not Found

or

>Status: 200 - OK

    {
        "id": "636b6509-25c6-433c-253c-08d60c5dc3a1",
        "requestId": "be205a21-14b2-43c0-925c-44e0ad79f6be",
        "merchantOrderId": "2014111701",
        "status": "Captured",
        "customer": {
            "name": "Comprador Teste",
            "identity": "11225468954",
            "identityType": "CPF",
            "email": "compradorteste@teste.com",
            "ipAddress": "127.0.0.1",
            "phoneAreaCode": "55",
            "phoneNumber": "999999999",
            "birthDate": "1991-01-02T00:00:00",
            "shippingAddress": {
                "street": "Rua Teste",
                "number": "123",
                "complement": "AP 123",
                "zipCode": "12345987",
                "city": "Rio de Janeiro",
                "state": "RJ",
                "country": "BRA"
            },
            "billingAddress": {
                "street": "Rua Teste",
                "number": "123",
                "complement": "AP 123",
                "zipCode": "12345987",
                "city": "Rio de Janeiro",
                "state": "RJ",
                "country": "BRA"
            }
        },
        "payment": {
            "type": "CreditCard",
            "amount": 15700,
            "creditCard": {
                "number": "1234123412341231",
                "expirationMonth": "12",
                "expirationYear": "2021",
                "brand": "Master"
            }
        },
        "fraudAnalysis": {
            "providerId": "34a0a486-27c5-4cc0-ae51-ddb03b944cf0",
            "status": "APA",
            "score": 5
        },
        "createdDate": "2018-08-27T20:45:28.21",
        "proofOfSale": "123",
        "acquirerTransactionKey": "123456",
        "authorizationCode": "123456",
        "acquirerTransactionId": "4756d183-e483-43bf-a8f0-0c506beae8da",
        "returnCode": "4",
        "returnMessage": "Operação realizada com sucesso",
        "links": [
            {
                "method": "GET",
                "rel": "self",
                "href": "http://localhost:51425/api/sale/636b6509-25c6-433c-253c-08d60c5dc3a1"
            }
        ]
    }
## Retrieve all Sale Transactions for Merchant

#### URL
>GET http://localhost:51425/api/sale/

#### Header
> MerchantId<br/> 
MerchantKey

#### Response
> Status: 401 - Unauthorized

or

> Status: 404 - Not Found

or

>Status: 200 - OK

    [
        {
            "id": "6ced8565-e8bf-4b60-389b-08d60b38f3ac",
            "requestId": "be205a21-14b2-43c0-925c-44e0ad79f6be",
            "merchantOrderId": "2014111701",
            "status": "Captured",
            "customer": {
                "name": "Comprador Teste",
                "identity": "11225468954",
                "identityType": "CPF",
                "email": "compradorteste@teste.com",
                "ipAddress": "127.0.0.1",
                "phoneAreaCode": "55",
                "phoneNumber": "999999999",
                "birthDate": "1991-01-02T00:00:00",
                "shippingAddress": {
                    "street": "Rua Teste",
                    "number": "123",
                    "complement": "AP 123",
                    "zipCode": "12345987",
                    "city": "Rio de Janeiro",
                    "state": "RJ",
                    "country": "BRA"
                },
                "billingAddress": {
                    "street": "Rua Teste",
                    "number": "123",
                    "complement": "AP 123",
                    "zipCode": "12345987",
                    "city": "Rio de Janeiro",
                    "state": "RJ",
                    "country": "BRA"
                }
            },
            "payment": {
                "amount": 15700,
                "type": "CreditCard",
                "creditCard": {
                    "number": "1234123412341231",
                    "expirationMonth": "12",
                    "expirationYear": "2021",
                    "brand": "Visa"
                }
            },
            "fraudAnalysis": {
                "providerId": "0ddaa35e-1f34-4932-8654-b90a1932167c",
                "status": 1,
                "score": 5
            },
            "createdDate": "2018-08-26T09:48:53.313",
            "proofOfSale": "4546",
            "acquirerTransactionKey": "4dfq3245r",
            "authorizationCode": "1234",
            "acquirerTransactionId": "24ddadef-5afd-47f9-83d8-eee685ac9e08",
            "returnCode": "10",
            "returnMessage": "Transação capturada com sucesso",
            "links": [
                {
                    "method": "GET",
                    "rel": "self",
                    "href": "http://localhost:51425/api/sale/6ced8565-e8bf-4b60-389b-08d60b38f3ac"
                }
            ]
        },
        {
            "id": "e548fc73-540e-49d6-389c-08d60b38f3ac",
            "requestId": "be205a21-14b2-43c0-925c-44e0ad79f6be",
            "merchantOrderId": "2014111701",
            "status": "Captured",
            "customer": {
                "name": "Comprador Teste",
                "identity": "11225468954",
                "identityType": "CPF",
                "email": "compradorteste@teste.com",
                "ipAddress": "127.0.0.1",
                "phoneAreaCode": "55",
                "phoneNumber": "999999999",
                "birthDate": "1991-01-02T00:00:00",
                "shippingAddress": {
                    "street": "Rua Teste",
                    "number": "123",
                    "complement": "AP 123",
                    "zipCode": "12345987",
                    "city": "Rio de Janeiro",
                    "state": "RJ",
                    "country": "BRA"
                },
                "billingAddress": {
                    "street": "Rua Teste",
                    "number": "123",
                    "complement": "AP 123",
                    "zipCode": "12345987",
                    "city": "Rio de Janeiro",
                    "state": "RJ",
                    "country": "BRA"
                }
            },
            "payment": {
                "amount": 15700,
                "type": "CreditCard",
                "creditCard": {
                    "number": "1234123412341231",
                    "expirationMonth": "12",
                    "expirationYear": "2021",
                    "brand": "Visa"
                }
            },
            "fraudAnalysis": {
                "providerId": "40427c2f-9637-4dcf-b556-79289db2ebaa",
                "status": 1,
                "score": 5
            },
            "createdDate": "2018-08-26T09:49:25.987",
            "proofOfSale": "4546",
            "acquirerTransactionKey": "4dfq3245r",
            "authorizationCode": "1234",
            "acquirerTransactionId": "79c6c337-97e3-446b-b394-ffea9cc92112",
            "returnCode": "10",
            "returnMessage": "Transação capturada com sucesso",
            "links": [
                {
                    "method": "GET",
                    "rel": "self",
                    "href": "http://localhost:51425/api/sale/e548fc73-540e-49d6-389c-08d60b38f3ac"
                }
            ]
        }
    ]
