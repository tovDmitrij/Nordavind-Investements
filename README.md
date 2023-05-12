## :floppy_disk: Архитектура БД

<div align="center">

![nordavind_investements_db_design](https://github.com/tovDmitrij/Nordavind-Investements/assets/86602542/c4b03491-7b95-4c68-98d0-b7ffe4107633)

</div>

## :cd: Установка БД

:bearded_person: **Win10**

Требуется установить PostgreSQL и pgAdmin4 (https://www.enterprisedb.com/downloads/postgres-postgresql-downloads)

Для реализации БД необходимо её создать с наименованием *nordavind_investements*, а после загрузить скрипты *create.sql* и *insert.sql*, находящиеся в *./app/server/database/scripts/nordavind_investements*.

:clown_face: **Linux**
```
TODO
```




## :game_die: Архитектура API

<div align="center">

![nordavind-inv-api](https://user-images.githubusercontent.com/86602542/231350545-6e2d9f05-63a8-4344-806c-577baf45bc5c.svg)

</div>

Архитектура API **монолитная**. Используется паттерн *repository*. Для реализации сервера необходимо установить *Asp.Net Core 7*. Остальное само подтянется при загрузке решения.

- *./app/server/api* - непосредственно апишка. Сюда пишутся только контроллёры.
- *./app/server/components* - всё, что не контроллёры, выносится в отдельные компоненты
- *./app/server/components/database.context* - взаимодействие с основной БД
- *./app/server/components/misc.security* - хеширование паролей

## :cd: Установка API

:bearded_person: **Win10**

Нужен установленный Asp.Net Core 7 на ПК
```
cd ./app/server
```
Запустить решение app.sln (пакеты NuGet сами подтянутся)

:clown_face: **Linux**
```
TODO
```




## :desktop_computer: Архитектура клиента

Архитектура клиента **классическая**, т.е. "архитектура без архитектуры". Используются *container-components*.

- *./app/client/src/API* - запросы к API
- *./app/client/src/pages* - страницы
- *./app/client/src/router/routes.js* - приватные и публичные маршруты для авторизованного и не- пользователя
- *./app/client/src/components/context* - контекст авторизации пользователя в системе
- *./app/client/src/components/hooks* - различные кастомные хуки (useFetching нужен для обработки запросов к API)
- *./app/client/src/components/UI* - все формочки, таблички и прочее
- *./app/client/src/components/UI/tables* - непосредственно таблички
- *./app/client/src/components/UI/forms* - непосредственно формочки

Для запросов к API необходимо использовать кастомный хук *useFetching* (*src/components/hooks/useFetching*), который в качестве параметра принимает анонимную функцию (в к-рой выполняется непосредственно *fetch*).

Сами запросы лежат в классе APIService.js (*./src/API*)

## :cd: Установка клиента

:bearded_person: **Win10**

Нужен установленный на ПК node.js и npm
```
cd ./app/client
npm install
npm start
```

:clown_face: **Linux**
```
TODO
```




## :computer: Стек технологий
### :desktop_computer: Фронтенд
```
React
```
### :hammer_and_wrench: Бекэнд
```
ASP.NET Core 7
```
### :floppy_disk: База данных
```
PostgreSQL 15
```
### :scroll: Прочее
```
Entity Framework
Tailwind
```
