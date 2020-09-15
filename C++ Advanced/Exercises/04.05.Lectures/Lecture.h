#ifndef LECTURE_H
#define LECTURE_H

#include <iostream>
#include <vector>
#include "ResourceType.h"
#include <set>
#include <algorithm>

using SoftUni::Resource;
using SoftUni::ResourceType;
using namespace std;

namespace SoftUni {
	class Lecture;
} // namespace SoftUni

class SoftUni::Lecture {
public:
	Lecture():resources(vector<Resource>()) {}

	typedef vector<Resource>::iterator iterator;
	typedef vector<Resource>::const_iterator const_iterator;
	iterator begin() { return this->resources.begin(); }
	const_iterator begin() const { return this->resources.begin(); }
	iterator end() { return this->resources.end(); }
	const_iterator end() const { return this->resources.end(); }

	void add(Resource resource);
	const int operator[](const ResourceType& restype)const;

private:
	vector<Resource> resources;

}; // class Lecture


void SoftUni::Lecture::add(Resource resource) {
	int nid = resource.id;
	size_t pos = 0;

	while ( pos < this->resources.size() ) {
		if ( nid < this->resources[pos].id ) break;
		else if ( nid == this->resources[pos].id ) {
			this->resources.erase(begin() + pos);
			break;
		}
		else pos++;
	}
	this->resources.insert(begin() + pos, resource);
}

const int SoftUni::Lecture::operator[](const ResourceType& restype)const {
	int sum = 0;
	for ( Resource r : this->resources ) if ( r.getType() == restype ) sum++;
	return sum;
}

// End class Lecture definitions

using SoftUni::Lecture;


vector<ResourceType>& operator<<(vector<ResourceType>& rt, const SoftUni::Lecture& lecture) {
	set<ResourceType> st;
	for ( Resource res : lecture ) st.insert(res.getType());
	if ( st.find(ResourceType::PRESENTATION) != st.end() ) rt.push_back(ResourceType::PRESENTATION);
	if ( st.find(ResourceType::DEMO) != st.end() ) rt.push_back(ResourceType::DEMO);
	if ( st.find(ResourceType::VIDEO) != st.end() ) rt.push_back(ResourceType::VIDEO);

	return rt;
}

Lecture& operator<<(Lecture& lecture, const Resource& r) { lecture.add(r);	return lecture; }



#endif // !LECTURE_H