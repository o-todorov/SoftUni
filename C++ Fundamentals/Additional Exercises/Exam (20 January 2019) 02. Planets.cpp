#include <iostream>
#include <string>
#include <vector>
#include<sstream>

using namespace std;

class Planet {

public:
    string Name;
    long distance_from_sun;
    long diameter;
    long mass;

    Planet() {
        Name = "Unknown";
        distance_from_sun = 0;
        diameter = 0;
        mass = 0;
    }
    Planet(string _name, long _distance_from_sun, long _diameter, long _mass):
        Name(_name),
        distance_from_sun(_distance_from_sun),
        diameter(_diameter),
        mass(_mass) {
    }
    int ligth_to_sun_in_sec() {
        int secs = 0;
        int ligth_speed = 299792;
        return distance_from_sun / ligth_speed;
    }
    void print(ostream& out) {
        out << Name << " " << distance_from_sun << " " << diameter;
        out << " " << mass << endl << ligth_to_sun_in_sec() << endl;
    }

};

long min_planet_mass(vector<Planet>& planets) {
    if ( planets.size() == 0 ) return 0;
    long min = INT_MAX;

    for ( auto p : planets )
        if ( p.mass < min ) min = p.mass;

    return min;
}
long max_planet_diam(vector<Planet>& planets) {
    if ( planets.size() == 0 ) return 0;
    long max = 0;

    for ( auto p : planets )
        if ( p.diameter > max ) max = p.diameter;

    return max;
}



int main() {
    string planet_name;
    long distance, diameter, mass;

    vector<Planet>planets;

    int count;
    cin >> count;

    while ( count-- ) {
        cin >> planet_name >> distance >> diameter >> mass;
        planets.push_back(Planet(planet_name, distance, diameter, mass));
    }

    for ( auto p : planets ) p.print(cout);
    cout << min_planet_mass(planets) << endl;
    cout << max_planet_diam(planets) << endl;




    return 0;
}
