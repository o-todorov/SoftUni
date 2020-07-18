#ifndef SUMOFVECTORS_H
#define SUMOFVECTORS_H


#include <vector>
#include <string>
typedef std::vector<std::string> myvec;

myvec operator+ (const myvec& left, const myvec& right);

myvec operator+ (const myvec& left, const myvec& right) {
	

	myvec retvec(left);
	
	for ( size_t i = 0; i < retvec.size(); i++ ) {
		retvec[i].append(" ").append(right[i]);
	}



	return retvec;

}









#endif // !SUMOFVECTORS_H