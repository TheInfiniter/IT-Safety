#include "pch.h"
#include "dllSource.h"

TEST(Results, Success) {
	double x1, x2;
	int res = Square(5, 1, 0, x1, x2);
  EXPECT_EQ(0, res);
}

TEST(Results, A_Equals_Zero) {
	double x1, x2;
	int res = Square(0, 5, 2, x1, x2);
	EXPECT_EQ(1, res);
}

TEST(Results, D_Less_Zero) {
	double x1 = 0, x2 = 0;
	int res = Square(5, 0, 2, x1, x2);
	EXPECT_EQ(2, res);
}

TEST(Results, D_Equals_Zero) {
	double x1, x2;
	int res = Square(1, 2, 1, x1, x2);
	EXPECT_EQ(3, res);
}

TEST(Roots, Success_Roots) {
	double x1, x2;
	int res = Square(2, 3, 1, x1, x2);
	EXPECT_DOUBLE_EQ(-0.5, x1);
	EXPECT_DOUBLE_EQ(-1, x2);
}

TEST(Roots, D_Equals_Zero_Roots) {
	double x1, x2;
	int res = Square(1, 2, 1, x1, x2);
	EXPECT_DOUBLE_EQ(x1, x2);
}

TEST(Roots, D_Less_Zero_Roots) {
	double x1 = -20, x2 = -20;
	int res = Square(5, 0, 2, x1, x2);
	EXPECT_DOUBLE_EQ(-20, x1);
	EXPECT_DOUBLE_EQ(-20, x2);
}

int main(int argc, char** argv) {
	::testing::InitGoogleTest(&argc, argv);
	return RUN_ALL_TESTS();
}