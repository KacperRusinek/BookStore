# BookStore
BookStore is a simple application that has several simple functions such as: adding books to the bookstore, rating them, adding opinions or registering and logging.
The project was created to practice my skills in ASP.NET Core.

# Stack

* ASP.NET Core 
* SqlServer 
* Entity Framework Core 
* FluentValidation 
* NLog
* JWT.Net 
* Auto Mapper

# Database scheme
![image](https://github.com/KacperRusinek/BookStore/assets/97053559/7739145b-01e0-43e6-a11b-b2ca61a04260)

# Endopints
## AccountController:
* POST /api/account/register - Registers a new user.
* POST /api/account/login - Logs in the user and returns an access token.

## BooksController:
* POST /api/BookStore/AddBook - Adds a new book to the bookstore.
* GET /api/BookStore/GetAll - Retrieves all books from the bookstore.
* GET /api/BookStore/SortAscDesc{asc/desc} - Retrieves books sorted in ascending or descending order.
* GET /api/BookStore/GetById - Retrieves the book with the specified ID.
* GET /api/BookStore/GetByNumberOfPages - Retrieves books up to the specified number of pages.
* PUT /api/BookStore/UpdateById - Updates the book with the specified ID.
* DELETE /api/BookStore/DeleteById - Deletes the book with the specified ID.

## ReviewController:
* POST /api/Review/AddReviewByTitle - Adds a review to the book with the specified title.
* GET /api/Review/GetReviewsByBookTitle - Retrieves reviews for the book with the specified title.
* PUT /api/Review/UpdateReviewById - Updates the review with the specified ID.
* DELETE /api/Review/DeleteReviewById - Deletes the review with the specified ID.

# Swagger 
![image](https://github.com/KacperRusinek/BookStore/assets/97053559/3db90212-e68f-4c00-b81b-cd0c326446f7)
