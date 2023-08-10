@echo off
start sqlcmd -E -S localhost -i ..\SQL\QLKEODUA_CoDuLieu.sql
start sqlcmd -E -S localhost -i ..\SQL\QL_KEODUA_WEB.sql
start sqlcmd -E -S localhost -i ..\SQL\QL_KEODUA_CoDuLieu.sql