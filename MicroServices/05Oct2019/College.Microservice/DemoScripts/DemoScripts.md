# Commands to Micro-Service Demo Scripts

## URLs for accessing the API

http://localhost:10000/api/weatherforecast
http://localhost:3010/api/health


## Login into the Docker Hub

docker login --username vishipayyallore

## Login into Azure

az login
az account list --output table
az account set -s "Your Subscription Name"


## Let's Verify the Docker Image

Let's do Docker Exec into the running Container
We will see that it is bringing the entire Source Code

Build custom Docker Image and pushing the custom image to Docker Hub
Pulling custom Docker image and executing locally
Creating AKS Cluster in Azure
Retrieving the Credentials of AKS
Deploying Web API’s custom Docker image to Kubernetes, and accessing Web API from AKS

## Let's Build the Custom Image

Build the Docker Image
docker build -f "C:\LordKrishna\GitHub\speaker_series\MicroServices\05Oct2019\College.Microservice\Source\Dockerfile" -t collegeapi:oct5v1 "C:\LordKrishna\GitHub\speaker_series\MicroServices\05Oct2019\College.Microservice"


## Live Mode

docker run -it --rm -p 3000:80 --name collegemicroservice collegeapi:oct5v1

## Detached Mode

docker run -it -d -p 3010:80 --name collegemicroservicev1 collegeapi:oct5v1

## Tagging the custom Image and Pushing it to docker Hub

docker tag collegeapi:oct5v2 vishipayyallore/collegeapi-oct05v2
docker push vishipayyallore/collegeapi-oct05v2

## Executing the Docker Cantainer from custom Image

Let's remove all the images from local box.

docker pull vishipayyallore/collegeapi-oct05
docker run -it -d -p 3020:80 --name collegemicroservice vishipayyallore/collegeapi-oct05


## Creating aks cluster

az aks create --resource-group rsg-techtalks --name collegeservice-akscluster --node-count 1 --enable-addons http_application_routing --generate-ssh-keys

## Retrieving the Credentials

az aks get-credentials --resource-group rsg-techtalks --name collegeservice-akscluster


## Deploying the Docker Image to Kubernetes Cluster

kubectl apply -f .\College.Services\Source\College.Api\K8s\deploy-collegemicroservice.yaml

kubectl get all

kubectl get service collegemicroservice --watch

## kubectl delete service collegemicroservicev1

## Accessing the Web Api

http://137.135.88.221/api/health

## Scaling the Web Api

kubectl scale --replicas=2 deployment/collegemicroservice



docker run -it -d -p 3030:80 vishipayyallore/collegeapi-oct05v2
