https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-3.1&tabs=visual-studio
https://grpc.io/docs/guides/
https://grpc.io/docs/guides/concepts/
https://developers.google.com/protocol-buffers/docs/proto3
https://developers.google.com/protocol-buffers/docs/csharptutorial
https://developers.google.com/web/fundamentals/performance/http2


gRPC Overview: https://grpc.io/docs/guides/
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

History: RPC, COM/DCOM/Java RMI, SOAP/XML, REST, gRPC
Binary communication | Contract-based | Available across ecosystems | Uni and Bi directional streaming
gRPC reqiuries HTTP/2 protocol to transport binary messages. (https://developers.google.com/web/fundamentals/performance/http2)
gRPC uses protocol buffers (Protobuf) as the Interface Definition Language (IDL) for describing both the service interface and the structure of the payload messages.
Best suits in Service to Service communication

REST: 	CRUD and purely web apps
SignalR:Multicasting and web messaging
gRPC:Streaming, low resource clients, and inter-service 

Types of RPCs supported by gRPC:
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
1. Currently gRPC comes with four different types of RPC

	Unary RPC: this is the simplest form of RPC. In this case, the client sends a request message to the server and receives a response.

	Server streaming RPC: in this scenario, the client sends a request message to the server and receives a sequence of responses.

	Client streaming RPC: this is the case where the client sends a sequence of messages and receives a single response from the server.

	Bidirectional streaming RPC: in this case, the client and the server exchange messages in both directions.


Protocol Buffers: https://developers.google.com/protocol-buffers/docs/proto3
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Protocol Buffers is an interface language used to build contracts.
Tools are available for the most common programming languages to translate these Protobuf interfaces into code.
Interface Definition Language | Language-neutral | Platform-neutral | Serializable

1. Version 3 (proto3)
proto2 and proto3.

In C#, generated classes will be placed in a namespace matching the package name if csharp_namespace is not specified.

2. Defining A Message Type

message SimpleRequest {
  string userName = 1;
  int32 userId = 2;
}

The first line of the file specifies proto3 syntax: if you don't do this the protocol buffer compiler will assume proto2.
We are using scalar type for the fields.
Each field in the message definition has a unique number.
It is used to identify the fields in the message binary format, and should not be changed once your message type is in use.
We can define multiple message inside single .proto file.
Adding Comments // OR /* */

3. Scalar Value Types

.proto type	=	C# Type
double 		= 	double
float 		= 	float
int32 		= 	int
int64 		= 	long
bool 		= 	bool
string 		= 	string

4. Default Values
strings = the default value is the empty string.
bools = the default value is false.
numeric = the default value is zero.


Create a gRPC service (Collage Service)
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

1. Dotnet Version Verification:
dotnet --list-sdks
dotnet --version

2. 
mkdir first-grpcdemo
cd first-grpcdemo
dotnet new grpc -o GrpcGreeter 
dotnet run and verify the URL in browser

3.
Verify the .csproj file
Verify the .cs files (Greet.cs, GreetGrpc.cs) auto generate GRPC tools
Verify the StartUp.cs

Create a gRPC service (Collage Service
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
1.
dotnet new console -o GrpcGreeterClient
 
2. 

  <ItemGroup>
    <PackageReference Include="Google.Protobuf" Version="3.11.1" />
    <PackageReference Include="Grpc.Core" Version="2.25.0" />
    <PackageReference Include="Grpc.Net.Client" Version="2.26.0-pre1" />
    <PackageReference Include="Grpc.Tools" Version="2.26.0-pre1">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
  </ItemGroup>

  <ItemGroup>
    <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
  </ItemGroup>

3. 
using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client =  new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
                              
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();


Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.1

************************************************************************************************************************************************************************

