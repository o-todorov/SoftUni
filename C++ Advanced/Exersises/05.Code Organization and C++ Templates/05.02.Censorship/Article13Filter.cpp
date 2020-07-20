//#include <string>
#include <algorithm>

#include "Article13Filter.h"


Article13Filter::Article13Filter(std::set<std::string> copyrighted):
	copyrighted(copyrighted),
	blocked(std::vector<std::string>()) {}

bool Article13Filter::blockIfCopyrighted(std::string s) {
	if ( isCopyrighted(s) ) {
		this->blocked.push_back(s);
		return true;
	}
	return false;
}


bool Article13Filter::isCopyrighted(std::string s) {
	return find(this->copyrighted.begin(), this->copyrighted.end(), s) != this->copyrighted.end();
}

std::vector<std::string> Article13Filter::getBlocked() {
	return this->blocked;
}


