#include "pch.h"
#include "CppUnitTest.h"
#include "DateLib.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest
{
	TEST_CLASS(DateTimeTest)
	{
	public:
		
		TEST_METHOD(Success) // успех
		{
			string date = "03.06", output = "";
			int res = GetDatePlus3DaysStr(date, output);
			Assert::AreEqual(0, res);
		}

		TEST_METHOD(EmptyString) // пустая строка
		{
			string date = "", output = "";
			int res = GetDatePlus3DaysStr(date, output);
			Assert::AreEqual(1, res);
		}

		TEST_METHOD(WrongFormat) // неверный формат строки
		{
			string date = "ab:cd", output = "";
			int res = GetDatePlus3DaysStr(date, output);
			Assert::AreEqual(2, res);
		}

		TEST_METHOD(WrongDay) // неверный день
		{
			string date = "34.06", output = "";
			int res = GetDatePlus3DaysStr(date, output);
			Assert::AreEqual(3, res);
		}

		TEST_METHOD(WrongMonth) // неверный месяц
		{
			string date = "22.14", output = "";
			int res = GetDatePlus3DaysStr(date, output);
			Assert::AreEqual(4, res);
		}

		TEST_METHOD(WrongDayQuantity) // в указанном месяце нет столько дней
		{
			string date = "31.02", output = "";
			int res = GetDatePlus3DaysStr(date, output);
			Assert::AreEqual(5, res);
		}
	};
}
