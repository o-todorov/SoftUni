#include<iostream>

using namespace std;

class Timeconvert {
private: int seconds;

public:
	Timeconvert(int hours, int minutes, int seconds):
		seconds(hours * 3600 + minutes * 60 + seconds) {
	}

	int tohours() {
		return seconds / 3600;
	}
	int tominutes() {
		return seconds / 60;
	}
	int toseconds() {
		return seconds;
	}

};


int main() {
	int hours;
	int minutes;
	int seconds;
	cin >> hours >> minutes >> seconds;

	Timeconvert time(hours, minutes, seconds);
	cout << time.tohours() << endl << time.tominutes() << endl << time.toseconds() << endl;

	return 0;
}