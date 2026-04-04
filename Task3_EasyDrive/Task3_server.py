import socket
import sqlite3

conn = sqlite3.connect("customers.db")
cursor = conn.cursor()

cursor.execute("""
CREATE TABLE IF NOT EXISTS customers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT,
    address TEXT,
    pps TEXT,
    license TEXT
)
""")
conn.commit()

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(("localhost", 12345))
server.listen(1)

print("Server started... Waiting for client...")

while True:
    client, addr = server.accept()
    print("Connected:", addr)

    data = client.recv(1024).decode()

    if data:
        name, address, pps, license = data.split(",")

        cursor.execute(
            "INSERT INTO customers (name, address, pps, license) VALUES (?, ?, ?, ?)",
            (name, address, pps, license)
        )
        conn.commit()

        reg_id = cursor.lastrowid
        client.send(f"Registration ID: {reg_id}".encode())

    client.close()