#ifndef RESOURCE_H
#define RESOURCE_H

#include <iostream>
#include "ResourceType.h"
#include <map>


namespace SoftUni {
	class Resource;
	//std::istream& operator>>(std::istream& in, Resource& r);

	//std::ostream& operator<<(std::ostream& out, const Resource& r);

	//bool operator<(const Resource& l, const Resource& r);



	class Resource {
	public:
		int id;
		std::string link;
		Resource();
		ResourceType getType()const;
		void setType(const ResourceType& ntype);
		//friend std::istream& operator>>(std::istream& in, Resource& r);
	private:
		ResourceType  restype;

	};  // class Resource

	Resource::Resource():id(0), restype(ResourceType::DEMO), link("") {}

	ResourceType SoftUni::Resource::getType()const { return restype; }

	inline void Resource::setType(const ResourceType& ntype) { this->restype = ntype; }

	// End class Resource definitions
}; // namespace SoftUni

	using SoftUni::ResourceType;
	using SoftUni::Resource;

	std::istream& operator>>(std::istream& in, Resource& r) {
		std::map<std::string, ResourceType> types = {
			{"Presentation", ResourceType::PRESENTATION},
			{"Demo", ResourceType::DEMO},
			{"Video", ResourceType::VIDEO}
		};
		std::string res;
		in >> r.id >> res >> r.link;
		r.setType(types[res]);
		return in;
	}

	std::ostream& operator<<(std::ostream& out, const Resource& r) {
		out << r.id << " " << r.getType() << " " << r.link;
		return out;
	}

	bool operator<(const Resource& l, const Resource& r) {
		return   l.id < r.id;;
	}





#endif // !RESOURCE_H