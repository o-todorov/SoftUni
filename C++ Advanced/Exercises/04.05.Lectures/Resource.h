#ifndef RESOURCE_H
#define RESOURCE_H

#include "ResourceType.h"
#include <iostream>

using SoftUni::ResourceType;
using namespace std;

namespace SoftUni {
	class Resource;
	istream& operator>>(istream& in, Resource& r);
	ostream& operator<<(ostream& out, const Resource& r);
	bool operator<(const Resource& l, const Resource& r);
}; // namespace SoftUni

class SoftUni::Resource {
public:
	int id;
	string link;
	Resource();
	ResourceType getType()const;

private:
	ResourceType  restype;
	friend istream& operator>>(istream& in, Resource& r);

};  // class Lecture


SoftUni::Resource::Resource():id(0), restype(ResourceType::DEMO), link("") {}

ResourceType SoftUni::Resource::getType()const {
	return restype;
}

// End class Lecture definitions
using SoftUni::Resource;


istream& SoftUni::operator>>(istream& in, Resource& r) {
	string res;
	in >> r.id >> res >> r.link;

	if ( res == "Presentation" ) r.restype = ResourceType::PRESENTATION;
	else if ( res == "Demo" )r.restype = ResourceType::DEMO;
	else if ( res == "Video" )r.restype = ResourceType::VIDEO;
	else;

	return in;
}


ostream& SoftUni::operator<<(ostream& out, const Resource& r) {
	out << r.id << " " << r.getType() << " " << r.link;
	return out;
}


bool operator<(const Resource& l, const Resource& r) { return l.id < r.id; }











#endif // !RESOURCE_H