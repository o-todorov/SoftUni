#include "Tropico.h"



int main() {
	int numcomm;
	std::cin >> numcomm;
	std::cin.ignore();

	Tropico commcenter;

	for ( int i = 0; i < numcomm; i++ ) {
		std::string command;
		std::cin >> command;
		if ( command == "build" ) {
			std::string type;
			int width, length;
			std::cin >> type >> width >> length;
			commcenter.build(type, width, length);
		}
		else if ( command == "duplicate" ) {
			int IDX1, IDX2;
			std::cin >> IDX1 >> IDX2;
			commcenter.duplicate(IDX1, IDX2);
		}
		else if ( command == "replace" ) {
			int IDX1, IDX2;
			std::cin >> IDX1 >> IDX2;
			commcenter.replace(IDX1, IDX2);
		}
		else if ( command == "demolish" ) {
			int IDX1;
			std::cin >> IDX1;
			commcenter.demolish(IDX1);
		}
		else
			std::cout << "Command unkhown";

	}


	return 0;
}