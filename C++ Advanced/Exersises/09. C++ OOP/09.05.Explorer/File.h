#pragma once
#ifndef  FILE_H
#define FILE_H

#include "ByteContainer.h"

class File:public FileSystemObject, public ByteContainer {
public:
	File(std::string fname, std::string bytes);
	size_t getSize() const override;
	bool operator== (const File& other)const;

	~File() {}
};

// End file declaration



inline File::File(std::string fname, std::string bytes):
	FileSystemObject(fname),
	ByteContainer(bytes) {
}

inline size_t File::getSize() const {
	return ByteContainer::getSize();
}

inline bool File::operator==(const File& other)const {
	return this->getName() == other.getName() &&
		this->getSize() == other.getSize();
	return false;
}

#endif // ! FILE_H
