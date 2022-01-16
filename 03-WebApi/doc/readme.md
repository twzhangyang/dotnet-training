## docker
- Build Music API
```
 docker build -f ./WebApi/Dockerfile -t music-api:v1 .
``` 
- Run Music API
```
docker run -d -e ASPNETCORE_ENVIRONMENT="Development" -p 8000:80 music-api:v1
``` 
- Run Api
```
http://localhost:8000/swagger/index.html
```
- Run PostgreSQL
```
docker run -e POSTGRES_USER=music -e POSTGRES_PASSWORD=music123 \
-e PGDATA=/var/lib/postgresql/data/pgdata -v /tmp:/var/lib/postgresql/data \
-p 5432:5432 -it postgres:14
```
- psql
```
psql -U music -W -h localhost -p 5432
```
## docker-compose
```
docker-compose up 
```
- check postgreSQL by Adminer
```
http://localhost:8080/
```
