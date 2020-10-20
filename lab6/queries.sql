--1. (#15)  Напишите SQL запросы  для решения задач ниже. 

INSERT INTO PC ("cpu", "memory", "hdd") 
 VALUES ('1600', '2000', '500'),
		('2400', '3000', '800'),
		('3200', '3000', '1200'),
		('2400', '2000', '500');
		
--1) Тактовые частоты CPU тех компьютеров, у которых объем памяти 3000 Мб. Вывод: id, cpu, memory

SELECT id, cpu, memory
FROM PC 
WHERE memory = 3000;


--2) Минимальный объём жесткого диска, установленного в компьютере на складе. Вывод: hdd

SELECT min(hdd)
FROM PC;

--3) Количество компьютеров с минимальным объемом жесткого диска, доступного на складе. Вывод: count, hdd

SELECT count(hdd), min(hdd)
FROM PC
WHERE (SELECT min(hdd) FROM pc) = hdd;


--2.  Напишите SQL-запрос, возвращающий все пары (download_count, user_count), 
--    удовлетворяющие следующему условию: 
  --  user_count — общее ненулевое число пользователей, сделавших 
  --  ровно download_count скачиваний 19 ноября 2010 года.

INSERT INTO track_downloads (track_id, user_id, download_time)
VALUES 
	(1, 213, date('2010-10-19')),
	(2, 321, date('2010-11-19')),
	(3, 111, date('2014-01-01')),
	(4, 111, date('2010-10-11')),
	(5, 413, date('2010-11-19')),
	(6, 321, date('2010-11-19')),
	(7, 444, date('2010-11-19'));
	
SELECT download_count, count(user_id) as user_count
FROM (SELECT user_id, count(download_id) as download_count
      FROM track_downloads
      WHERE date(download_time) = '2010-11-19'
      GROUP BY user_id)
GROUP BY download_count;

-- 3. (#10) Опишите разницу типов данных DATETIME и TIMESTAMP

-- MySQL:

-- DATETIME занимает 8 байт и не зависит от временной зоны. 
-- Отображается так же как было сохранено.

-- TIMESTAMP занимает 4 байта, равное количеству секунд, начиная 1970-01-01 00:00:00 UTC. При получении из базы отображается с учётом часового пояса.

--(#20)  Необходимо создать таблицу студентов (поля id, name) и таблицу курсов (поля id, name). Каждый студент может посещать несколько курсов. Названия курсов и имена студентов - произвольны.

INSERT INTO students(name)
 VALUES ('Паша'),
		('Маша'),
		('Саша'),
		('Маша'),
		('Игорь'),
		('Гена');

INSERT INTO courses(name)
 VALUES ('Дипломатия'),
		('История'),
		('Топология');

INSERT INTO students_on_courses(id_course, id_student)
 VALUES (1, 1),
		(1, 2),
		(1, 3),
		(2, 4),
		(3, 1),
		(3, 2),
		(3, 3),
		(3, 4),
		(3, 5),
		(3, 6);

--Написать SQL запросы: 
--    1. отобразить количество курсов, на которые ходит более 5 студентов
SELECT count(DISTINCT id_course) as "curses_count"
FROM students_on_courses
GROUP BY id_course
HAVING (COUNT(id_course) >= 5);
 --   2. отобразить все курсы, на которые записан определенный студент.
 SELECT courses.name
 FROM courses, students_on_courses, students
 WHERE courses.id_course = students_on_courses.id_course
 AND students.id_student = students_on_courses.id_student
 AND students.name = 'Паша';
 
-- 5. (5#) Может ли значение в столбце(ах), на который наложено ограничение foreign key, равняться null? Привидите пример. 
	 
--Может, если на столбец не наложено ограничение not null

DROP TABLE foreign_key;
DROP TABLE foreign_key_user;

CREATE TABLE foreign_key (
	id INTEGER PRIMARY KEY,
	foreign_key_user_id INTEGER,
	FOREIGN KEY (foreign_key_user_id) REFERENCES foreign_key_user(id)
);

CREATE TABLE foreign_key_user (
	id	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT)
);

INSERT INTO foreign_key_user (id)
VALUES (NULL);

--6. (#15) Как удалить повторяющиеся строки с использованием ключевого слова Distinct?
--Приведите пример таблиц с данными и запросы.


SELECT DISTINCT id_course
FROM students_on_courses;

-- Есть две таблицы:
--   users - таблица с пользователями (users_id, name)
--  orders - таблица с заказами (orders_id, users_id, status)
--  1) Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице orders имеют status = 0
--  2) Выбрать всех пользователей из таблицы users, у которых больше 5 записей в таблице orders имеют status = 1

INSERT INTO users (name)
VALUES 
	('Виталий'),
	('Громяко'),
	('Гордон'),
	('Кихот'),
	('Евгений');

INSERT INTO orders (users_id, status)
VALUES 
	(1, 0),
	(2, 0),
	(3, 0),
	(4, 0),
	(5, 1),
	(2, 1),
	(3, 1),
	(4, 1),
	(5, 1),
	(5, 1),
	(5, 1),
	(5, 1),
	(5, 1);

SELECT DISTINCT users.*
FROM orders, users
WHERE users.users_id NOT IN (
    SELECT users_id
    FROM orders
    WHERE status <> 0);
	
SELECT users.name
FROM orders, users
WHERE users.users_id = orders.users_id
AND orders.status = 1
GROUP BY orders.users_id, users.name
HAVING COUNT(orders.status) > 5;

--8. (#10)  В чем различие между выражениями HAVING и WHERE?

-- WHERE выбирает и группирует строки, выполняется до того, как будет получен результат операции
-- HAVING фильтрует полученный результат