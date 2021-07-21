'''
Author: Mustafa S. Hamada
Date: 2018-09-18
File name: problem_B__final.py
'''

from sys import exit

# readin in DNA sequence from console
dnaSeq_1 = input()
dnaSeq_2 = input()

# check if first DNA strand is a substring of the second DNA strand e.g. dnaSeq_1 = "AAA" & dnaSeq_2 = "AAAAA"
if dnaSeq_1.find(dnaSeq_2) == 1:
    print(len(dnaSeq_2) - len(dnaSeq_1))
    exit()

# firstBase counting for the first unmatched DNA nucleobase from the left (beginning of DNA sequence)
firstBase = 0
while firstBase < len(dnaSeq_1) and firstBase < len(dnaSeq_2) and dnaSeq_1[firstBase] == dnaSeq_2[firstBase]:
    firstBase += 1

# endBase counting for the first mismatched DNA nucleobase from the right (end of DNA sequence)
endBase_1 = len(dnaSeq_1) - 1
endBase_2 = len(dnaSeq_2) - 1
while endBase_1 >= 0 and endBase_2 >= 0 and dnaSeq_1[endBase_1] == dnaSeq_2[endBase_2]:
    endBase_1 -= 1
    endBase_2 -= 1

# nothing has been inserted i.e. endBase_2 and firstBase cross
if endBase_1 < firstBase:
    print(0)
# print out index difference
else:
    print(endBase_2 - firstBase + 1)