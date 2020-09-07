#pragma once
#ifndef  REVERSE_NODE_H
#define REVERSE_NODE_H

#include "NodeBase.h"

class ReverseNode:public NodeBase {
	const char stop = '.';
public:
	ReverseNode(size_t id):NodeBase(id) {}

	void process(byte data)override {
		static std::string result = "";
		if ( data == stop ) {
			for ( int i = result.size() - 1; i >= 0; i-- )
				this->sendToConnected(result[i]);

			result = "";
			return;
		}
		result+=data;
	}

	~ReverseNode() {}

private:

};


#endif // ! REVERSE_NODE_H