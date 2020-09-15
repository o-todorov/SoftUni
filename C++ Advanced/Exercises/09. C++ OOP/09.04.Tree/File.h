#pragma once
#ifndef  FILE_H
#define FILE_H


class File:public FileSystemObject, public ByteContainer {
public:
	File(std::string fname, std::string bytes);
	size_t getSize() const override;
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


#endif // ! FILE_H
