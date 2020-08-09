#ifndef SEQUENCE_H
#define SEQUENCE_H

#include <vector>

template<typename T, typename Generator>
class Sequence;

template<typename T, typename Generator>
class SequenceIteratorType {
public:
	SequenceIteratorType(const Sequence<T, Generator>& sequence, const size_t& index):
		sequence(sequence),
		index(index) {
	}

	SequenceIteratorType getBegin() {
		return SequenceIteratorType(sequence, 0);
	}

	SequenceIteratorType getEnd() {
		return SequenceIteratorType(sequence, sequence.size());
	}

	bool operator !=(const SequenceIteratorType& other)const {
		return this->index != other.index;
	}

	SequenceIteratorType& operator ++() {
		this->index++;
		return *this;
	}

	const T& operator *()const {
		return this->sequence.at(this->index);
	}

private:
	std::vector<T>& sequence;
	size_t index;
};

template<typename T, typename Generator>
using iterator = SequenceIteratorType<T, Generator>;

template<typename T, typename Generator>
using const_iterator = SequenceIteratorType<T, Generator>;


template<typename T, typename Generator>
class Sequence {

private:
	Generator generator;
	std::vector<T> generated;
	SequenceIteratorType<T,Generator> Iterator;

public:
	Sequence():Iterator(*this, 0) {}

	size_t size()const { return generated.size(); }
	void generateNext(int n) {
		for ( int i = 0; i < n; i++ ) {
			this->generated.push_back(this->generator());
		}
	}
	//template <typename T, size_t const Size>
	//dummy_array_iterator<T, Size> begin(
	//	dummy_array<T, Size>& collection) {
	//	return dummy_array_iterator<T, Size>(collection, 0);
	//}
	template<typename T, Generator>
	SequenceIteratorType<T, Generator>& begin() const {
		return Iterator.getBegin();
	}

	//iterator<T, Sequence <typename T, typename Generator>, 0 > end()(Sequence& coll) {
	//	return Sequence < T, Sequence <typename T, typename Generator>(
	//		coll, colj
	//		)
	//}



};




#endif // !SEQUENCE_H
