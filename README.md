# Farmers-Market-System
REST API for a farmers' market system, enabling CRUD operations on products, with real-time inventory management and customer transactions via WPF interfaces 'Admin' and 'Sales'.  This also tested thoroughly via ADO.NET and REST API for CRUD operations.

REST API CRUD Operation 
1] AddProduct
![image](https://github.com/3bearhug/Assignment2/assets/123404001/2b31d7ca-0177-48a1-9357-98b7da715f6e)

Add Body
![image](https://github.com/3bearhug/Assignment2/assets/123404001/e06900e5-2d10-4e94-853e-946fd6e4a9e7)

Response - ok 
![image](https://github.com/3bearhug/Assignment2/assets/123404001/22b04baf-8e5f-485d-bdf8-5aacb003bc3c)

2] GetAllProducts
![image](https://github.com/3bearhug/Assignment2/assets/123404001/7991bace-ba30-440b-b3e1-814cff4257bd)

![image](https://github.com/3bearhug/Assignment2/assets/123404001/8224463c-b183-498b-81ec-1fa56bc3d247)

double check with MySQL
![image](https://github.com/3bearhug/Assignment2/assets/123404001/fbe79f0e-2cf1-45e8-81a2-6ab8c6a01b13)

![image](https://github.com/3bearhug/Assignment2/assets/123404001/242e0922-f2ed-43c7-8d73-c4ee2c73b018)

3] GetAllProductById
![image](https://github.com/3bearhug/Assignment2/assets/123404001/cd999a71-1078-4e62-8c2a-bb8a348d8783)

Response - ok
![image](https://github.com/3bearhug/Assignment2/assets/123404001/92fcaba9-a8d6-4ae2-b544-277f78dce65a)

4] UpdateProduct 
Get - ID # 111 first
![image](https://github.com/3bearhug/Assignment2/assets/123404001/35d3f2ec-9cc5-4f3c-8365-074b704429c5)
Test with Put Method 
![image](https://github.com/3bearhug/Assignment2/assets/123404001/b872f240-b6b4-4f17-9a3b-2434410d5020)
![image](https://github.com/3bearhug/Assignment2/assets/123404001/002dcc57-d258-43ae-8257-724e35c3a44f)
Retrieve it using GET
![image](https://github.com/3bearhug/Assignment2/assets/123404001/ea8d3b7a-88ae-4585-b1c7-f7caa48598c5)

5]GetProductbyname
![image](https://github.com/3bearhug/Assignment2/assets/123404001/55c14cab-3cec-4294-95ee-de71c70f0ab0)
Response - ok 
![image](https://github.com/3bearhug/Assignment2/assets/123404001/3ea54eee-1cf1-41c9-a7a9-ba4108dbc6d2)

6] DeleteProductbyId
Retrieve ID # 111 first 
![image](https://github.com/3bearhug/Assignment2/assets/123404001/69ea26a7-6344-4144-8887-4195ef1d477f)
Delete
![image](https://github.com/3bearhug/Assignment2/assets/123404001/d9b48e19-fc67-4588-856d-3fdaff5ee22d)
Double check using GET
![image](https://github.com/3bearhug/Assignment2/assets/123404001/37699b00-5808-441c-b015-bbb3552fc5a5)

7] Read product name.amount and update inventory 
![image](https://github.com/3bearhug/Assignment2/assets/123404001/0e0ab998-e426-4e80-b465-542abe079e2b)

WPF class testing 
1] ADD 
![image](https://github.com/3bearhug/Assignment2/assets/123404001/561dbaaf-ec14-4037-948b-99f83159e884)
server responded
![image](https://github.com/3bearhug/Assignment2/assets/123404001/44c1eb0b-cdd9-4699-ae33-a656d1adb01b)
Double check with Swagger
![image](https://github.com/3bearhug/Assignment2/assets/123404001/ef7ab80f-9f14-4688-8890-5f622d713819)
Double check with MySQL
![image](https://github.com/3bearhug/Assignment2/assets/123404001/2dfb4ec3-da94-48a4-8483-55dc6aa08fe3)

2] GET/Search by ID
![image](https://github.com/3bearhug/Assignment2/assets/123404001/1d090068-c337-430d-b6c0-74cde8b2f5cb)

3] GET all products & shown on dataGrid
![image](https://github.com/3bearhug/Assignment2/assets/123404001/246a7928-9516-43be-8b74-4b4440af431c)

4] UPDATE 
Search ID 777
![image](https://github.com/3bearhug/Assignment2/assets/123404001/502884ad-5499-41f7-916b-2508be7f77a9)
Product name changed to ORANGE777 from ORANGE
![image](https://github.com/3bearhug/Assignment2/assets/123404001/83e2e85d-6717-49a0-bac1-1f96ded1949a)
Calling GetAllProducts method 
![image](https://github.com/3bearhug/Assignment2/assets/123404001/aa1798a4-32f1-49c4-a4b6-4709e371d142)
![image](https://github.com/3bearhug/Assignment2/assets/123404001/09f580c7-8c86-4517-b7fe-decafa948ef6)

5] DELETE
Delete ID #777
![image](https://github.com/3bearhug/Assignment2/assets/123404001/bbcc00f9-0533-4f9d-bf3d-ac7bd6dfeafa)
Double check
![image](https://github.com/3bearhug/Assignment2/assets/123404001/60363d67-f6b0-4d4a-99c3-0dc484118a7c)

6] UPDATE after sales is done 
Inventory of Clementine, 2KGS left 
![image](https://github.com/3bearhug/Assignment2/assets/123404001/624c22d9-0d27-4aa1-8492-e7ab168f7af6)
Purchase - 1KG
![image](https://github.com/3bearhug/Assignment2/assets/123404001/1de438bc-d6cf-4ef9-8904-230e153c4a65)
Inventory - 1KG
![image](https://github.com/3bearhug/Assignment2/assets/123404001/f0be9cf7-236a-4c8d-a48f-b25e53003923)

Another test with Apple
![image](https://github.com/3bearhug/Assignment2/assets/123404001/16c5f45c-4217-42df-9f02-bb9848c5a5e3)

NUnit Test -> verifying data using an ADO connection 
1]AddProduct
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/904ae168-fb34-42f6-adfa-c54c61fa5342)

Double check with MySQL
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/10bb0d7d-41ec-45c3-bce4-ea8eeb7c59fa)

Test using REST API
“GetAllProducts” method successfully retrieved “NunitFruit”
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/f661eb97-10e9-43f4-a8d3-7c54a77220f2)

Test result 
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/67d2b9d4-513d-4cf8-be0a-69061d071b4a)

Double check with browser
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/7605169d-5cb2-4131-bb52-700c45220034)

NUnit Test -> verifying if data is updated using an ADO connection 
2]UpdateProduct
Currently productName is NunitFruit with PricePerKG is $10.00
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/ace11657-8423-44eb-88a5-45d75cc8489e)

Test passed
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/3f680742-1e44-4d56-a060-db2d44c5ed32)

Updated 
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/c0dd358a-333e-4264-8d1a-babdbcddb32e)

Test using REST API
Fetch product first that needs to be updated 
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/ee1570f2-ef35-41a0-9a45-eb75c258a75f)

Test passed
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/f99ebda1-f15a-4af9-b2e1-c1cdaf1eb6d1)

Updated on browser 
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/fcd4bd75-b87e-45f3-85c9-ea65088bbac9)

Updated on MySQL
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/db18a904-bdf1-4b6b-9b76-203e9c588269)

NUnit Test -> verifying if data is deleted using an ADO connection 
3]DeleteProduct
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/f0795468-9372-464f-9d81-c9810b076c2a)

ID# 2295484 does not exist in MySQL
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/5a33e203-95d2-46e9-a936-fc617bad4086)

Test using REST API
Delete productId # 2295486
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/49cdca60-3e49-44dd-8746-c8be1fe67459)

Test Passed 
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/71c6a0c8-6dba-40a0-aa1f-1986ae1428a9)

Unable to fetch id# 2295484 as it is deleted 
![image](https://github.com/3bearhug/Farmers-Market-System/assets/123404001/dff03a98-5786-4ea8-8c03-7f4e712831c2)
































