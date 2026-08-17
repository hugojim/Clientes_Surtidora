# Clientes_Surtidora
Aplicación web para administrar clientes mediante operaciones CRUD. La solución deberá permitir registrar, consultar, modificar y dar de baja clientes mediante una interfaz Angular que consuma una API REST desarrollada en C#.


El proyecto está compuesto por:

- Frontend: Angular 18
- Backend: ASP.NET Core 8 Web API
- Persistencia: Entity Framework Core 8
- Base de datos: SQL Server
- Arquitectura: CQRS
- Mediador: MediatR
- Mapeo: extensión `MapTo<T>()`
- Comunicación: API REST mediante HTTP/JSON

---

## 1. Funcionalidades

La aplicación permite:

- Listar clientes.
- Crear clientes.
- Editar clientes.
- Eliminar clientes.
- Buscar clientes por nombre.
- Buscar clientes por correo.
- Paginar los resultados.
- Mostrar nombre y apellido como nombre completo.
- Validar operaciones desde el backend.
- Separar operaciones de lectura y escritura mediante CQRS.

---

## 2. Datos del cliente

La entidad Cliente contiene los siguientes campos:

| Campo | Tipo | Descripción |
|---|---|---|
| Id | int | Identificador único |
| Nombre | string | Nombre del cliente |
| Apellido | string | Apellido del cliente |
| Correo | string | Correo electrónico |

El DTO de respuesta incluye adicionalmente:

| Campo | Tipo | Descripción |
|---|---|---|
| NombreCompleto | string | Nombre + Apellido |

`NombreCompleto` es un campo calculado en el DTO y no se persiste en la base de datos.

---

## 3. Arquitectura

La solución utiliza CQRS mediante MediatR.

### Flujo de lectura

```text
Angular
   |
   | GET /api/clientes
   v
ClientesController
   |
   v
GetClientesQuery
   |
   v
GetClientesQueryHandler
   |
   v
Entity Framework Core
   |
   v
SQL Server
