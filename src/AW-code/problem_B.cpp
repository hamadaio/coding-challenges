/* 
Author: Mustafa S. Hamada
Date: 2018-09-18
File name: problem_B__final.cpp
*/

#include <iostream>
#include <string>

int main(int argc, char const *argv[])
{
    /* main code */

    // define string DNA sequences
    std::string dnaSeq_1;
    std::string dnaSeq_2;
    // readin in DNA sequence from console
    std::cin >> dnaSeq_1;
    std::cin >> dnaSeq_2;
    // check if first DNA strand is a substring of the second DNA strand e.g. dnaSeq_1 = "AAA" & dnaSeq_2 = "AAAAA"
    if (dnaSeq_2.find(dnaSeq_1) != std::string::npos) {
        std::cout << dnaSeq_2.length() - dnaSeq_1.length() << std::endl;
        return 0;
    }
    // firstBase counting for the first unmatched DNA nucleobase from the left (beginning of DNA sequence)
    int firstBase = 0;
    while (firstBase < dnaSeq_1.length() && firstBase < dnaSeq_2.length() && dnaSeq_1[firstBase] == dnaSeq_2[firstBase]) {
        firstBase += 1;
    }
    // endBase counting for the first mismatched DNA nucleobase from the right (end of DNA sequence)
    int endBase_1 = dnaSeq_1.length() - 1; // set the index values for dnaSeq_1
    int endBase_2 = dnaSeq_2.length() - 1; // set the index values for dnaSeq_2
    while (endBase_1 >= 0 && endBase_2 >= 0 && dnaSeq_1[endBase_1] == dnaSeq_2[endBase_2]) {
        endBase_1 -= 1;
        endBase_2 -= 1;
    }
    // nothing has been inserted i.e. endBase_2 and firstBase cross
    if (endBase_2 < firstBase) {
        std::cout << "0" << std::endl;
    } else {
        // print out index difference
        std::cout << endBase_2 - firstBase + 1 << std::endl;
    }

    return 0;
}