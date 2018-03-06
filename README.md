# Think Event
 
Esta é uma aplicação Multi-Tenant criada usando ASP.NET Boilerplate e module-zero. 
Neste repositório existem 2 códigos-fonte diferentes que servem pro painel administrativo do Geek Etec e demais eventos que possam acontecer.
Um deles é desenvolvido usando Angular, e o outro 
é desenvolvido usando ASP.NET Core, Angular e EntityFrameworkCore. 
Aqui estão as feaures:

* Qualquer pessoa pode criar uma rede usando um formulário de registro e se torna administrador da rede.
* Qualquer pessoa pode se registrar na rede.
* Os usuários admin podem criar eventos.
* Os usuários admin podem ver eventos e outros usuários registrados.
* Os usuários podem se registrar nos eventos com base em alguma política.
* Os usuários podem cancelar seu registro com base em alguma política.
* Os usuários admin podem cancelar seus próprios eventos.

## Live Demo

__https://thinkevent.azurewebsites.net__

![alt login form](/images/login.png "Formulário de Login do Painel Administrativo")

Nota: Você pode se registrar na rede __default__ ou criar sua própria rede.

## Autenticação

Basta enviar uma requisição POST para https://api-thinkevent.azurewebsites.net/api/TokenAuth/Authenticate com o cabeçalho Context-Type="application/json" como demonstrado abaixo:

![Requisição Local](/images/tokenAuth.png "Requisição local feita pelo postman")

![Requisição Remota](/images/tokenAuth-remote.png "Requisição Remota feita pelo postman")

Enviamos no corpo da requisição um objeto JSON que poderia incluir o tanancyName junto com os demais atributos que enviamos, userNameOrEmailAddress e password, porém o tenancyName não é necessário para os usuário que estão na rede Default. Como vimos acima, o resultado da requisição retorna um JSON com o token. Podemos salvá-lo e usar nos próximos pedidos de requisição.

## Artigos

Existem 2 artigos do Codeproject explicando este exemplo profundamente:

##### ASP.NET MVC, Angularjs and EntityFramework version:
http://www.codeproject.com/Articles/1043326/A-Multi-Tenant-SaaS-Application-With-ASP-NET-MVC-A

##### ASP.NET Core, Angular and EntityFrameworkCore version
https://www.codeproject.com/Articles/1231118/A-Multi-Tenant-SaaS-Application-With-ASP-NET-Core
