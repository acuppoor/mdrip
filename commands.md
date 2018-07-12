docker run -d --name mdripsql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=123456aA!' -e 'MSSQL_PID=Developer' -p 1433:1433 microsoft/mssql-server-linux:2017-latest

- since this image is already installed, just run coker start/run mdrip/mdripsql
- this is to get the docker image up and running for mssql

mssql -u sa -p 123456aA!
- this is to connect to the database for CLI

CREATE DATABASE MDRIP
- this is to be run in the CLI for the database mdrip to be created
