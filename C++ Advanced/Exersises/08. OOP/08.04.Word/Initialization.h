#pragma once
#ifndef  INITIALIZATION_H
#define INITIALIZATION_H

#include <string>

class Initialization:CommandInterface {
public:
	Initialization(std::string& text):
		CommandInterface(text),
		text(text) {
	}


private:
	std::string text;
};



std::shared_ptr<CommandInterface>  buildCommandInterface(std::string& text) {

	return std::make_shared<CommandInterface>( new Initialization(text));
}

#endif // ! INITIALIZATION_H
