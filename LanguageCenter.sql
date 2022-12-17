----------------------------------TẠO DATABASE----------------------------------
create database LanguageCenter
go
use LanguageCenter
go

-- Courses
create table Courses(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(40) not null,
	Target float not null,
	No_Lessons int not null check (No_Lessons >= 0),
	Price int not null check(Price >= 0),
);
go

--Roles
create table Roles(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(50) not null,
);
go

-- Accounts
create table Accounts (
	Username varchar(100) primary key,
	Password varchar(100)  not null,
	RoleID int not null,
	foreign key (RoleID) references Roles(ID) , 
);
go

-- Student 
create table Students(
	Username varchar(100) primary key,
	Date_Birth date not null,
	Address nvarchar(100) not null,
	Name nvarchar(50) not null,
	Email varchar(50) unique not null,
	Phone varchar(11) unique not null,
	check(10 = len(Phone) or len(Phone) = 11),
	foreign key(Username) references Accounts(Username)  on update cascade ,
);
go 

-- Teacher
create table Teachers(
	Username varchar(100) primary key,
	Date_Birth date not null,
	Address nvarchar(100) not null,
	Name nvarchar(50) not null,
	Email varchar(50) unique not null,
	Phone varchar(11) unique not null,
	check(10 = len(Phone) or len(Phone) = 11),
	foreign key(Username) references Accounts(Username) on update cascade,
);
go

-- Staff 
create table Staff(
	Username varchar(100) primary key,
	Date_Birth date not null,
	Address nvarchar(100) not null,
	Name nvarchar(50) not null,
	Email varchar(50) unique not null,
	Phone varchar(11) unique not null,
	Position nvarchar(40) not null,
	check(10 = len(Phone) or len(Phone) = 11),
	foreign key(Username) references Accounts(Username) on update cascade ,
);
go

-- Classes
create table Classes(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(100) not null,
	Start_Date date not null,
	End_Date date not null,
	Username varchar(100) not null,
	Course_ID int not null,
	WeekDays varchar(10) not null,
	Start_Time time not null,
	End_Time time not null,
	ClassRoom varchar(20) not null,
	No_Students int not null,
	foreign key(Username) references Teachers(Username)  on update cascade on delete cascade,
	foreign key(Course_ID) references Courses(ID) ,
);
go

-- Class_student
create table Class_Students(
	Class_ID int,
	Username varchar(100),
	primary key (Class_ID, Username),
	foreign key(Class_ID) references Classes(ID) on delete cascade,
	foreign key(Username) references Students(Username)  on update cascade ,
);
go

-- Payment_method
create table Payment_Methods(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(100) not null
);
go

-- Payment
create table Payments(
	ID int IDENTITY(1,1) primary key,
	Payment_Date date not null,
	Amount int not null check(Amount >= 0),
	Payment_Method_ID int not null,
	Status bit not null,
	Username varchar(100) not null,
	foreign key(Payment_Method_ID) references Payment_Methods(ID),
	foreign key(Username) references Students(Username) on update cascade ,
);
go

----------------------------------CONSTRAINTS----------------------------------

-- ràng buộc vị trí cố định: Admin, HR, Marketing, Trainer, Sales, Receptionist

alter table Staff 
add constraint CheckPosition 
check (Position like 'Admin' or Position like 'HR' or Position like 'Marketing' or
Position like 'Trainer' or Position like 'Sales' or Position like 'Receptionist');

-- ràng buộc check password phải có chữ hoa, chữ thường, số, một vài loại kí tự đặc biệt và hơn 6 ký tự
alter table Accounts 
add constraint CheckPassword_Accounts 
check (Password like '%[0-9]%' and Password like '%[A-Z]%' collate Latin1_General_BIN2
and Password like '%[!@#$%^&*()-_+=.,;:~]%' and len(Password)>6);

-- ràng buộc check email đúng format và chứa một vài ký tự đặc biệt
alter table Students 
add constraint checkEmailStudent 
check (Email like '%_@__%.__%'and Email not like '% %' and PATINDEX('%[^a-z,0-9,@,.,]%', Email) = 0);

alter table Staff 
add constraint checkEmailStaff 
check (Email like '%_@__%.__%'and Email not like '% %' and PATINDEX('%[^a-z,0-9,@,.,]%', Email) = 0);

alter table Teachers 
add constraint checkEmailTeacher 
check (Email like '%_@__%.__%'and Email not like '% %' and PATINDEX('%[^a-z,0-9,@,.,]%', Email) = 0);

--ràng buộc check số điện thoại chỉ chứa số
alter table Students add constraint checkPhoneStudent check (PATINDEX('%[^0-9]%', Phone) = 0);

alter table Staff add constraint checkPhoneStaff check (PATINDEX('%[^0-9]%', Phone) = 0);

alter table Teachers add constraint checkPhoneTeacher check (PATINDEX('%[^0-9]%', Phone) = 0);

-- check lịch học
alter table Classes add constraint checkDay check (PATINDEX('%[^2-7, -]%', Weekdays) = 0);

-- check thời gian của lớp học
alter table Classes add constraint checkDayStartEnd check (Start_Date < End_Date);

alter table Classes add constraint checkTimeStartEnd check (Start_Time < End_Time);
go

----------------------------------TRIGGERS----------------------------------

--check thang điểm của các khóa học khác nhau dựa theo tên khóa học
create trigger checkTargetCourse on Courses
after update, insert as
declare @name nvarchar(40), @target float
select @name = ne.Name, @target = ne.Target
from inserted ne
begin 
	if @target < 0 
		rollback
	else	
		begin
			if @name like '%IELTS%' 
				if @target > 9
					rollback
			if @name like '%TOEIC%' and @target != CAST(@target as int) 
				rollback
			if @name like '%TOEIC%' and @name like '%LR%'  and @target > 990 
				rollback
			if @name like '%TOEIC%' and  @name like '%SW%' and @target >400
				rollback
			if @name like '%TOEIC%' and  @name not like '%SW%' and  @name not like '%LR%' 
				rollback
		end
end
go

--trigger chuyển đổi trạng thái thanh toán học phí, cộng dồn theo số tiền đóng và so sánh với tổng tiền của các khóa học đã đăng ký
create trigger Status_Payment
on Payments for insert, update
as 
begin
	declare @current_Amount int;
	declare @price int;
	declare @cid int;
	
	select @current_Amount = sum(dbo.Payments.Amount) from dbo.Payments, inserted where inserted.Username = Payments.Username
	
	select @price = sum(c.Price)
	from inserted, Class_Students cs inner join Classes cl on cs.Class_ID = cl.ID inner join Courses c on cl.Course_ID = c.ID
	where inserted.Username = cs.Username

	if @current_Amount >= @price
	begin
		update dbo.Payments set dbo.Payments.Status = 1 from inserted, dbo.Payments where dbo.Payments.ID = inserted.ID
	end
	else
	begin
		update dbo.Payments set dbo.Payments.Status = 0 from inserted, dbo.Payments where dbo.Payments.ID = inserted.ID
	end

end
go

--trigger tăng tự động số học viên của lớp học khi thêm học viên mới
create trigger IncreaseNoStudent
on dbo.Class_Students for insert, update
as
begin
	declare @noStudents int;
	declare @classId int;
	select @noStudents = dbo.Classes.No_Students, @classId = inserted.Class_ID from dbo.Classes, inserted where inserted.Class_ID = dbo.Classes.ID
	if @noStudents = 10
	begin 
		raiserror (N'This class is full of students!',16,1)
		rollback
	end
	
	else
	begin
		update dbo.Classes set dbo.Classes.No_Students += 1 from dbo.Classes where @classId = dbo.Classes.ID
	end
end
go

--trigger giảm tự động số học viên của lớp học khi xóa học viên 
create trigger DecreaseNoStudent
on dbo.Class_Students for delete, update
as
	update dbo.Classes set dbo.Classes.No_Students -= 1 from deleted, dbo.Classes where deleted.Class_ID = dbo.Classes.ID
go

-- Tạo các roles
create role Adminstrator
create role Staff
create role Teacher
create role Student

--Phân quyền toàn bộ cho admin
GRANT ALTER, VIEW DEFINITION, EXECUTE TO Adminstrator

--Phân quyền toàn bộ cho nhân viên
GRANT ALTER, VIEW DEFINITION, EXECUTE TO Staff

--Phân quyền cho giảng viên
--Phân quyền mức view
GRANT SELECT on dbo.Class_Students to Teacher 
GRANT SELECT on dbo.Classes to Teacher 
GRANT SELECT on dbo.Courses to Teacher 
GRANT SELECT on dbo.Roles to Teacher 
GRANT SELECT on dbo.Students to Teacher 
GRANT SELECT on dbo.Teachers to Teacher 
GRANT SELECT on dbo.Accounts to Teacher 

--Phân quyền cho học viên
--Phân quyền mức view
GRANT SELECT on dbo.Class_Students to Student 
GRANT SELECT on dbo.Accounts to Student 
GRANT SELECT on dbo.Classes to Student 
GRANT SELECT on dbo.Courses to Student 
GRANT SELECT on dbo.Roles to Student 
GRANT SELECT on dbo.Students to Student 
GRANT SELECT on dbo.Teachers to Student 
GRANT SELECT on dbo.Payment_Methods to Student 
GRANT SELECT on dbo.Payments to Student 


----------------------------------NHẬP DỮ LIỆU ----------------------------------

insert into Roles values ('Staff');
insert into Roles values ('Teacher');
insert into Roles values ('Student');

insert into Payment_Methods values ('Mobile Banking');
insert into Payment_Methods values ('Cash');
insert into Payment_Methods values ('Visa');
go

--Đầu tiên phải khởi tạo tài khoản của admin sa 
insert into Accounts values ('sa', 'Mtl@091202', 1);
insert into Staff values ('sa', '2012-10-25', 'Tien Giang', 'Le Minh Tuong', 'lmt2002@gmail.com', '0834091202', 'Admin');
go
-----------------------------------------------COURSE MANAGE-----------------------------------------------
--view lấy thông tin của khóa học
create view Course_Info as
select ID, Name as CourseName, ROUND(Target,1) as Target, No_Lessons as NoLessons, Price from Courses
go

--procedure thêm khóa học
create procedure AddCourse @coursename nvarchar(40), @target float, @nolessons int, @price int as
begin
	begin try
		insert into Courses values (@coursename, @target, @nolessons, @price);
	end try
	begin catch
		DECLARE @CustomMessage VARCHAR(1000),
			@CustomError INT,
			@CustomState INT;
		SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
		SET @CustomError = 54321;
		SET @CustomState = 1;
		THROW @CustomError, @CustomMessage, @CustomState;
	end catch
end
go

--nhap du lieu
exec AddCourse 'TOEIC LR', '650', '30', '3000000'; 
exec AddCourse 'TOEIC LR', '900', '60', '7000000'; 
exec AddCourse 'TOEIC SW', '250', '40', '3000000'; 
exec AddCourse 'TOEIC SW', '400', '70', '7000000'; 
exec AddCourse 'IELTS', '6.5', '70', '10000000'; 
exec AddCourse 'IELTS', '9.0', '100', '12000000'; 
go

--procedure cập nhật thông tin khóa học
create procedure UpdateCourse @courseid int , @coursename nvarchar(40), @target float, @nolessons int, @price int as
begin
	if exists (select Courses.ID from Courses where Courses.ID = @courseid)
		begin
			update Courses
			set Name = @coursename, Target = @target, No_Lessons=@nolessons, Price=@price where ID = @courseid
		end
	else
		begin
			DECLARE @CustomMessage VARCHAR(1000),
				@CustomError INT,
				@CustomState INT;
			SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
			SET @CustomError = 54321;
			SET @CustomState = 1;
			THROW @CustomError, @CustomMessage, @CustomState;
		end
end
go

--procedure + transaction thực hiện xóa khóa học
create procedure deleteCOURSE_sequently @id int
as
begin try
	begin transaction
	delete from Classes where Classes.Course_ID = @id;
	delete from Courses where Courses.ID = @id;
	commit transaction
end try
begin catch
	DECLARE @CustomMessage VARCHAR(1000),
		@CustomError INT,
		@CustomState INT;
	SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
	SET @CustomError = 54321;
	SET @CustomState = 1;
	rollback;
	THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

--procedure lấy thông tin khóa học thông qua tên khóa học
create procedure GetCourseByCoureName @coursename nvarchar(40) as
select * from Course_Info where CourseName= @coursename;
go

--procedure lấy thông tin những khóa học có mức giá cao hơn hoặc bằng mức giá được nhập
create procedure GetCourseByMinPrice @price int as
begin try
	select * from Course_Info where Price >=  @price;
end try
begin catch
	DECLARE @CustomMessage VARCHAR(1000),
		@CustomError INT,
		@CustomState INT;
	SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
	SET @CustomError = 54321;
	SET @CustomState = 1;
	THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

--procedure lấy thông tin những khóa học có mức giá thấp hơn hoặc băng mức giá được nhập
create procedure GetCourseByMaxPrice @price int as
begin try
	select * from Course_Info where Price <=  @price;
end try
begin catch
	DECLARE @CustomMessage VARCHAR(1000),
		@CustomError INT,
		@CustomState INT;
	SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
	SET @CustomError = 54321;
	SET @CustomState = 1;
	THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

----------------------------------TEACHER MANAGE FORM----------------------------------

--procedure thêm giảng viên vào sql server
create procedure addTeacherAcountToServer @username varchar(30)
as begin 
	begin try
		declare @login nvarchar(4000)
		set @login = N'CREATE LOGIN ' + QUOTENAME(@username) + ' WITH PASSWORD = ' + QUOTENAME('Mtl@091202', '''') + ', default_database = ' + QUOTENAME('LanguageCenter')
		exec(@login)
		declare @user nvarchar(4000)
		set @user = N'CREATE USER ' + QUOTENAME(@username) + ' FOR LOGIN ' + QUOTENAME(@username)
		exec(@user)
		exec sp_addrolemember 'Teacher', @username
	end try
	begin catch
		rollback
	end catch
end
go

-- procedure xóa user trong sql server
create procedure DeleleUserOnServer @username varchar(30)
as begin 
	begin try
		declare @user nvarchar(4000)
		set @user = N'DROP USER' + QUOTENAME(@username) + ';'
		exec(@user)
		declare @login nvarchar(4000)
		set @login = N'DROP LOGIN ' + QUOTENAME(@username) + ';'
		exec(@login)
	end try
	begin catch
		rollback
	end catch
end
go

--procedure + transaction thực hiện xóa tài khoản của giảng viên
create procedure deleteACCOUNT_TEACHER_sequently @username nvarchar(50)
as
if exists (select Accounts.Username from Accounts where Username = @username)
	begin
		begin transaction
		delete from Teachers where Username=@username;
		delete from Accounts where Username = @username;
		exec DeleleUserOnServer @username;
		commit transaction
	end
else
	begin
		DECLARE @CustomMessage VARCHAR(1000),
			@CustomError INT,
			@CustomState INT;
		SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
		SET @CustomError = 54321;
		SET @CustomState = 1;
		rollback;
		THROW @CustomError, @CustomMessage, @CustomState;
	end
go

--procedure lấy thông tin giảng viên thông qua tên giảng viên
create procedure GetTeacherByTeacherName @name nvarchar(50)
as
begin
	select distinct * from Teacher_Info where TeacherName= @name
end
go

--procedure lấy thông tin giảng viên thông qua tên khóa học
create procedure GetTeacherByCourseName @name nvarchar(50)
as
begin
	select distinct Username, TeacherName, DateOfBirth, Address, Email, Phone, Salary from TeacherAndSalary where CourseName= @name
end
go

--procedure lấy thông tin giảng viên thông qua tên lớp học
create procedure GetTeacherByClassName @name nvarchar(50)
as
begin
	select distinct Username, TeacherName, DateOfBirth, Address, Email, Phone, Salary from TeacherAndSalary where ClassName= @name
end
go

--procedure thêm giảng viên
create procedure AddTeacher @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), 
@email varchar(50), @phone varchar(11)
as
begin
	begin try
		if IS_MEMBER('sysadmin') = 0
				begin
					EXEC master..sp_addsrvrolemember @loginame = @username, @rolename = N'sysadmin'
				end
		begin transaction
		insert into Accounts values (@username, 'Mtl@091202', 2);
		insert into Teachers values (@username, @dateofbirth, @address, @name, @email, @phone);
		exec addTeacherAcountToServer @username
		EXEC master..sp_dropsrvrolemember @loginame = @username, @rolename = N'sysadmin'
		commit transaction
	end try
	begin catch
		DECLARE @CustomMessage VARCHAR(1000),
			@CustomError INT,
			@CustomState INT;
		SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
		SET @CustomError = 54321;
		SET @CustomState = 1;
		ROLLBACK;
		THROW @CustomError, @CustomMessage, @CustomState;
	end catch
end
go

exec AddTeacher 'teacher1',  'Pham Quynh Huong', '01-31-2002', 'Vung Tau', 'huong@gmail.com', '0912334898';
exec AddTeacher 'teacher2',  'Nguyen Van Lam', '01-01-2002', 'Quy Nhon', 'lam@gmail.com', '0912334777';
exec AddTeacher 'teacher3',  'Le Quang Tung', '01-01-2002', 'Binh Dinh', 'tung@gmail.com', '0912334090';
exec AddTeacher 'teacher4',  'Le Minh Tuong', '12-09-2002', 'Tien Giang', 'tuong@gmail.com', '0912334121';
go


--procedure cập nhật thông tin giảng viên
create procedure UpdateTeacher @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), @email varchar(50), @phone varchar(11)
as
begin
	if exists (select Accounts.Username from Accounts where Username = @username)
		begin
			update Teachers
			set Name=@name, Date_Birth=@dateofbirth, Address=@address, Email = @email, Phone=@phone where Username=@username
		end
	else
		begin
			DECLARE @CustomMessage VARCHAR(1000),
				@CustomError INT,
				@CustomState INT;
			SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
			SET @CustomError = 54321;
			SET @CustomState = 1;
			THROW @CustomError, @CustomMessage, @CustomState;
		end
end
go

--function tính lương giảng viên theo công thức lương = 5000000* số lớp giảng viên đó dạy
create function TinhLuong (@noclass as int)
returns int
as begin
	declare @result int = 5000000*@noclass
	if @noclass is null
		set @result =0
	return @result
end;
go

--view lấy ra thông tin tổng hợp của giảng viên
create view Teacher_Info as
select Teachers.Username,  Teachers.Name as TeacherName,convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address, Email, 
Phone, ISNULL(LUONG,0) as Salary from Teachers left join (select *, 
dbo.TinhLuong(A.HSL) as LUONG from (select Username, count (*) as HSL from Classes group by Username)A)B on 
B.Username= Teachers.Username
go

--view lấy ra thông tin tổng hợp của giảng viên kèm lương
create view TeacherAndSalary as
select Teachers.Username,  Teachers.Name as TeacherName,convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address, Email, 
Phone, ISNULL(LUONG,0) as Salary, Classes.Name as ClassName, Courses.Name as CourseName from Teachers left join (select *, 
dbo.TinhLuong(A.HSL) as LUONG from (select Username, count (*) as HSL from Classes group by Username)A)B on 
B.Username= Teachers.Username inner join Classes on B.Username = Classes.Username inner join Courses 
on Classes.Course_ID=Courses.ID;
go

-----------------------------------------------CLASS MANAGE-----------------------------------------------

--view lấy ra thông tin kết hợp của lớp học
create view Class_Info as
select Classes.ID, Classes.Name as ClassName, convert (varchar(100),Start_Date, 103) as StartDate, convert (varchar(100),End_Date, 103) as EndDate, WeekDays, convert (varchar(100),Start_Time, 108) as StartTime,
convert (varchar(100),End_Time, 108) as EndTime, ClassRoom, No_Students as NoStudents, Courses.Name as CourseName, ROUND(Target,1) as Target, Teachers.Name as TeacherName from Classes left join Courses 
on Classes.Course_ID=Courses.ID left join Teachers on Teachers.Username=Classes.Username;
go

--procedure thêm lớp học
create procedure AddClass @classname nvarchar(100), @startdate date, @enddate date, @weekdays varchar(10), 
@starttime time(7), @endtime time(7), @classroom varchar(20), @coursename nvarchar(40),
@target float, @teachername nvarchar(50) as
begin
	declare @courseid int, @teacherusename varchar(100)
	set @courseid = (select Courses.ID from Courses where Name = @coursename and Target = @target)
	set @teacherusename = (select Username from Teachers where Name = @teachername)
	begin try
			insert into Classes values (@classname, @startdate, @enddate, @teacherusename, @courseid, @weekdays, @starttime, @endtime, @classroom, 0);
	end try
	begin catch
			DECLARE @CustomMessage VARCHAR(1000),
				@CustomError INT,
				@CustomState INT;
			SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
			SET @CustomError = 54321;
			SET @CustomState = 1;
			THROW @CustomError, @CustomMessage, @CustomState;
	end catch
end
go

exec AddClass 'Lop 01', '10-24-2022', '11-30-2022', '2-4-6',  '17:0:0', '19:0:0', 'P01', 'TOEIC LR', '650', 'Pham Quynh Huong';
exec AddClass 'Lop 02', '10-24-2022', '11-30-2022', '3-5-7',  '17:0:0', '19:0:0', 'P02', 'TOEIC LR', '900', 'Pham Quynh Huong';
exec AddClass 'Lop 03', '10-24-2022', '11-30-2022', '2-4-6',  '17:0:0', '19:0:0', 'P03', 'TOEIC SW', '250', 'Le Quang Tung';
exec AddClass 'Lop 04', '10-24-2022', '11-30-2022', '3-5-7',  '17:0:0', '19:0:0', 'P04', 'TOEIC SW', '400', 'Le Quang Tung';
exec AddClass 'Lop 05', '10-24-2022', '11-30-2022', '2-4-6',  '17:0:0', '19:0:0', 'P05', 'IELTS', '9.0', 'Nguyen Van Lam';
exec AddClass 'Lop 06', '10-24-2022', '11-30-2022', '3-5-7',  '17:0:0', '19:0:0', 'P06', 'IELTS', '6.5', 'Le Minh Tuong';
go

--procedure cập nhật lớp học
create procedure UpdateClass @classid int, @classname nvarchar(100), @startdate date, @enddate date, @weekdays varchar(10), @starttime time(7), @endtime time(7), 
@classroom varchar(20), @coursename nvarchar(40), @target float, @teachername nvarchar(50) as
begin
	declare @courseid int, @teacherusename varchar(100)
	set @courseid = (select Courses.ID from Courses where Name = @coursename and Target = @target)
	set @teacherusename = (select Username from Teachers where Name = @teachername)
	begin try
		update Classes
		set Name = @classname, Start_Date=@startdate, End_Date=@enddate, Username=@teacherusename, Course_ID=@courseid, WeekDays=@weekdays, Start_Time=@starttime,
		End_Time = @endtime, ClassRoom=@classroom where Classes.ID = @classid
	end try
	
	begin catch
		DECLARE @CustomMessage VARCHAR(1000),
			@CustomError INT,
			@CustomState INT;
		SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
		SET @CustomError = 54321;
		SET @CustomState = 1;
		THROW @CustomError, @CustomMessage, @CustomState;
	end catch
end
go

--procedure + transaction thực hiện xóa lớp học
create procedure deleteCLASS_sequently @id int
as
delete from Classes where ID = @id;
go


--procedure lấy thông tin lớp học thông qua tên lớp học
create procedure GetClassBYClassName @classname nvarchar(100) as
select * from Class_Info where ClassName=@classname
go

--procedure lấy thông tin lớp học thông qua tên phòng học
create procedure GetClassBYClassRoom @classroom varchar(20) as
select * from Class_Info where ClassRoom=@classroom
go

--procedure lấy thông tin lớp học thông qua tên khóa học
create procedure GetClassBYCourseName @coursename nvarchar(40) as
select * from Class_Info where CourseName=@coursename
go

--procedure lấy thông tin lớp học thông qua tên giảng viên
create procedure GetClassBYTeacherName @teachername nvarchar(100) as
select * from Class_Info where TeacherName=@teachername
go

----------------------------------STUDENT MANAGE FORM----------------------------------
--procedure + transaction thực hiện xóa thông tin của học viên ở lớp học cụ thể
create procedure deleteSTUDENT_View @username nvarchar(100), @classname nvarchar(100)
as
begin try
	declare @classid int set @classid = (select ID from Classes where Name = @classname)
	delete from Class_Students where Username = @username and Class_ID = @classid;
end try
begin catch
	DECLARE @CustomMessage VARCHAR(1000),
		@CustomError INT,
		@CustomState INT;
	SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
	SET @CustomError = 54321;
	SET @CustomState = 1;
	THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

--procedure + transaction thực hiện tài khoản của học viên
create procedure deleteACCOUNT_STUDENT_sequently @username nvarchar(50)
as
if exists (select Accounts.Username from Accounts where Username = @username)
	begin
		begin transaction
		delete from Class_Students where Class_Students.Username = @username ;
		delete from Payments where Payments.Username = @username;
		delete from Students where Students.Username = @username;
		delete from Accounts where Accounts.Username = @username;
		exec DeleleUserOnServer @username;
		commit transaction
	end
else
	begin
		DECLARE @CustomMessage VARCHAR(1000),
			@CustomError INT,
			@CustomState INT;
		SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
		SET @CustomError = 54321;
		SET @CustomState = 1;
		rollback;
		THROW @CustomError, @CustomMessage, @CustomState;
	end 
go

--view chứa thông tin tổng hợp học viên
create view Student_Info as
select Students.Username, Students.Name as StudentName, convert (varchar(100),Students.Date_Birth, 103) as DateOfBirth, 
Students.Address,  Students.Email, Students.Phone, Courses.Name as CourseName, Classes.Name as ClassName, Teachers.Name as TeacherName
from Students 
inner join Class_Students on Students.Username=Class_Students.Username
inner join Classes on Class_Students.Class_ID=Classes.ID 
inner join Teachers on Classes.Username=Teachers.Username
inner join Courses on Course_ID = Courses.ID;
go

--procedure liệt kê một vài thông tin của học viên
create procedure GetListStudent as
select Username, StudentName, DateOfBirth, Address,  Email, Phone, ClassName 
from Student_Info;
go

--procedure lấy thông tin học viên thông qua tên học viên
create procedure GetStudentByStudentName @name nvarchar(50)
as begin
select distinct Username, StudentName, DateOfBirth, Address,  Email, Phone, ClassName from Student_Info
where StudentName= @name
end
go

--procedure lấy thông tin học viên thông qua tên giảng viên 
create procedure GetStudentByTeacherName @name nvarchar(50)
as begin
select distinct Username, StudentName, DateOfBirth, Address,  Email, Phone, ClassName from Student_Info
where Student_Info.TeacherName = @name
end
go

--procedure lấy thông tin học viên thông qua tên khóa học
create procedure GetStudentByCourseName @name nvarchar(50)
as
begin
select distinct Username, StudentName, DateOfBirth, Address,  Email, Phone, ClassName from Student_Info
where Student_Info.CourseName = @name
end
go

--procedure lấy thông tin học viên thông qua tên lớp học
create procedure GetStudentByClassName @name nvarchar(50)
as
begin
select distinct Username, StudentName, DateOfBirth, Address,  Email, Phone from Student_Info
where Student_Info.ClassName = @name
end
go

--procedure thêm học viên vào sql server
create procedure addStudentAcountToServer @username varchar(30)
as begin 
	begin try
		declare @login nvarchar(4000)
		set @login = N'CREATE LOGIN ' + QUOTENAME(@username) + ' WITH PASSWORD = ' + QUOTENAME('Mtl@091202', '''') + ', default_database = ' + QUOTENAME('LanguageCenter')
		exec(@login)
		declare @user nvarchar(4000)
		set @user = N'CREATE USER ' + QUOTENAME(@username) + ' FOR LOGIN ' + QUOTENAME(@username)
		exec(@user)
		exec sp_addrolemember 'Student', @username
	end try
	begin catch
		rollback
	end catch
end
go

--procedure thêm học viên
create procedure AddStudent @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), 
@email varchar(50), @phone varchar(11), @classname nvarchar(100)
as
begin
	declare @check bit = 0
	if IS_MEMBER('sysadmin') = 0
			begin
				set @check = 1
				EXEC master..sp_addsrvrolemember @loginame = @username, @rolename = N'sysadmin'
			end

	declare @classid int = -1
	set @classid = (select ID from Classes where Name = @classname)
	if @classid = - 1
		THROW 51000, 'Class id does not exist.', 1;  	
	if not exists (select Username from Students where Username=@username)
		
		begin try
			begin transaction
			insert into Accounts values (@username, 'Mtl@091202', 3);
			insert into Students values (@username, @dateofbirth, @address, @name, @email, @phone);
			insert into Class_Students values (@classid, @username);
			insert into Payments values (getdate(), 0, 1, 0, @username);
			exec addStudentAcountToServer @username
			commit transaction
		end try
		begin catch
			rollback;
			THROW 51000, 'Add not successfully.', 1;  
		end catch	
	else
		begin
		
		if not exists (select * from Class_Students where Class_ID = @classid and Username=@username)
			begin try
				begin transaction
				insert into Class_Students values (@classid, @username);
				insert into Payments values (GETDATE(), 0, 1, 0, @username);
				commit transaction
			end	try
			begin catch
				rollback
			end catch
		else
			begin
			rollback;
			THROW 51000, 'Class id have existed.', 1;
		end
	end
	if @check = 1
		EXEC master..sp_dropsrvrolemember @loginame = @username, @rolename = N'sysadmin'
end
go

exec AddStudent 'student1', 'le minh tuong', '12-09-2002', 'hoang dieu 2', 'lmt@gmail.com', '0941144562', 'Lop 01';
exec AddStudent 'student1', 'le minh tuong', '12-09-2002', 'hoang dieu 2', 'lmt@gmail.com', '0941144562', 'Lop 02';
exec AddStudent 'student1', 'le minh tuong', '12-09-2002', 'hoang dieu 2', 'lmt@gmail.com', '0941144562', 'Lop 03';

exec AddStudent 'student2', 'nguyen van lam', '07-07-2002', 'to ngoc van', 'nvl@gmail.com', '0998765403', 'Lop 02';
exec AddStudent 'student2', 'nguyen van lam', '07-07-2002', 'to ngoc van', 'nvl@gmail.com', '0998765403', 'Lop 05';

exec AddStudent 'student3', 'le quang tung', '01-01-2002', 'quan 9', 'lqt@gmail.com', '0983625172', 'Lop 01';
exec AddStudent 'student3', 'le quang tung', '01-01-2002', 'quan 9', 'lqt@gmail.com', '0983625172', 'Lop 03';
exec AddStudent 'student3', 'le quang tung', '01-01-2002', 'quan 9', 'lqt@gmail.com', '0983625172', 'Lop 06';

exec AddStudent 'student4', 'pham quynh huong', '01-31-2002', 'dang van bi', 'pqh@gmail.com', '0143892012', 'Lop 01';
exec AddStudent 'student4', 'pham quynh huong', '01-31-2002', 'dang van bi', 'pqh@gmail.com', '0143892012', 'Lop 03';
exec AddStudent 'student4', 'pham quynh huong', '01-31-2002', 'dang van bi', 'pqh@gmail.com', '0143892012', 'Lop 04';
exec AddStudent 'student4', 'pham quynh huong', '01-31-2002', 'dang van bi', 'pqh@gmail.com', '0143892012', 'Lop 06';
go

--procedure cập nhật thông tin học viên
create procedure UpdateStudent @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), @email varchar(50), @phone varchar(11), @classname varchar(100)
as
begin
	if exists (select Accounts.Username from Accounts where Username = @username)
		begin try
		begin transaction
			declare @classid int = (select ID from Classes where Name = @classname);
			update Class_Students
			set Class_ID= @classid where Class_Students.Username=@username
			update Students
			set Name=@name, Date_Birth=@dateofbirth, Address=@address, Email = @email, Phone=@phone where Username=@username
			commit transaction
		end try
		begin catch
			DECLARE @CustomMessage VARCHAR(1000),
					@CustomError INT,
					@CustomState INT;
			SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
			SET @CustomError = 54321;
			SET @CustomState = 1;
			rollback;
			THROW @CustomError, @CustomMessage, @CustomState;
		end catch
	else
		THROW 51000, ' Username does not exist.', 1;  		
end
go

----------------------------------STAFF MANAGE FORM----------------------------------
--procedure + transaction thực hiện xóa tài khoản của nhân viên
create procedure deleteACCOUNT_STAFF_sequently @username nvarchar(50)
as
begin try
	begin transaction
	delete from Staff where Username=@username;
	delete from Accounts where Username = @username;
	exec DeleleUserOnServer @username;
	commit transaction
end try
begin catch
	DECLARE @CustomMessage VARCHAR(1000),
		@CustomError INT,
		@CustomState INT;
	SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
	SET @CustomError = 54321;
	SET @CustomState = 1;
	THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

--function tính lương nhân viên theo quy chuẩn
create function Tinh_Luong (@position as nvarchar(40))
returns int
as begin
	declare @result int
	if @position = 'Admin'
		set @result = 12000000
	if @position = 'HR'
		set @result = 10000000
	if @position = 'Marketing'
		set @result = 9000000
	if @position = 'Sales' or @position = 'Trainer'
		set @result = 7000000
	if @position = 'Receptionist'
		set @result = 4000000
	return @result
end;
go

--view lấy ra thông tin của nhân viên
create view Staff_Info as
select Username, Name as StaffName, convert (varchar(100),Date_Birth, 103) as DateOfBirth, Address, Email, Phone, Position, dbo.Tinh_Luong(Position) as Salary
from Staff
go

--procedure lấy ra thông tin của nhân viên thông qua tên nhân viên
create procedure GetStaffByStaffName @name nvarchar(50)
as
select * from Staff_Info where StaffName =@name
go

--procedure lấy ra thông tin của nhân viên thông qua vị trí
create procedure GetStaffByPosition @name nvarchar(50)
as
select * from Staff_Info where Position =@name
go

--procedure thêm nhân viên vào sql server
create procedure addStaffAcountToServer @username varchar(30), @position varchar(30)
as begin
	declare @login nvarchar(4000)
	set @login = N'CREATE LOGIN ' + QUOTENAME(@username) + ' WITH PASSWORD = ' + QUOTENAME('Mtl@091202', '''') + ', default_database = ' + QUOTENAME('LanguageCenter')
	exec(@login)
	declare @user nvarchar(4000)
	set @user = N'CREATE USER ' + QUOTENAME(@username) + ' FOR LOGIN ' + QUOTENAME(@username)
	exec(@user)
	
	if @position = 'Admin'
		begin
			EXEC sp_addrolemember 'Adminstrator', @username
			EXEC master..sp_addsrvrolemember @loginame = @username, @rolename = N'sysadmin'
		end
	else
		EXEC sp_addrolemember 'Staff', @username
end
go

--procedure thêm nhân viên
create procedure AddStaff @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), 
@email varchar(50), @phone varchar(11), @position nvarchar(40)
as 
begin try
	begin transaction
	insert into Accounts values (@username, 'Mtl@091202', 1);
	insert into Staff values (@username, @dateofbirth, @address, @name, @email, @phone, @position);
	exec addStaffAcountToServer @username, @position
	commit transaction
end try
begin catch
	DECLARE @CustomMessage VARCHAR(1000),
		@CustomError INT,
		@CustomState INT;
	SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
	SET @CustomError = 54321;
	SET @CustomState = 1;
	rollback;
	THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

exec AddStaff 'admin1', 'Le Minh Tuong', '12-09-2002', 'Hoang Dieu 2', 'admin1@gmail.com', '0834091899', 'Admin';
exec AddStaff 'staff1', 'Le Minh Tuong', '12-09-2002', 'Hoang Dieu 2', 'staff1@gmail.com', '0834091990', 'HR';
exec AddStaff 'staff2', 'Pham Quynh Huong', '01-31-2002', 'Dang Van Bi', 'staff2@gmail.com', '0941156762', 'Marketing';
exec AddStaff 'staff3', 'Le Quang Tung', '01-01-2002', 'Quan 9', 'staff3@gmail.com', '0877600192', 'Trainer';
exec AddStaff 'staff4', 'Nguyen Van Lam', '01-01-2002', 'To Ngoc Van', 'staff4@gmail.com', '0762541389', 'Sales';
exec AddStaff 'staff5', 'Le Minh Tuong', '12-09-2002', 'Hoang Dieu 2', 'staff5@gmail.com', '0872616381', 'Receptionist';
go

--procedure cập nhật thông tin nhân viên
create procedure UpdateStaff @username varchar(100), @name nvarchar(50), @dateofbirth date, @address nvarchar(100), @email varchar(50), @phone varchar(11),
@position nvarchar(40) as
begin
	if exists (select Accounts.Username from Accounts where Username = @username)
		begin try
			update Staff
			set Name=@name, Date_Birth=@dateofbirth, Address=@address, Email = @email, Phone=@phone, Position=@position where Username=@username
		end try
		begin catch
			DECLARE @CustomMessage VARCHAR(1000),
					@CustomError INT,
					@CustomState INT;
				SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
				SET @CustomError = 54321;
				SET @CustomState = 1;
				THROW @CustomError, @CustomMessage, @CustomState;
		end catch
	else
		THROW 51000, 'Username does not exist.', 1;  		
end
go

----------------------------------PAYMENTS MANAGE FORM----------------------------------
-- function trả về tên phương thức thanh toán
create function PaymentMethodName_byId (@id int)
returns nvarchar(20)
as begin
	declare @name nvarchar(20) 
	set @name = (select Payment_Methods.Name from Payment_Methods where Payment_Methods.ID = @id)
	return @name
end
go

--function trả về trạng thanh toán theo dạng chữ
create function TrangThaiThanhToan (@status bit)
returns nvarchar(30)
as begin 
declare @status_name nvarchar(30)
set @status_name = ''
if @status = 1
	begin 
		set @status_name = N'Paid'
	end
if @status = 0
	begin 
		set @status_name = N'Unpaid'
	end
return @status_name
end
go

--view lấy ra thông tin thanh toán của học viên
create view PaymentsView
as
select ID ,Students.Username,Students.Name as StudentName, Students.Email, Students.Phone as Phone, 
Payments.Payment_Date as PaymentDate, Amount as Amount ,
[dbo].PaymentMethodName_byId(Payments.Payment_Method_ID) as PaymentMethod, 
[dbo].TrangThaiThanhToan(Payments.Status) as PaymentStatus
from Payments inner join Students on Students.Username = Payments.Username
go

-- procedure lấy thông tin thanh toán
create procedure getPayments
as begin 
select * from PaymentsView
end
go

-- procedure thêm thông tin thanh toán
create procedure InsertPayment @payment_date date, @amount int, @method_id int, @status int, @username nvarchar(30)
as 
begin try
	insert into Payments values(@payment_date, @amount, @method_id	, @status, @username)
end try
begin catch
	DECLARE @CustomMessage VARCHAR(1000),
		@CustomError INT,
		@CustomState INT;
	SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
	SET @CustomError = 54321;
	SET @CustomState = 1;
	THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

-- procedure cập nhật thông tin thanh toán
create procedure updatePayment @id int ,@payment_date date, @amount int, @method_id int, @username nvarchar(30)
as
begin try
	update Payments
	set Payment_Date = @payment_date, Amount = @amount, Payment_Method_ID = @method_id, Username = @username
	where ID = @id
end try
begin catch
	DECLARE @CustomMessage VARCHAR(1000),
		@CustomError INT,
		@CustomState INT;
	SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
	SET @CustomError = 54321;
	SET @CustomState = 1;
	THROW @CustomError, @CustomMessage, @CustomState;
end catch
go

-- procedure xóa thông tin thanh toán
create procedure deletePayment @id int
as begin
delete from Payments where Payments.ID = @id
end
go

--function lấy tên khóa học thông qua ID
create function getCourseName_byID (@id int) 
returns nvarchar(30)
as begin
	declare @name nvarchar(30)
	set @name = (select Courses.Name from Courses where Courses.ID = 1)
	return @name
end
go

--function lấy tên giảng viên thông qua username
create function getTeacherName_byUsername (@username nvarchar(30)) 
returns nvarchar(30)
as begin
	declare @name nvarchar(30)
	set @name = (select Teachers.Name from Teachers where Teachers.Username = @username)
	return @name
end
go

-- procedure lấy thông tin lớp học thông qua id lớp học
create procedure GetClassByClassID @id int
as begin
select * from ClassesView where ClassesView.ID = @id
end
go

-- procedure lấy ra lịch sử giao dịch của học viên cụ thể thông qua tên học viên
create procedure GetPaymentBYStudentName @name nvarchar(30)
as begin
select * from PaymentsView where PaymentsView.StudentName = @name
end
go

-- procedure lấy ra lịch sử giao dịch của học viên cụ thể thông qua số điện thoại
create procedure GetPaymentBYPhone @phone nvarchar(10)
as begin
select * from PaymentsView where PaymentsView.Phone = @phone
end
go

-- procedure lấy ra lịch sử giao dịch của học viên cụ thể thông qua phương thức thanh toán
create procedure GetPaymentBYPaymentMethod @method nvarchar(30)
as begin
select * from PaymentsView where PaymentsView.PaymentMethod = @method
end
go

-- procedure lấy ra lịch sử giao dịch của học viên cụ thể thông qua trạng thái thanh toán
create procedure GetPaymentByPaymentStatus @status nvarchar(30)
as begin
	if(@status = N'Paid' or @status = N'Unpaid')
		begin
			select * from PaymentsView where PaymentsView.PaymentStatus = @status
		end
	else
		begin 
			DECLARE @CustomMessage VARCHAR(1000),
				@CustomError INT,
				@CustomState INT;
			SET @CustomMessage = 'My Custom Text ' + ERROR_MESSAGE();
			SET @CustomError = 54321;
			SET @CustomState = 1;
			THROW @CustomError, @CustomMessage, @CustomState;
		end 
end
go


--function lấy thông tin thanh toán
create function getPayments_func()
returns table
as
return (
	select ID ,Students.Username,Students.Name as StudentName, Students.Email, Students.Phone as Phone, 
Payments.Payment_Date as PaymentDate, Amount as Amount, 
[dbo].PaymentMethodName_byId(Payments.Payment_Method_ID) as PaymentMethod, 
[dbo].TrangThaiThanhToan(Payments.Status) as PaymentStatus
from Payments inner join Students on Students.Username = Payments.Username
)
go

----------------------------------AllClass Form---------------------------------
-- procedure lấy thông tin tất cả các lớp học của giảng viên
create procedure getAllClasses
as 
select * from Class_Info
go

--view lấy ra những thông tin của lớp học
create view ClassesView
as
select Classes.ID, Classes.Name as ClassName, Classes.Start_Date as StartDate, Classes.End_Date as EndDate, [dbo].getTeacherName_byUsername(Classes.Username) 
as TeacherName, [dbo].getCourseName_byID(Classes.Course_ID) as CourseName, Classes.WeekDays, Classes.Start_Time, Classes.End_Time, Classes.ClassRoom, Classes.No_Students
from Classes
go

----------------------------------Student Schedule Form---------------------------------
--view lấy ra thông tin thời khóa biểu của tất cả học viên
create view StudentScheduleView 
as
select cs.Username as Username, cl.ID as ClassID, cl.Name as ClassName,c.Name as CourseName ,t.Name as TeacherName, 
cl.WeekDays, CONCAT(SUBSTRING(convert(varchar, cl.Start_Time ,108),1,5),' : ' ,SUBSTRING(convert(varchar, cl.End_Time ,108),1,5)) as Time, cl.ClassRoom as ClassRoom
from Class_Students cs inner join Classes cl on cs.Class_ID = cl.ID inner join Courses c on cl.Course_ID = c.ID inner join Teachers t on cl.Username = t.Username
go

-- procedure lấy thông tin thời khóa biểu của học viên cụ thể
create procedure getScheduleStudent (@name varchar(100))
as begin 
select * from StudentScheduleView where StudentScheduleView.Username= @name
end
go

----------------------------------Teacher Schedule Form---------------------------------
--view lấy ra thông tin thời khóa biểu của tất cả giảng viên
create view TeacherScheduleView
as
select t.Username as Username, cl.ID as ClassID, cl.Name as ClassName, cl.Course_ID as CourseID,c.Name as CourseName , 
cl.WeekDays as Date, CONCAT(SUBSTRING(convert(varchar, cl.Start_Time ,108),1,5),' : ' ,SUBSTRING(convert(varchar, cl.End_Time ,108),1,5)) as Time, cl.ClassRoom as ClassRoom
from Classes cl inner join Courses c on cl.Course_ID = c.ID inner join Teachers t on cl.Username = t.Username
go

-- procedure lấy thông tin thời khóa biểu của giảng viên cụ thể
create procedure getScheduleTeacher (@name varchar(100))
as begin 
	select * from TeacherScheduleView where TeacherScheduleView.Username = @name
end
go

----------------------------------Transaction History---------------------------------
--view lấy ra lịch sử giao dịch của tất cả học viên
create view PaymentView
as
select st.Username, pa.Payment_Date as PaymentDate, pa.Amount as Amount, pm.Name as PaymentMethod, pa.Status as PaymentStatus
from Students st inner join Payments pa on st.Username = pa.Username inner join Payment_Methods pm on pa.Payment_Method_ID = pm.ID
go

--procedure lấy ra lịch sử giao dịch của học viên cụ thể
create procedure GetTransactionHistory (@name varchar(100))
as begin 
select * from PaymentView where PaymentView.Username = @name
end
go

--------------------------------------------- ĐỔI PASSWORD----------------------------------------------------

--procedure thực hiện đổi password
create procedure ChangePassword @username varchar(100), @pass varchar(100)
as 
begin try 
	declare @check int
	set @check = 0
	declare @oldPass varchar(100)
	select @oldPass = Accounts.Password from Accounts where Username = @username
	update Accounts set Accounts.Password = @pass where Accounts.Username = @username
	if IS_MEMBER('sysadmin') = 0
		begin
			set @check = 1
			EXEC master..sp_addsrvrolemember @loginame = @username, @rolename = N'sysadmin'
		end
	declare @query varchar(100)
	set @query = 'ALTER LOGIN ' + QUOTENAME(@username) + ' WITH PASSWORD = '+'''' + @pass + '''' + ' OLD_PASSWORD = ' + '''' +@oldPass + '''';
	print @query
	exec(@query)
	if @check = 1
		EXEC master..sp_dropsrvrolemember @loginame = @username, @rolename = N'sysadmin'
end try
begin catch
	declare @err_mess varchar(1000);
	set @err_mess = 'Error ' + ERROR_MESSAGE();
	PRINT @err_mess;
	THROW;
	rollback
end catch
go

--------------------------------------------- PHÂN QUYỀN  PROC & VIEW----------------------------------------------------

--Phân quyền mức procedure cho staff
REVOKE EXECUTE on dbo.deleteACCOUNT_STAFF_sequently to Staff
REVOKE EXECUTE on dbo.GetStaffByStaffName  to Staff
REVOKE EXECUTE on dbo.GetStaffByPosition  to Staff
REVOKE EXECUTE on dbo.addStaffAcountToServer to Staff
REVOKE EXECUTE on dbo.AddStaff  to Staff
REVOKE EXECUTE on dbo.UpdateStaff  to Staff
REVOKE EXECUTE on dbo.Tinh_Luong   to Staff

-- Trên các view cho giảng viên
GRANT ALTER, VIEW DEFINITION, SELECT on dbo.Staff_Info  to Staff

--Phân quyền mức procedure cho giảng viên
GRANT EXECUTE on dbo.getScheduleTeacher to Teacher
GRANT EXECUTE on dbo.ChangePassword to Teacher
GRANT EXECUTE on dbo.getAllClasses to Teacher
GRANT EXECUTE on dbo.GetClassBYTeacherName to Teacher
GRANT EXECUTE on dbo.GetClassByClassID to Teacher
GRANT EXECUTE on dbo.GetClassByClassName to Teacher
GRANT EXECUTE on dbo.GetClassByCourseName to Teacher

-- Trên các view cho giảng viên
GRANT ALTER, VIEW DEFINITION, SELECT on dbo.TeacherScheduleView to Teacher

-- --Phân quyền mức procedure cho học viên
GRANT EXECUTE on dbo.getScheduleStudent to Student
GRANT EXECUTE on dbo.GetTransactionHistory to Student
GRANT EXECUTE on dbo.ChangePassword to Student

-- Trên các view cho học viên
GRANT ALTER, VIEW DEFINITION, SELECT on dbo.StudentScheduleView to Student
go