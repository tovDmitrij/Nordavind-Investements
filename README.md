## :floppy_disk: Архитектура БД

<div align="center">

![nordavind_investements_db_design](https://user-images.githubusercontent.com/86602542/230556147-b1c89235-d235-49d0-a295-65da74a8540c.svg)

</div>

## :game_die: Архитектура бэка
- server
  - api - непосредственно апишка. Сюда пишутся только контроллёры.
  - components - всё, что не контроллёры, выносится в отдельные компоненты
  - database - скрипты для БД Postgres
