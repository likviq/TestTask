# TestTask
Реалізація системи з тестами(.net + react)

Короткий опис структури таблиць:
База даних складається з п'яти таблиць, але моделей тільки 4(між таблицями користувачів і тестів існує зв'язок багато до багатьох).
Кожний тест може мати багато запитань, а запитання, відповідно, відповідей, тобто між парами таблиць 
"тести" і "запитання", "запитання" і "відповіді" є зв'язок багато до одного. На кожне запитання може бути декілька правильний відповідей.

Уся логіка побудована на тому, щоб контролери не працювали напряму з об'єктами бази даних та самою базою, а усе це здійснювалось за допомогою сервісів, 
які, у свою чергу, вже мають доступ до бази. Тобто було реалізовано mvc патерн.