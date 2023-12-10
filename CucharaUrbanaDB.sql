USE CucharaUrbana;

-- Crear la tabla Rol
CREATE TABLE Rol (
    RolID INT PRIMARY KEY,
    NombreRol NVARCHAR(50) NOT NULL
);

-- Crear tabla Usuarios
CREATE TABLE Usuario (
    UsuarioID INT PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    CorreoElectronico NVARCHAR(100) UNIQUE NOT NULL,
    RolID INT,

    FOREIGN KEY (RolID) REFERENCES Rol(RolID)
);

-- Crear Tabla Categorias

CREATE TABLE Categoria (
	CategoriaID INT PRIMARY KEY,
	Nombre VARCHAR (30),
);


-- Creacion de la tabla productos

CREATE TABLE Producto (
	ProductoID INT PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR (100),
	CategoriaID INT,
	CONSTRAINT fk_CategoriaID_Producto FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID)
);

ALTER TABLE Producto
ADD Precio DECIMAL(10, 2);

ALTER TABLE Producto
ALTER COLUMN Descripcion VARCHAR(500);

-- Creación de tabla Pedidos:

CREATE TABLE Pedidos (	
	PedidoID INT PRIMARY KEY,
	FechaPedido  DATETIME NOT NULL,  	
	MesaPedido   INT NOT NULL,	
	UsuarioID    INT, --llave foranea del id cliente 
	EstadoPedido VARCHAR(20),
	ProductoID   INT 

	CONSTRAINT fk_UsuarioID_Pedidos FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
	CONSTRAINT fk_ProductoID_Pedidos FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID)
);
--Creación de tabla Reservaciones:

CREATE TABLE Reservacion (
	ReservacionID      INT PRIMARY KEY,
	UsuarioID          INT,
	FechaReservacion   DATETIME NOT NULL,
	MesaReservacion    INT NOT NULL,
	HoraReservacion    TIME NOT NULL,
	DetalleReservacion INT NOT NULL, -- Para cuantas personas es la reserva
	
	CONSTRAINT fk_UsuarioID_Reservacion FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID)
	
); 

	-- Creación de la tabla temporal "TipoPago" en caso de requerirse
CREATE TABLE TipoPago  (
    MetodoPagoID INT PRIMARY KEY,
    TipoPago VARCHAR(50) NOT NULL
);

	-- Creación de la tabla "Factura"
CREATE TABLE Factura (
    FacturaID INT PRIMARY KEY,
    FechaFactura DATE NOT NULL,
    UsuarioID INT NOT NULL, --Llave foranea de la tabla Clientes para mostrar el id del cliente 
    Total DECIMAL(10, 2) NOT NULL,
    PagoID INT,
    MetodoPagoID INT,
    EstadoPago VARCHAR(20),
    TipoPagoID INT,
    CONSTRAINT fk_UsuarioID_Factura FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT fk_MetodoPagoID_Factura FOREIGN KEY (MetodoPagoID) REFERENCES TipoPago(MetodoPagoID)
);

-- Creación de la tabla "DetalleFactura"
CREATE TABLE DetalleFactura (
    DetalleID INT PRIMARY KEY,
    FacturaID INT,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    Subtotal DECIMAL(10, 2) NOT NULL,
    NombreProducto VARCHAR(50), -- Llave foranea de la tabla Productos para mostrar el nombre del producto en la factura
    TipoPagoID INT,
    CONSTRAINT fk_FacturaID_DetalleFactura FOREIGN KEY (FacturaID) REFERENCES Factura(FacturaID),
    CONSTRAINT fk_ProductoID_DetalleFactura FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID),
    CONSTRAINT fk_TipoPagoID_DetalleFactura FOREIGN KEY (TipoPagoID) REFERENCES TipoPago(MetodoPagoID)
);

ALTER TABLE DetalleFactura
DROP COLUMN PrecioUnitario;

-- Inserts

-- Insertar datos en la tabla Rol
INSERT INTO Rol (RolID, NombreRol) VALUES (1, 'Administrador');
INSERT INTO Rol (RolID, NombreRol) VALUES (2, 'Usuario');

-- Insertar datos en la tabla Usuario
INSERT INTO Usuario (UsuarioID, Nombre, Apellido, CorreoElectronico, RolID) VALUES (1, 'Juan', 'Perez', 'juan@example.com', 1);
INSERT INTO Usuario (UsuarioID, Nombre, Apellido, CorreoElectronico, RolID) VALUES (2, 'Maria', 'Lopez', 'maria@example.com', 2);

-- Insertar datos en la tabla Categoria
INSERT INTO Categoria (CategoriaID, Nombre) VALUES (1, 'Comida');
INSERT INTO Categoria (CategoriaID, Nombre) VALUES (2, 'Bebida');

-- Insertar datos en la tabla Producto
INSERT INTO Producto (ProductoID, Nombre, Descripcion, CategoriaID, Precio) VALUES (1, 'Melt Callejero', 
'Pan de molde, 2 smash de carne, 2 rebanadas de cheddar, 2 rebanadas de queso americano, cebolla lentamente caramelizada, salsa urbana y derretido en mantequilla a la plancha', 1, 4600);
INSERT INTO Producto (ProductoID,Nombre, Descripcion, CategoriaID, Precio) VALUES (2, 'Urban Classic Doble', 
'Pan de papa, 2 smash de carne, 2 rebanadas de queso americano, 1 rebanada de queso cheddar, pepinilos de la casa, cebolla picada, salsa urbana', 1, 4600);
INSERT INTO Producto (ProductoID,Nombre, Descripcion, CategoriaID, Precio) VALUES (3, 'Urban Classic Triple', 
'Pan de papa, 3 smash de carne, 2 rebanadas de queso americano, 1 rebanada de queso cheddar, pepinilos de la casa, cebolla picada, salsa urbana', 1, 5300);
INSERT INTO Producto (ProductoID,Nombre, Descripcion, CategoriaID, Precio) VALUES (4, 'Krunchy Bella', 
'Pan de papa, 2 smash de carne, tocineta crujiente, cebolla crujiente, 1 rebanada de queso americano, 1 reabanada de queso cheddar y salsa urbana', 1, 4900);
INSERT INTO Producto (ProductoID,Nombre, Descripcion, CategoriaID, Precio) VALUES (5, 'Juicy Luchi', 
'Pan de papa, 2 smash de carne sin vuelta, en medio 1 rebanada de cheddar y 2 de queso americano, pepinillos, cebolla picada, kétchup y mostaza', 1, 4650);
INSERT INTO Producto (ProductoID,Nombre, CategoriaID, Precio) VALUES (6, 'Extra papas fritas',  1, 1000);


-- Insertar datos en la tabla TipoPago
INSERT INTO TipoPago (MetodoPagoID, TipoPago) VALUES (1, 'Efectivo');
INSERT INTO TipoPago (MetodoPagoID, TipoPago) VALUES (2, 'Tarjeta');