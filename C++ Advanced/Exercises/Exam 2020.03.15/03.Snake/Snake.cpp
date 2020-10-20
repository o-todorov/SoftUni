#include "Snake.h"

Snake::Snake(const int fieldRows, const int fieldCols, const Point& startPos):
	_FIELD_ROWS(fieldRows),
	_FIELD_COLS(fieldCols),
	_currPos(startPos) {
	_snakeNodes.push_back(startPos);
}

Snake::~Snake() {
}

StatusCode Snake::move(const Direction dir, const std::vector<Point>& obstacles, std::vector<Point>& powerUps) {
	Point newPoint=_snakeNodes.front();

	if ( dir == Direction::UP ) newPoint.row--;
	else if ( dir == Direction::DOWN ) newPoint.row++;
	else if ( dir == Direction::LEFT ) newPoint.col--;
	else newPoint.col++;  // dir == Direction::RIGHT 

	if ( newPoint.row < 0 || newPoint.row >= _FIELD_ROWS ||
		newPoint.col < 0 || newPoint.col >= _FIELD_COLS )
		return StatusCode::SNAKE_DEAD;

	for ( Point p : obstacles )
		if ( p == newPoint )
			return StatusCode::SNAKE_DEAD;

	for ( Point p : _snakeNodes )
		if ( p == newPoint )
			return StatusCode::SNAKE_DEAD;

	for ( unsigned i = 0; i < powerUps.size(); i++ )
		if ( powerUps[i] == newPoint ) {
			_snakeNodes.insert(_snakeNodes.begin(), newPoint);
			powerUps.erase(powerUps.begin() + i);
			return StatusCode::SNAKE_GROWING;
		}

	_snakeNodes.insert(_snakeNodes.begin(), newPoint);
	_snakeNodes.erase(_snakeNodes.begin() + _snakeNodes.size()-1);

	return StatusCode::SNAKE_MOVING;
}

std::deque<Point>& Snake::getSnakeNodes() {
	return this->_snakeNodes;
}
