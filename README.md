# CRM-Frontend

Buenas, este es un back utilizando los principios REST API para la comunicacion HTTP entre servicios, en el cual se extraen, guardan, modifican o eliminan datos de un servicio CRM WEB.
Tambien se siguen principios solid, se hace uso de interfaces, una arquitectura en capas, se hacen uso de validaciones estrictas, object mapping, formato de mensaje JSON y EntityFramework como ORM, para realizar la interaccion y 
el uso de operaciones CRUD entre el back y la base de datos, usando el enfoque codefirst para la creacion de esta ultima. Todo esto con hecho con una base de datos SQL alojada en SQL Server Management Studio.
Algunos patrones de diseño que se utilizaron son:
* CORS (Command Query Responsibility Segregation): este patrón separa las operaciones de lectura (queries) de las operaciones de escritura (commands), lo que permite optimizar cada una de estas acciones de manera independiente.
* Dependency Injection: que permite desacoplar los objetos en una aplicación al proporcionarles sus dependencias desde el exterior, en lugar de que los objetos mismos las creen.
  
El sistema puede refactorizarse, aplicando mejoras, mas patrones de diseños, un middleware para la seguridad, agregar un sistema de autenticacion para los usuarios, etc.
