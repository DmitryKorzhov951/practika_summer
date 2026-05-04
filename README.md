# Прокат автомобилей

Минимальный учебный проект на C# / WinForms + SQL Server.

## Что есть

**3 таблицы:**
- `Klienty` — клиенты (ФИО, телефон, паспорт)
- `Avtomobili` — автомобили (марка, гос. номер, цена в день, свободен/занят)
- `Prokat` — прокат (кто взял, какую машину, даты, цена)

**1 запрос (`vw_Prokat`)** — список прокатов с именами клиентов и марками автомобилей.

**Формы:**
- `MainForm` — главное меню с кнопками
- `TableForm` — универсальная форма для редактирования любой из трёх таблиц
- `ProkatViewForm` — просмотр запроса
- `AboutForm` — «О программе»

## Запуск

1. Открыть `Database/CarRentalDB.sql` в SSMS и выполнить — создастся БД с тестовыми данными.
2. Открыть `CarRentalApp.sln` в Visual Studio 2022.
3. F5.

При необходимости поменять строку подключения в `CarRentalApp/App.config`.

## Файлы

```
Database/CarRentalDB.sql
CarRentalApp.sln
CarRentalApp/
  CarRentalApp.csproj
  App.config
  Program.cs
  Db.cs
  MainForm.cs
  TableForm.cs
  ProkatViewForm.cs
  AboutForm.cs
```
