# City bike statistics Blazor application
## Disclaimer:
This is **not** a serious application. Created only to test Blazor and EF Core.
## What's it about:
Uses [HSL Open data](https://www.hsl.fi/en/hsl/open-data) to read city bike journeys. Utilizes NServiceBus and EF Core to save data to database.
Frontend is Blazor web assembly that loads and shows city bike related statistics from server.
## Remarks:
* NServiceBus has learning transport that uses computer memory to simulate servicebus transport infrastructure. All messages are configured to be purged on startup
* Uses local MS SQL database
* Bike data must be downloaded with _Bike data update_ page