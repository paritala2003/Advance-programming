import socket
from Customer import Customer

client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect(("localhost", 12345))

name = input("Enter Name: ")
address = input("Enter Address: ")
pps = input("Enter PPS Number: ")
license = input("Enter Driving License: ")

customer = Customer(name, address, pps, license)

client.send(customer.to_string().encode())

response = client.recv(1024).decode()
print(response)

client.close()