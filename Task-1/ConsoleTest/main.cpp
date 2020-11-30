#include "dllSource.h"
#include <iostream>

using namespace std;

void main()
{
	double a, b, c;

	cout << "vvedi chislo a" << endl;
	cin >> a;

	cout << "vvedi chislo b" << endl;
	cin >> b;

	cout << "vvedi chislo c" << endl;
	cin >> c;
	cout << endl;

	double x1, x2;
	int result;

	result = Square(a, b, c, x1, x2);

	cout << "kod oshibki: " << result << ", to est ";

	switch (result)
	{
	case 0:
	{
		cout << "vse norm" << endl;
		break;
	}
	case 1: 
	{
		cout << "nu ti konechno molodec" << endl;
		break;
	}
	default:
	{
		cout << "Varning" << endl;
		break;
	}
	}

	cout << "Pevriy koren': " << x1 << "\t" << "Vtoroy koren': " << x2 << endl;

	//cin << endl;
}