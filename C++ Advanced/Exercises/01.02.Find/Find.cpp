#include "Find.h"
using namespace std;

Company* find(vector <Company*> companies, int searchId) {
	for  ( auto ptr : companies ) {
		if ( (*ptr).getId() == searchId ) {
			return ptr;
			break;
		}
	}



	return NULL;
}
