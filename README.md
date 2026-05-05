# БД «Прокат автомобилей» (Вариант №17)

Учебный проект на C# (WinForms, .NET 6) + Microsoft SQL Server.

## Структура

```
Database/
  CreateDatabase.sql       — создаёт CarRentalDB.mdf со всеми таблицами и данными
CarRentalApp.sln
CarRentalApp/
  CarRentalApp.csproj
  App.config               — строка подключения к .mdf
  Program.cs               — точка входа: Заставка → Главная форма
  Db.cs                    — обёртка для работы с БД
  SplashForm.cs            — форма «Заставка» (стартовая)
  MainForm.cs              — главная кнопочная форма
  AboutForm.cs             — форма «О программе»
  Forms/
    SotrudnikiForm.cs      — ленточная форма Сотрудников
    SotrudnikiGridForm.cs  — табличная форма Сотрудников
    SotrudnikiReport.cs    — отчёт «Сотрудники»
```

## Запуск

1. Откройте `Database/CreateDatabase.sql` в SQL Server Management Studio.
2. На вверху скрипта поправьте путь `@path` (по умолчанию `C:\CarRentalDB\`) — туда положится `CarRentalDB.mdf`.
3. Создайте такую папку, выполните скрипт.
4. В `CarRentalApp/App.config` поправьте `AttachDbFilename=` на тот же путь к `.mdf`.
5. Откройте `CarRentalApp.sln` в Visual Studio 2022, нажмите F5.

## Что уже работает (этап 1)

- БД полностью создана: 7 таблиц, 3 запроса (vw_OtdelKadrov, vw_Avtopark, vw_AvtoVProkate), все данные.
- Заставка → Главная форма с вкладками «Формы» / «Отчёты».
- Кнопки **Выход / О программе / Гистограмма** внизу.
- Полностью реализована таблица **Сотрудники** в трёх видах (ленточная, табличная, отчёт).
- Остальные таблицы / запросы / фильтры — заглушки в меню.

## Что планируется на след. этапах

- Формы для остальных 6 таблиц (по образцу «Сотрудников»).
- Формы для 3 запросов и 5 фильтров.
- Гистограмма зарплат сотрудников.
