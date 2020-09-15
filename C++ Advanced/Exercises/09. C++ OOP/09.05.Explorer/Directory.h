#pragma once
#ifndef DIRECTORY_H
#define DIRECTORY_H

#include <algorithm>

class Directory:public FileSystemObjectsContainer, public FileSystemObject {
private:
	std::vector< std::shared_ptr<FileSystemObject>>fs_objects;
public:
	Directory(std::string path);
	void add(const std::shared_ptr<FileSystemObject>& obj) override;
	size_t getSize()const override;
	std::vector<std::shared_ptr<FileSystemObject> >::const_iterator begin() const override;
	std::vector<std::shared_ptr<FileSystemObject> >::const_iterator end() const override;
	virtual void remove(std::shared_ptr<FileSystemObject> obj);
	bool operator ==(std::shared_ptr<FileSystemObject> other);

	virtual ~Directory();
};

// End Directory declaration


Directory::Directory(std::string path):
	FileSystemObject(path) {
}
inline void Directory::add(const std::shared_ptr<FileSystemObject>& obj) {
	this->fs_objects.push_back(obj);
}

size_t Directory::getSize()const {
	size_t size = 0;
	for ( auto f : fs_objects ) 	size += f->getSize();
	return size;
}

inline std::vector<std::shared_ptr<FileSystemObject>>::const_iterator Directory::begin() const {
	return this->fs_objects.begin();
}

inline std::vector<std::shared_ptr<FileSystemObject>>::const_iterator Directory::end() const {
	return this->fs_objects.end();
}

inline void Directory::remove(std::shared_ptr<FileSystemObject> obj) {
	auto f = find(this->fs_objects.begin(), this->fs_objects.end(), obj);

	if ( f != this->fs_objects.end() )	this->fs_objects.erase(f);
}

inline bool Directory::operator==(std::shared_ptr<FileSystemObject> other) {
	return this->getName() == other->getName();
}

inline Directory::~Directory() {
}

#endif // !DIRECTORY_H
