#include <iostream>
#include<algorithm>



using namespace std;
int attacked[8][8];



void printboard(char board[8][8]) {
    for ( int i = 0; i < 8; i++ ) {
        for ( int j = 0; j < 8; j++ )   cout << board[i][j] << " ";
        cout << endl;
    }
    cout << endl;
}
void setQueen(char board[8][8], int row, int col, bool add) {
    int factor = 1;
    if ( add )
        board[row][col] = '*';
    else {
        board[row][col] = '-';
        factor = -1;
    }
    int k = min(row, col);
    int r = row - k;
    int c = col - k;
    while ( r < 8 && c < 8 ) {
        attacked[r][c] += factor;
        r++; c++;
    }
    k = 7 - max(row, col);
    r = row - k;
    c = col + k;
    while ( r < 8 && c >= 0 ) {
        attacked[r][c] += factor;
        r++;  c--;
    }
    for ( int i = 0; i < 8; i++ ) attacked[i][col] += factor;
    for ( int i = 0; i < 8; i++ ) attacked[row][i] += factor;

}

void find_queen_pos(char board[8][8], int row) {
    int col = 0;
    if ( row == 8 ) {
        printboard(board);
        return;
    }
    while ( col < 8 ) {
        if ( attacked[row][col] == 0 ) {
            setQueen(board, row, col, 1);
            find_queen_pos(board, row + 1);
            setQueen(board, row, col, 0);
        }
        col++;
    }
    return;


}





int main() {
    char board[8][8];

    for ( int i = 0; i < 8; i++ ) {
        for ( int j = 0; j < 8; j++ ) {
            board[i][j] = '-';
            attacked[i][j] = 0;
        }
    }


    find_queen_pos(board, 0);


    return 0;
}
