Assumptions have been made:
<ol>
<li>Dotnet 9 required</li>
<li>Podman required (docker might work) replace ``podman`` in the relevant commands with ``docker``</li>
<li>Tested on linux system (not on windows)</li>

</ol>
After cloning the repo
Fix the permissions for the data files, run:
<br>

``` sudo chmod a+rwx dvdrental/*```

<br>
Setup the DB

```podman run --name some-postgres -e POSTGRES_PASSWORD=verybadpassword -p 5432:5432 -v ./dvdrental:/docker-entrypoint-initdb.d -d public.ecr.aws/docker/library/postgres:18.0-alpine```

Run the backend api, from the root directory:

`` dotnet run --project letber.grpc.backend/letber.grpc.backend.csproj --launch-profile "https"``

<br>
Run the client App to test the Api
<br>

``dotnet run --project letber.client/letber.client.csproj``

The client app is simple interactive cli will let you chose an endpoint then call it and print the result