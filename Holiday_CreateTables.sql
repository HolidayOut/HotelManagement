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
	room_id INTEGER,
	checkOut Date,
	checkIn Date,
	
	FOREIGN KEY(username) REFERENCES Accounts(username),
	FOREIGN KEY(room_id) REFERENCES Rooms(ID_Room)
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


create TABLE RoleHasPermissions(
	Key_Role INTEGER,
	Key_Permissions INTEGER,
	
	FOREIGN KEY(Key_Role) REFERENCES Roles(ID_Role),
	FOREIGN KEY(Key_Permissions) REFERENCES Permissions(ID_Permission),
	CONSTRAINT pkRoleHasPermissions PRIMARY KEY(Key_Role, Key_Permissions)
);

create TABLE HotelGuestHasAddOns(
	Key_HotelGuest_id INTEGER,
	Key_AddOn_id INTEGER,
	
	FOREIGN KEY(Key_HotelGuest_id) REFERENCES HotelGuests(ID_HotelGuest),
	FOREIGN KEY(Key_AddOn_id) REFERENCES AddOns(ID_AddOn),
	CONSTRAINT pkHotelGuestHasAddOns PRIMARY KEY(Key_HotelGuest_id, Key_AddOn_id)
);
