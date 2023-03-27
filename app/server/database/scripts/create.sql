--наименование бд nordavind_investements



-------------
-- ТАБЛИЦЫ --
-------------
create table if not exists users(
	id serial primary key,
	surname text not null,
	name text not null,
	patronymic text,
	email text not null,
	password text not null,
	date timestamp default current_timestamp not null
);

create table if not exists currencies(
	id serial primary key,
	title text not null,
	short_title text not null
);

create table if not exists cources(
	cur_from integer not null references currencies(id),
	cur_to integer not null references currencies(id),
	value decimal not null,
	primary key(cur_from, cur_to)
);

create table if not exists account_types(
	id serial primary key,
	title text not null,
	description text not null
);

create table if not exists trade_bots(
	id serial primary key,
	title text not null,
	description text not null
);

create table if not exists conditions(
	id serial primary key,
	title text not null,
	value decimal not null,
	description text not null
);

create table if not exists ownerships(
	id serial primary key,
	title text not null,
	description text not null
);

create table if not exists operations(
	id serial primary key,
	title text not null,
	description text not null
);

create table if not exists accounts(
	id integer primary key,
	owner integer not null references users(id),
	type integer not null references account_types(id),
	currency integer not null references currencies(id),
	bot integer not null references trade_bots(id),
	condition integer not null references conditions(id),
	ownership integer not null references ownerships(id),
	title text not null,
	date timestamp default current_timestamp not null
);

create table if not exists investors(
	id serial primary key,
	user_id integer not null references users(id),
	account_id integer not null references accounts(id),
	date timestamp default current_timestamp not null
);

create table if not exists events(
	id serial primary key,
	type integer references operations(id),
	account_from integer not null references accounts(id),
	account_to integer references accounts(id),
	value decimal not null,
	hold_interest boolean not null,
	date timestamp default current_timestamp not null
);



-------------------
-- ПРЕДСТАВЛЕНИЯ --
-------------------
--Состояние по счёту
/*create or replace view view_account_info as
	select a.id "id", a.title title, at.title type, 
		os.title ownership, c.short_title currency, 
		dc.title condition, tb.title trade_bot,
		(
			select sum(value) from events
			where account_to = a.id
		)
		-
		(
			select sum(value) from events
			where account_from = a.id
		) balance,
		(
			select sum(value * )
		) percents
	from accounts a
		left join account_types at 				on a.type = at.id
		left join currencies c 					on a.currency = c.id
		left join trade_bots tb 				on a.bot = tb.id
		left join distribution_conditions dc 	on a.condition = dc.id
		left join ownerships os					on a.ownership = os.id
		left join events e						on a.id = e.account_to*/
		
	
	
----------------------------
-- ПОЛЬЗОВАТЕЛЬ С ПРАВАМИ --
----------------------------
create user user_default with password 'jwu7iSQ';
grant all privileges on all tables in schema public to user_default;
grant all privileges on all sequences in schema public to user_default;