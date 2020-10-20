#include "Lecture.h"
//#include "Resource.h"

//using SoftUni::Resource;
//using SoftUni::ResourceType;

using namespace SoftUni;


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



std::vector<ResourceType>& SoftUni::operator<<(std::vector<ResourceType>& rt, const SoftUni::Lecture& lecture) {

	ResourceType restypes[] = {ResourceType::PRESENTATION, ResourceType::DEMO, ResourceType::VIDEO};
	bool exist[] = {0, 0, 0};
	for ( Resource res : lecture ) exist[res.getType()] = 1;
	for ( int i = 0; i < 3; i++ ) if ( exist[i] )rt.push_back(restypes[i]);

	return rt;
}

SoftUni::Lecture& SoftUni::operator<<(SoftUni::Lecture& lecture, const Resource& r) { lecture.add(r);	return lecture; }
