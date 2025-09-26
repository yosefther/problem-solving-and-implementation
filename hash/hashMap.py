import sys

class pair:
    def __init__(self , key =0  , val =0  ):
        self.key = key 
        self.val = val

class HashMap:
    def __init__(self , key = 0  , val = 0  ):
        self.map=[None]
        self.pair = pair (key , val)
        self.key = key
    def hash(self):
        for c in self.pair.key:
            index = ord(c)%sys.getsizeof(self.map)
        self.key = index
        print (self.key)
        return self.key

    def put(self,key,val):
        if self.map[self.hash(key)] ==  None:
            self.map[self.hash(key)] = pair(key , val) 
        else:
            k = 0 
            while self.map[self.hash(key)] != None:
                i+=i
                k = self.hash(key)+i
            self.map[k] = pair(key,val)
        # print(self.map[self.hash()].__dict__) >> for test
    
    # def get (self , key):
    #     self .
    #     pass 


test = HashMap("","") 
test.hash()



