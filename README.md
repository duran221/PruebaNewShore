# Web Service y Cliente Web usando Tecnología ASP .NET Framework

A continuación, se dará una breve introducción a la estructura interna del proyecto, así como sus componentes principales:
El código fuente consta de una solución desarrollada usando un enfoque de arquitectura en CAPAS, la cual a su vez contiene Cinco proyectos los cuales serán descritos a continuación:

![](/DOC/preview1.JPG)
### Estructura del proyecto:

## FrontendAerolineasNewShore
Este proyecto contiene el **Cliente Web** el cual fué desarrollado en ASP .NET FRAMEWORK y contiene las vistas y controladores que permiten consumir los servicios del REST api proporcionado para el ejercicio, así como el respectivo consumo de los servicios del API rest creada



## Capa APIAerolineasNewShore
El proyecto consta de una Web Api Rest que permite resolver las solicitudes enviadas por el proyecto Cliente **FrontendAerolineasNewShore**
Las solicitudes a resolver son trasladas hacia la capa de **Negocio** Donde posteriormente se ejecuta la lógica del núcleo de negocio de la aplicación.

![](/DOC/preview2.JPG)

## Capa De Núcleo de Negocio (Business)
En esta capa es procesada la información procedente del cliente en formato JSON, la cual es impulsada hacía la base de datos, de acuerdo 
al resultado de la petición se responde con un código de respuesta.

![](/DOC/preview3.JPG)


## Capa De Entidades (Entity)
Esta capa es la encargada de mediar la creación de los modelos o entidades en base de datos, migraciones y conexiones directamente con la base de datos

![](/DOC/preview4.JPG)


## Poner En Marcha El Servicio:
La solución ha sido desarrollada usando ASP .NET Framework 4.7.2 Algunos Requerimientos: 

* Bases de datos SQL Server 15.0.2000.5
* ASP .NET Framework 4.7.2
* IIS Express
* Visual Studio 2019

Clone la solución proporcionada en este repositorio y abra el IDE de Visual Studio:


Abra el asistete de bases de datos, se aconseja usar **Microsoft SQL Server Management Studio** y cree una base de datos con el nombre **NewShoreDB**

![](/DOC/preview5_1.JPG)


![](/DOC/preview6.JPG)


Ahora, debe configurar los archivos de cadena de conexión con la base de datos en los proyectos **Entity** , **APIAerolineasNewShore** y **TestAerolineasNewShore** En el archivo App.Config y Web.Config respectivamente, asegúrese de establecer los parámetros de host, contexto, base de datos, usuario y contraseña, esto es especialmente importante a la hora de correr los servicios más adelante
![](/DOC/preview7.JPG)

Abra el Proyecto **Entity** , Elimine el archivo de migración denominado migracion_inicial y abra la consola de administración de paquetes.
Ejecute las migraciones usando los siguientes comandos:

```bash
Enable-Migrations
add-migration 'migracion inicial'
update-database
```

## Ejecución

Ejecute el proyecto **FrontendAerolineasNewShore** , deberá obtener un pantallazo como el que se muestra a continuación:
![](/DOC/preview8.JPG)

Para realizar una consulta sobre algún vuelo en específico no se hace necesaria la ejecución del Web Api Proporcionado ya que este servicio es obtenido desde un servicio en la Web:

![](/DOC/preview9.JPG)

### Insertar un registro en base de datos: 

Dirigase a Visual estudio y ejecute también el proyecto **APIAerolineasNewShore** deberá obtener una página como la que se muestra a continuación esto es necesario ya que pone en marcha la Servicio Web creado para la insercion de base de datos de los registros de vuelo:
Prueba insertar un registro.
![](/DOC/preview10.JPG)

Si la inserción ha sido exitosa deberá obtener un mensaje indicando la inserción del registro como se muestra a continuación:
![](/DOC/preview11.JPG)

En base de datos:
La inserción puede ser corroborada consultando la tabla 'Flights':
![](/DOC/preview12.JPG)


## Ejecución de Pruebas: 
La solución consta de un proyecto de pruebas el cual usa NUNIT para su respectiva ejecución, aségurese de tener lo necesario para 
ejecutar pruebas de NUNIT así como tener correctamente configurada la cadena de conexión, ejecute las pruebas, debería obtener un resultado como el siguiente para el caso de prueba especificado:

![](/DOC/preview13.JPG)


### Notes
Cualquier Duda o inquietud favor ponerse en contacto vía correo electrónico.
