#pragma once
#ifndef  TREE_VIEW_H
#define TREE_VIEW_H

#include <set>

typedef std::shared_ptr<FileSystemObject>  ptr_FSO;

typedef std::shared_ptr<FileSystemObjectsContainer>  ptr_FSOCont;

struct Comp {
	bool operator() (
		const ptr_FSO a,
		const ptr_FSO b)const {
		return a->getName() < b->getName();
	}
};

void reveal(ptr_FSOCont dir, std::ostringstream& out, const int& level);

void revealTree(ptr_FSO fso, std::ostringstream& out, const int& level) {
	std::string tab;
	for ( int i = 0; i < level; i++ ) tab += "--->";
	out << tab << fso->getName() << std::endl;

	if ( fso->getName() == "[shortcuts]" || std::dynamic_pointer_cast < Directory >(fso) ) {
		reveal(std::dynamic_pointer_cast< FileSystemObjectsContainer >(fso), out, level);
	}
}

void reveal(ptr_FSOCont dir, std::ostringstream& out, const int& level) {
	std::set<ptr_FSO, Comp> sortedDirs(dir->begin(), dir->end());
	for ( auto fso : sortedDirs )	revealTree(fso, out, level + 1);
}

std::string getTreeView(std::vector<ptr_FSO>& rootObjects) {
	std::ostringstream out;

	for ( ptr_FSO fso : rootObjects ) 	revealTree(fso, out, 0);

	return out.str();
}


#endif // ! TREE_VIEW_H
