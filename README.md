# SupplierOfferTracker

/****************************/
Тестовое задание
/****************************/

Реализация Web Api с двумя основными бизнес объектами:

----------------------------------------------------------------

Модель сущности «Оффер»:

Id (int) - поле генерируется системой

Марка (строка)

Модель (строка)

Поставщик (справочник)

Дата регистрации (дата и время)

Таблицу «Оффер» заполнить 15 тестовыми значениями

----------------------------------------------------------------

Модель справочника «Поставщик»

Id (int) - поле генерируется системой

Наименование (строка)

Дата создания (дата и время)

Справочник «Поставщик» заполнить 5 тестовыми значениями

----------------------------------------------------------------


----------------------------------------------------------------

Созданы три основных метода работы с объектами:

1) Метод создания оффера.
2) Метод с поиском. Метод возвращает все записи офферов со всеми доступными полями и полем количество записей всего. Поиск должен работать по полям: Марка, Модель, Поставщик
3) Метод со списком популярных поставщиков. Метод возвращает троих поставщиков (наименование и количеством офферов у каждого) с наибольшим количеством офферов.

----------------------------------------------------------------
