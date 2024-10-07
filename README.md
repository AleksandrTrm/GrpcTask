## Запуск сервера
# 1. Открыть dockercompose файл
# 2. Установить миграции бд
# 3. Запустить сервер
## Запуск клиента
# 1. Запустить клиент
# 2. Отправить Post запрос на маршрут http://localhost:5064/packets со следующим содержимым
{
    "Packets" :
    [
        {
            "Timestamp" : "2018-12-10T13:46:00.000Z",
            "PacketSeqNum" : 1,
            "NRecords" : 5,
            "PacketData" : [
                {
                    "Decimal1" : 10.5,
                    "Decimal2" : 20.75,
                    "Decimal3" : 30.0,
                    "Decimal4" : 40.9,
                    "RecordTimestamp" : "2018-12-10T13:46:00.000Z"
                },
                {
                    "Decimal1" : 11.0,
                    "Decimal2" : 21.3,
                    "Decimal3" : 31.5,
                    "Decimal4" : 41.7,
                    "RecordTimestamp" : "2018-12-10T13:47:00.000Z"
                },
                {
                    "Decimal1" : 12.4,
                    "Decimal2" : 22.9,
                    "Decimal3" : 32.1,
                    "Decimal4" : 42.6,
                    "RecordTimestamp" : "2018-12-10T13:48:00.000Z"
                },
                {
                    "Decimal1" : 13.5,
                    "Decimal2" : 23.7,
                    "Decimal3" : 33.9,
                    "Decimal4" : 43.3,
                    "RecordTimestamp" : "2018-12-10T13:49:00.000Z"
                },
                {
                    "Decimal1" : 14.0,
                    "Decimal2" : 24.5,
                    "Decimal3" : 34.6,
                    "Decimal4" : 44.1,
                    "RecordTimestamp" : "2018-12-10T13:50:00.000Z"
                }
            ]
        },
        {
            "Timestamp" : "2018-12-10T14:00:00.000Z",
            "PacketSeqNum" : 2,
            "NRecords" : 5,
            "PacketData" : [
                {
                    "Decimal1" : 15.1,
                    "Decimal2" : 25.4,
                    "Decimal3" : 35.2,
                    "Decimal4" : 45.0,
                    "RecordTimestamp" : "2018-12-10T14:01:00.000Z"
                },
                {
                    "Decimal1" : 16.3,
                    "Decimal2" : 26.1,
                    "Decimal3" : 36.0,
                    "Decimal4" : 46.2,
                    "RecordTimestamp" : "2018-12-10T14:02:00.000Z"
                },
                {
                    "Decimal1" : 17.2,
                    "Decimal2" : 27.7,
                    "Decimal3" : 37.4,
                    "Decimal4" : 47.5,
                    "RecordTimestamp" : "2018-12-10T14:03:00.000Z"
                },
                {
                    "Decimal1" : 18.0,
                    "Decimal2" : 28.5,
                    "Decimal3" : 38.1,
                    "Decimal4" : 48.7,
                    "RecordTimestamp" : "2018-12-10T14:04:00.000Z"
                },
                {
                    "Decimal1" : 19.4,
                    "Decimal2" : 29.3,
                    "Decimal3" : 39.8,
                    "Decimal4" : 49.0,
                    "RecordTimestamp" : "2018-12-10T14:05:00.000Z"
                }
            ]
        }
    ]
}
