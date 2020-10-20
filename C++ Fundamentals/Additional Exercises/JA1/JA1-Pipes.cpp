
#include <iostream>
#include <vector>

void pipes();
void pipes1();

using namespace std;

int main()
{
    pipes1();

    return 0;
}


void pipes()
{
    vector <int> pipesS, pipesS1;
    int N;
    cin >> N;
    for (int i = 0; i < N; i++)
    {
        int y;
        cin >> y;
        pipesS1.push_back(y);
    }

    for (int i = 0; i < N; i++)
    {
        int y;
        cin >> y;
        pipesS.push_back(y);
    }

    for (int i = 0; i < N; i++)
    {
        int y = pipesS[i] / (pipesS[i] - pipesS1[i]);
        cout << y << " ";
    }
    cout << endl;
}

void pipes1()
{
    vector <int> pipesS1;
    int N;
    cin >> N;
    for (int i = 0; i < N; i++)
    {
        int y;
        cin >> y;
        pipesS1.push_back(y);
    }

    for (int i = 0; i < N; i++)
    {
        int y;
        cin >> y;
        cout << y / (y - pipesS1[i]) << " ";
    }

    cout << endl;



}
