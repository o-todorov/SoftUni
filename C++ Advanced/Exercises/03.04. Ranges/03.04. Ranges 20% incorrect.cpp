
#include <iostream>
#include <vector>
#include <sstream>
#include <string>
#include <iterator>

size_t counter = 0;
size_t msize = 0;

void fillarrs(int** m) {
    std::vector<int* > couples;

    std::string line;

    std::getline(std::cin, line, '.');
    std::istringstream in(line);
    int from, to;

    while ( in >> from >> to )      couples.emplace_back(new int[2] {from, to});

    msize = couples.size();
    m = new int* [msize];
    std::copy(couples.begin(), couples.end(), m);
    for ( auto a : couples ) a=nullptr;
}

void checkinrange(int& x,int** m) {

    for ( ; counter < msize; counter++ ) {
        if ( x < m[counter][0] ) {
            std::cout << "out\n";
            return;
        }
        if ( x <= m[counter][1] ){
            std::cout << "in\n";
            return;
        }
        if ( counter == msize-1 )   std::cout << "out\n";
    }
}


int main(){
    int** m = nullptr;

    fillarrs(m);

    std::string line;
    int num;
    std::getline(std::cin, line, '.');
    std::istringstream in(line);

    void (*docheck)(int& x, int** )=nullptr;
    docheck = checkinrange;
    while (in>>num )  docheck(num,m) ;


    for ( size_t i = 0; i < msize; i++ ) {
        delete[] m[i];

    }
    delete[] m;
    m = nullptr;


    return 0;
}

