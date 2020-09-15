#pragma once
#ifndef WORD_H
#define  WORD_H
#include <string>



class Word {
public:
	Word();
	Word(std::string word);
	std::string getWord()const;
	int getCount()const;
	void incCount()const;
	Word (const Word& other);

	friend bool operator<(const Word& l,const Word& r);
	friend bool operator==(const Word& l, const Word& r);
	friend bool operator!=(const Word& l, const Word& r);

private:
	std::string word;
	mutable int count;
};





#endif // !WORD_H
