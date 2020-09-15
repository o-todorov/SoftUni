
#include <iostream>
#include <vector>
#include <sstream>
#include <string>
#include <iterator>
#include<algorithm>


int msize = 0;
int jump_size = 100;

bool sortarr(const int* a, const int* b) {
    return a[0] < b[0];
}

void fillarrs(int**& matr) {
    std::vector<int* > couples;

    std::string line;

    std::getline(std::cin, line, '.');
    std::istringstream in(line);
    int from, to;

    while ( in >> from >> to )   couples.push_back(new int[2] {from, to});

    msize = couples.size();
    matr = new int* [msize];
    std::copy(couples.begin(), couples.end(), matr);
    for ( auto a : couples ) a = nullptr;


    std::sort(matr, matr + msize, sortarr);
}


void checkinrange(int** matr) {

    std::string line;
    std::getline(std::cin, line, '.');
    std::istringstream in(line);

    int num;
    int start = 0, newstart,  end ;

    while ( in >> num ) {

        newstart = start + jump_size;

        while ( newstart < msize && num >= matr[newstart][0] ) {
            start = newstart;
            newstart = start + jump_size;
        }

        newstart <= msize ? end = newstart : end = msize;

        bool found = false;

        for ( int i = start; i < end; i++ ) {

            if ( matr[i][0] <= num && num <= matr[i][1] ) {
                std::cout << "in\n";
                found = true;
                break;
            }
        }

        if ( !found ) std::cout << "out\n";
        
    }
}


int main() {
    int** matr = nullptr;

    fillarrs(matr);

    checkinrange(matr);


    for ( int i = 0; i < msize; i++ ) {
        std::cout << matr[i][0] << " " << matr[i][1] << std::endl;
        delete[] matr[i];
    }
    delete[] matr;
    matr = nullptr;


    return 0;
}

