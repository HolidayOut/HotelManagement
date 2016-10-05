drop TABLE Accounts CASCADE CONSTRAINTS;
drop TABLE Employees CASCADE CONSTRAINTS;
drop TABLE Roles CASCADE CONSTRAINTS;
drop TABLE RoleHasPermissions CASCADE CONSTRAINTS;
drop TABLE Permissions CASCADE CONSTRAINTS;
drop TABLE HotelGuests CASCADE CONSTRAINTS;
drop TABLE HotelGuestHasAddOns CASCADE CONSTRAINTS;
drop TABLE Rooms CASCADE CONSTRAINTS;
drop TABLE AddOns CASCADE CONSTRAINTS;
drop TABLE Addresses CASCADE CONSTRAINTS;

create TABLE Accounts(
	username VARCHAR2(40) PRIMARY KEY,
	password VARCHAR2(40),
	flagEmp INTEGER
);

create TABLE Employees(
	name VARCHAR2(40),
	birthdate Date,
	role_id INTEGER,
	address_id INTEGER,
	username VARCHAR2(40),
	
	FOREIGN KEY(role_id) REFERENCES Roles(ID_Role),
	FOREIGN KEY(address_id) REFERENCES Addresses(ID_Addresses),
	FOREIGN KEY(username) REFERENCES Accounts(username)
);

create TABLE Roles(
	ID_Role INTEGER PRIMARY KEY,
	RoleName VARCHAR2(40)
);

create TABLE Permissions(
	ID_Permission INTEGER PRIMARY KEY,
	PermissionName VARCHAR2(40)
);

create TABLE HotelGuests(
	name VARCHAR2(40) PRIMARY KEY,
	username VARCHAR2(40),
	address_id INTEGER,
	room_id INTEGER,
	
	FOREIGN KEY(username) REFERENCES Accounts(username),
	FOREIGN KEY(address_id) REFERENCES Addresses(ID_Addresses),
	FOREIGN KEY(room_id) REFERENCES Rooms(ID_Room)
);

create TABLE Rooms(
	ID_Room INTEGER PRIMARY KEY,
	RoomSize INTEGER,
	RoomPrice INTEGER
);

create TABLE AddOns(
	ID_AddOn INTEGER PRIMARY KEY,
	name VARCHAR2(40),
	price INTEGER
);

create TABLE Addresses(
	ID_Addresses INTEGER PRIMARY KEY,
	Country VARCHAR2(40),
	Postalcode VARCHAR2(40),
	City VARCHAR2(40),
	Street VARCHAR2(40),
	Housenumber VARCHAR2(40)
);

create TABLE RoleHasPermissions(
	Key_Role INTEGER,
	Key_Permissions INTEGER,
	
	FOREIGN KEY(Key_Role) REFERENCES Roles(ID_Role),
	FOREIGN KEY(Key_Permissions) REFERENCES Permissions(ID_Permission),
	CONSTRAINT pkRoleHasPermissions PRIMARY KEY(Key_Role, Key_Permissions)
);

create TABLE HotelGuestHasAddOns(
	Key_Name VARCHAR2(40),
	Key_AddOn_id INTEGER,
	
	FOREIGN KEY(Key_Name) REFERENCES HotelGuests(name),
	FOREIGN KEY(Key_AddOn_id) REFERENCES AddOns(ID_AddOn),
	CONSTRAINT pkHotelGuestHasAddOns PRIMARY KEY(Key_Name, Key_AddOn_id)
);


