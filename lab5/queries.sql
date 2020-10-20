--3.  Подготовьте SQL запросы для заполнения таблиц данными.

DELETE FROM dvd;

DELETE FROM customer;

DELETE FROM offer;

INSERT INTO dvd ("title", "production_year")
 VALUES ('Властелин колец: возвращение короля', '2003'),
	    ('Гран Торино', '2008'),
	    ('Звёздные войны. Эпизод IV: Новая надежда', '1977'),
		('Тринадцать', '2010'),
		('Возмездие', '2010');
		
INSERT INTO customer ("first_name", "last_name", "passport_code", "registration_date")
 VALUES ('Киану', 'Ривз', 'B2091964', '22-02-2012'),
		('Уилл ', 'Смит', 'B25061968', '2-11-2019'),
		('Риз', 'Уизерспун', 'B22031976', '13-08-2016'),
		('Райан', 'Гослинг', 'B12111980', '19-03-2014');
	
INSERT INTO offer ("dvd_id", "customer_id", "offer_date", "return_date") 
 VALUES ('4', '1', '2013-02-12', '2013-02-15'),
		('5', '2', '2020-10-15', NULL),
		('3', '3', '2018-12-28', '2019-01-02'),
		('2', '3', '2020-09-11', '2020-09-12'),
		('1', '4', '2017-07-10', '2017-07-13'),
		('2', '4', '2017-07-10', '2017-07-13'),
		('5', '4', '2017-07-14', '2017-07-15');
	
--4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010, 
-- отсортированных в алфавитном порядке по названию DVD.

SELECT * 
FROM dvd
WHERE production_year = 2010
ORDER BY title ASC;

--5.  Подготовьте SQL запрос для получения списка DVD дисков, которые в настоящее время
-- находятся у клиентов.

SELECT dvd.*
FROM dvd, offer
WHERE offer.dvd_id = dvd.dvd_id 
AND return_date is NULL;

--6.  Напишите SQL запрос для получения списка клиентов, которые брали какие-либо DVD 
--диски в текущем году. В результатах запроса необходимо также отразить какие диски брали клиенты.
SELECT customer.*, dvd.*
FROM offer, dvd, customer
WHERE STRFTIME('%Y', DATE('now')) = STRFTIME('%Y', offer.offer_date)
AND customer.customer_id = offer.customer_id
AND dvd.dvd_id = offer.dvd_id;
