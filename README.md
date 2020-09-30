Guia para correr
===================
Primer paso
------------
Descargar Git de https://git-scm.com/downloads.
Deben descargar NodeJS de https://nodejs.org, ya sea la version recomendada o la mas reciente.
Descargar la version 3.1 de .NET https://dotnet.microsoft.com/download/dotnet-core. Una vez instalado utilicen el comando dotnet --info y asegurense que salga     .NET Core con la version que acaban de instalar. Correr dotnet tool install --global dotnet-ef
Instalar SQL Server y poner string de conexion en la linea 25 del Startup.cs
Correr dentro de la carpeta del proyecto el comando "dotnet ef migrations add NewInstallation01". Cuando termine correr "dotnet ef database update". Una vez hecho esto, verificar que la base de datos se haya creado en SQL server.

Segundo Paso
-------------
Despues de descargar e instalar Node, deben instalar las dependencias de Angular utilizando el siguiente comando en la consola: "npm install -g @angular/cli". Una vez se haya terminado de instalar pueden utiizar el comando "ng v" para verificar que este instalado y funcionando.

Tercer Paso
------------
Dentro de la carpeta de "ClientApp" del proyecto correr en consola "npm install"

Correr el comando
Una vez instaladas las dependencias de NPM y si les funciona bien Angular pueden intentar correr todo el proyecto desde Visual Studio

Cuarto Paso (en caso que no les funcione desde el Visual)
------------------------------------------------------
A partir de aca, ya deberian de tener las dependencias necesarias para correr la aplicacion de Angular como tal. 

Para descartar que haya un problema con Angular pueden intentar correr nada mas el front end desde la consola ubicando la carpeta "ClientApp", primero deben correr el comando "npm install" para instalar todas las dependencias de la aplicacion como tal (tengo entendido que esto Visual lo deberia de hacer automaticamente cuando se corre) y luego utilizar el comando "ng serve", cuando termina de compilar deben entrar a http://localhost:4200 en su navegador y deberia de verse el front end.

Quinto Paso
------------
Si llegan a este punto, quiere decir que el Angular si les esta funcionando pero no les corre en Visual, pero pueden intentar lo siguiente: Entren a https://dotnet.microsoft.com/download/dotnet-core y descarguen la version 3.1. Una vez instalado utilicen el comando dotnet --info y asegurense que salga     .NET Core con la version que acaban de instalar.

Si hasta aqui todo va bien, entren a la carpeta del proyecto desde la consola y utilicen el comando dotnet run y cuando termine de cargar intenten entrar a http://localhost:5000 desde su navegador y deberia de cargar la aplicacion.

Ahora vuelvan a intentar correrlo desde Visual Studio, y ya deberia funcionar con normalidad.

Si aun no funciona desde Visual
-------------------------------
Yo no utilizo Visual Studio asi que estoy tan perdido como ustedes. Pero si quieren me escriben y les ayudo a buscar un fix o algo.

