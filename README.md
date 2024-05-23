# Информационная система по школьному предмету "Физика"
Данная информационная система разработана на языке программирования C# для помощи в изучении физики и решении задач. Система предоставляет возможность использования специальных калькуляторов и просмотра теории.
![image](https://github.com/Perchik7731/InformationSystem/assets/169958476/147d8e8d-3c3c-45cb-af8d-7f4083628e15)


# [Скриншоты](https://disk.yandex.ru/d/gOs-_174Zu3mgA)
# Функциональность
1. Навигация: Пользователь имеет возможность удобного перемещения между темами по вкладкам.

2. Калькулятор з-на Ома: Пользователь может использовать специальный калькулятор для рассчета Напряжения, Сопротивления и Силы тока по закону Ома.

3. Конвертатор значений: В системе пользователь может с легкостью переводить значения в степени.

4. Содержание: Система выводит из базы данных содежание тем, которые можно будет просматривать.

# Технические детали
* Язык програмирования c#.
* База данных: SQLite (с использованием библиотеки System.Data.Sqlite
* Калькулятор
* Конвертер

# Принцип работы базы данных в программе
```
class Database
{
    public Database()
    {
        using (var connection = new SQLiteConnection("Data Source=database.db;Version=3;"))
        {
            connection.Open();
            using (var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS topics (name TEXT PRIMARY KEY, content TEXT)", connection))
            {
                command.ExecuteNonQuery();
            }
            using (var command = new SQLiteCommand("INSERT OR IGNORE INTO topics (name, content) VALUES ('Тепловое движение. Температура', 'Содержимое темы...')", connection))
            {
                command.ExecuteNonQuery();
            }
            using (var command = new SQLiteCommand("INSERT OR IGNORE INTO topics (name, content) VALUES ('Внутренняя энергия', 'Содержимое темы...')", connection))
            {
                command.ExecuteNonQuery();
            }
            using (var command = new SQLiteCommand("INSERT OR IGNORE INTO topics (name, content) VALUES ('Способы изменения внутренней энергии тела', 'Содержимое темы...')", connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
```
Конструктор класса Database создает (если еще не создана) таблицу topics в базе данных database.db и вставляет три записи, если таких записей еще нет. Это достигается с помощью подключения к базе данных SQLite, выполнения команд SQL и автоматического управления ресурсами через блоки using.

# Как использовать
1. Установите необходимые зависимости, включая библиотеку System.Data.Sqlite
2. Запустите программу и воспользуйтесь функциональностью.

# Автор
Сергей Васильев
