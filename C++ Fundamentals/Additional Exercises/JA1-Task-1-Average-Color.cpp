//Write a program which, given two colors written in the Hex Code format
//(with a “#” in front of exactly 6 hexadecimal digits),
//computes the “average” between the colors – by calculating the average
//of each channel separately –and prints the resulting color in the same Hex Code
//format to the console.For computing the average of the channels of two colors, 
//just sum the numbers of the channelsand divide them by 2 (integer division, 
//i.e.round down to the nearest integer, i.e.take the floor value).

#include <iostream>
#include <string>
#include <vector>
#include<math.h>

using namespace std;

int hex_to_int(string hex) {
    int result = 0;
    int i = hex.size() - 1, j = 0;

    while (i >= 0)
    {
        char ch = hex[i]; int t;

        if (ch >= '0' && ch <= '9')         t = ch - 48;
        else if (ch >= 'A' && ch <= 'F')    t = ch - 55;
        else if (ch >= 'a' && ch <= 'f')    t = ch - 87;
        else    break;

        result = result + t * pow(16, j);
        i--;    j++;
    }
    return result;
}
void hexcolor_to_rgbcolor(string hexcolor, int(*rgb)[3])
{   // for color formats "#HHHHHH" "#hhhhhh" "#HhhHhH" "hHHhHh" - last 6 chars are hex chars
    int start = hexcolor.size() - 6;

    for (int i = 0; i <= 2; i++)
    {
        (*rgb)[i] = hex_to_int(hexcolor.substr(start + i * 2, 2));
    }
}
string int_to_hex(int inum, string prefix = "", int zero_fill_to = 0, bool capitals = false) {
    string res = prefix, HexChars = "0123456789", result;

    if (capitals)   HexChars.append("ABCDEF");
    else            HexChars.append("abcdef");

    while (inum > 0) {
        res.push_back(HexChars[inum % 16]);
        inum /= 16;
    }

    while (res.size() < zero_fill_to) res.push_back('0');

    for (int i = res.size() - 1;i >= 0;i--)
        result.push_back(res[i]);

    return result;
}
string rgbcolor_to_hexcolor(int(*rgb)[3], string prefix = "#") {
    string result = prefix;

    for (int i = 0;i <= 2;i++)
        result.append(int_to_hex((*rgb)[i], "", 2, false));

    return result;
}

int main() {
    string color1hex, color2hex;
    cin >> color1hex >> color2hex;  // for color format "#HHHHHH"
    int rgb1[] = { 0,0,0 };
    int rgb2[] = { 0,0,0 };
    hexcolor_to_rgbcolor(color1hex, &rgb1);
    hexcolor_to_rgbcolor(color2hex, &rgb2);

    int rgb[3];
    for (int i = 0;i <= 2;i++)
        rgb[i] = (rgb1[i] + rgb2[i]) / 2;

    string colorhex = rgbcolor_to_hexcolor(&rgb);
    cout << colorhex << endl;

    return 0;
}
