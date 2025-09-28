## 1. `_rehash` method
- [ ] Initialize `newMap` with the correct size (`self.capasity`) instead of an empty list.

## 2. `put` method
- [ ] Rehash when the **load factor** (`size / capacity`) is too high, not only when `size >= capacity`.

## 3. `get` method
- [ ] Add handling for when the key is not found (return `None` or raise an error).

## 4. General improvements
- [ ] Ensure linear probing works correctly (`index += 1` with modulo).
- [ ] Confirm `_rehash` reinserts all old pairs correctly.
- [ ] Add a clear policy for what happens if a key already exists (update value vs. ignore).
