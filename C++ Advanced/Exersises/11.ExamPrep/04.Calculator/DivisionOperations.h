#pragma once
#ifndef DIVISION_OPERATIONS_H
#define DIVISION_OPERATIONS_H



class DivisionOp: public Operation {
	enum State { isEmpty = 0, oneOperand = 1, completed = 2 };

	State state = isEmpty;
	int number;
	int result;
public:
	void addOperand(int operand) override {
		if ( state == isEmpty ) {
			number = operand;
			state = oneOperand;
		}
		else {
			if ( operand == 0 )throw "Error: Division by 0";
			this->result = number / operand;
			state = completed;
		}
	}

	bool isCompleted() override {
		return state == completed;
	}

	int getResult() override {
		return this->result;
	}
};



#endif // !DIVISION_OPERATIONS_H