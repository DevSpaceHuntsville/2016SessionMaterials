#include "Rectangle.h"



Rectangle::Rectangle(int w, int h)
{
	this->width = w;
	this->height = h;
}


Rectangle::~Rectangle()
{
}

int Rectangle::get_width()
{
	return this->width;
}

int Rectangle::get_height()
{
	return this->height;
}

int Rectangle::get_area()
{
	return this->width * this->height;
}
