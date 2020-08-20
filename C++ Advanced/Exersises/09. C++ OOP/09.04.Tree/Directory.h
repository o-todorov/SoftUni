#pragma once
#ifndef DIRECTORY_H
#define DIRECTORY_H


class Directory:public FileSystemObjectsContainer, public FileSystemObject {
private:
	std::vector< std::shared_ptr<FileSystemObject>>files;
public:
	Directory(std::string path);
	void add(const std::shared_ptr<FileSystemObject>& obj) override;
	size_t getSize()const override;
	std::vector<std::shared_ptr<FileSystemObject> >::const_iterator begin() const override;
	std::vector<std::shared_ptr<FileSystemObject> >::const_iterator end() const override;
	bool empty();

	virtual ~Directory();
};

// End Directory declaration


Directory::Directory(std::string path):
	FileSystemObject(path) {
}
inline void Directory::add(const std::shared_ptr<FileSystemObject>& obj) {
	this->files.push_back(obj);
}

size_t Directory::getSize()const {
	size_t size = 0;
	for ( auto f : files ) 	size += f->getSize();
	return size;
}

inline std::vector<std::shared_ptr<FileSystemObject>>::const_iterator Directory::begin() const {
	return this->files.begin();
}

inline std::vector<std::shared_ptr<FileSystemObject>>::const_iterator Directory::end() const {
	return this->files.end();
}

inline bool Directory::empty() {
	return this->files.empty();
}

inline Directory::~Directory() {
}

#endif // !DIRECTORY_H
