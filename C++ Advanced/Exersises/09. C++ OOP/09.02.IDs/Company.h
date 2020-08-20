#ifndef COMPANY
#define COMPANY

#include <vector>
#include <string>
#include <sstream>

class HasInfo {
public:
	virtual std::string getInfo()const  = 0;
	virtual ~HasInfo() {}
};

class HasId {
public:
	virtual int getId()const = 0;
	virtual ~HasId() {}
};

class Company: public HasId, public HasInfo {
	int id=0;
	std::string name;
	std::vector<std::pair<char, char>> employees;
public:

	Company();
	Company(int id, std::string name, std::vector<std::pair<char, char> > employees);

	int getId()const override;

	std::string getName()const ;

	std::vector<std::pair<char, char>> getEmployees() const;

	virtual std::string getInfo() const override;

	friend std::ostream& operator<<(std::ostream& stream, const Company& c);
	friend std::istream& operator>>(std::istream& stream, Company& c);
	~Company() {};
};


#endif // !COMPANY
