from mysql
WORKDIR /MySql
COPY . .
ENV MYSQL_DATABASE=recimage\
	MYSQL_ROOT_PASSWORD=root
ADD init.sql /docker-entrypoint-initdb.d
CMD ["mysqld"]
