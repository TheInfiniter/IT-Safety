#define TIMELIB_EXPORTS

#include "TimeLibHeader.h"
#include <map>

map<int, string> Hours = {
	{0, "����"}, {1, "����"}, {2, "���"}, {3, "���"}, {4, "������"}, {5, "����"}, {6, "�����"},
	{7, "����"}, {8, "������"}, {9, "������"}, {10, "������"}, {11, "�����������"}, {12, "����������"},
	{13, "����������"}, {14, "������������"}, {15, "����������"}, {16, "�����������"}, {17, "����������"},
	{18, "������������"}, {19, "������������"}, {20, "��������"}, {21, "�������� ����"}, {22, "�������� ���"}, {23, "�������� ���"}
};

map<int, string> Minutes = {
	{0, "����"}, {1, "����"}, {2, "���"}, {3, "���"}, {4, "������"}, {5, "����"}, {6, "�����"},
	{7, "����"}, {8, "������"}, {9, "������"}, {10, "������"}, {11, "�����������"}, {12, "����������"},
	{13, "����������"}, {14, "������������"}, {15, "����������"}, {16, "�����������"}, {17, "����������"}, {18, "������������"},
	{19, "������������"}, {20, "��������"}, {21, "�������� ����"}, {22, "�������� ���"}, {23, "�������� ���"}, {24, "�������� ������"},
	{25, "�������� ����"}, {26, "�������� �����"}, {27, "�������� ����"}, {28, "�������� ������"}, {29, "�������� ������"}, {30, "��������"},
	{31, "�������� ����"}, {32, "�������� ���"}, {33, "�������� ���"}, {34, "�������� ������"}, {35, "�������� ����"}, {36, "�������� �����"},
	{37, "�������� ����"}, {38, "�������� ������"}, {39, "�������� ������"}, {40, "�����"}, {41, "����� ����"}, {42, "����� ���"},
	{43, "����� ���"}, {44, "����� ������"}, {45, "����� ����"}, {46, "����� �����"}, {47, "����� ����"}, {48, "����� ������"},
	{49, "����� ������"}, {50, "���������"}, {51, "��������� ����"}, {52, "��������� ���"}, {53, "��������� ���"}, {54, "��������� ������"},
	{55, "��������� ����"}, {56, "��������� �����"}, {57, "��������� ����"}, {58, "��������� ������"}, {59, "��������� ������"}
};

string GetEnding(int remnant, bool whatToDo)
{
	string ending = "";

	if (remnant == 0 || remnant > 4)
	{
		if (whatToDo)
			ending = "�����";
		else
			ending = "�����";
	}
	else if (remnant == 1)
	{
		if (whatToDo)
			ending = "���";
		else
			ending = "������";
	}
	else if (remnant > 1 && remnant < 5)
	{
		if (whatToDo)
			ending = "����";
		else
			ending = "������";
	}

	return ending;
}

/// <summary>
/// ���������� � ���������� ������� 5 �����.
/// </summary>
/// <param name="time">�������� ����� � ������� ��:��.</param>
/// <param name="res">����� � ������������� 5 ��������.</param>
/// <returns>��� ����������: 0 - �����, 1 - �������� ������ ��������� �������, 2 - �������� ���, 3 - �������� ������.</returns>
int GetTimePlus5MinStr(string time, string& res)
{
	if (time.length() != 5 || time[2] != ':')
		return 1;

	int hour, minute;

	string hours = "";
	hours += time[0];
	hours += time[1];

	try
	{
		hour = stoi(hours);
	}
	catch(exception)
	{
		return 1;
	}

	if (hour > 23 || hour < 0)
		return 2;

	string minutes = "";
	minutes += time[3];
	minutes += time[4];

	try
	{
		minute = stoi(minutes);
	}
	catch (exception)
	{
		return 1;
	}
	
	if (minute > 59 || minute < 0)
		return 3;

	minute += 5;
	if (minute > 59)
	{
		hour += 1;
		minute -= 60;

		if (hour > 23)
		{
			hour = 0;
		}
	}

	string hourEnding = "";
	int hourRemnant = hour % 10;
	hourEnding = GetEnding(hourRemnant, true);

	string minuteEnding = "";
	int minuteRemnant = minute % 10;
	minuteEnding = GetEnding(minuteRemnant, false);

	res = Hours[hour] + " " + hourEnding + " " + Minutes[minute] + " " + minuteEnding;
	return 0;
}

