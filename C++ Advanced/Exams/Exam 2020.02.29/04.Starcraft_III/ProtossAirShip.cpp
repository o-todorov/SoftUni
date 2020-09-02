#include "ProtossAirShip.h"

ProtossAirShip::ProtossAirShip(const AirShipType type,
							   const int health,
							   const int damage,
							   const int maxShield,
							   const int shieldRegenerateRate,
							   const int shipId)
	:AirShip(type, health, damage, shipId),
	_maxShield(maxShield),
	_shieldRegenerateRate(shieldRegenerateRate),
	_currShield(maxShield) {
}

void ProtossAirShip::takeDamage(const int damage) {
	int diff = std::min(damage, _currShield);
	_currShield -= diff;

	_currHealth -= ( damage - diff);
}

void ProtossAirShip::finishTurn() {
	_currShield = std::min(_maxShield, _currShield + this->_shieldRegenerateRate);
}
