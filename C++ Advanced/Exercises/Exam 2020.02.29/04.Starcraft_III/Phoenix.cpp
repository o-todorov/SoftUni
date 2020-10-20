#include "Phoenix.h"
#include"Defines.h"

Phoenix::Phoenix(const AirShipType type, 
				 const int health, 
				 const int damage, 
				 const int maxShield, 
				 const int shieldRegenerateRate, 
				 const int shipId)
	:ProtossAirShip(type,
					health,
					damage,
					maxShield,
					shieldRegenerateRate,
					shipId) {
}

void Phoenix::dealDamage(std::vector<std::unique_ptr<AirShip>>& enemyFleet) {
	int damage = this->_damage;
	Defines::SingleTurn(enemyFleet, damage, this);
}
