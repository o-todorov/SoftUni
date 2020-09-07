#pragma once
#ifndef  SUM_NODE_H
#define SUM_NODE_H

#include "NodeBase.h"

class SumNode:public NodeBase {

public:
	SumNode(size_t id):NodeBase(id) {}

	void process(byte data)override {
		static int sum = 0;

		if ( ( int ) data == 0 ) {
			this->sendToConnected(( byte ) sum);
			sum = 0;
		}
		else	sum += ( int ) data;
	}


	~SumNode() {}

private:

};


#endif // ! SUM_NODE_H
