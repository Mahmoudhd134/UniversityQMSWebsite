# First Of All

you must add appsettings.json file in Api dircectory contains something like that

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "default": "<YOUR-CONNECTION-STRING-HERE>"
  },
  "Jwt": {
    "key": "<YOUR-TOKEN-SERCRET-KEY-HERE>"
  },
  "Expiry": {
    "TokenExpiryInMinutes": 45, //token expiry date in minits
    "RefreshTokenExpiryInDays": 10 //refresh token exipry date in days
  }
}
```

## Instalation Maniual
`git clone https://github.com/Mahmoudhd134/UniversityQMSWebsite`

`cd UniversityQMSWebsite`

`dotnet restore`

`dotnet ef database update --project logic --startup-project api`

`cd front-react`

`npm i`


## To Run The Project 
### First be in the root directory UniversityQMSWebsite
### Opent two terminals
#### First one 
`dotnet run`
#### Second one
`cd front-react`

`npm run dev`
