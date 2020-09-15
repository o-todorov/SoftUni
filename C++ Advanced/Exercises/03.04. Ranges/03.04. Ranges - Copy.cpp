
#include <iostream>
#include <vector>
#include <sstream>
#include <string>
#include <iterator>


    int msize = 0;

void fillarrs(int** &m) {
    std::vector<int* > couples;

    std::string line;

    std::getline(std::cin, line, '.');
    std::istringstream in(line);
    int from, to;

    while ( in >> from >> to )   couples.emplace_back(new int[2] {from, to});

    msize = couples.size();
    m = new int* [msize];
    //m = &couples[0];
    std::copy(couples.begin(), couples.end(), m);
    for ( auto a : couples ) a = nullptr;

}

void checkinrange( int** m) {

    std::string line;
    int num;
    std::getline(std::cin, line, '.');
    std::istringstream in(line);

    while ( in >> num ) {

        for ( int i = 0; i < msize; i++ ) {
            if ( num < m[i][0] ) {
                std::cout << "out\n";
                break;
            }
            else if( num <= m[i][1] ){
                std::cout << "in\n";
                break;
            }else if ( i == msize - 1 )std::cout << "out\n";

        }
    }
}


int main(){
    int** m = nullptr;

    fillarrs(m);

    checkinrange(m);


    for ( int i = 0; i < msize; i++ ) {
        delete[] m[i];
        m[i] = nullptr;
    }

    delete[] m;
    m = nullptr;


    return 0;
}

