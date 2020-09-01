#include "MemoryPool.h"
#include <iostream>

MemoryPool::MemoryPool(const int memoryPoolSize):
	_MEMORY_POOL_SIZE(memoryPoolSize) {
	this->_memoryBuffer = new int[memoryPoolSize] {0};
	this->_isMemoryBufferOccupied = new bool[memoryPoolSize] {false};
}

MemoryPool::~MemoryPool() {
	delete[]this->_memoryBuffer;
	this->_memoryBuffer = nullptr;
	delete[] this->_isMemoryBufferOccupied;
	this->_isMemoryBufferOccupied = nullptr;
}

ErrorCode MemoryPool::requestMemory(MemoryNode& outNode) {
	if ( outNode.size > _MEMORY_POOL_SIZE )
		return ErrorCode::REQUEST_FAILURE_BIGGER_THAN_BUFFER;

	int mem = 0, index = 0;

	for ( ; index < _MEMORY_POOL_SIZE; index++ ) {
		!_isMemoryBufferOccupied[index] ? mem++ : mem = 0;

		if ( mem == outNode.size ) {
			index = index - mem + 1;
			outNode.bufferStartIndex = index;
			outNode.memory = &_memoryBuffer[index];
			occupyMemory(outNode);
			return ErrorCode::REQUEST_SUCCESS;
		}
	}

	return ErrorCode::REQUEST_FAILURE_NOT_ENOUGH_MEMORY;
}

void MemoryPool::releaseMemory(const MemoryNode& outNode) {
	int offset = outNode.bufferStartIndex;
	for ( int i = offset; i < offset + outNode.size; i++ ) {
		_isMemoryBufferOccupied[i] = false;
	}
}

void MemoryPool::zeroMemoryValue(const MemoryNode& node) {
	int offset = node.bufferStartIndex;
	for ( int i = offset; i < offset + node.size; i++ ) {
		_memoryBuffer[i] = 0;
		_isMemoryBufferOccupied[i] = false;
	}
}

void MemoryPool::occupyMemory(const MemoryNode& node) {
	for ( int i = node.bufferStartIndex; i < node.bufferStartIndex + node.size; i++ )
		_isMemoryBufferOccupied[i] = true;
}

