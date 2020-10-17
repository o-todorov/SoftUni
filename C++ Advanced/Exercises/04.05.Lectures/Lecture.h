#ifndef LECTURE_H
#define LECTURE_H

#include <vector>
#include "Resource.h"

//using SoftUni::Resource;
//using SoftUni::ResourceType;

namespace SoftUni {

	class Lecture {
	public:
		Lecture():resources(std::vector<Resource>()) {}

		typedef std::vector<Resource>::iterator iterator;
		typedef std::vector<Resource>::const_iterator const_iterator;
		iterator begin() { return resources.begin(); }
		const_iterator begin() const { return this->resources.begin(); }
		iterator end() { return resources.end(); }
		const_iterator end() const { return this->resources.end(); }

		void add(Resource resource);
		const int operator[](const ResourceType& restype)const;

	private:
		std::vector<Resource> resources;

	}; // class Lecture

	std::vector<ResourceType>& operator<<(std::vector<ResourceType>& rt, const SoftUni::Lecture& lecture);

	SoftUni::Lecture& operator<<(SoftUni::Lecture& lecture, const Resource& r);

} // namespace SoftUni





#endif // !LECTURE_H