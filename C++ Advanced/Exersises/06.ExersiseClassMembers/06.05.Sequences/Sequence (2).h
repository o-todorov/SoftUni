#ifndef SEQUENCE_H
#define SEQUENCE_H

#include <vector>


template <typename T>
class Sequence_iterator_type {
public:
	Sequence_iterator_type() { index = 0; }
	Sequence_iterator_type(const std::vector<T>& vec, const size_t  index):
		index(index),
		vec(vec) {
	}

	Sequence_iterator_type getEnd(const std::vector<T>& sequenceElements) {
		return Sequence_iterator_type(sequenceElements, -1);
	}

	bool operator!= (Sequence_iterator_type const& other) const {
		return this->index != other.index;
	}

	T const& operator* () const {
		return vec.at(this->index);
	}

	Sequence_iterator_type const& operator++ () {
		++index;
		return *this;
	}

private:
	size_t   index;
	std::vector<T>& vec;
};

template <typename T>
using iterator = Sequence_iterator_type< T>;

template < typename T>
using const_iterator = const Sequence_iterator_type<  T>;


template <typename T, typename Generator>
class Sequence {
	Generator generator;
	std::vector<T> generated;
	iterator<T> it;
public:
	Sequence():it(iterator<T>()){}
	void generateNext(int n) {
		for ( int i = 0; i < n; i++ ) {
			this->generated.push_back(this->generator());
		}
	}

	iterator<T> begin() {
		return iterator<T>(this->generated, 0);
	}

	iterator<T> end() {
		return it.getEnd(this->generated);
	}

};






//template <typename T>

//template <typename T>

//template <typename T>
//const_iterator<T> begin(const std::vector<T>& vec) {
//	return const_iterator< T>(vec, 0);
//}
//
//template <typename T>
//const_iterator<T> end(const std::vector<T>& vec) {
//	return const_iterator< T>(vec, vec.size());
//}



#endif // !SEQUENCE_H
