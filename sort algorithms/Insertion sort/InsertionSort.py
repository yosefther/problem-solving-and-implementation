# Input :  A sequence of n numbers <a1 ,a2 , ...  , an>
# Output : a permutation (reordering) <a1` ,a2` , ... , an`> such that  [a1'<= a2' <= ...<=a2`]
#  The numbers that we wish to sort are also known as the "keys"
# 
#  

A = (2,3,1,6,5,4)
key = 0
for i in range(len(A)):
    key = A[i]
    while A[i] > key :
        A[i+1] = A[i] 
              
#unsolved