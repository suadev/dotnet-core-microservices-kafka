Asp dot Net Core microservices that communicate asynchronous through Kafka message broker.

## Prerequities

* DotNet Core SDK 3.1
* Docker
* pgAdmin or Azure Data Studio


## Running in Debug Mode

* Run 'docker-compose up'
* Wait all infra to up and running.
* Select 'All' debug option and start debuging. ( for vscode)
* Wait until all microservices are up and running.

## How Can I Test?

* Create a user in the identity service with the following request. 

    Endpoint: http://localhost:5001/api/sign-up 

```json
Body:

{
	"FirstName" : "Suat",
	"LastName" : "Köse",
	"Address" : "Üsküdar",
	"Email" : "suadev@gmail.com",
	"Password" : "12345"
}
```

* Check Identity and  ```Customer``` databases to make sure user and customer are created properly.



* Check KafDrop to see messages on the ```users``` topic.

