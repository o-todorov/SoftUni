#pragma once
#ifndef MAIN_INTERFACE_H
#define MAIN_INTERFACE_H

#include "TextTransform.h"
#include "CutTransform.h"
#include "PasteTransform.h"
#include "CommandInterface.h"

class MainInterface:public CommandInterface {
public:
	MainInterface(std::string& text):CommandInterface(text) {
	}

	~MainInterface() {}

private:
	std::vector<Command> initCommands()override {
		auto v = CommandInterface::initCommands();
		v.push_back(Command("cut", std::make_shared<CutTransform>()));
		v.push_back(Command("paste", std::make_shared<PasteTransform>()));
		return v;
	}

};

#endif // !MAIN_INTERFACE_H
