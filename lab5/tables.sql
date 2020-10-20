DROP TABLE customer;
DROP TABLE dvd;
DROP TABLE offer;

CREATE TABLE customer (
	"customer_id"	INTEGER,
	"first_name"	TEXT NOT NULL,
	"last_name"	TEXT NOT NULL,
	"passport_code"	INTEGER NOT NULL,
	"registration_date"	TEXT NOT NULL,
	PRIMARY KEY("customer_id" AUTOINCREMENT)
);

CREATE TABLE dvd (
	"dvd_id"	INTEGER,
	"title"	TEXT NOT NULL,
	"production_year"	INTEGER NOT NULL,
	PRIMARY KEY("dvd_id" AUTOINCREMENT)
);

CREATE TABLE offer (
	"offer_id"	INTEGER,
	"dvd_id"	INTEGER NOT NULL,
	"customer_id"	INTEGER NOT NULL,
	"offer_date"	TEXT NOT NULL,
	"return_date"	TEXT,
	PRIMARY KEY("offer_id" AUTOINCREMENT)
);