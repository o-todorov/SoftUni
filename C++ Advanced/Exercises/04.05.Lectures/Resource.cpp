#include "Resource.h"

using namespace SoftUni;



//std::istream& SoftUni::operator>>(std::istream& in, Resource& r) {
//	std::map<std::string, ResourceType> types = {
//		{"Presentation", ResourceType::PRESENTATION},
//		{"Demo", ResourceType::DEMO},
//		{"Video", ResourceType::VIDEO}
//	};
//	std::string res;
//	in >> r.id >> res >> r.link;
//	r.setType(types[res]);
//	return in;
//}
//
//std::ostream& SoftUni::operator<<(std::ostream& out, const Resource& r) {
//	out << r.id << " " << r.getType() << " " << r.link;
//	return out;
//}
//
//bool SoftUni::operator<(const Resource& l, const Resource& r) {
//	return   l.id < r.id;;
//}

