drop TABLE Accounts CASCADE CONSTRAINTS;
drop TABLE Employees CASCADE CONSTRAINTS;
drop TABLE Roles CASCADE CONSTRAINTS;
drop TABLE RoleHasPermissions CASCADE CONSTRAINTS;
drop TABLE Permissions CASCADE CONSTRAINTS;
drop TABLE HotelGuests CASCADE CONSTRAINTS;
drop TABLE StaysHaveAddOns CASCADE CONSTRAINTS;
drop TABLE Rooms CASCADE CONSTRAINTS;
drop TABLE AddOns CASCADE CONSTRAINTS;
drop TABLE Addresses CASCADE CONSTRAINTS;
drop TABLE Stays CASCADE CONSTRAINTS;
drop TABLE StaysHaveRooms CASCADE CONSTRAINTS;

create TABLE Roles(
	ID_Role INTEGER PRIMARY KEY,
	RoleName VARCHAR2(40)
);

create TABLE Permissions(
	ID_Permission INTEGER PRIMARY KEY,
	PermissionName VARCHAR2(40)
);

create TABLE Rooms(
	ID_Room INTEGER PRIMARY KEY,
	RoomSize INTEGER,
	RoomPrice INTEGER
);

create TABLE AddOns(
	ID_AddOn INTEGER PRIMARY KEY,
	name VARCHAR2(40),
	price INTEGER,
	bookingDay Date
);

create TABLE Accounts(
	username VARCHAR2(40) PRIMARY KEY,
	password VARCHAR2(40),
	role_id INTEGER,
	
	FOREIGN KEY(role_id) REFERENCES ROLES(ID_Role)
);

create TABLE HotelGuests(
	ID_HotelGuest INTEGER PRIMARY KEY,
	name VARCHAR2(40),
	username VARCHAR2(40),
	checkOut Date,
	checkIn Date,
	
	FOREIGN KEY(username) REFERENCES Accounts(username)
);

create TABLE Employees(
	ID_Employee INTEGER PRIMARY KEY,
	name VARCHAR2(40),
	birthdate Date,
	username VARCHAR2(40),

	FOREIGN KEY(username) REFERENCES Accounts(username)
);

create TABLE Addresses(
	ID_Addresses INTEGER PRIMARY KEY,
	Country VARCHAR2(40),
	Postalcode VARCHAR2(40),
	City VARCHAR2(40),
	Street VARCHAR2(40),
	Housenumber VARCHAR2(40),
	user_name VARCHAR2(40),
	
	FOREIGN KEY(user_name) REFERENCES ACCOUNTs(username)
);

create Table Stays(
  ID_Stay INTEGER PRIMARY KEY,
  CheckIn Date,
  CheckOut Date,
  room_id INTEGER,
  guest_id INTEGER,
  
  FOREIGN KEY(room_id) REFERENCES Rooms(ID_Room),
  FOREIGN KEY(guest_id) REFERENCES HotelGuests(ID_HotelGuest)
);

create TABLE RoleHasPermissions(
	Key_Role INTEGER,
	Key_Permissions INTEGER,
	
	FOREIGN KEY(Key_Role) REFERENCES Roles(ID_Role),
	FOREIGN KEY(Key_Permissions) REFERENCES Permissions(ID_Permission),
	CONSTRAINT pkRoleHasPermissions PRIMARY KEY(Key_Role, Key_Permissions)
);

create TABLE StaysHaveRooms(
  Key_Stays_id INTEGER,
  Key_Room_id INTEGER,
  
  FOREIGN KEY(Key_Stays_id) REFERENCES Stays(ID_Stay),
  FOREIGN KEY(Key_Room_id) REFERENCES Rooms(ID_Room),
  
  CONSTRAINT pkStaysHaveRooms PRIMARY KEY(Key_Stays_id, Key_Room_id)

);

create TABLE StaysHaveAddOns(
	Key_Stay_id INTEGER,
	Key_AddOn_id INTEGER,
	
	FOREIGN KEY(Key_Stay_id) REFERENCES Stays(ID_Stay),
	FOREIGN KEY(Key_AddOn_id) REFERENCES AddOns(ID_AddOn),
	CONSTRAINT pkStaysHaveAddOns PRIMARY KEY(Key_Stay_id, Key_AddOn_id)
);