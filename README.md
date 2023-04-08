## :floppy_disk: Архитектура БД

<div align="center">

![nordavind_investements_db_design](https://user-images.githubusercontent.com/86602542/230709034-363ac979-0b52-4bdc-9260-8904b6d37c0b.svg)

</div>

## :game_die: Архитектура бэка
- server
  - api - непосредственно апишка. Сюда пишутся только контроллёры.
  - components - всё, что не контроллёры, выносится в отдельные компоненты
  - database - скрипты для БД Postgres
