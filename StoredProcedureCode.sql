// stored procedure

// ------------------create stored procedure----------------------

create procedure spgetStudent
as
begin
select s_id,s_name,s_age from students;
end

// -------------------use created stored procedure----------------------

spgetStudent;


// -------------------stored procedure with single parameter-------------------

create proc spgetStudentById
@id int
as
begin
select * from students where s_id = @id;
end

spgetStudentById 402;


// -----------------stired procedure with multuple parameter------------------

create procedure spGETstudentByIdandName
@id int, 
@name nvarchar(50)
as
begin
select * from students where s_id = @id and s_name = @name;
end

spGETstudentByIdandName 406 , "Devendra";



create proc spGetStudentByFacultyId
@f_id nchar(10) 
as
begin
select * from facultyDetail where f_id = @f_id;
end

spGetStudentByFacultyId 1;

drop proc spGetStudentByFacultyId;