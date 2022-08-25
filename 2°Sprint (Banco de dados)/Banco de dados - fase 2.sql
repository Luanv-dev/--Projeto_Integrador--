create database METech
create table produtos(
	id int primary key identity,
	nome varchar(50) not null,
	descricao varchar(140) not null,
	preco decimal not null,
	categoria varchar(50) not null,
	review varchar(100) not null
	)
	drop table produtos
	create table produtos(
	id int primary key identity,
	nome varchar(50) not null,
	descricao varchar(140) not null,
	preco decimal not null,
	categoria varchar(50) not null,
	review varchar(100) null,
	imagem varchar (200) null
	)
	create table login(
	id int primary key identity,
	usuario varchar(50) not null,
    senha varchar(8)not null
	)		