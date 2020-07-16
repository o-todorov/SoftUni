#ifndef CAR_H
#define CAR_H

using namespace std;

class Car {
public:
	Car(std::string brand, std::string model, int year):
		brand(brand),
		model(model),
		year(year) {};

	string GetBrand()const { return brand; }
	string GetModel() const{ return model; }
	int GetYear()const { return year; }

private:
	std::string brand;
	std::string model;
	int year;

};



#endif // !CAR_H
