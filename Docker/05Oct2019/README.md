# Speaker Series

URL: https://www.c-sharpcorner.com/events/handson-docker-on-windows-10-docker-file-custom-images

## Creating New Web Api Project using .Net Core 2.1

Executed the Web Api using IIS Express and Kestrel

## Adding Docker Support

## Executing the Web Api using IIS Express, Kestrel, and Docker


## Viewing the contents of the running Container

docker exec -it container_name bash

## Publishing the Content and Creating simple Dockerfile

dotnet publish -o ./Output -c Release --self-contained -r linux-x64 

docker build -t simplewebapi:v1 .

docker run -it --rm -p 3000:80 --name firstcontainer simplewebapi:v1


dotnet publish -o ./Output1 -c Release
docker build -f ./CustomImage/Dockerfile1 -t simplewebapi:v2 .
docker run -d -p 3000:80 --name firstcontainer simplewebapi:v2

docker run -it -p 3010:80 --name firstcontainer simplewebapiv1:version1
docker run -d -p 3020:80 --name secondcontainer simplewebapiv1:version1

docker run -d -p 3030:80 --name secondcontainer simplewebapiv1:version2

docker tag simplewebapiv1:version2 vishipayyallore/simplewebapiv1-version2
docker push vishipayyallore/simplewebapiv1-version2

docker pull vishipayyallore/simplewebapiv1-version2
docker run -d -p 3040:80 --name newcontainer vishipayyallore/simplewebapiv1-version2

