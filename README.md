# ListaTareasApi

Proyecto API en CleanArchitecture utilizando NET 8, utilizando patrón CQRS y patrón Repositorio y DDD.

La Base de Datos es SQL Server, para lo cual hay que crear un contenedor docker ejecutando lo siguiente:

    - docker pull mcr.microsoft.com/mssql/server
    - docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Jorge@Rodes" -p 1433:1433 -d mcr.microsoft.com/mssql/server

Esta contraseña es lo que pondremos en el app.settings del proyecto ListaTareasApi.Api, aunque por defecto ya está la indicada.

Al ejecutar el proyecto Api, automáticamente se generará la Base de datos y se ejecutará la migración, creándose una única tabla de tareas.

Se han creado, mediante Minimal Api, 4 endpoints:

    - Creación de tarea
    - Listado de tareas : este es el único endpoint que se ha hecho con Dapper, utilizando los otros 3 EF
    - Reordenación de tareas : Recibe un listado de pares de tarea-orden, sean 2 sean 20
    - Finalizar tarea : al igual que para creación de tareas, cada vez que se finaliza una tarea, se ejecuta con Domain Event (actualmente no hace nada, pero se podría enviar un email por ejemplo).







