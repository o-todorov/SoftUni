#include "Glock.h"

Glock::Glock(const int damagePerRound, const int clipSize, const int remainingAmmo)
	:Pistol(damagePerRound, clipSize, remainingAmmo) {
}

bool Glock::fire(PlayerVitalData& enemyPlayerData) {
	int power = this->_damagePerRound;

	for ( int i = 0; i < 3; i++ ) {
		if ( this->_currClipBullets == 0 ) {
			reload();
			return false;
		}

		if ( enemyPlayerData.armor == 0 ) enemyPlayerData.health -= power;
		else {
			int rest = std::max(power / 2 - enemyPlayerData.armor, 0);
			enemyPlayerData.armor = std::max(0, enemyPlayerData.armor - power / 2);
			enemyPlayerData.health = enemyPlayerData.health - power / 2 - rest;

		}
		_currClipBullets--;

		std::cout << "Enemy left with: " << enemyPlayerData.health << " health and ";
		std::cout << enemyPlayerData.armor << " armor" << std::endl;

		if ( enemyPlayerData.health <= 0 ) break;

	}


	if ( enemyPlayerData.health <= 0 ) return true;
	else	return false;
}
