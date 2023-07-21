--LISTAS
CREATE PROCEDURE SP_LISTAR_PACIENTES 
AS
SELECT Pa.Id as Id_Paciente, P.Id as Id_Persona, P.NOMBRE, P.APELLIDO, P.DNI, P.FECHA_NACIMIENTO, P.Nacionalidad,
DC.Email, DC.Celular, DC.Telefono, DC.Direccion, DC.Localidad, DC.Provincia, DC.Codigo_Postal,
C.Nombre_Usuario, c.Contrasenia,
OS.Nombre as Obra_Social, PA.Nro_Afiliado, PA.Fecha_Alta
FROM Pacientes Pa
INNER JOIN Personas P on  P.Id = Pa.Id_Persona
INNER JOIN Datos_Contacto DC ON DC.Id = P.Id_Datos_Contacto
INNER JOIN Obras_Sociales OS ON OS.Id = PA.Id_Obra_Social
INNER JOIN Credenciales C ON C.Id = P.Id_Credencial
WHERE PA.Estado = 1 
GO
CREATE PROCEDURE SP_LISTAR_PROFESIONALES
AS
SELECT PF.Id as Id_Profesional, P.Id as Id_Persona, P.NOMBRE, P.APELLIDO, P.DNI, P.FECHA_NACIMIENTO, P.Nacionalidad,
DC.Email, DC.Celular, DC.Telefono, DC.Direccion, DC.Localidad, DC.Provincia, DC.Codigo_Postal,
C.Nombre_Usuario, c.Contrasenia,
PF.Fecha_Alta, PF.Fecha_Baja, PF.Matricula
FROM PROFESIONALES PF
INNER JOIN Personas P on  P.Id = Pf.Id_Persona
INNER JOIN Datos_Contacto DC ON DC.Id = P.Id_Datos_Contacto
INNER JOIN Credenciales C ON C.Id = P.Id_Credencial
WHERE PF.ESTADO = 1
GO
CREATE PROCEDURE SP_LISTAR_EMPLEADOS
AS 
SELECT E.Id as Id_Empleado, P.Id as Id_Persona, P.NOMBRE, P.APELLIDO, P.DNI, P.FECHA_NACIMIENTO, P.Nacionalidad, Pe.Nombre AS Permiso,
DC.Email, DC.Celular, DC.Telefono, DC.Direccion, DC.Localidad, DC.Provincia, DC.Codigo_Postal,
C.Nombre_Usuario, c.Contrasenia,
E.Fecha_Alta, E.Fecha_Baja
FROM Empleados E
INNER JOIN Personas P on  P.Id = E.Id_Persona
INNER JOIN Datos_Contacto DC ON DC.Id = P.Id_Datos_Contacto
INNER JOIN Credenciales C ON C.Id = P.Id_Credencial
INNER JOIN Permisos Pe ON Pe.Id = P.Id_Permiso
WHERE E.Estado = 1
GO
CREATE PROCEDURE SP_LISTAR_OBRAS_SOCIALES
AS
BEGIN
    SELECT *
    FROM Obras_Sociales;
END
GO
CREATE PROCEDURE SP_LISTAR_ESPECIALIDADES 
AS
BEGIN
    SELECT *
    FROM Especialidades;
END
GO
CREATE PROCEDURE SP_LISTAR_ESPACIALIDADES_PROFESIONAL_HORARIO
AS
BEGIN
    SELECT HP.Id as Id_Horario, P.Nombre, P.Apellido, PR.Id as Id_Profesional, PR.Matricula, 
    E.Id as Id_Especialidad, E.Nombre AS Especialidad, 
    DS.Dia, HP.Horario_Inicio, HP.Horario_Fin
    FROM Horarios_Profesional HP
    INNER JOIN Profesionales PR ON PR.Id = HP.Id_Profesional
    INNER JOIN Especialidades E ON E.Id = HP.Id_Especialidad
    INNER JOIN Personas P ON P.Id = PR.Id_Persona
    INNER JOIN Dias_Semana DS ON DS.Id = HP.Id_Dia
END
GO
--ALTAS
CREATE PROCEDURE SP_ALTA_DATOS_CONTACTO(
    @Email VARCHAR(100),
    @Celular VARCHAR(15),
	@Telefono VARCHAR(15),
	@Direccion VARCHAR(128),
    @Localidad VARCHAR(100),
    @Provincia varchar(100),
    @Codigo_Postal varchar(10)
) AS 
BEGIN 
	INSERT INTO Datos_Contacto (Email,Celular,Telefono,Direccion,Localidad,Provincia,Codigo_Postal) 
    VALUES(@Email,@Celular,@Telefono,@Direccion,@Localidad,@Provincia,@Codigo_Postal)
END
GO
CREATE PROCEDURE SP_ALTA_CREDENCIAL(
    @Nombre_Usuario VARCHAR(100),
	@Contrasenia VARCHAR(50)
) AS 
BEGIN 
	INSERT INTO Credenciales (Nombre_Usuario,Contrasenia) 
    VALUES(@Nombre_Usuario,@Contrasenia)
END
GO
CREATE PROCEDURE SP_ALTA_PERSONA(
	@Nombre VARCHAR(50),
	@Apellido VARCHAR(50),
	@Dni VARCHAR(50),
	@Fecha_Nacimiento DATETIME,
	@Nacionalidad VARCHAR(40),
	@Id_Datos_Contacto INT,
	@Id_Credencial INT,
	@Id_Permiso INT
) AS 
BEGIN 
	INSERT INTO Personas (Nombre,Apellido,Dni,Fecha_Nacimiento,Nacionalidad,Id_Datos_Contacto,Id_Credencial,Id_Permiso) 
    VALUES(@Nombre,@Apellido,@Dni,@Fecha_Nacimiento,@Nacionalidad,@Id_Datos_Contacto,@Id_Credencial,@Id_Permiso)
END
GO
CREATE PROCEDURE SP_ALTA_PACIENTE(
	@Id_Persona INT,
	@Fecha_Alta DATETIME,
	@Id_Obra_Social INT,
    @Nro_Afiliado INT
) AS 
BEGIN 
	INSERT INTO Pacientes(Id_Persona,Fecha_Alta,Id_Obra_Social,Nro_Afiliado) 
    VALUES(@Id_Persona,@Fecha_Alta,@Id_Obra_Social,@Nro_Afiliado)
END
GO
CREATE PROCEDURE SP_ALTA_TODO_PACIENTE
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Dni VARCHAR(50),
    @Fecha_Nacimiento DATETIME,
    @Nacionalidad VARCHAR(40),
    @Email VARCHAR(100),
    @Celular VARCHAR(15),
    @Telefono VARCHAR(15),
    @Direccion VARCHAR(128),
    @Localidad VARCHAR(100),
    @Provincia VARCHAR(100),
    @Codigo_Postal VARCHAR(10),
    @Id_Obra_Social int,
    @Nro_Afiliado int,
    @Nombre_Usuario VARCHAR(100),
    @Contrasenia VARCHAR(50)
AS
BEGIN
  
    DECLARE @Datos_Contacto_Id INT;
    INSERT INTO Datos_Contacto (Email, Celular, Telefono, Direccion, Localidad, Provincia, Codigo_Postal)
    VALUES (@Email, @Celular, @Telefono, @Direccion, @Localidad, @Provincia, @Codigo_Postal);
    SET @Datos_Contacto_Id = SCOPE_IDENTITY();

    DECLARE @Credenciales_Id INT;
    INSERT INTO Credenciales (Nombre_Usuario, Contrasenia)
    VALUES (@Nombre_Usuario, @Contrasenia);
    SET @Credenciales_Id = SCOPE_IDENTITY();

    DECLARE @Personas_Id INT;
    INSERT INTO Personas (Nombre, Apellido, Dni, Fecha_Nacimiento, Nacionalidad, Id_Datos_Contacto, Id_Credencial, Id_Permiso)
    VALUES (@Nombre, @Apellido, @Dni, @Fecha_Nacimiento, @Nacionalidad, @Datos_Contacto_Id, @Credenciales_Id, 4);
    SET @Personas_Id = SCOPE_IDENTITY();

    INSERT INTO Pacientes (Id_Persona, Fecha_Alta, Id_Obra_Social, Nro_Afiliado, Estado)
    VALUES (@Personas_Id, GETDATE(), @Id_Obra_Social, @Id_Obra_Social, @Nro_Afiliado, 1);
END
GO
CREATE PROCEDURE SP_ALTA_PROFESIONAL(
    @Id_Persona INT,
    @Fecha_Alta datetime,
    @Fecha_Baja datetime,
    @Matricula varchar(50)
) AS
BEGIN
    INSERT INTO Profesionales(Id_Persona,Fecha_Alta,Fecha_Baja,Matricula)
    VALUES(@Id_Persona,@Fecha_Alta,@Fecha_Baja,@Matricula)
END
GO
CREATE PROCEDURE SP_ALTA_EMPLEADO(
    @Id_Persona int,
    @Fecha_Alta datetime,
    @Fecha_Baja datetime
) AS
BEGIN
    INSERT INTO Empleados(Id_Persona,Fecha_Alta,Fecha_Baja)
    VALUES(@Id_Persona,@Fecha_Alta,@Fecha_Baja)
END
GO
CREATE PROCEDURE SP_ALTA_TURNO(
	@FECHA DATETIME,
	@ID_PROFESIONAL INT,
	@Id_Paciente INT,
	@OBSERVACION VARCHAR,
	@DIAGNOSTICO VARCHAR
) AS
BEGIN
	INSERT INTO TURNOS_ASIGNADOS(FECHA, Id_Profesional, Id_Paciente, Observacion, Diagnostico, Id_Estado) 
    VALUES(@FECHA, @ID_PROFESIONAL, @Id_Paciente, @OBSERVACION, @DIAGNOSTICO, 1)
END
GO
--MODIFICAR
CREATE PROCEDURE SP_MODIFICAR_PACIENTE
    @Id_Paciente INT,
    @Id_Persona INT,
    @Id_Datos_Contacto INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Dni VARCHAR(50),
    @Fecha_Nacimiento DATETIME,
    @Nacionalidad VARCHAR(40),
    @Email VARCHAR(100),
    @Celular VARCHAR(15),
    @Telefono VARCHAR(15),
    @Direccion VARCHAR(128),
    @Localidad VARCHAR(100),
    @Provincia VARCHAR(100),
    @Codigo_Postal VARCHAR(10),
    @Id_Obra_Social INT,
    @Nro_Afiliado INT
AS
BEGIN
    UPDATE Datos_Contacto
    SET 
        Email = @Email,
        Celular = @Celular,
        Telefono = @Telefono,
        Direccion = @Direccion,
        Localidad = @Localidad,
        Provincia = @Provincia,
        Codigo_Postal = @Codigo_Postal
    WHERE Id = @Id_Datos_Contacto;

    UPDATE Personas
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Dni = @Dni,
        Fecha_Nacimiento = @Fecha_Nacimiento,
        Nacionalidad = @Nacionalidad
    WHERE Id = @Id_Persona;

    UPDATE Pacientes
    SET
        Id_Obra_Social = @Id_Obra_Social,
        Nro_Afiliado = @Nro_Afiliado
    WHERE Id = @Id_Paciente;
END
GO
CREATE PROCEDURE SP_MODIFICAR_PROFESIONAL
    @Id_Profesional INT,
    @Id_Persona INT,
    @Id_Datos_Contacto INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Dni VARCHAR(50),
    @Fecha_Nacimiento DATETIME,
    @Nacionalidad VARCHAR(40),
    @Email VARCHAR(100),
    @Celular VARCHAR(15),
    @Telefono VARCHAR(15),
    @Direccion VARCHAR(128),
    @Localidad VARCHAR(100),
    @Provincia VARCHAR(100),
    @Codigo_Postal VARCHAR(10),
    @Matricula VARCHAR(50)
   
AS
BEGIN
    UPDATE Datos_Contacto
    SET 
        Email = @Email,
        Celular = @Celular,
        Telefono = @Telefono,
        Direccion = @Direccion,
        Localidad = @Localidad,
        Provincia = @Provincia,
        Codigo_Postal = @Codigo_Postal
    WHERE Id = @Id_Datos_Contacto;

    UPDATE Personas
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Dni = @Dni,
        Fecha_Nacimiento = @Fecha_Nacimiento,
        Nacionalidad = @Nacionalidad
    WHERE Id = @Id_Persona;

    UPDATE Profesionales
    SET
        Matricula = @Matricula
    WHERE Id = @Id_Profesional;
END
GO
CREATE PROCEDURE SP_MODIFICAR_EMPLEADO
    @Id_Empleado INT,
    @Id_Persona INT,
    @Id_Datos_Contacto INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Dni VARCHAR(50),
    @Fecha_Nacimiento DATETIME,
    @Nacionalidad VARCHAR(40),
    @Email VARCHAR(100),
    @Celular VARCHAR(15),
    @Telefono VARCHAR(15),
    @Direccion VARCHAR(128),
    @Localidad VARCHAR(100),
    @Provincia VARCHAR(100),
    @Codigo_Postal VARCHAR(10),
    @Id_Permiso INT
AS
BEGIN
    UPDATE Datos_Contacto
    SET 
        Email = @Email,
        Celular = @Celular,
        Telefono = @Telefono,
        Direccion = @Direccion,
        Localidad = @Localidad,
        Provincia = @Provincia,
        Codigo_Postal = @Codigo_Postal
    WHERE Id = @Id_Datos_Contacto;

    UPDATE Personas
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Dni = @Dni,
        Fecha_Nacimiento = @Fecha_Nacimiento,
        Nacionalidad = @Nacionalidad,
        Id_Permiso = @Id_Permiso
    WHERE Id = @Id_Persona
END
GO
--BUSCAR
CREATE PROCEDURE SP_BUSCAR_PROFESIONAL_POR_ID
    @Id_Profesional INT

AS
BEGIN
    SELECT PE.Id as Id_Persona, PE.Nombre, PE.Apellido, PE.Dni, PE.Fecha_Nacimiento, PE.Nacionalidad,
           DC.Id as Id_Datos_Contacto, DC.Email, DC.Celular, DC.Telefono, DC.Direccion, DC.Localidad, DC.Provincia, DC.Codigo_Postal,
           PR.Matricula
    FROM Personas PE
    INNER JOIN Datos_Contacto DC ON PE.Id_Datos_Contacto = DC.Id
    INNER JOIN Profesionales PR ON PE.Id = PR.Id_Persona
    WHERE PR.Id = @Id_Profesional;
END
GO
CREATE PROCEDURE SP_BUSCAR_EMPLEADO_POR_ID
    @Id_Empleado INT

AS
BEGIN
    SELECT PE.Id as Id_Persona, PE.Nombre, PE.Apellido, PE.Dni, PE.Fecha_Nacimiento, PE.Nacionalidad, PE.Id_Permiso,
           DC.Id as Id_Datos_Contacto, DC.Email, DC.Celular, DC.Telefono, DC.Direccion, DC.Localidad, DC.Provincia, DC.Codigo_Postal
    FROM Personas PE
    INNER JOIN Datos_Contacto DC ON PE.Id_Datos_Contacto = DC.Id
    INNER JOIN Empleados E ON PE.Id = E.Id_Persona
    WHERE E.Id = @Id_Empleado;
END
GO
CREATE PROCEDURE SP_BUSCAR_PACIENTE_POR_ID
    @Id_Paciente INT

AS
BEGIN
    SELECT PE.Id as Id_Persona, PE.Nombre, PE.Apellido, PE.Dni, PE.Fecha_Nacimiento, PE.Nacionalidad,
           DC.Id as Id_Datos_Contacto, DC.Email, DC.Celular, DC.Telefono, DC.Direccion, DC.Localidad, DC.Provincia, DC.Codigo_Postal,
           PA.Id_Obra_Social, PA.Nro_Afiliado, OS.Nombre AS Obra_Social
    FROM Personas PE
    INNER JOIN Datos_Contacto DC ON PE.Id_Datos_Contacto = DC.Id
    INNER JOIN Pacientes PA ON PE.Id = PA.Id_Persona
    INNER JOIN Obras_Sociales OS ON OS.Id = PA.Id_Obra_Social 
    WHERE PA.Id = @Id_Paciente;
END
GO
CREATE PROCEDURE SP_VERIFICAR_DISPONIBILIDAD_TURNO
    @horaSeleccionada DATETIME
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Turnos_Asignados t
        WHERE t.Fecha = CONVERT(DATE, @horaSeleccionada) 
            AND DATEPART(HOUR, t.Fecha) = DATEPART(HOUR, @horaSeleccionada) 
    )
    BEGIN
        
        SELECT 1 AS DisponibilidadTurno;
	END
	ELSE
	BEGIN
		SELECT 0 AS DisponibilidadTurno

    END
END
go
CREATE PROCEDURE SP_LISTAR_ESPACIALIDADES_PROFESIONAL_HORARIO_2
AS
BEGIN
SELECT * FROM Horarios_Profesional
END
go
create PROCEDURE SP_LISTAR_DIAS_SEMANA
AS
BEGIN
 select Id, Dia from Dias_Semana
END
GO
create procedure SP_BUSCAR_PROFESIONAL
 (@IdProfesional int)
as
begin
	select * from Profesionales p where p.id = @IdProfesional
end
GO
--BAJAS
CREATE PROCEDURE SP_BAJA_PACIENTE
    @Id_Paciente INT
AS
BEGIN
    UPDATE Pacientes
    SET Estado = 0
    WHERE Id = @Id_Paciente;
END
GO
CREATE PROCEDURE SP_BAJA_PROFESIONAL
    @Id_Profesional INT
AS
BEGIN
    UPDATE Profesionales
    SET Estado = 0
    WHERE Id = @Id_Profesional;
END
GO
CREATE PROCEDURE SP_BAJA_EMPLEADO
    @Id_Empleado INT
AS
BEGIN
    UPDATE Empleados
    SET Estado = 0
    WHERE Id = @Id_Empleado;
END


GO
ALTER procedure SP_INSERTAR_TURNO (
@FECHA datetime,
@id_profesional int,
@id_paciente int,
@observacion varchar,
@diagnostico varchar,
@idEstado int,
@idEspecialidad int
)
as
begin
	insert into Turnos_Asignados (Fecha, Id_Profesional, Id_Paciente, Observacion, Diagnostico, Id_Estado, Id_Especialidad)
	values(@FECHA, @id_profesional, @id_paciente, @observacion, @diagnostico, @idEstado, @idEspecialidad);
end
GO
ALTER PROCEDURE SP_LISTAR_TURNOS_PACIENTE
    @Id_Paciente INT
AS
BEGIN
    SELECT TA.Id_Paciente, TA.Id_Profesional, P.Nombre, P.Apellido, Pr.Matricula,
    TA.Fecha, TA.Diagnostico, TA.Observacion, ET.Nombre as Estado, E.Nombre as Especialidad
    FROM Turnos_Asignados TA
    INNER JOIN Estados_Turno ET ON TA.Id_Estado = ET.Id
    INNER JOIN Pacientes PA ON PA.Id = TA.Id_Paciente
    INNER JOIN Profesionales PR ON PR.Id = TA.Id_Profesional
    INNER JOIN Personas P ON P.Id = PR.Id_Persona
    INNER JOIN Especialidades E ON E.Id = TA.Id_Especialidad
    WHERE TA.Id_Paciente = @Id_Paciente
END
GO

create PROCEDURE SP_VERIFICAR_DISPONIBILIDAD_TURNO_2
    @Anio INT,
    @Mes INT,
    @Dia INT,
    @Hora INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Combinar los parámetros para formar la fecha completa
    DECLARE @FechaCompleta DATETIME = CAST(@Anio AS NVARCHAR(4)) + '-' +
                                       RIGHT('0' + CAST(@Mes AS NVARCHAR(2)), 2) + '-' +
                                       RIGHT('0' + CAST(@Dia AS NVARCHAR(2)), 2) + ' ' +
                                       RIGHT('0' + CAST(@Hora AS NVARCHAR(2)), 2) + ':00:00';

    -- Realizar la búsqueda de la fecha en la tabla o realizar la acción deseada
     IF NOT EXISTS (SELECT 1 FROM Turnos_Asignados WHERE Fecha = @FechaCompleta)
	 BEGIN
        
        SELECT 1 AS DisponibilidadTurno;
	END
	ELSE
	BEGIN
		SELECT 0 AS DisponibilidadTurno
	end
END
GO