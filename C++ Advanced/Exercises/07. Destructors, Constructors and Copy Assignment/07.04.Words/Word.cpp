#include "Word.h"

Word::Word():count(0) {
}

Word::Word(std::string word) :
	word(word),
	count(1) {
}

std::string Word::getWord() const {
	return this->word;
}

int Word::getCount() const {
	return this->count;
}

void Word::incCount()const {
	this->count++;
}

bool operator<(const Word& l, const Word& r) {
	if ( l.getWord() == r.getWord() ) l.incCount();
	return l.getWord() < r.getWord();
}

bool operator==(const Word& l, const Word& r) {
	return  l.getWord() == r.getWord();
}

bool operator!=(const Word& l, const Word& r) {
	return !(l == r);
}

Word::Word(const Word& other):
	word(other.word),
	count(other.count) {
}





