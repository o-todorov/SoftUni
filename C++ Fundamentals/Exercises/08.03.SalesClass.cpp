#include<iostream>
#include<set>
#include<vector>
#include<iomanip>

using namespace std;

class Sales {

    class Sale {

            class Product {
        public:
            string name;    double price;   double quantity;

            Product(string name, double price, double quant):
                name(name), 
                price(price), 
                quantity(quant){ }
        };

        Product product;
    public:
        string town;
        Sale(string town, string name, double price, double quant):
            town(town),
            product(name,price,quant){ }

        double get_sale_price() {
            return product.price * product.quantity;
        }
    };

    vector<Sale> sales;
public:
    void add_sale(string town,string product,double price,double quantity) {
        sales.push_back(Sale (town, product, price, quantity));
    }

    double get_total_sales(string town) {
        double total = 0;

        for ( Sale sale : this->sales ) 
            if ( sale.town == town )  total += sale.get_sale_price();

        return total;
    }
};


int main() {
    
    int sales_number;
    cin >> sales_number;
    cin.ignore();

    set<string>towns;
    Sales sales;
    string town, product;
    double price, quantity;
    
    while(sales_number--) {
        cin >> town >> product >> price >> quantity;
        sales.add_sale(town,product,price,quantity);
        towns.insert(town);
    }


    for ( string town : towns )
        cout << town << " -> " <<fixed<<setprecision(2)<< sales.get_total_sales(town) << endl;

    return 0;
}