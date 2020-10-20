#pragma once
#ifndef  DIGIT_TO_INT_NODE_H
#define DIGIT_TO_INT_NODE_H

#include "NodeBase.h"


class DigitsToIntNode:public NodeBase {
	const char stop = '.';
	std::vector<byte> result;
	std::string res;
public:
	DigitsToIntNode(size_t id):
		NodeBase(id) {
	}

	void process(byte data)override {

		if ( data >= '0' && data <= '9' )
			res += data;

		else if ( data == stop ) {
			this->sendToConnected(( byte ) stoi(res));
			res.clear();
		}
	}

	~DigitsToIntNode() {}

private:

};



#endif // ! DIGIT_TO_INT_NODE_H