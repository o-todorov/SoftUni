#pragma once
#ifndef EXPLORER_H
#define EXPLORER_H

#include <string>
#include <algorithm>

typedef std::shared_ptr<FileSystemObject>  ptr_FSO;
typedef std::shared_ptr<FileSystemObjectsContainer>  ptr_FSOCont;

class Explorer {
	std::vector<ptr_FSO >& rootObjects;
	std::shared_ptr<Directory> currDir;
	std::shared_ptr<Directory> clipbrd;
	std::shared_ptr<Directory> rootDir;
	std::shared_ptr<Shortcuts> shortcuts;


public:
	Explorer(std::vector<ptr_FSO >& rootObjects);
	void createFile(const std::string& filename, const std::string& contents);
	void createDirectory(const std::string& directory);
	void createShortcut(const std::string& name);
	void cut(const std::string& name);
	void paste();
	void navigate(const std::string& path);
	void setCurrDirectory(const std::shared_ptr<Directory> dir);
	std::shared_ptr<Directory> getCurrDirectory();
	friend void addObj(const ptr_FSO newObj, Explorer* expl);

	~Explorer() {
	}
};

////////////          DEFINITIONS       /////////////////



bool operator ==(ptr_FSO l, std::string r) {
	return l->getName() == r;
}

template <typename Iterator>
ptr_FSO getFSObyName(const Iterator begin, const Iterator end, const  std::string& name) {
	auto f = find(begin, end, name);

	if ( f != end )	return *f;

	else return nullptr;
}

//void moveTo(ptr_FSO obj, std::shared_ptr<Directory> container) {
//	container->add(obj);
//	obj->setParent(container);
//}

void addObj(const ptr_FSO newObj, Explorer* expl) {
	if ( expl->currDir != nullptr ) {
		expl->currDir->add(newObj);
		newObj->setParent(expl->currDir);
	}
	else
		expl->rootObjects.push_back(newObj);
}

Explorer::Explorer(std::vector<ptr_FSO>& rootObjects):
	rootObjects(rootObjects),
	clipbrd(std::make_shared<Directory>("Clipboard")),
	rootDir(std::make_shared<Directory>("ROOT")) {
	rootDir->begin() = rootObjects.begin();
	rootDir->end() = rootObjects.end();
}
void Explorer::createFile(const std::string& filename, const std::string& contents) {
	addObj(std::make_shared<File>(filename, contents), this);
}

void Explorer::createDirectory(const std::string& directory) {
	addObj(std::make_shared<Directory>(directory), this);
}

void Explorer::createShortcut(const std::string& name) {
	if ( !this->shortcuts ) {
		shortcuts = std::make_shared<Shortcuts>();
		this->rootObjects.push_back(shortcuts);
	}
	ptr_FSO o = nullptr;

	if ( this->currDir )
		o = getFSObyName(this->currDir->begin(), this->currDir->end(), name);
	else
		o = getFSObyName(this->rootObjects.begin(), this->rootObjects.end(), name);

	if ( o )this->shortcuts->add(o);
}

void Explorer::cut(const std::string& name) {
	if ( name == "" ) return;
	ptr_FSO o = nullptr;

	if ( this->currDir )
		o = getFSObyName(this->currDir->begin(), this->currDir->end(), name);
	else
		o = getFSObyName(this->rootObjects.begin(), this->rootObjects.end(), name);

	if ( o )this->clipbrd->add(o);
}

void Explorer::paste() {
	for ( ptr_FSO fso : *this->clipbrd ) {
		if ( fso->getParent().lock() )
			std::dynamic_pointer_cast< Directory >
			(fso->getParent().lock())->remove(fso);
		else {
			auto it = find(this->rootObjects.begin(), this->rootObjects.end(), fso->getName());
			this->rootObjects.erase(it);
		}

		addObj(fso, this);
		this->clipbrd->remove(fso);
	}
}

void Explorer::navigate(const std::string& path) {
	ptr_FSO newDir = nullptr;

	if ( path == ".." ) {
		newDir = this->currDir->getParent().lock();
	}
	else {
		if ( this->currDir )	newDir = getFSObyName(this->currDir->begin(), this->currDir->end(), path);
		else newDir = getFSObyName(this->rootObjects.begin(), this->rootObjects.end(), path);
	}
	this->setCurrDirectory(std::dynamic_pointer_cast< Directory >(newDir));
}

void Explorer::setCurrDirectory(const std::shared_ptr<Directory> dir) {
	this->currDir = dir;
}

std::shared_ptr<Directory> Explorer::getCurrDirectory() {
	return currDir;
}


#endif // !EXPLORER_H
