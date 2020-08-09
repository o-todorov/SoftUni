#include <iostream>
#include <sstream>

#include "List.h"

List::Node::Node(int value, Node* prev, Node* next):
	value(value),
	prev(prev),
	next(next) {
}

int List::Node::getValue() const {
	return this->value;
}

void List::Node::setValue(int value) {
	this->value = value;
}

List::Node* List::Node::getNext() const {
	return this->next;
}

void List::Node::setNext(Node* next) {
	this->next = next;
}

List::Node* List::Node::getPrev() const {
	return this->prev;
}

void List::Node::setPrev(Node* prev) {
	this->prev = prev;
}

List::List():
	head(nullptr),
	tail(nullptr),
	size(0) {
}

List::List(const List& other):
	head(nullptr),
	tail(nullptr),
	size(0) {
	this->addAll(other);
}

int List::first() const {
	if ( this->size > 0 )	return this->head->getValue();
	else throw ("List Is Empty, There Is No First Element");
}

void List::add(int value) {
	if ( this->size == 0 ) {
		this->head = new List::Node(value, nullptr, nullptr);
		this->tail = this->head;
	}
	else {
		this->tail->setNext(new List::Node(value, this->tail, nullptr));
		this->tail = this->tail->getNext();
	}
	this->size++;
}

void List::addAll(const List& other) {
	if ( other.size == 0 )return;

	this->add(other.first());

	List::Node* node = other.head->getNext();

	while ( node != nullptr ) {
		this->tail->setNext(new List::Node(node->getValue(), this->tail, nullptr));
		this->tail = this->tail->getNext();
		this->size++;
		node = node->getNext();
	}
	node = nullptr;
}

void List::removeFirst() {

	if ( this->size == 0 )return;

	else if ( this->size == 1 ) {
		this->tail = nullptr;
		delete this->head;
		this->head = nullptr;
		this->size = 0;
	}

	else {
		this->head = this->head->getNext();
		delete this->head->getPrev();
		this->head->setPrev(nullptr);
		this->size--;
	}
}

void List::removeAll() {
	if ( this->size == 0 )return;

	List::Node* node;
	while ( this->tail != nullptr ) {
		node = this->tail;
		this->tail = node->getPrev();
		delete node;
	}
	this->head = nullptr;
	this->size = 0;
	node = nullptr;
}

size_t List::getSize() const {
	return this->size;
}

bool List::isEmpty() const {
	return this->size == 0;
}

List List::getReversed(List l) {
	List ret;
	List::Node* node = l.tail;

	while ( node != nullptr ) {
		ret.add(node->getValue());
		node = node->getPrev();
	}
	ret.size = l.getSize();
	node = nullptr;
	return ret;
}

std::string List::toString() const {
	std::ostringstream out;

	List::Node* node = this->head;

	while ( node != nullptr ) {
		out << node->getValue() << " ";
		node = node->getNext();
	}
	if ( out.str().back() = ' ' )out.str().pop_back();
	return out.str();
	node = nullptr;
}

List& List::operator<<(const int& value) {
	this->add(value);
	return *this;
}

List& List::operator<<(const List& other) {
	this->addAll(other);
	return *this;
}

List& List::operator=(const List& other) {
	this->removeAll();
	this->addAll(other);
	return *this;
}

List::~List() {
	this->removeAll();
}
