#include <string>
#include <vector>
#include <algorithm>

#include <iostream>
#include "Company.h"


void populatecompanies(std::vector<Company>&companies) {

    int id;
    std::string name;

    while ( std::cin >> name && name != "end" ) {
        std::cin >> id;
        companies.emplace_back(id, name);
    }
}

bool sortbyid(Company& a, Company& b) {    return a.getId() < b.getId();}

bool sortbyname(Company& a, Company& b) {    return a.getName() < b.getName();}

int main(){
    std::vector<Company>companies;
    populatecompanies(companies);
    
    std::string compby;
    std::cin >> compby;

    bool(*sortby)(Company &, Company& );

    sortby = nullptr;

    if ( compby == "id" ) sortby = &sortbyid;
    else if ( compby == "name" ) sortby = &sortbyname;
    else return 0;

    std::sort(companies.begin(), companies.end(), sortby);

    for ( Company c : companies ) std::cout << c.getName() << " " << c.getId() << std::endl;

    return 0;

}

