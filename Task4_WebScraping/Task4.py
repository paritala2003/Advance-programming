
import requests
from bs4 import BeautifulSoup
import csv


url = "https://books.toscrape.com/catalogue/category/books/travel_2/index.html"


response = requests.get(url)
response.encoding = 'utf-8' 
soup = BeautifulSoup(response.text, 'html.parser')

books = soup.find_all('article', class_='product_pod')

with open('books.csv', 'w', newline='', encoding='utf-8') as file:
    writer = csv.writer(file)
    
    writer.writerow(['Book Name', 'Price', 'Rating', 'Stock'])

    for book in books:
        
        title = book.h3.a['title']

        price = book.find('p', class_='price_color').text
        
        
        rating_class = book.find('p', class_='star-rating')['class']
        rating = rating_class[1] 

        stock = book.find('p', class_='instock availability').text.strip()
        
       
        writer.writerow([title, price, rating,stock])

print(" Data saved into books.csv")




print("\n Reading data from CSV:\n")

with open('books.csv', 'r', encoding='utf-8') as file:
    reader = csv.reader(file)
    
    for row in reader:
        print(f"Title  : {row[0]}")
        print(f"Price  : {row[1]}")
        print(f"Rating : {row[2]}")
        print(f"Stock  : {row[3]}")
        print("\n Scraping completed & data saved \n")
        print("-" * 40)