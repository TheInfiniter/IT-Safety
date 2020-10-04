#pragma once

#ifdef TIMELIB_EXPORTS
#define TIMELIB_API __declspec(dllexport)
#else
#define TIMELIB_API __declspec(dllimport)
#endif

#include <string>
using namespace std;

/// <summary>
/// ���������� � ���������� ������� 5 �����.
/// </summary>
/// <param name="time">�������� �����.</param>
/// <param name="res">����� � ������������� 5 ��������.</param>
/// <returns>��� ����������: 0 - �����, 1 - �������� ������ ��������� �������, 2 - �������� ���, 3 - �������� ������.</returns>
extern "C" TIMELIB_API int GetTimePlus5MinStr(string time, string &res);