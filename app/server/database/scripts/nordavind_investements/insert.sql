insert into account_types(title, description) values('Торговый', 'Основной тип счёта, через который ведётся торговля');
insert into account_types(title, description) values('Affiliate', 'счёт, на который приходят различные реферальные вознаграждения');

insert into currencies(title, short_title) values('Dollar', 'USD');
insert into currencies(title, short_title) values('Cent', 'USC');

insert into ownerships(title, description) values('Инвестор', 'Счёт принадлежит некоторому количеству инвесторов');
insert into ownerships(title, description) values('Собственный', 'Счёт лично компании');

insert into trade_bots(title, description) values('Siperfast', '...');
insert into trade_bots(title, description) values('Argo', '...');
insert into trade_bots(title, description) values('FastFlow', '...');
insert into trade_bots(title, description) values('Accuflow', '...');

insert into operations(title, description) values('Внесение средств', '...');
insert into operations(title, description) values('Вывод средств', '...');
insert into operations(title, description) values('Вывод процентов', '...');
insert into operations(title, description) values('Переброс', '...');

insert into funds(title, description) values('Проценты', 'Заработанные посредством торгов средства');
insert into funds(title, description) values('Тело', 'Внесённые инвесторами средства на счёт');

insert into conditions(title, value, description) values('X%', 1, 'X должен задаваться от 1 до 100, где X % - это то, что получает инвестор. Т.е. процент');
insert into conditions(title, value, description) values('Y/Y', 1, 'Y должен задаваться от 1 до 5, где Y - это количество соинвесторов, в т.ч. мы. Т.е. доля');
insert into conditions(title, value, description) values('16%', 0.16, 'Инвестора будут получать 16% с прибыли');
insert into conditions(title, value, description) values('1/4', 0.25, 'Инвестора будут получать 1/4 доли с прибыли');