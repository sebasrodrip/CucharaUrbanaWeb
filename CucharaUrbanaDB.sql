CREATE DATABASE CucharaUrbana;
USE CucharaUrbana;

CREATE TABLE Categoria (
	CategoriaID INT IDENTITY (1,1) PRIMARY KEY,
	Nombre VARCHAR (30),
);


-- Creacion de la tabla productos

CREATE TABLE Producto (
	ProductoID INT  IDENTITY (1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR (500),
	CategoriaID INT,
	Precio DECIMAL(10, 2),
	CONSTRAINT fk_CategoriaID_Producto FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID)
);

CREATE TABLE Carrito (
    CarritoID INT IDENTITY (1,1) PRIMARY KEY,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    CONSTRAINT fk_ProductoID_Carrito FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID)
);

-- Creación de tabla Pedidos:

CREATE TABLE Pedidos (	
	PedidoID INT IDENTITY (1,1) PRIMARY KEY,
	FechaPedido  DATETIME NOT NULL,  	
	MesaPedido   INT NOT NULL,	
	EstadoPedido VARCHAR(20),
	ProductoID   INT 

	CONSTRAINT fk_ProductoID_Pedidos FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID)
);
--Creación de tabla Reservaciones:

CREATE TABLE Reservacion (
	ReservacionID      INT IDENTITY (1,1) PRIMARY KEY,
	FechaReservacion   DATETIME NOT NULL,
	MesaReservacion    INT NOT NULL,
	HoraReservacion    TIME NOT NULL,
	DetalleReservacion INT NOT NULL, -- Para cuantas personas es la reserva
	
); 

	-- Creación de la tabla temporal "TipoPago" en caso de requerirse
CREATE TABLE TipoPago  (
    MetodoPagoID INT IDENTITY (1,1) PRIMARY KEY,
    TipoPago VARCHAR(50) NOT NULL
);

-- Creación de la tabla "Factura"
CREATE TABLE Factura (
    FacturaID INT IDENTITY (1,1) PRIMARY KEY,
    Detalle VARCHAR (500),
	CarritoID INT,
    Subtotal DECIMAL(10, 2) NOT NULL,
    TipoPagoID INT,
	Fecha smalldatetime default SYSDATETIME(),
    CONSTRAINT fk_TipoPagoID_DetalleFactura FOREIGN KEY (TipoPagoID) REFERENCES TipoPago(MetodoPagoID),
	CONSTRAINT fk_CarritoId_Factura FOREIGN KEY (CarritoID) REFERENCES Carrito(CarritoID)
);


-- Inserts


-- Insertar datos en la tabla Categoria
INSERT INTO Categoria ( Nombre) VALUES ('Comida');
INSERT INTO Categoria ( Nombre) VALUES ('Bebida');

-- Insertar datos en la tabla Producto
INSERT INTO Producto (Nombre, Descripcion, CategoriaID, Precio) VALUES ( 'Melt Callejero', 
'Pan de molde, 2 smash de carne, 2 rebanadas de cheddar, 2 rebanadas de queso americano, cebolla lentamente caramelizada, salsa urbana y derretido en mantequilla a la plancha', 1, 4600);
INSERT INTO Producto (Nombre, Descripcion, CategoriaID, Precio) VALUES ('Urban Classic Doble', 
'Pan de papa, 2 smash de carne, 2 rebanadas de queso americano, 1 rebanada de queso cheddar, pepinilos de la casa, cebolla picada, salsa urbana', 1, 4600);
INSERT INTO Producto (Nombre, Descripcion, CategoriaID, Precio) VALUES ( 'Urban Classic Triple', 
'Pan de papa, 3 smash de carne, 2 rebanadas de queso americano, 1 rebanada de queso cheddar, pepinilos de la casa, cebolla picada, salsa urbana', 1, 5300);
INSERT INTO Producto (Nombre, Descripcion, CategoriaID, Precio) VALUES ( 'Krunchy Bella', 
'Pan de papa, 2 smash de carne, tocineta crujiente, cebolla crujiente, 1 rebanada de queso americano, 1 reabanada de queso cheddar y salsa urbana', 1, 4900);
INSERT INTO Producto (Nombre, Descripcion, CategoriaID, Precio) VALUES ( 'Juicy Luchi', 
'Pan de papa, 2 smash de carne sin vuelta, en medio 1 rebanada de cheddar y 2 de queso americano, pepinillos, cebolla picada, kétchup y mostaza', 1, 4650);
INSERT INTO Producto (Nombre, CategoriaID, Precio) VALUES ('Extra papas fritas',  1, 1000);

-- Insertar datos en la tabla TipoPago
INSERT INTO TipoPago (TipoPago) VALUES ('Efectivo');
INSERT INTO TipoPago (TipoPago) VALUES ('Tarjeta');

INSERT INTO Carrito (ProductoID, Cantidad, PrecioUnitario)
VALUES 
    (1, 2, 4600),  -- Agregar 2 unidades del producto con ProductoID 1
    (3, 1, 5300),  -- Agregar 1 unidad del producto con ProductoID 3
    (2, 3, 4600);  -- Agregar 3 unidades del producto con ProductoID 2