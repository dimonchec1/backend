DROP TABLE PC;
DROP TABLE track_downloads;
DROP TABLE students;
DROP TABLE courses;
DROP TABLE students_on_courses;
DROP TABLE users;
DROP TABLE orders;

CREATE TABLE PC (
	"id"	INTEGER,
	"cpu"	INTEGER NOT NULL,
	"memory"	INTEGER NOT NULL,
	"hdd"	INTEGER NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);

CREATE TABLE track_downloads ( 
      download_id INTEGER NOT NULL, 
      track_id INTEGER NOT NULL, 
      user_id BIGINT INTEGER NOT NULL, 
      download_time TEXT NOT NULL DEFAULT 0, 
      PRIMARY KEY (download_id AUTOINCREMENT)
    ); 
	
CREATE TABLE students (
	id_student	INTEGER NOT NULL,
	name	TEXT NOT NULL,
	PRIMARY KEY(id_student AUTOINCREMENT)
);

CREATE TABLE courses (
	id_course	INTEGER NOT NULL,
	name	TEXT NOT NULL,
	PRIMARY KEY(id_course AUTOINCREMENT)
);

CREATE TABLE students_on_courses (
	id_course INTEGER  NOT NULL,
	id_student INTEGER  NOT NULL
);

CREATE TABLE users (
	users_id	INTEGER NOT NULL,
	name	TEXT NOT NULL,
	PRIMARY KEY(users_id AUTOINCREMENT)
);

CREATE TABLE orders (
	orders_id	INTEGER NOT NULL,
	users_id	INTEGER NOT NULL,
	status	INTEGER,
	PRIMARY KEY(orders_id AUTOINCREMENT)
);
