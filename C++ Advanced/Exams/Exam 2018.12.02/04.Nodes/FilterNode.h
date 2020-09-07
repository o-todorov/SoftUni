#pragma once
#ifndef  FILTER_NODE_H
#define FILTER_NODE_H

#include "NodeBase.h"

class FilterNode:public NodeBase {
	std::vector<byte> filtered;
public:
	FilterNode(size_t id, std::vector<byte> filtered):
		NodeBase(id),
		filtered(filtered) {
	}

	void process(byte data)override {
		for ( byte b : filtered )
			if ( data == b ) 	return;

		this->sendToConnected(data);
	}

	~FilterNode() {}

private:

};






#endif // ! FILTER_NODE_H