#pragma once

class Rectangle
{
public:
	Rectangle(int w, int h);
	~Rectangle();

	int get_width();
	int get_height();
	int get_area();

private:
	int width;
	int height;
};

