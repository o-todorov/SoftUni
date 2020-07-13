#ifndef PROFITREPORT_H
#define PROFITREPORT_H

#include <map>
#include <string>


using namespace std;

string getProfitReport(Company* fromInclusive, Company* toInclusive,
				map<int, ProfitCalculator>  profitCalculatorsByCompany){

	ProfitCalculator* calc ;

	ostringstream report;

	for ( auto it = fromInclusive; it <= toInclusive; it++ ) 
	{

		int id = it->getId();

		calc = & profitCalculatorsByCompany[id];

		int profit = calc->calculateProfit(*it);


		report << it->getName() << " = " << calc->calculateProfit(*it) << endl;

	}

	return report.str();
}




#endif
