#pragma once

#ifdef TIMELIB_EXPORTS
#define TIMELIB_API __declspec(dllexport)
#else
#define TIMELIB_API __declspec(dllimport)
#endif

#include <string>
using namespace std;

/// <summary>
/// Прибавляет к указанному времени 5 минут.
/// </summary>
/// <param name="time">Исходное время.</param>
/// <param name="res">Время с прибавленными 5 минутами.</param>
/// <returns>Код результата: 0 - успех, 1 - неверный формат исходного времени, 2 - неверный час, 3 - неверная минута.</returns>
extern "C" TIMELIB_API int GetTimePlus5MinStr(string time, string &res);