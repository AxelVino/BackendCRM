# CRM-Backend

Este es un backend utilizando los principios REST API para la comunicacion HTTP entre servicios, en el cual se extraen, guardan, modifican o eliminan datos de un servicio CRM WEB.
Tambien se siguen principios solid, se hace uso de interfaces, una arquitectura en capas, clean architecture, se hacen uso de validaciones estrictas, asincronismo, object mapping, formato de mensaje JSON y EntityFramework como ORM, para realizar la interaccion y 
el uso de operaciones CRUD entre el back y la base de datos, usando el enfoque codefirst para la creacion de esta ultima. Todo esto con hecho con una base de datos SQL alojada en SQL Server Management Studio.

Algunos patrones de diseño que se utilizaron son:
* CQRS (Command Query Responsibility Segregation): este patrón separa las operaciones de lectura (queries) de las operaciones de escritura (commands), lo que permite optimizar cada una de estas acciones de manera independiente.
* Dependency Injection: que permite desacoplar los objetos en una aplicación al proporcionarles sus dependencias desde el exterior, en lugar de que los objetos mismos las creen.
* Strategy: es un patrón de comportamiento que permite definir una familia de algoritmos, encapsularlos y hacerlos intercambiables sin modificar el código del cliente que los usa.
* Repository: patrón de diseño usado principalmente en aplicaciones que acceden a bases de datos. Sirve para abstraer la lógica de acceso a datos y desacoplar la lógica de negocios del almacenamiento.
