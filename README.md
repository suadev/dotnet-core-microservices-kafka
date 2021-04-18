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

* Create a user in the identity service with the following json. 

    Endpoint: http://localhost:5001/api/sign-up 

```json
{
	"FirstName" : "Suat",
	"LastName" : "Köse",
	"Address" : "Üsküdar",
	"Email" : "email@gmail.com",
	"Password" : "12345"
}
```

* Check Identity and  ```Customer``` databases to make sure user and customer are created properly.

<img src = "https://github.com/suadev/dotnet-core-microservices-kafka/blob/master/img/customer_db.png" />

<img src = "https://github.com/suadev/dotnet-core-microservices-kafka/blob/master/img/identity_db.png" />

* Check KafDrop (http://localhost:9000) to see messages on the ```users``` topic.

<img src = "https://github.com/suadev/dotnet-core-microservices-kafka/blob/master/img/kafdrop.JPG" />

