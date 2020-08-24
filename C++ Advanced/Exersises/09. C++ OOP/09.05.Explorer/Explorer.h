#pragma once
#ifndef EXPLORER_H
#define EXPLORER_H

#include <string>
#include <algorithm>

typedef std::shared_ptr<FileSystemObject>  ptr_FSO;
typedef std::shared_ptr<FileSystemObjectsContainer>  ptr_FSOCont;

class Explorer {
	std::vector<ptr_FSO >& rootObjects;
	std::vector<ptr_FSO > clipbrd;
	std::shared_ptr<Directory> currDir;
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
	friend ptr_FSO getFSObyName(const  std::string& name, Explorer* expl);

	~Explorer() {
	}
};

////////////          DEFINITIONS       /////////////////

bool operator ==(ptr_FSO l, std::string r) {
	return l->getName() == r;
}

template <typename T>
ptr_FSO getFSO(const T& container, const  std::string& name) {
	auto f = find(container.begin(), container.end(), name);

	if ( f != container.end() )	return *f;

	else return nullptr;
}

ptr_FSO getFSObyName(const  std::string& name, Explorer* expl) {
	if ( expl->currDir )
		return getFSO(*(expl->currDir), name);
	else
		return getFSO(expl->rootObjects, name);
}

Explorer::Explorer(std::vector<ptr_FSO>& rootObjects):
	rootObjects(rootObjects) {
}

void addObj(const ptr_FSO newObj, Explorer* expl) {
	if ( expl->currDir ) {
		expl->currDir->add(newObj);
		newObj->setParent(expl->currDir);
	}
	else {
		expl->rootObjects.push_back(newObj);
		std::weak_ptr<FileSystemObject> w;
		newObj->setParent(w);
	}
}

void Explorer::createFile(const std::string& filename, const std::string& contents) {
	addObj(std::make_shared<File>(filename, contents), this);
}

void Explorer::createDirectory(const std::string& directory) {
	addObj(std::make_shared<Directory>(directory), this);
}

void Explorer::createShortcut(const std::string& name) {
	if ( !this->shortcuts ) {
		this->shortcuts = std::make_shared<Shortcuts>();
		this->rootObjects.push_back(this->shortcuts);
	}
	ptr_FSO o = getFSObyName(name, this);

	if ( o )this->shortcuts->add(o);
}

void Explorer::cut(const std::string& name) {
	ptr_FSO o = getFSObyName(name, this);

	if ( o )this->clipbrd.push_back(o);
}

void Explorer::paste() {
	auto it = this->clipbrd.begin();

	while ( !this->clipbrd.empty() ) {
		auto oldparent = std::dynamic_pointer_cast< Directory >((this->clipbrd[0])->getParent().lock());

		addObj(this->clipbrd[0], this);

		if ( oldparent )oldparent->remove((*this->clipbrd.begin()));
		else this->rootObjects.erase(find(this->rootObjects.begin(), this->rootObjects.end(), this->clipbrd[0]));

		this->clipbrd.erase(this->clipbrd.begin());
	}
}

void Explorer::navigate(const std::string& path) {
	ptr_FSO newDir = nullptr;

	if ( path == ".." )
		newDir = this->currDir->getParent().lock();
	else
		newDir = getFSObyName(path, this);

	this->setCurrDirectory(std::dynamic_pointer_cast< Directory >(newDir));
}

void Explorer::setCurrDirectory(const std::shared_ptr<Directory> dir) {
	this->currDir = dir;
}

std::shared_ptr<Directory> Explorer::getCurrDirectory() {
	return this->currDir;
}


#endif // !EXPLORER_H
