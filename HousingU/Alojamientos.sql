use HousingU

create table Amenidad(
   cAmenidad int primary key,
   nombre varchar(100))

create table Direccion(
   cDir int primary key,
   CP int,
   num int,
   colonia varchar(100))
   
create table Residencia(
   cResidencia int primary key,
   cDir int references Direccion,
   tipo varchar(100))
   
create table Usuario(
   cUsuario int primary key,
   nombre varchar(100),
   correo varchar(100),
   pwd varchar(100),
   tipo int)
 
create table Estancia(
   cEstancia int primary key,
   habitantes int,
   descripcion text,
   disponible int, --Cambie el disponible a un int, 0 si no esta disponible y 1 si esta disponible
   numInt int,
   precio int,
   nCuartos int,
   nBaños int,
   mtsCuad decimal,
   cResidencia int references Residencia,
   cUsuario int references Usuario)
   
create table AmenidadEstancia(
    cAmenidad int references Amenidad,
    cEstancia int references Estancia,
    primary key(cAmenidad,cEstancia))
  

create table Universidad(
   cUni int primary key,
   nombre varchar(100),
   CP int)

create table Reseña(
   cReseña int primary key,
   calificacion int,
   contenido text,
   recomendado int,
   fecha datetime,
   likes int,
   arrenCal int)

create table DireccionUniversidad(
    tiempo varchar(100),
    distancia varchar(100),
    cDir int references Direccion,
    cUni int references Universidad,
    primary key(cDir,cUni))

create table EstanciaReseñaUsuario(
    cEstancia int references Estancia,
    cReseña int references Reseña,
    cUsuario int references Usuario,
    primary key(cReseña,cEstancia))


create table Imagenes(
	cImg int primary key,
	link text,
	nombre varchar(200)
)

alter table Estancia add cImg int references Imagenes

