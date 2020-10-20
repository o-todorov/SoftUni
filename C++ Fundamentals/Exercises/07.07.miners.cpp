#include<iostream>
#include<map>
#include<sstream>
#include<string>
#include <vector>
using namespace std;


///////////////////////////////////////////////////////////////

int main(){
    string input;
    int quantity;
    vector <string>res;
    map<string,int>resource;
    
    while (getline (cin,input)){
        if (input=="stop") break;
        cin>>quantity;
        cin.ignore();
        if(resource.find(input)==resource.end()){
            resource[input]=quantity;
            res. push_back(input);
            }
        else
            resource[input]+=quantity;
    }
    
    for(auto r:res){
        cout<<r<<" -> ";
        cout<<resource[r]<<endl;
    }
    
    
    return 0;
}