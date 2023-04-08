## :floppy_disk: Архитектура БД

<div align="center">

![nordavind_investements_db_design](https://user-images.githubusercontent.com/86602542/230714116-9dab8a54-317d-422a-9b90-23dbf099885c.svg)

</div>

## :game_die: Архитектура бэка
- server
  - api - непосредственно апишка. Сюда пишутся только контроллёры.
  - components - всё, что не контроллёры, выносится в отдельные компоненты
  - database - скрипты для БД Postgres
