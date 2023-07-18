CREATE DATABASE CLINICA_TP
go
USE CLINICA_TP
go

drop table if exists Credenciales;

create table Credenciales(
Id int primary key not null IDENTITY(1,1),
Nombre_Usuario varchar(100) not null,
Contrasenia varchar(50) not null
);

drop table if exists Especialidades; 

create table Especialidades(
Id int primary key not null IDENTITY(1,1),
Nombre varchar(50) not null,
);

drop table if exists Obras_Sociales; 

create table Obras_Sociales(
Id int primary key not null IDENTITY(1,1),
Nombre varchar(20) not null,
);

drop table if exists Estados_Turno; 
create table Estados_Turno(
Id int primary key not null IDENTITY(1,1),
Nombre varchar(50) not null,
);

drop table if exists Permisos; 

create table Permisos(
Id int primary key not null IDENTITY(1,1),
Nombre varchar(50) not null,
);

drop table if exists Dias_Semana;

CREATE TABLE Dias_Semana(
    Id INT PRIMARY KEY not null IDENTITY(1,1),
    Dia VARCHAR(20) NOT NULL
);

drop table if exists Datos_Contacto; 

create table Datos_Contacto(
Id int primary key not null IDENTITY(1,1),
Email varchar(100) not null,
Celular VARCHAR(15) null,
Telefono VARCHAR(15) null,
Direccion varchar(128) null,
Localidad varchar(100) null,
Provincia varchar(100) null,
Codigo_Postal varchar(10) null
);

drop table if exists Personas; 

create table Personas(
Id int primary key not null IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
Dni VARCHAR(50) NOT NULL,
Fecha_Nacimiento DATETIME NOT NULL,
Nacionalidad VARCHAR(40) NOT NULL,
--Sexo
Id_Datos_Contacto int not null FOREIGN KEY REFERENCES Datos_Contacto(id),
Id_Credencial int not null FOREIGN KEY REFERENCES Credenciales(id),
Id_Permiso int not null FOREIGN KEY REFERENCES Permisos(id)
);

drop table if exists Pacientes; 

create table Pacientes(
Id int primary key not null IDENTITY(1,1),
Id_Persona int not null FOREIGN KEY REFERENCES Personas(id),
Fecha_Alta datetime not null,
Id_Obra_Social int not null FOREIGN KEY REFERENCES Obras_Sociales(id),
Nro_Afiliado int null,--Cambiar a varchar
Estado bit not null
);

drop table if exists Profesionales; 

create table Profesionales(
Id int primary key not null IDENTITY(1,1),
Id_Persona int NOT NULL FOREIGN KEY REFERENCES Personas(id),
Fecha_Alta datetime not null,
Fecha_Baja datetime null,
Matricula varchar(50) not null,
Estado BIT NOT NULL
);

drop table if exists Empleados;

create table Empleados(
Id int primary key not null IDENTITY(1,1),
Id_Persona int not null FOREIGN KEY REFERENCES Personas(id),
Fecha_Alta datetime not null,
Fecha_Baja datetime null,
--Legajo
Estado bit not null
);

drop table if exists Turnos_Asignados;

create table Turnos_Asignados(
Id int primary key not null IDENTITY(1,1),
Fecha datetime not null,
Id_Profesional int not null FOREIGN KEY REFERENCES Profesionales(id),
Id_Paciente int not null FOREIGN KEY REFERENCES Pacientes(id),
Observacion varchar null,
Diagnostico varchar null,
Id_Estado int not null FOREIGN KEY REFERENCES Estados_Turno(id)
);

drop table if exists Especialidades_Profesional;

CREATE TABLE Especialidades_Profesional(
Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
Id_Profesional int NOT NULL FOREIGN KEY REFERENCES Profesionales(id),
Id_Especialidad int NOT NULL FOREIGN KEY REFERENCES Especialidades(id)
)

drop table if exists Horarios_Profesional;

create table Horarios_Profesional(
Id int primary key not null IDENTITY(1,1),
Id_Profesional int not null FOREIGN KEY REFERENCES Profesionales(id),
Id_Especialidad INT not null FOREIGN KEY REFERENCES Especialidades(id),
Id_Dia int not null FOREIGN KEY REFERENCES Dias_Semana(id),
Horario_Inicio INT not null,
Horario_Fin INT not null
);
DELETE FROM Horarios_Profesional;
ALTER TABLE Horarios_Profesional
ADD Id_Especialidad INT not null;
ALTER TABLE Horarios_Profesional
ALTER COLUMN Id_Especialidad INT NOT NULL;
ALTER TABLE Horarios_Profesional
DROP COLUMN Id_Especialidad;
ALTER TABLE Horarios_Profesional
ADD CONSTRAINT FK_HorariosProfesional_Especialidades
FOREIGN KEY (Id_Especialidad) REFERENCES Especialidades(Id);

-------INSERTS-----
--Especialidades
INSERT INTO Especialidades (Nombre) VALUES ('Cardiología');
INSERT INTO Especialidades (Nombre) VALUES ('Dermatología');
INSERT INTO Especialidades (Nombre) VALUES ('Gastroenterología');
INSERT INTO Especialidades (Nombre) VALUES ('Neurología');
INSERT INTO Especialidades (Nombre) VALUES ('Oftalmología');
INSERT INTO Especialidades (Nombre) VALUES ('Otorrinolaringología');
INSERT INTO Especialidades (Nombre) VALUES ('Pediatría');
INSERT INTO Especialidades (Nombre) VALUES ('Psiquiatría');
INSERT INTO Especialidades (Nombre) VALUES ('Traumatología');
INSERT INTO Especialidades (Nombre) VALUES ('Urología');

SELECT * FROM Especialidades

--Obras Sociales
INSERT INTO Obras_Sociales (Nombre) VALUES ('Particular');
INSERT INTO Obras_Sociales (Nombre) VALUES ('Galeno');
INSERT INTO Obras_Sociales (Nombre) VALUES ('Sancor Salud');
INSERT INTO Obras_Sociales (Nombre) VALUES ('Omint');
INSERT INTO Obras_Sociales (Nombre) VALUES ('Medicus');
INSERT INTO Obras_Sociales (Nombre) VALUES ('Avalian');
INSERT INTO Obras_Sociales (Nombre) VALUES ('PreMedic');
INSERT INTO Obras_Sociales (Nombre) VALUES ('Osde');
INSERT INTO Obras_Sociales (Nombre) VALUES ('Unión Personal');
INSERT INTO Obras_Sociales (Nombre) VALUES ('Luis Pasteur');

SELECT * FROM Obras_Sociales

--Estado del turno
INSERT INTO Estados_Turno (NOMBRE) VALUES ('Nuevo' );
INSERT INTO Estados_Turno (NOMBRE) VALUES ('Cerrado');
INSERT INTO Estados_Turno (NOMBRE) VALUES ('Cancelado');
INSERT INTO Estados_Turno (NOMBRE) VALUES ('Reprogramado');
INSERT INTO Estados_Turno (NOMBRE) VALUES ('No asistió');

SELECT * FROM Estados_Turno

--Permisos
INSERT INTO Permisos (Nombre) VALUES ('Administrador');
INSERT INTO Permisos (Nombre) VALUES ('Recepcionista');
INSERT INTO Permisos (Nombre) VALUES ('Profesional');
INSERT INTO Permisos (Nombre) VALUES ('Paciente');

SELECT * FROM Permisos

--Dias
INSERT INTO Dias_Semana (Dia) VALUES ('Lunes');
INSERT INTO Dias_Semana (Dia) VALUES ('Martes');
INSERT INTO Dias_Semana (Dia) VALUES ('Miércoles');
INSERT INTO Dias_Semana (Dia) VALUES ('Jueves');
INSERT INTO Dias_Semana (Dia) VALUES ('Viernes');
INSERT INTO Dias_Semana (Dia) VALUES ('Sábado');
INSERT INTO Dias_Semana (Dia) VALUES ('Domingo');

SELECT * FROM Dias_Semana


--Inserts para la tabla Credenciales (pacientes)
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente1', 'contrasenia1');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente2', 'contrasenia2');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente3', 'contrasenia3');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente4', 'contrasenia4');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente5', 'contrasenia5');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente6', 'contrasenia6');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente7', 'contrasenia7');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente8', 'contrasenia8');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente9', 'contrasenia9');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('paciente10', 'contrasenia10');

SELECT * FROM Credenciales

-- Inserts para la tabla Datos_Contacto (pacientes)
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo1@example.com', '01112345678', '01187654321', 'Av. Corrientes 123', 'Ciudad Autónoma de Buenos Aires', 'Buenos Aires', '1010');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo2@example.com', '01123456789', '01198765432', 'Av. Santa Fe 456', 'Córdoba', 'Córdoba', '5000');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo3@example.com', '01134567890', '01187654321', 'Av. Pellegrini 789', 'Rosario', 'Santa Fe', '2000');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo4@example.com', '01145678901', '01198765432', 'Av. San Martín 1234', 'Mendoza', 'Mendoza', '5500');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo5@example.com', '01156789012', '01187654321', 'Av. Belgrano 5678', 'Salta', 'Salta', '4400');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo6@example.com', '01167890123', '01198765432', 'Av. Independencia 9012', 'San Miguel de Tucumán', 'Tucumán', '4000');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo7@example.com', '01178901234', '01187654321', 'Av. 7 12345', 'La Plata', 'Buenos Aires', '1900');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo8@example.com', '01189012345', '01198765432', 'Av. Colón 67890', 'Mar del Plata', 'Buenos Aires', '7600');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo9@example.com', '01190123456', '01187654321', 'Av. Bicentenario 23456', 'San Fernando del Valle de Catamarca', 'Catamarca', '4700');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('ejemplo10@example.com', '01101234567', '01198765432', 'Av. San Martín 78901', 'San Juan', 'San Juan', '5400');

SELECT * FROM Datos_Contacto

-- Inserts para la tabla Personas (pacientes)
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Juan', 'Pérez', '11111111', '1990-05-15', 'Argentina', 1, 1, 4);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('María', 'Gómez', '22222222', '1985-09-25', 'Argentina', 2, 2, 4);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Carlos', 'López', '33333333', '1992-07-12', 'Argentina', 3, 3, 4);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Laura', 'Rodríguez', '44444444', '1995-03-20', 'Argentina', 4, 4, 4);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Lucas', 'Fernández', '55555555', '1988-12-05', 'Argentina', 5, 5, 4);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Carolina', 'Sánchez', '66666666', '1991-08-18', 'Argentina', 6, 6, 4);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Martín', 'López', '77777777', '1986-06-10', 'Argentina', 7, 7, 4);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Florencia', 'García', '88888888', '1993-02-28', 'Argentina', 8, 8, 4);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Luis', 'González', '99999999', '1989-11-15', 'Argentina', 9, 9, 4);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Ana', 'Martínez', '10101010', '1994-07-08', 'Argentina', 10, 10, 4);

SELECT * FROM Personas

-- Inserts para la tabla Pacientes
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (1, '2022-01-15', 1, 12345, 1);
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (2, '2022-02-20', 2, 67890, 1);
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (3, '2022-03-10', 3, 54321, 1);
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (4, '2022-04-05', 4, 98765, 1);
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (5, '2022-05-12', 5, 24680, 1);
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (6, '2022-06-20', 6, 13579, 1);
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (7, '2022-07-08', 7, 86420, 1);
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (8, '2022-08-15', 8, 97531, 1);
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (9, '2022-09-22', 9, 10293, 1);
INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
VALUES (10, '2022-10-30', 10, 74859, 1);

SELECT * FROM Pacientes

-- Inserts para la tabla Credenciales (profesionales)
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional1', 'contrasenia1');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional2', 'contrasenia2');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional3', 'contrasenia3');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional4', 'contrasenia4');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional5', 'contrasenia5');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional6', 'contrasenia6');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional7', 'contrasenia7');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional8', 'contrasenia8');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional9', 'contrasenia9');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('profesional10', 'contrasenia10');

SELECT * FROM Credenciales

-- Inserts para la tabla Datos_Contacto (profesionales)
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional1@example.com', '01112345678', '01198765432', 'Av. Corrientes 123', 'Ciudad Autónoma de Buenos Aires', 'Buenos Aires', '1010');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional2@example.com', '01123456789', '01187654321', 'Av. Santa Fe 456', 'Córdoba', 'Córdoba', '5000');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional3@example.com', '01134567890', '01198765432', 'Av. Pellegrini 789', 'Rosario', 'Santa Fe', '2000');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional4@example.com', '01145678901', '01187654321', 'Av. San Martín 1234', 'Mendoza', 'Mendoza', '5500');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional5@example.com', '01156789012', '01198765432', 'Av. Belgrano 5678', 'Salta', 'Salta', '4400');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional6@example.com', '01167890123', '01187654321', 'Av. Independencia 9012', 'San Miguel de Tucumán', 'Tucumán', '4000');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional7@example.com', '01178901234', '01198765432', 'Av. 7 12345', 'La Plata', 'Buenos Aires', '1900');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional8@example.com', '01189012345', '01187654321', 'Av. Colón 67890', 'Mar del Plata', 'Buenos Aires', '7600');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional9@example.com', '01190123456', '01198765432', 'Av. Bicentenario 23456', 'San Fernando del Valle de Catamarca', 'Catamarca', '4700');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('profesional10@example.com', '01101234567', '01187654321', 'Av. San Martín 78901', 'San Juan', 'San Juan', '5400');

SELECT * FROM Datos_Contacto

-- Inserts para la tabla Personas (profesionales)
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Juan', 'Pérez', '11111111', '1980-05-15', 'Argentina', 11, 11, 3);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('María', 'Gómez', '22222222', '1975-09-25', 'Argentina', 12, 12, 3);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Carlos', 'López', '33333333', '1982-07-12', 'Argentina', 13, 13, 3);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Laura', 'Rodríguez', '44444444', '1985-03-20', 'Argentina', 14, 14, 3);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Lucas', 'Fernández', '55555555', '1978-12-05', 'Argentina', 15, 15, 3);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Carolina', 'Sánchez', '66666666', '1981-08-18', 'Argentina', 16, 16, 3);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Martín', 'López', '77777777', '1976-06-10', 'Argentina', 17, 17, 3);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Florencia', 'García', '88888888', '1983-02-28', 'Argentina', 18, 18, 3);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Luis', 'González', '99999999', '1979-11-15', 'Argentina', 19, 19, 3);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Ana', 'Martínez', '10101010', '1984-07-08', 'Argentina', 20, 20, 3);

SELECT * from Personas

-- Inserts para la tabla Profesionales
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (11, '2022-01-15', NULL, 'M12345', 1);
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (12, '2022-02-20', NULL, 'M67890', 1);
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (13, '2022-03-10', NULL, 'M54321', 1);
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (14, '2022-04-05', NULL, 'M98765', 1);
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (15, '2022-05-12', NULL, 'M24680', 1);
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (16, '2022-06-20', NULL, 'M13579', 1);
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (17, '2022-07-08', NULL, 'M86420', 1);
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (18, '2022-08-15', NULL, 'M97531', 1);
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (19, '2022-09-22', NULL, 'M10293', 1);
INSERT INTO Profesionales (Id_Persona, Fecha_Alta, Fecha_Baja, Matricula, ESTADO)
VALUES (20, '2022-10-30', NULL, 'M74859', 1);

SELECT * FROM Profesionales

-- Inserts para la tabla Credenciales (empleados)
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('empleado1', 'contrasenia1');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('empleado2', 'contrasenia2');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('empleado3', 'contrasenia3');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('empleado4', 'contrasenia4');
INSERT INTO Credenciales (Nombre_Usuario, Contrasenia) VALUES ('empleado5', 'contrasenia5');

SELECT * FROM Credenciales

-- Inserts para la tabla Datos_Contacto (empleados)
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('empleado1@example.com', '0111111111', '0112222222', 'Av. Corrientes 123', 'Ciudad Autónoma de Buenos Aires', 'Buenos Aires', '1010');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('empleado2@example.com', '0113333333', '0114444444', 'Calle 9 de Julio 456', 'Córdoba', 'Córdoba', '5000');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('empleado3@example.com', '0115555555', '0116666666', 'Av. Pellegrini 789', 'Rosario', 'Santa Fe', '2000');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('empleado4@example.com', '0117777777', '0118888888', 'Av. San Martín 1234', 'Mendoza', 'Mendoza', '5500');
INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
VALUES ('empleado5@example.com', '0119999999', '0110000000', 'Calle Belgrano 5678', 'Salta', 'Salta', '4400');

SELECT * FROM Datos_Contacto

-- Inserts para la tabla Personas (empleados)
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Lucía', 'García', '33333333', '1990-01-15', 'Argentina', 21, 21, 1);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Juan', 'Rodríguez', '44444444', '1985-05-20', 'Argentina', 22, 22, 1);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('María', 'López', '55555555', '1988-09-12', 'Argentina', 23, 23, 2);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Carlos', 'Martínez', '66666666', '1992-02-25', 'Argentina', 24, 24, 2);
INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
VALUES ('Laura', 'Gómez', '77777777', '1995-06-08', 'Argentina', 25, 25, 2);

SELECT * FROM Personas

-- Inserts para la tabla Empleados
INSERT INTO Empleados (Id_Persona, Fecha_Alta, Fecha_Baja, Estado)
VALUES (21, '2022-01-15', NULL, 1);
INSERT INTO Empleados (Id_Persona, Fecha_Alta, Fecha_Baja, Estado)
VALUES (22, '2022-02-20', NULL, 1);
INSERT INTO Empleados (Id_Persona, Fecha_Alta, Fecha_Baja, Estado)
VALUES (23, '2022-03-10', NULL, 1);
INSERT INTO Empleados (Id_Persona, Fecha_Alta, Fecha_Baja, Estado)
VALUES (24, '2022-04-05', NULL, 1);
INSERT INTO Empleados (Id_Persona, Fecha_Alta, Fecha_Baja, Estado)
VALUES (25, '2022-05-12', NULL, 1);

SELECT * FROM Empleados

-- Inserts para la tabla Especialidades_Profesional
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (1, 1);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (2, 2);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (3, 3);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (4, 4);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (5, 5);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (6, 6);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (7, 7);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (8, 8);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (9, 9);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (10, 10);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (1, 7);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (2, 7);
INSERT INTO Especialidades_Profesional (Id_Profesional, Id_Especialidad)
VALUES (3, 7);

-- Inserts para la tabla Horarios_Profesional
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (1, 1, 9, 17, 1);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (1, 2, 10, 18, 7);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (2, 3, 8, 16, 2);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (2, 2, 9, 17, 2);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (2, 5, 10, 16, 7);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (3, 4, 8, 14, 3);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (3, 3, 9, 12, 7);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (4, 4, 14, 18, 4);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (4, 5, 16, 19, 4);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (5, 4, 13, 17, 5);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (5, 5, 11, 18, 5);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (6, 4, 12, 16, 6);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (6, 2, 11, 17, 6);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (7, 2, 14, 19, 7);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (7, 1, 8, 12, 7);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (8, 6, 10, 15, 8);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (8, 3, 10, 14, 8);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (9, 1, 11, 16, 9);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (10, 2, 13, 17, 10);
INSERT INTO Horarios_Profesional (Id_Profesional, Id_Dia, Horario_Inicio, Horario_Fin, Id_Especialidad)
VALUES (10, 1, 15, 18, 10);

SELECT * FROM Horarios_Profesional