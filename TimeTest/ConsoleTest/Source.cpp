#include "TimeLibHeader.h"
#include <iostream>

int main()
{
	setlocale(LC_ALL, "Russian");
	string time = "", resultTime = "";
	
	while (true)
	{
		cin >> time;

		int res = GetTimePlus5MinStr(time, resultTime);

		cout << resultTime << endl;
		cout << "Result code: " << res << endl;
		cout << endl;
	}
}