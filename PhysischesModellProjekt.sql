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
	birthdate Date
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
	name VARCHAR2(40)
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

);

create TABLE HotelGuestHasAddOns(

);


