/* 
Author: Mustafa S. Hamada
Date: 2018-09-18
File name: problem_A.cpp
*/

#include <iostream>
#include <string>

int main(int argc, char const *argv[])
{
    /* main running program */
    std::string input;        // defining 'input' as a string sequence of characters
    std::cin >> input;        // reading string sequence input from user console
    char initStat = input[0]; // index of the initial character in the string stream indicating the 'toilet seat status'
    int upState = 0;          // defining & initialising policy (1) to 0
    int downState = 0;        // defining & initialising policy (2) to 0
    int leaveState = 0;       // defining & initialising policy (3) to 0

    if (initStat != input[1]){
        upState += 1;
        downState += 1;
        leaveState += 1;
    }
    if (input[1] == 'D'){
        upState += 1;
    }
    if (input[1] == 'U'){
        downState += 1;
    }

    int precPer = input[1];
    for(int i = 2; i <= input.substr(2).length() + 1; i++){
        if (input[i] == 'D'){
            upState += 2;
        }
        if (input[i] == 'U'){
            downState += 2;
        }
        if (precPer != input[i]){
            leaveState += 1;
        }
        precPer = input[i];
    }

    std::cout << upState << std::endl;
    std::cout << downState << std::endl;
    std::cout << leaveState << std::endl;

    return 0;
}
