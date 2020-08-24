#pragma once
#ifndef INITIALIZATION_H
#define INITIALIZATION_H

#include "CommandInterface.h"
#include "MainInterface.h"

std::shared_ptr<CommandInterface> buildCommandInterface(std::string& text) {

	auto ptr = std::make_shared< MainInterface>(text);
	ptr->init();

	return ptr;
}

#endif // !INITIALIZATION_H
