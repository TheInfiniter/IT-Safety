#pragma once

#ifdef SQUARELIB_EXPORTS
#define SQUARELIB_API __declspec(dllexport)
#else
#define SQUARELIB_API __declspec(dllimport)
#endif


extern "C" SQUARELIB_API int Square(double a, double b, double c, double &x1, double &x2);