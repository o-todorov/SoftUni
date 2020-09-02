#include "Viking.h"
#include"Defines.h"
#include "ProtossAirShip.h"

Viking::Viking(const AirShipType type,
			   const int health,
			   const int baseDamage,
			   const int shipId):
	TerranAirShip(type, health, baseDamage, shipId) {
}

void Viking::dealDamage(std::vector<std::unique_ptr<AirShip>>& enemyFleet) {
	int damage = this->_damage;
	Defines::SingleTurn(enemyFleet, damage, this);

}


