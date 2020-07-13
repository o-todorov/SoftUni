#ifndef PARSE_COMPANIES_H
#define PARSE_COMPANIES_H

#include <sstream>

#include <string>
#include "Company.h"

using namespace std;

Company* parseUniqueCompanies(string input,int &numCompanies, string(* get)(const Company& )) {

	numCompanies = 0;

	istringstream in(input);
	vector<Company*> companies;

	string id, name;

	

	while ( in >> id && id != "end" ) {

		bool isduplicate = false;

		in >> name;

		Company *c =new Company(stoi(id), name);

		for ( Company* iter: companies ) {

			if ( get(*iter) == get(*c)) {

				isduplicate = true;
				break;
			}

		}

		if ( !isduplicate ) {

			companies.push_back(c);
			numCompanies++;
		}

	}

	Company* retval = new Company[numCompanies];
	Company* p = retval;

	for ( Company* c : companies ) {
		*p = *c;
		delete  c;
		p++;
	}

	p = nullptr;

	return retval;


}





#endif // !PARSE_COMPANIES_H