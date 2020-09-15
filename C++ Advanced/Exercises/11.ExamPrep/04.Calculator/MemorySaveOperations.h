#pragma once
#ifndef MEMORY_SAVE_OPERATIONS_H
#define MEMORY_SAVE_OPERATIONS_H


class MemorySaveOp: public Operation {
	bool isSaved;
	int result;
public:
	MemorySaveOp():isSaved(false) {}

	void addOperand(int operand) override {
		result = operand;
		memory.push(operand);
		isSaved = true;
	}

	bool isCompleted() override {
		return isSaved;
	}

	int getResult() override {
		return this->result;
	}
};


#endif // !MEMORY_SAVE_OPERATIONS_H