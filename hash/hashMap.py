class Pair:
    def __init__(self , key , val):
        self.val = val
        self.key = key

class HashMap:
    def __init__(self):
        self.size = 0
        self.capasity = 2
        self.map=[None,None]
        
    def _hash(self,key):
        index = 0
        for c in key:
            index += ord(c)
        print(index % self.capasity)
        return index % self.capasity

    def _rehash(self):
        self.capasity = 2 *self.capasity
        newMap = []
        for i in range(self.capasity):
            newMap.append(None)
        oldMap = self.map
        self.map = newMap
        self.size =0 
        for pair in oldMap :
            if pair:
                self.put(pair.key , pair.val)
  
    def put (self, key , val):
        pair = Pair(key , val)
        index = self._hash(key)
        while True : 
            if self.map[index] == None:
                self.map[index] = pair 
                self.size +=
                if self.size>=self.capasity:
                    self._rehash()
            elif self.map[index].key == key:
                return pair.key
            index += 1
            index = index%self.capasity


    def get(self,key):
        index = self._hash(key)
        while self.map[index] != None:
            if self.map[index].key == key :
                return self.map[index].val
            index+=1
            index = index%self.capasity # * 

