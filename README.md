# NavTechOrderProject
I have only worked on Asp.net, and DbFirst Approach in EntityFramework. So I made a WebApi in .net instead of .netcore

Steps I have used are 
Made Orders Table, OrderDetailsTable, CustomerTable
Then made model and edmx diagram using ADO.Net

There are 3 operations that can be done

1. Make New Customer: this is done by calling post method in CustomerTable Controller and following the following json Object in body
{
    "CustomerName": "Sushank",
	"CustomerEmail": "Sushank.1003@gmail.com",
	"CustomerPhone": "9908090998"	
}
I have added Validations for Phone number and CustomerEmail

2. Make New Orders With OrderDetails list: This is used by calling the post method of orders Controller and passing the following json object in body
{
    "CustomerName": "Sushank",
	"OrderName": "Tutorialspoint",
	"OrderDate": "11/17/2022",
	"BillNumber": "1",
	"OrderItems": [{
		"ItemName": "Item1",
		"ItemPrice": "100"
	}] 
}

3. Get Order Details based on page index and page size. WE can get this by get request of Order Controller
url with parameter /api/Orders?Index=1&Paging=3
