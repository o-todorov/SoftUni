#pragma once
#ifndef ECHO_H
#define ECHO_H

extern bool echoOn;

#include <iostream>
#define echo(value) if(echoOn)  std::cout<<(value)<<std::endl;



#endif // !ECHO_H
