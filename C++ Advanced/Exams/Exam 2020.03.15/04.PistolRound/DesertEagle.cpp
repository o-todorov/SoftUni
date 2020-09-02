#include "DesertEagle.h"

DesertEagle::DesertEagle(const int damagePerRound, const int clipSize, const int remainingAmmo)
	:Pistol(damagePerRound, clipSize, remainingAmmo) {
}

bool DesertEagle::fire(PlayerVitalData& enemyPlayerData) {
	int power = this->_damagePerRound;

	if ( this->_currClipBullets == 0 ) {
		reload();
		return false;
	}

	if ( enemyPlayerData.armor == 0 ) enemyPlayerData.health -= power;
	else {
		int rest = std::max(power / 4 - enemyPlayerData.armor, 0);

		enemyPlayerData.armor = std::max(0, enemyPlayerData.armor - power / 4);

		enemyPlayerData.health =  enemyPlayerData.health - power * 3 / 4 - rest;

	}
	_currClipBullets--;

	std::cout << "Enemy left with: " << enemyPlayerData.health << " health and ";
	std::cout << enemyPlayerData.armor << " armor" << std::endl;

	if ( enemyPlayerData.health > 0 ) return false;
	else return true;
}
