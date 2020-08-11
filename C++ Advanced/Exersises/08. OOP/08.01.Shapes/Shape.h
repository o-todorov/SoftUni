#pragma once
#ifndef  SHAPE_H
#define   SHAPE_H

#include "Vector2D.h"

class Shape {
public:
	Shape();
	Shape(const Vector2D& center);
	std::string getCenter()const;
	double getArea()const;
private:
	Vector2D center;
protected:
	double area;
};

// End declarations 



Shape::Shape()
	: center(Vector2D(0.0, 0.0)),
	area(0.0) {
}

Shape::Shape(const Vector2D& center) :
	center(center),
	area(0.0) {
}

inline std::string Shape::getCenter() const {
	return (std::string)this->center;
}


inline double Shape::getArea() const {
	return this->area;
}

#endif // ! SHAPE_H
