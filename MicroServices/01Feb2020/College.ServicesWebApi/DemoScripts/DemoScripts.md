# Commands to Micro-Service Demo Scripts

## URLs for accessing the API

http://localhost:10000/api/weatherforecast
http://localhost:3010/api/health


## Login into the Docker Hub

docker login --username userName

## Login into Azure

az login
az account list --output table
az account set -s "Your Subscription Name"


## Let's Verify the Docker Image

Let's do Docker Exec into the running Container
We will see that it is bringing the entire Source Code

## Let's Build the Custom Image

Build the Docker Image
docker build -f "C:\LordKrishna\GitHub\speaker_series_csharp_dotnetcode\28Sep2019\College.Services\College.Services\Dockerfile" -t collegeapi:version1 "C:\LordKrishna\GitHub\speaker_series_csharp_dotnetcode\28Sep2019\College.Services"


## Live Mode

docker run -it --rm -p 3000:80 --name collegemicroservice collegeapi:version4

## Detached Mode

docker run -it -d -p 3010:80 --name collegemicroservicev1 collegeapi:version4

## Tagging the custom Image and Pushing it to docker Hub

docker tag collegeapi:version4 vishipayyallore/collegeapiv4
docker push vishipayyallore/collegeapiv4

## Executing the Docker Cantainer from custom Image

Let's remove all the images from local box.

docker run -it -d -p 3020:80 --name collegemicroservice vishipayyallore/collegeapiv4


## Creating aks cluster

az aks create --resource-group rsg-demo-tech-talks --name collegeservice-akscluster --node-count 1 --enable-addons http_application_routing --generate-ssh-keys

## Retrieving the Credentials

az aks get-credentials --resource-group rsg-demo-tech-talks --name collegeservice-akscluster


## Deploying the Docker Image to Kubernetes Cluster

kubectl apply -f .\College.Services\Source\College.Api\K8s\deploy-collegemicroservice.yaml

kubectl get all

kubectl get service collegemicroservice --watch

## kubectl delete service collegemicroservicev1

## Accessing the Web Api

http://137.135.88.221/api/health

## Scaling the Web Api

kubectl scale --replicas=2 deployment/collegemicroservice

