#pragma once
#ifndef DIRECTORY_H
#define DIRECTORY_H

class Directory:public FileSystemObjectsContainer, public FileSystemObject {
private:
	std::vector< std::shared_ptr<FileSystemObject>>files;
public:
	Directory(std::string path);
	void add(const std::shared_ptr<FileSystemObject>& obj) override;
	size_t getSize()const;
	~Directory() {}
};

// End Directory declaration


Directory::Directory(std::string path):
	FileSystemObject(path) {
}
inline void Directory::add(const std::shared_ptr<FileSystemObject>& obj)  {
	this->files.push_back(obj);
}

size_t Directory::getSize()const {
	size_t size = 0;
	for ( auto f : files ) 	size += f->getSize();
	return size;
}

#endif // !DIRECTORY_H
