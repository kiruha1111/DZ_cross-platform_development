@echo off
chcp 65001 >nul
title Создание документации Timirbaev_Erik_Lab_5
echo ====================================================
echo    СОЗДАНИЕ ДОКУМЕНТАЦИИ TIMIRBAEV_ERIK_LAB_5
echo ====================================================
echo.

cd /d "D:\Desktop\DZ_cross-platform_development"

echo Текущая папка: %CD%
echo.

REM 1. Проверка Doxygen
echo Проверка Doxygen...
where doxygen >nul 2>nul
if errorlevel 1 (
    echo ОШИБКА: DOXYGEN НЕ НАЙДЕН!
    echo.
    echo Установите Doxygen:
    echo 1. Скачайте с: http://www.doxygen.nl/download.html
    echo 2. Установите с галочкой "Add to PATH"
    echo 3. Перезапустите этот скрипт
    echo.
    pause
    exit /b 1
)

echo Doxygen найден: 
doxygen --version
echo.

REM 2. Проверка и создание Doxyfile
echo Проверка Doxyfile...
if not exist Doxyfile (
    echo Создаю Doxyfile...
    
    (
        echo # Doxyfile для Timirbaev_Erik_Lab_5
        echo DOXYFILE_ENCODING      = UTF-8
        echo PROJECT_NAME           = "Timirbaev_Erik_Lab_5 - Курьерская служба"
        echo PROJECT_NUMBER         = "Лабораторная работа #5"
        echo OUTPUT_DIRECTORY       = docs
        echo INPUT                  = .
        echo FILE_PATTERNS          = *.cs
        echo RECURSIVE              = YES
        echo EXCLUDE                = bin/ obj/
        echo EXTRACT_ALL            = YES
        echo GENERATE_HTML          = YES
        echo HTML_OUTPUT            = html
        echo GENERATE_TREEVIEW      = YES
        echo SEARCHENGINE           = YES
    ) > Doxyfile
    
    echo Doxyfile создан
) else (
    echo Doxyfile уже существует
)

REM 3. Удаление старой документации
echo.
echo Удаление старой документации...
if exist docs (
    rmdir /s /q docs
    timeout /t 1 /nobreak >nul
)

REM 4. Запуск Doxygen
echo.
echo Запуск Doxygen...
echo ----------------------------------------------------
doxygen Doxyfile
echo ----------------------------------------------------

REM 5. Проверка результата
echo.
echo Проверка результата...

if exist "docs\html\index.html" (
    echo УСПЕХ: HTML документация создана!
    echo Папка: %CD%\docs\html
    echo Главный файл: docs\html\index.html
    echo.
    echo Содержимое docs\html:
    dir docs\html\*.html | find "File(s)"
) else (
    echo ОШИБКА: Документация не создана!
    echo.
    echo Отладка:
    echo 1. Проверьте наличие .cs файлов:
    dir *.cs /b
    pause
    exit /b 1
)

REM 6. Создание example_data.xml
echo.
echo Создание example_data.xml...

(
echo ^<?xml version="1.0" encoding="UTF-8"?^>
echo ^<ArrayOfTimirbaevCourier xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"^>
echo   ^<TimirbaevCourier^>
echo     ^<id^>1^</id^>
echo     ^<firstname^>Иван^</firstname^>
echo     ^<surname^>Петров^</surname^>
echo     ^<age^>25^</age^>
echo     ^<phone^>9215551212^</phone^>
echo   ^</TimirbaevCourier^>
echo   ^<TimirbaevAutoCourier^>
echo     ^<id^>2^</id^>
echo     ^<firstname^>Анна^</firstname^>
echo     ^<surname^>Сидорова^</surname^>
echo     ^<age^>30^</age^>
echo     ^<phone^>9213334444^</phone^>
echo     ^<car_model^>Toyota Camry^</car_model^>
echo     ^<car_number^>A123BV777^</car_number^>
echo   ^</TimirbaevAutoCourier^>
echo   ^<TimirbaevCourier^>
echo     ^<id^>3^</id^>
echo     ^<firstname^>Сергей^</firstname^>
echo     ^<surname^>Иванов^</surname^>
echo     ^<age^>28^</age^>
echo     ^<phone^>9216667890^</phone^>
echo   ^</TimirbaevCourier^>
echo ^</ArrayOfTimirbaevCourier^>
) > example_data.xml

echo example_data.xml создан

REM 7. Открытие результатов
echo.
echo Открываю результаты...
timeout /t 2 /nobreak >nul

echo Открываю документацию...
start "" "docs\html\index.html"

echo Открываю example_data.xml...
start "" "example_data.xml"

REM 8. Итог
echo.
echo ====================================================
echo ИТОГ:
echo ====================================================
echo.
echo Документация: docs\html\index.html
echo Пример данных: example_data.xml
echo Конфиг Doxygen: Doxyfile
echo.
echo ПРОВЕРКА:
echo 1. В документации должны быть все классы
echo 2. example_data.xml должен открываться в браузере
echo 3. XML можно загрузить в программу
echo.
echo ====================================================
pause