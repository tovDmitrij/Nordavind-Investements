## Установка "ручками"

### ===Клиент===
Нужен установленный на ПК node.js и npm
```
cd app/client
npm install
npm start
```
### ===Сервер===
Нужен установленный Asp.Net Core 7 на ПК
```
cd app/server
```
Запустить решение app.sln (пакеты NuGet сами подтянутся)


### ===БД===

Нужен PostgreSQL 15 и pgAdmin4 (https://www.enterprisedb.com/downloads/postgres-postgresql-downloads)

Для реализации БД необходимо её создать с наименованием *nordavind_investements*, а после загрузить скрипты *create.sql* и *insert.sql*, находящиеся в *app/server/database/scripts/nordavind_investements*.

Опциональна БД для логгирования ошибок *nordavind_investements_logs*, скрипты которой находятся в *app/server/database/scripts/nordavind_investements_logs*.



## Установка через Docker (НЕ ДОДЕЛАНО)

docker-compose up --build

**Клиент**
cd app/client
docker build . -t nord_ist_client_image
docker run -p 3000:3000 nord_ist_client_image

**Сервер**
cd app/server
docker
docker

**База данных**

## :floppy_disk: Архитектура БД

<div align="center">

![nordavind_investements_db_design](https://user-images.githubusercontent.com/86602542/230714116-9dab8a54-317d-422a-9b90-23dbf099885c.svg)

</div>

## :game_die: Архитектура сервера (на 12.04.23)

<div align="center">

![nordavind-inv-api](https://user-images.githubusercontent.com/86602542/231350545-6e2d9f05-63a8-4344-806c-577baf45bc5c.svg)

</div>

Архитектура сервера **монолитная**. Для реализации сервера необходимо установить *Asp.Net Core 7*. Остальное должно само подтянуться при загрузке решения.

- *server/api* - непосредственно апишка. Сюда пишутся только контроллёры.
- *server/components* - всё, что не контроллёры, выносится в отдельные компоненты
- *server/components/api.logger.error* - логгер ошибок
- *server/components/database.context* - взаимодействие с основной БД
- *server/components/database.context.logs* - взаимодействие с БД логов
- *server/components/misc.security* - хеширование паролей
- *server/database* - скрипты для БД Postgres




## :desktop_computer: Архитектура клиента

Архитектура клиента **классическая**, т.е. "архитектура без архитектуры"

- *./src/API* - запросы к API
- *./src/pages* - страницы
- *./src/router/routes.js* - приватные и публичные маршруты для авторизованного и не- пользователя соответственно
- *./src/components/context* - контекст авторизации пользователя в системе
- *./src/components/hooks* - различные кастомные хуки (useFetching нужен для обработки запросов к API)
- *./src/components/UI* - все формочки, таблички и прочее
- *./src/components/UI/tables* - непосредственно таблички
- *./src/components/UI/forms* - непосредственно формочки

Для запросов к API необходимо использовать кастомный хук *useFetching* (*src/components/hooks/useFetching*), который в качестве параметра принимает анонимную функцию (в к-рой выполняется непосредственно *fetch*). За примерами смотрите *.\src\pages\directory\DirectoryPage.jsx*.

Сами запросы лежат в классе APIService.js (*./src/API*)




## :computer: Стек технологий
### :desktop_computer: Фронтенд
```
ReactJs
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
RabbitMQ
Entity Framework
Tailwind
```