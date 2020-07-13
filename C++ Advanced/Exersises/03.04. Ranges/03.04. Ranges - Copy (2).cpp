
#include <iostream>
#include <vector>
#include <sstream>
#include <string>
#include <iterator>

int msize = 0;
int jump_size = 5;

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
}

void checkinrange(int** matr) {

    std::string line;
    int num;
    std::getline(std::cin, line, '.');
    std::istringstream in(line);

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
                std::cout << num << "  " << "in\n";
                found = true;
                break;
            }
        }

        if ( !found) std::cout << num << "  " << "out\n";
        
    }
}


int main() {
    int** matr = nullptr;

    fillarrs(matr);

    checkinrange(matr);


    for ( int i = 0; i < msize; i++ ) {
        delete[] matr[i];
    }
    delete[] matr;
    matr = nullptr;


    return 0;
}

