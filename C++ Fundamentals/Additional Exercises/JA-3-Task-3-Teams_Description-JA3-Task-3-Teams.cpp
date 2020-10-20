#include <iostream>
#include <string>
#include <map>
#include<vector>
#include<set>

using namespace std;

int main() {
    int count;
    cin >> count;

    map<string, vector<string> > teams;
    map<string, int>teamscores;
    map<string, int>playersscores;

    while ( count--) {
        string team,player;
        int players;
        cin >> team>>players;
        vector<string>t(players);

        for ( int i = 0; i < players; i++ ) {
            cin >> t[i];
            playersscores[t[i]] = 0;
        }

        teams[team] = t;
        teamscores[team] = 0;
    }

    cin >> count;
    string winner;

    while ( count-- ) {
        cin >> winner;
        teamscores[winner]++;
    }
    for ( auto team : teams ) {
        string teamname = team.first;
        for ( string player : team.second )
            playersscores[player] += teamscores[teamname];

    }
    for ( auto player : playersscores ) cout << player.second << " ";

    return 0;
}
