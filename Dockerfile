FROM postgres:15

ENV POSTGRES_PASSWORD 123456
ENV POSTGRES_DB nordavind_investements
EXPOSE 3005
COPY /app/server/database/scripts/create.sql /docker-entrypoint-initdb.d/
COPY /app/server/database/scripts//insert.sql /docker-entrypoint-initdb.d/