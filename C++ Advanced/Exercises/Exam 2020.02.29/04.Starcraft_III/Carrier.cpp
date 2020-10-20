#include "Carrier.h"
#include"Defines.h"

Carrier::Carrier(const AirShipType type,
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
	_activeInterceptors = InterceptorDefines::MAX_INTERCEPTORS;
}

void Carrier::takeDamage(const int damage) {
	ProtossAirShip::takeDamage(damage);

	if ( _currHealth < _maxHealth ) _activeInterceptors = InterceptorDefines::DAMAGED_STATUS_INTERCEPTORS;
	else _activeInterceptors = InterceptorDefines::MAX_INTERCEPTORS;
}

void Carrier::dealDamage(std::vector<std::unique_ptr<AirShip>>& enemyFleet) {
	int damage = this->_damage;

	for ( int i = 0; i < _activeInterceptors; i++ )
		if ( !enemyFleet.empty() )
			Defines::SingleTurn(enemyFleet, damage, this);
}
