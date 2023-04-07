## :floppy_disk: Архитектура БД

<div align="center">

![nordavind_investements_db_design](https://user-images.githubusercontent.com/86602542/230631052-de931f58-3ef8-4005-afba-f7985177a3e1.svg)

</div>

## :game_die: Архитектура бэка
- server
  - api - непосредственно апишка. Сюда пишутся только контроллёры.
  - components - всё, что не контроллёры, выносится в отдельные компоненты
  - database - скрипты для БД Postgres
