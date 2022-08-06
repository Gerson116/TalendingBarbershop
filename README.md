# TalendingBarbershop
TalendingBarbershop es un proyecto final del curso impartido por Talending.

# Configuraciones básicas
Al clonar el repositorio, debe ejecutar buscar el project TalendingBarbershop.Data y ejecutar los siguientes pasos:

-> Abrir el Package Manager Console
-> Cambiar el Default project y seleccionar el TalendingBarbershop.Data
->update-database

# Insertar los siguientes datos en la tabla tblRoles

Se deben agregar estos dos tipos de roles (Barbero y Clientes) en la base de datos ya que son los iniciales.

use DbTalendigBarbershop
GO
<br>
insert into tblRoles values('Barbero'),('Cliente')
go

# Insertar los siguientes tipos de pago

use DbTalendigBarbershop
GO
<br>
insert into tblPaidTypes values('tarjeta de credito'),('efectivo')
go
