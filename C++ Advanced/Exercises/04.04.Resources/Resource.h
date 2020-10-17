#ifndef RESOURCE_H
#define RESOURCE_H

#include "ResourceType.h"
#include <map>

using SoftUni::ResourceType;
using namespace std;

namespace SoftUni {

	class Resource {
	public:
		int id;
		string link;
		Resource();
		ResourceType getType()const;

	private:
		SoftUni::ResourceType  restype;
		friend istream& operator>>(istream& in, Resource& r);
	};
	Resource::Resource():id(0), restype(ResourceType::DEMO), link("") {}

	ResourceType Resource::getType()const {
		return restype;
	}




	istream& operator>>(istream& in, Resource& r) {
		std::map<string, ResourceType> types = {{"Presentation", PRESENTATION}, {"Demo", DEMO}, {"Video", VIDEO}};
		string res;
		in >> r.id >> res >> r.link;
		r.restype = types[res];

		return in;
	}

	ostream& operator<<(ostream& out, const Resource& r) {

		out << r.id << " " << r.getType() << " " << r.link;

		return out;
	}

	bool operator<(const Resource& l, const Resource& r) {

		return l.id < r.id;
	}

};


#endif // !RESOURCE_H