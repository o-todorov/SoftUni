#pragma once
#ifndef DEFINES_H
#define DEFINES_H

#include "AirShip.h"

namespace Defines {
	void SingleTurn(std::vector<std::unique_ptr<AirShip>>& Fleet, int& damage, AirShip* ship);
}




#endif // !DEFINES_H


