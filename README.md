# Contacts
Contacts
 
*Kiþinin iletiþim bilgilerini verir.
HTTP_GET 
https://localhost:7138/api/Contact/getPersonContacts/6'

Response  =>  HTTP200 
[
  {
    "id": 3,
    "contactType": 0,
    "contactTypeText": "Telefon Numarasý",
    "content": "0506330****"
  },
  {
    "id": 4,
    "contactType": 1,
    "contactTypeText": "E-Posta",
    "content": "orkun.koz****.com"
  },
  {
    "id": 5,
    "contactType": 2,
    "contactTypeText": "Konum",
    "content": "Mersin"
  }
]

************************************************************

*Contact Ekleme 
HTTP_POST
https://localhost:7138/api/Contact/Add
Request Body => 
{
  "name": "string",
  "surName": "string",
  "company": "string"
}

Response => HTTP200 long (new record ID)

************************************************************

*Contact Silme 
HTTP_DELETE
https://localhost:7138/api/Contact/Delete/1

Response => HTTP204 

************************************************************


*Kiþileri listeleme 
HTTP_GET
https://localhost:7138/api/Person/getAll

Response=>  HTTP200 
[
  {
    "id": 6,
    "name": "string",
    "surName": "string",
    "company": "Ankara"
  },
    {
    "id": 7,
    "name": "fgdfg",
    "surName": "ertert",
    "company": ""
  }
]


*Kiþi Ekleme
HTTP_POST
https://localhost:7138/api/Person/Add
Request Body => 
{
  "name": "string",
  "surName": "string",
  "company": "string"
}

Response => HTTP200 long (new record ID)

************************************************************

*Kiþi Silme 
HTTP_DELETE 
https://localhost:7138/api/Person/Delete/1 
Response => HTTP204