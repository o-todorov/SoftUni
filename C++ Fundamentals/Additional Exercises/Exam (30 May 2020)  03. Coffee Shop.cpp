#include <iostream>
#include<string>
#include<vector>

using namespace std;

class Coffee {
    double price;
    double rating;

public:
    string name;

    Coffee(string name_,double price_,double rating_):
        name(name_),
        price(price_),
        rating(rating_) { }

    void addNew() {     // Just for the requirements

    }

    double getRating() {
        return this->rating;
    }

    double getPrice() {
        double res = this->price;

        if ( rating >= 4 && rating <= 5.99 ) res *= 0.9;

        return res;
    }

    void changePrice(double newprice) {
        price = newprice;
    }
};
    //  Just for the requirements
    void deleteDrink(vector <Coffee> &drinks,string drinkname) {
        for ( vector<Coffee>::iterator it = drinks.begin(); it != drinks.end(); it++ )
            if ( it->name == drinkname ) {
                drinks.erase(it);
                break;
            }
    }

int main() {
    vector <Coffee> drinks;
    int count;
    cin >> count;

    string name;
    double price, rating;

    while ( count-- ) {
        cin.ignore();
        getline(cin, name);         // Getline() because of dual words names in the Input
        cin >> price >> rating;     
        drinks.push_back(Coffee(name, price, rating));
    }

    for ( int i = drinks.size() - 1; i >= 0; i-- )
        if ( drinks[i].getRating ()< 4 )            // Vheck drinks for low rating
            deleteDrink(drinks, drinks[i].name);    // Call delete drink by name method 

    if ( drinks.empty() ) cout << "The menu is empty" << endl;
    else
        for ( auto drink : drinks ) 
            cout << drink.name << " " << drink.getPrice() << endl;

    return 0;
}
