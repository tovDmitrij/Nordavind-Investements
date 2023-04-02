## :floppy_disk: Архитектура БД (не окончательная))) )

<div align="center">

![Main](https://user-images.githubusercontent.com/86602542/228007385-de4b31be-a295-4e78-a0ba-54e82ab601db.svg)

</div>

## :game_die: Архитектура бэка
- server
  - api - непосредственно апишка. Сюда пишутся только контроллёры!
  - components - всё, что не контроллёры, выносится в отдельные компоненты
  - database - скрипты для БД Postgres
