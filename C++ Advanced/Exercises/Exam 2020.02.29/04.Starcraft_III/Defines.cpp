#include "Defines.h"

#include <string>
#include <sstream>
#include <iostream>

void Defines::SingleTurn(std::vector<std::unique_ptr<AirShip>>& fleet, int& damage, AirShip* ship) {
	AirShip* enemy = &(*fleet.back());

	if ( ship->getAirShipType() == AirShipType::VIKING &&
		enemy->getAirShipType() == AirShipType::PHOENIX ) damage *= 2;

	enemy->takeDamage(damage);

	if ( !enemy->isAlive() ) {
		std::string type = "";

		switch ( ship->getAirShipType() ) {
			case AirShipType::VIKING: type = "Viking";
				break;
			case AirShipType::BATTLE_CRUSER: type = "BattleCruser";
				break;
			case AirShipType::PHOENIX: type = "Phoenix";
				break;
			case AirShipType::CARRIER: type = "Carrier";
				break;
			default:
				break;
		}
		std::ostringstream print;
		print << type << " with ID: " << ship->getAirShipId();
		print << " killed enemy airship with ID: " << enemy->getAirShipId() << std::endl;
		std::cout << print.str();

		enemy = nullptr;
		fleet.erase(fleet.begin() + fleet.size()-1);
	}

}

