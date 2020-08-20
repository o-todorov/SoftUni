#pragma once
#ifndef BYTE_CONTAINER_H
#define BYTE_CONTAINER_H

class ByteContainer {
private:
protected:
	std::string bytes;
public:
	ByteContainer(std::string bytes):bytes(bytes) {}

	virtual std::string getBytes()const { return this->bytes; }

	virtual void setBytes(const std::string& new_bytes) { this->bytes = new_bytes; }

	virtual size_t getSize() const { return this->bytes.length(); }

	~ByteContainer() {}
};


#endif // !BYTE_CONTAINER_H
