docker run -d --name mdrip -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=123456aA!' -e 'MSSQL_PID=Developer' -p 1433:1433 microsoft/mssql-server-linux:2017-latest

- since this image is already installed, just run docker start/run mdrip/mdripsql
- this is to get the docker image up and running for mssql

mssql -u sa -p 123456aA!
- this is to connect to the database for CLI

CREATE DATABASE MDRIP
- this is to be run in the CLI for the database mdrip to be created



RUNNING THE PROJ:

1. docker start mdrip - this starts the mdrip sql database
2. docker run --name phpmyadmin -d --link mdrip:MDRIP -p 9090:80 phpmyadmin/phpmyadmin
