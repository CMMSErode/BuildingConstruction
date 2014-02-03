CREATE TABLE Company
(
	ID INT NOT NULL,
	Code VARCHAR(10) NOT NULL,
	Name VARCHAR(60) NOT NULL,
	Creator INT NULL,
	Created DATETIME NULL,
	IsActive BIT NULL
)


go 


CREATE TABLE CompanyType
(
	ID INT NOT NULL,
	Code VARCHAR(10) NOT NULL,
	Name VARCHAR(60) NOT NULL,
	CompanyID int not null,
	Creator INT NULL,
	Created DATETIME NULL,
	IsActive BIT NULL
)

go


CREATE TABLE Estimation(
	[ID] [int] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Site] [nvarchar](50) NOT NULL,
	[QualityType] [nvarchar](50) NOT NULL,
	[Units] [int] NOT NULL,
	[UnitType] [nvarchar](50) NOT NULL,
	[RatePerUnit] [int] NOT NULL,
	[TotalCost] [int] NOT NULL,
	[Creator] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL
)

go

insert into Company values(1,'YY','Yes & Yes',null,GETDATE(),1)
insert into CompanyType values(1,'Suplier','Supliers',1,null,GETDATE(),1)
insert into CompanyType values(2,'Customer','Customers',1,null,GETDATE(),1)

update CompanyType set Creator=0
update Company set Creator=0

select CT.Code,CT.Name from Company C
join CompanyType CT on C.ID=CT.CompanyID



