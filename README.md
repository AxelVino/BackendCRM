# CRM-Backend
Un CRM es una herramienta que ayuda a las empresas a administrar y analizar sus interacciones con los clientes.
Este es un servicio que utiliza los principios REST API para la comunicacion HTTP entre el back y el front, para poder proporcionar distintos recursos y mostrarlos mediante una interfaz.
Siguen principios solid haciendo uso de interfaces, modularizando y haciendo que cada elemento tenga una responsabilidad unica dentro del sistema. Se hace uso de clean architecture para tener un codigo mantenible, escalable y legible, y se utiliza una arquitectura en capas, las cuales son las siguientes:
- Capa de aplicacion
- Capa de dominio
- Capa de infraestructura

Se hacen validaciones estrictas y las solicitudes se realizan de manera asincrona, para que no se bloquee el servicio mientras se va a buscar un recurso a la base de datos. Tambien re realiza object mapping para poder devolver respuestas en formato JSON y se hace uso de EntityFramework como ORM con enfoque code-first para poder codear la base de datos y luego realizar una migracion a la base de datos. Todo esto con hecho con una base de datos SQL alojada en SQL Server Management Studio con la cual se realizaran las operaciones CRUD.
 
Algunos de los patrones de diseño que se utilizaron:
* CQRS (Command Query Responsibility Segregation): este patrón separa las operaciones de lectura (queries) de las operaciones de escritura (commands), lo que permite optimizar cada una de estas acciones de manera independiente.
* Dependency Injection: que permite desacoplar los objetos en una aplicación al proporcionarles sus dependencias desde el exterior, en lugar de que los objetos mismos las creen.
* Strategy: es un patrón de comportamiento que permite definir una familia de algoritmos, encapsularlos y hacerlos intercambiables sin modificar el código del cliente que los usa.
* Repository: patrón de diseño usado principalmente en aplicaciones que acceden a bases de datos. Sirve para abstraer la lógica de acceso a datos y desacoplar la lógica de negocios del almacenamiento.
