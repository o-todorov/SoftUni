
#include <iostream>
#include <vector>

using namespace std;

int timeInMinutes(int t)
{
    int result;
    result = t % 10;
    t /= 10;
    result += (t % 10) * 10;
    t /= 10;
    result += (t % 10) * 60;
    t /= 10;
    result += t * 10 * 60;

    return result;
}

vector <int> readVector(int numCount)
{
    vector<int> result;
    for (int i = 0; i < numCount; i++)
    {
        int j;
        cin >> j;
        result.push_back(j);
    }
    return result;
}

int main()
{
    const int minutesin24H = 24 * 60;

    int numBusses;
    cin >> numBusses;

    vector <int> busTimes = readVector(numBusses);

    int trainTime;
    cin >> trainTime;
    trainTime = timeInMinutes(trainTime);

    int diff = 0, minTime = minutesin24H, indexMinTime;


    for (int i = 0; i < numBusses; i++)
    {
        int t;
        t = timeInMinutes(busTimes[i]);
        diff = (trainTime + minutesin24H * (t > trainTime) - t);
        if (diff <= minTime)
        {
            minTime = diff;
            indexMinTime = i + 1;
        }
    }

    cout << indexMinTime << endl;

    return 0;
}


