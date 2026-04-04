class Customer:
    def __init__(self, name, address, pps, license):
        self.name = name
        self.address = address
        self.pps = pps
        self.license = license

    def to_string(self):
        return f"{self.name},{self.address},{self.pps},{self.license}"