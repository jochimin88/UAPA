
/*
CREACION DE LAS TABLAS 
*/
create database inventario;
GO
use inventario

create table productos
(
    id int IDENTITY PRIMARY KEY,
    codigo_producto VARCHAR(5) not null,
    nombre VARCHAR(50) not null,
)
GO

create table historial(
    hora TIMESTAMP,
    usuario VARCHAR(20),
    fecha DATE
)

/*
Insertar valores en la tabla "codigo", "Producto", "Precio"
*/

insert into productos values("a001","Salami Induveca",70);




