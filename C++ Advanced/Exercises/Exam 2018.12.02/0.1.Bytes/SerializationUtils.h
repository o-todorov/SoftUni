#pragma once
#ifndef SERIALIZATION_UTILS_H
#define SERIALIZATION_UTILS_H

char* serializeStrings(const std::vector<std::string>& lines, int& serializedSize) {
	serializedSize = 0;
	for ( std::string s : lines )serializedSize += s.size();
	serializedSize += lines.size();

	char* serialized = new char[serializedSize];

	int IDX = 0;
	for ( std::string s : lines ) {
		serialized[IDX++] = s.size();

		for ( char ch : s ) serialized[IDX++] = ch;

	}


	return serialized;
}



#endif // !SERIALIZATION_UTILS_H
