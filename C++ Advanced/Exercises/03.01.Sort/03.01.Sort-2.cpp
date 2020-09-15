#include <string>
#include <vector>
#include <algorithm>

#include <iostream>
#include "Company.h"


void populatecompanies(std::vector<Company>& companies) {

    int id;
    std::string name;

    while ( std::cin >> name && name != "end" ) {
        std::cin >> id;
        companies.emplace_back(id, name);
    }
}


int main() {
    std::vector<Company>companies;
    populatecompanies(companies);

    std::string compby;
    std::cin >> compby;


    if ( compby == "id" ) std::sort(companies.begin(), companies.end(),
        [] (Company& a, Company& b) { return a.getId() < b.getId(); });
    else if ( compby == "name" ) std::sort(companies.begin(), companies.end(),
        [] (Company& a, Company& b) { return a.getName() < b.getName(); });
    else return 0;

    

    for (Company& c : companies ) std::cout << c.toString() << std::endl;

    return 0;

}

