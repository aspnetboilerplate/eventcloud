# Event Cloud
 
This is a sample Multi-Tenant application built using ASP.NET Boilerplate and module-zero. 
In this repository there are 2 diffrent source code of even cloud sample.
One of them is developed using ASP.NET MVC, Angularjs and EntityFramewok, and the other 
is developed using ASP.NET Core, Angular and EntityFrameworkCore. 
Here are the feaures:

* Anyone can create a tenant using a registration form and becomes admin of the tenant.
* Anyone can register to a tenant.
* Users can create events.
* Users can see events and other registered users.
* Users can register to events based on some policy.
* Users can cancel their registration based on some policy.
* Users can cancel their own events.

## Live Demo

__https://thinkevent.azurewebsites.net__

![alt login form](/images/login.png "Formulário de Login do Painel Administrativo")

Nota: Você pode se registrar na rede __default__ ou criar sua própria rede.

## Autenticação

Basta enviar uma requisição POST para https://api-thinkevent.azurewebsites.net/api/TokenAuth/Authenticate com o cabeçalho Context-Type="application/json" como demonstrado abaixo:

![Requisição Local](/images/tokenAuth.png "Requisição local feita pelo postman")

![Requisição Remota](/images/tokenAuth-remote.png "Requisição Remota feita pelo postman")

## Articles

There are 2 Codeproject articles explains this example deeply:

##### ASP.NET MVC, Angularjs and EntityFramework version:
http://www.codeproject.com/Articles/1043326/A-Multi-Tenant-SaaS-Application-With-ASP-NET-MVC-A

##### ASP.NET Core, Angular and EntityFrameworkCore version
https://www.codeproject.com/Articles/1231118/A-Multi-Tenant-SaaS-Application-With-ASP-NET-Core
