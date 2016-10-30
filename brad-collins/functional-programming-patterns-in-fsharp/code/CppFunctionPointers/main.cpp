#include <cstdio>
#include "Rectangle.h"

int multiply(int x, int y)
{
	return x * y;
}

int add(int x, int y)
{
	return x + y;
}

int operate(int(*op)(int, int), int x, int y)
{
	return op(x, y);
}

void main(int argc, char** argv)
{
	int a = 5;
	int b = 4;

	int(*times)(int, int) = multiply;

	int product = operate(multiply, a, b);
	int sum = operate(add, a, b);

	std::printf("%d + %d = %d\n", a, b, sum);
	std::printf("%d * %d = %d\n", a, b, product);
	std::printf("%d * %d = %d\n", a, b, times(a, b));

	Rectangle r(5, 4);
	std::printf("Rectangle [w: %d, h: %d]\n",
		r.get_width(), r.get_height());

	int (Rectangle::*calc_area)(void) = &Rectangle::get_area;
	std::printf("Area: %d\n", ((r).*(calc_area))());
}