#ifndef SERIALIZE_H
#define SERIALIZE_H

#include <string>

#include "Company.h"

using namespace std;

void put_char(char towrite, byte* ptr) { *ptr = towrite; }// ptr++; }

byte*  serializeToMemory(string companiesString, size_t& bytesWritten) {

	bytesWritten = 1; //инициализира с 1 баит за броя компании

	vector <Company> companies;


	std::istringstream companiesIn(companiesString);
		Company company;

	while ( companiesIn >> company ) {	// read companies from the input
										// need that for the array size
		companies.push_back(company);

		bytesWritten += 1;				// start summing all bytes for the final array
		bytesWritten += company.getName().size() + 1;
		bytesWritten += 1;
		bytesWritten += company.getEmployees().size() * 2 ;
	}

	byte* ptr = new byte[bytesWritten]; // array initialization to keep memory

	byte* pt = ptr;		// helper pointer


	
	put_char( companies.size(),pt++);	
									
	for ( Company curr_comp : companies ) {

		put_char(curr_comp.getId(), pt++);

		for (char  s : curr_comp.getName() ) {
			put_char(s, pt++);
		}

		put_char('\0', pt++);

		put_char(curr_comp.getEmployees().size(), pt++);

		for ( pair <char, char> p : curr_comp.getEmployees() ) {
			put_char(p.first, pt++);
			put_char(p.second, pt++);
		}

			}

	pt = nullptr;	

	return ptr;		// return array start address
}










#endif // !SERIALIZE_H