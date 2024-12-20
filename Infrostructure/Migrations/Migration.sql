create table Products
(
    Id serial primary key ,
Name varchar(50).
Price decimal,
Stock int 
);
create table Orders
(
    Id serial primary key ,
    ProductId   int references Products(Id),
    Quantity int,
    TotalPrice decimal,
    OrderDate date
);


insert into Products(Name, Stock) values (@Name, @Stock);
select * from Products;
select * from Products where Id=@Id;
update Products set Name=@Name, Stock=@Stock where Id=@Id;
delete from Products where Id=@Id;


insert into Orders( ProductId, Quantity, TotalPrice, OrderDate) values ( @ProductId, @Quantity,(select Price from Products where id = @ProductId)*@Quantity, @OrderDate);
select * from Orders;
select * from Orders where Id=@Id;
update Orders set ProductId=@ProductId, Quantity=@Quantity, TotalPrice=@TotalPrice,OrderDate=@OrderDate where Id=@Id;
delete from Orders where Id=@Id;

(select price from Products where id = @ProductId)