'''
Author: Mustafa S. Hamada
Date: 2018-09-18
File name: problem_A.py
'''

seq = input()

up_policy = 0 # always up
down_policy = 0 # always down
leave_policy = 0 # as you would like it

# treat the first 'guest' at seq[1] differently than the others
# if the initial position is different than the user's preference,
# there's a position change regardless
if seq[0] != seq[1]:
    up_policy += 1
    down_policy += 1
    leave_policy += 1

if seq[1] == 'U':
    down_policy += 1
if seq[1] == 'D':
    up_policy += 1

# we can now assume that everyone has had
# someone visit the toilet before them
# so the seat is in the position dictated by policy
prev = seq[1]
for ch in seq[2:]:
    if ch == 'U':
        # U in down policy goes D -> U -> D
        down_policy += 2
    if ch == 'D':
        # D in up policy goes U -> D -> U
        up_policy += 2
    if prev != ch:
        # only changes if different from last position
        leave_policy += 1
    prev = ch

print(up_policy)
print(down_policy)
print(leave_policy)
