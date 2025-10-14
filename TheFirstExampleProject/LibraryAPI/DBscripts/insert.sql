-- ===========================================
-- Вставка данных в Genres (жанры)
-- ===========================================
SET IDENTITY_INSERT [dbo].[Genres] ON;
INSERT INTO [dbo].[Genres] ([id_genre], [name]) VALUES
    (1, 'Фантастика'),
    (2, 'Детектив'),
    (3, 'Роман'),
    (4, 'Научная фантастика'),
    (5, 'Боевик');
SET IDENTITY_INSERT [dbo].[Genres] OFF;
GO

-- ===========================================
-- Вставка данных в Users (пользователи)
-- ===========================================
SET IDENTITY_INSERT [dbo].[Users] ON;
INSERT INTO [dbo].[Users] ([id_user], [name], [description]) VALUES
    (1, 'Иван Иванов', 'Любитель фантастики'),
    (2, 'Мария Петрова', 'Обожает детективы'),
    (3, 'Алексей Сидоров', 'Читает романы на ночь'),
    (4, 'Елена Кузнецова', 'Фанат научной фантастики'),
    (5, 'Дмитрий Морозов', 'Предпочитает боевики');
SET IDENTITY_INSERT [dbo].[Users] OFF;
GO

-- ===========================================
-- Вставка данных в Books (книги)
-- ===========================================
SET IDENTITY_INSERT [dbo].[Books] ON;
INSERT INTO [dbo].[Books] ([id_book], [title], [author], [description], [cost], [id_genre]) VALUES
    (1, 'Звездные войны', 'Джордж Лукас', 'Эпическая сага о борьбе добра и зла', 500, 1),
    (2, 'Шерлок Холмс', 'Артур Конан Дойль', 'Классический детектив', 350, 2),
    (3, 'Гордость и предубеждение', 'Джейн Остин', 'Роман о любви и обществе', 400, 3),
    (4, 'Дюна', 'Фрэнк Герберт', 'Эпическая научно-фантастическая сага', 600, 4),
    (5, 'Молчание ягнят', 'Томас Харрис', 'Психологический триллер', 450, 5);
SET IDENTITY_INSERT [dbo].[Books] OFF;
GO

-- ===========================================
-- Вставка данных в Logins (логины пользователей)
-- ===========================================
SET IDENTITY_INSERT [dbo].[Logins] ON;
INSERT INTO [dbo].[Logins] ([id_login], [login], [password], [id_user]) VALUES
    (1, 'ivan_ivanov', 'pass123', 1),
    (2, 'maria_petrova', 'secret456', 2),
    (3, 'alex_sidorov', 'mypassword789', 3),
    (4, 'elena_kuznetsova', 'booklover', 4),
    (5, 'dmitry_morozov', 'actionfan', 5);
SET IDENTITY_INSERT [dbo].[Logins] OFF;
GO

-- ===========================================
-- Вставка данных в RentLists (список аренд)
-- ===========================================
SET IDENTITY_INSERT [dbo].[RentLists] ON;
INSERT INTO [dbo].[RentLists] ([id_list], [date_start], [date_end], [id_book], [id_user]) VALUES
    (1, '2025-01-10', '2025-02-10', 1, 1),
    (2, '2025-01-15', '2025-02-15', 2, 2),
    (3, '2025-01-20', '2025-02-20', 3, 3),
    (4, '2025-01-25', '2025-02-25', 4, 4),
    (5, '2025-01-30', '2025-02-28', 5, 5);
SET IDENTITY_INSERT [dbo].[RentLists] OFF;
GO

-- ===========================================
-- Проверка: вывод всех таблиц
-- ===========================================
SELECT * FROM [dbo].[Genres];
SELECT * FROM [dbo].[Users];
SELECT * FROM [dbo].[Books];
SELECT * FROM [dbo].[Logins];
SELECT * FROM [dbo].[RentLists];
GO