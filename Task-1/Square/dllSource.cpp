#define SQUARELIB_EXPORTS

#include "dllSource.h"
#include <math.h>

// 0 - молодец, 1 - а = 0, 2 - дискримининат < 0, 3 - дискриминант = 0
int Square(double a, double b, double c, double &x1, double &x2)
{
	if (a == 0) return 1;

	double discr = b * b - 4 * a * c;

	if (discr < 0) return 2;

	x1 = (-b + sqrt(discr)) / (2 * a);
	x2 = (-b - sqrt(discr)) / (2 * a);

	if (discr == 0) return 3;

	return 0;
}