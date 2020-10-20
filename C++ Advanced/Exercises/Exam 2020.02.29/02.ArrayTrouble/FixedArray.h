#ifndef FIXEDARRAY_H_
#define FIXEDARRAY_H_

#include "BrokenArray.h"
#include <string>

class FixedArray : public BrokenArray
{
    public:
        FixedArray(const int arraySize);
        virtual ~FixedArray();

        FixedArray(const FixedArray & other);
        FixedArray & operator=(const FixedArray & other);

        void addValueToMemory(const int value);

        int getMemorySumValue() const;

        //void print( std::string message );
        //void print( std::string message ) const;
};

#endif /* FIXEDARRAY_H_ */
