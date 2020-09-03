#include "MemoryMonitor.h"
#include <iostream>

MemoryMonitor::MemoryMonitor() {
}

MemoryMonitor::~MemoryMonitor() {
	for ( MemoryNode node : this->_nodes ) {
		delete[] node.data;
		node.data = nullptr;
	}
}

void MemoryMonitor::pushNode(const int nodeSize) {
	_nodes.emplace_back();
	_nodes.back().size = nodeSize;
	_nodes.back().data = new int[nodeSize];

	std::cout << "Pushed node with memory occupation: " << sizeof(_nodes.back().data[0]) * _nodes.back().size << std::endl;
}


void MemoryMonitor::popNode() {
	if ( !this->_nodes.empty() ) {
		std::cout << "Popped node with memory occupation: " << sizeof(_nodes.back().data[0]) * _nodes.back().size << std::endl;

		delete[] this->_nodes.back().data;
		this->_nodes.back().data = nullptr;
		this->_nodes.erase(this->_nodes.begin() + this->_nodes.size() - 1);
	}
	else
		std::cout << "No nodes to pop" << std::endl;
}

void MemoryMonitor::printMemoryOccupation(const int numberOfNodes) {
	size_t size = 0;
	for ( int i = 0; i < std::min(numberOfNodes,(int) _nodes.size()); i++) {
		size += sizeof(_nodes[i].data[0]) * _nodes[i].size;
	}
	std::cout << "Memory occupation for first " << numberOfNodes << " memory nodes is: ";
		std::cout << size << std::endl;
}

MemoryNode MemoryMonitor::getLastNode() const {
	if ( !this->_nodes.empty() )
		return this->_nodes.back();

		return MemoryNode();
}
