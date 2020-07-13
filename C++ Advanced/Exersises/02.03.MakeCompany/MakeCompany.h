#ifndef MAKE_COMPANY_H
#define MAKE_COMPANY_H

#include <memory>
#include "Company.h"


std::shared_ptr<Company> makeCompany(std::vector<std::string> &properties) {

	 int Id =stoi( properties[0]);

	 std::string name = properties[1];

	 properties.erase(properties.begin(), properties.begin() + 2);

	 std::vector<std::pair<char, char> > employees;

	 for ( std::string s : properties )
		 employees.push_back(std::pair<char, char>(s[0], s[1]));

	return std::make_shared<Company>(Id, name, employees);
}


#endif // !MAKE_COMPANY_H