# Registering for a Conference

The api lets someone register for a conference.
They POST to our API a reservation, and we register them.

The operation:

```yaml
operation: registration-created
    operands:
        -
            - name: who
            - description: the identity
        -
            - name: conference
              description: the conference they are attending    

```

## The person makes the request

```http
POST /conference-registration-requests
Content-Type: application/json
Authorization: bearer some.jwt.io

{
    "conference": {
        "id": "someid",
        "name": "Microservice World 2022"
    }

}

```
## Processing

## What is the response

```http
201 Created
Location http://server.com/conference-registration-requests/3989389

{
"conference": {
        "id": "someid",
        "name": "Microservice World 2022"
    },
    "status": "Pending"
   
}


