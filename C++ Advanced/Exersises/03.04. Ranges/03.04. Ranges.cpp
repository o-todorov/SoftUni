
#include <iostream>
#include<algorithm>

int msize = 0;      // Keep used size of the array
int ranges[20002];  // Max 10000 ranges * 2  + 2 just in case :)

void checkinrange() {

    std::cin.clear();
    std::cin.ignore();

    int num;

    std::cin.sync_with_stdio(false); std::cin.tie(NULL);

    while ( std::cin >> num ) {

        int* found = std::lower_bound(ranges, ranges + msize,num);
        int pos = found - ranges;   

                                            // check if the position is even ( start of range )
                                            // or odd ( end of range )
        if(pos!=msize  && num>=ranges[0] && ( pos%2==0 ? num==(*found) : num<=(*found)))    
                std::cout << "in\n";
        else                                                    
                std::cout << "out\n";
    }
}


int main() {
    std::cin.sync_with_stdio(false); std::cin.tie(NULL);

    while ( std::cin >> ranges[msize] ) msize++;

    std::sort(ranges, ranges + msize);  // Sort the bounds 

    checkinrange();

    return 0;
}

