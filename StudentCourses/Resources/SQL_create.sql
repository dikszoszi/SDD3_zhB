IF OBJECT_ID('course', 'U') IS NOT NULL DROP TABLE course;
 
CREATE TABLE course (
    courseId NUMERIC(3) NOT NULL,
    courseShortName VARCHAR(200),
    courseLongName VARCHAR(200),
    credit INT NOT NULL
    CONSTRAINT COURSE_PRIMARY_KEY PRIMARY KEY (courseId)
    );
   
INSERT INTO course VALUES (1,'sztf1','Szoftver tervezés-és fejlesztés I.',6);
INSERT INTO course VALUES (2,'opre','Operációs rendszerek',5);
INSERT INTO course VALUES (3,'whp','Web programozás-és haladó fejlesztési technikák',4);
INSERT INTO course VALUES (4,'archi1','Számítógép architektúrák alapjai I.',2);
INSERT INTO course VALUES (5,'halal','Haladó algoritmusok',3);
INSERT INTO course VALUES (6,'fnyg','Formális nyelvek és gépek',2);
