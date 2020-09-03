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


// auto sp = std::make_shared<C>(12);
std::shared_ptr<CommandInterface>  buildCommandInterface(std::string& text) {
	auto ptr= std::make_shared <Initialization>(text);

	return 
}

#endif // ! INITIALIZATION_H
