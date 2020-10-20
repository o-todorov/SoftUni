#include "BattleCruser.h"
#include "Defines.h"

BattleCruser::BattleCruser(const AirShipType type,
						   const int health,
						   const int baseDamage,
						   const int shipId):
	TerranAirShip(type, health, baseDamage, shipId) {
}

void BattleCruser::dealDamage(std::vector<std::unique_ptr<AirShip>>& enemyFleet) {
	int damage = this->_damage;
	if ( _passedTurns == YAMATO_CANNON_LOADING_TIME ) damage *= 5;

	Defines::SingleTurn(enemyFleet, damage, this);
}
