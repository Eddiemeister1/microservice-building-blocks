# Running our Dev Environment



## Getting the supporting services going



In this folder, run:



```
docker compose up -d
```



Make sure Dapr is running (dapr init, all that jazz).



To run our API Locally with Dapr:



```
dapr run --app-id=conference-api --app-port=1337 --dapr-http-port=3500 --dapr-grpc-port=50000 --components-path=.\components -- dotnet run --project ..\ConferenceRegistrationSolution\ConferenceRegistrationApi\ConferenceRegistrationApi.csproj
```