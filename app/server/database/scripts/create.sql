--------------------------
-- СОЗДАНИЕ БАЗЫ ДАННЫХ --
--------------------------
/*create database nordavind_investements with
	owner = postgres
	encoding = 'UTF8'
	connection limit = -1
	IS_TEMPLACE = False;*/

create table if not exists users(
	id serial primary key,
	email text not null,
	password text not null,
	date timestamp default current_timestamp not null
);

create table if not exists currencies(
	id serial primary key,
	title text not null,
	short_title text not null
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

create table if not exists funds(
	id serial primary key,
	title text not null,
	description text not null
);

create table if not exists accounts(
	id integer primary key,
	type integer not null references account_types(id),
	currency_type integer not null references currencies(id),
	bot_type integer not null references trade_bots(id),
	condition_type integer not null references conditions(id),
	ownership_type integer not null references ownerships(id),
	title text not null,
	date timestamp default current_timestamp not null
);

create table if not exists events(
	id serial primary key,
	operation_type integer not null references operations(id),
	value decimal not null,
	description text,
	date timestamp default current_timestamp not null
);

create table if not exists main_events(
	id integer primary key references events(id),
	account_id integer not null references accounts(id),
	hold_interest boolean default true not null,
	link text
);

create table if not exists flip_events(
	id integer primary key references events(id),
	account_from integer not null references accounts(id),
	account_to integer not null references accounts(id),
	fund_type integer not null references funds(id)
);

create table if not exists sell_events(
	id integer primary key references events(id),
	bot_type integer not null references trade_bots(id)
);

create table if not exists pay_events(
	id integer primary key references events(id),
	link text not null
);

create table if not exists bargaining(
	id serial primary key,
	account_id integer not null references accounts(id),
	closed_trade_pl decimal,
	balance decimal,
	ib_commision decimal,
	share_bonus decimal,
	rebate_bonus decimal,
	ir_rebate_bonus decimal,
	vip_rebate_bonus decimal,
	date timestamp default current_timestamp not null
);

create table if not exists investors(
	id serial primary key,
	surname text not null,
	name text,
	patronymic text,
	description text,
	date timestamp default current_timestamp not null
);

create table if not exists account_investors(
	id serial primary key,
	investor_id integer not null references investors(id),
	account_id integer not null references accounts(id),
	percent decimal not null,
	description text,
	date timestamp default current_timestamp not null
);

create table if not exists investor_events(
	id serial primary key,
	investor_id integer not null references investors(id),
	event_id integer not null references events(id),
	description text
);



-------------------
-- ПРЕДСТАВЛЕНИЯ --
-------------------
--Детализация по счёту
create or replace view view_account_details as
	select a.id "A/C No", a.title, at.title type, os.title ownership, cc.short_title currency, ct.title condition, tb.title bot, 
	(
		select sum(e.value)
		from events e
		where e.account_id = a.id and e.operation_type = (select id from operations where title = 'Ввод средств')
	)
	-
	(
		select sum(e.value)
		from events e
		where e.account_id = a.id and e.operation_type = (select id from operations where title != 'Ввод средств')
	) value, 
	(
		select sum(b.closed_trade_pl)
		from bargaining b
		where b.account_id = a.id
	) percents
	from accounts a
		left join account_types at on a.type = at.id
		left join ownerships os on a.ownership_type = os.id
		left join currencies cc on a.currency_type = cc.id
		left join conditions ct on a.condition_type = ct.id
		left join trade_bots tb on a.bot_type = tb.id;
	
--События на ввод и вывод средств со счетов
create or replace view view_history_main_events as
	select e.id event_id, i.surname||' '||i.name||' '||i.patronymic investor, e.date, o.title op_title, e.value, me.account_id "A/C No"
	from accounts a
		left join main_events me on me.account_id = a.id
		left join events e on e.id = me.id
		left join account_investors ai on ai.account_id = a.id
		left join investor_events ie on ie.event_id = e.id
		left join investors i on i.id = ai.investor_id
		left join operations o on o.id = e.operation_type
	
--События на переброс средств со счёта на счёт
create or replace view view_history_flip_events as
	select e.id event_id, e.date, o.id op_id, o.title op_title, e.value, fe.account_from "A/C X", fe.account_to "A/C Y"
	from accounts a
		left join flip_events fe on fe.account_from = a.id
		left join events e on e.id = fe.id
		left join account_investors ai on ai.account_id = a.id
		left join investor_events ie on ie.event_id = e.id
		left join investors i on i.id = ai.investor_id
		left join operations o on o.id = e.operation_type
		
--События на оплату ЗП сотрудникам
create or replace view view_history_pay_events as
	select e.id event_id, e.date, o.id op_id, o.title op_title, e.value, pe.link
	from pay_events pe
		left join events e on pe.id = e.id
		left join operations o on o.id = e.operation_type

--События на продажу ботов
create or replace view view_history_sell_events as
	select e.id event_id, e.date, o.id op_id, o.title op_title, e.value, tb.id bot_id, tb.title bot_title
	from sell_events se
		left join events e on se.id = e.id
		left join trade_bots tb on tb.id = se.bot_type
		left join operations o on o.id = e.operation_type
	
--Список результатов торгов (эксель страница "Торги")
create or replace view view_history_bargaining as
	...
	
--Диаграмма
create or replace view view_diagram as
	select ... investors_value, ... our_value, ... investors_percent, ... our_percent, ... bonus
	from 
	
	
	
----------------------------
-- ПОЛЬЗОВАТЕЛЬ С ПРАВАМИ --
----------------------------
create user user_default with password 'jwu7iSQ';
grant all privileges on all tables in schema public to user_default;
grant all privileges on all sequences in schema public to user_default;