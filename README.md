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

Для реализации БД необходимо её создать с наименованием *nordavind_investements*, а после загрузить скрипты *create.sql* и *insert.sql*, находящиеся по адресу *app/server/database/scripts*.

## :game_die: Архитектура сервера

<div align="center">

![nordavind-inv-api](https://user-images.githubusercontent.com/86602542/231350545-6e2d9f05-63a8-4344-806c-577baf45bc5c.svg)

</div>

Архитектура сервера **монолитная**. Для реализации сервера необходимо установить *Asp.Net Core 7*. Остальное должно само подтянуться при загрузке решения.

- *server/api* - непосредственно апишка. Сюда пишутся только контроллёры.
- *server/components* - всё, что не контроллёры, выносится в отдельные компоненты
- *server/database* - скрипты для БД Postgres

## Архитектура клиента

Архитектура клиента **классическая**, т.е. все элементы складываются в общие папки по смыслу. Например, все формы заполнения лежат в *src/components/UI/forms*.
Потому как в клиенте настроена маршрутизация на основе сессии, то существует два списка маршрутов: приватные и публичные *src/router/routes.js*. При добавлении новой страницы в проект, необходимо в список приватных маршрутов добавить новый элемент для этой страницы.