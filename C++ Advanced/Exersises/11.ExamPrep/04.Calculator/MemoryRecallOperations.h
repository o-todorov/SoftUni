#pragma once
#ifndef MEMORY_RECALL_OPERATIONS_H
#define MEMORY_RECALL_OPERATIONS_H


class MemoryRecallOp: public Operation {
	int result;
public:
	MemoryRecallOp():result(0){
		if ( !memory.empty() ) {
			result = memory.top();
			memory.pop();
		}
	}

	void addOperand(int operand) override {
		throw "Invalid operation";
	}

	bool isCompleted() override {
		return true;
	}

	int getResult() override {
		return this->result;
	}
};



#endif // !MEMORY_RECALL_OPERATIONS_H
