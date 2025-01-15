# Student Information System - .NET Core Web API with Database

## Objective:
The goal of this project is to design and develop a student information system using .NET Core Web API. The system will provide various functionalities for retrieving, saving, and validating student information. Unlike the previous version, this system will store data in a database, and CRUD operations will be performed using Entity Framework Core (EF Core).

## Tasks:
1. **Project Setup:**
   - Create a new .NET Core Web API project using Visual Studio.

2. **Add EF Core:**
   - Install the necessary EF Core libraries for your project by adding the following NuGet packages:
     - `EntityFrameworkCore`
     - `EntityFrameworkCore.SqlServer`

3. **Create Entity Model:**
   - Create a `StudentEntity` class that represents student information (such as student name, number, class, etc.).

4. **Set up DbContext:**
   - Create an `AppDbContext` class that inherits from `DbContext` and includes a `DbSet<StudentEntity>` property to manage student records.

5. **Database Initialization and Seeding:**
   - In the `Program.cs`, use the `EnsureCreated` method to create the database if it doesn't exist and seed it with 20 student records using the Bogus library to generate fake data.

6. **Create StudentsController:**
   - Implement a `StudentsController` that handles CRUD (Create, Read, Update, Delete) operations for managing student data.
   - The controller should include necessary actions and make use of `AppDbContext` for database operations.

7. **Model Binding:**
   - Implement the POST method to allow the addition of a student. Ensure the method works with model binding to receive, validate, and store student information in the database.

8. **Server-side Validation:**
   - Implement server-side validation for the following fields:
     - Student first and last name cannot be empty.
     - Student number must be unique (i.e., not already in the database).

9. **HTML Forms & Client-side Validation:**
   - Create forms for the Create and Update operations, and implement client-side validation using JavaScript for fields such as uniqueness and empty field checks.
   - For the Read and Delete operations, use the `fetch` API to dynamically retrieve and delete data.

10. **Web API & HTML Forms Interaction:**
   - The relationship between the Web API and HTML forms can be structured as follows:
     - Example HTML Form:
     ```html
     <form id="studentForm" action="https://localhost:5001/api/students" method="post">
       <input type="hidden" asp-for="Id">
       <!-- Form fields go here -->
       <button type="submit">Add Student</button>
     </form>
     ```

11. **CRUD Operations:**
    - For the CRUD operations, the following steps should be followed:
      - **Create (POST):** Use the form to submit student data via a POST request to the Web API.
      - **Read (GET):** Use JavaScript `fetch` to request data from the Web API and display it dynamically (e.g., in a table).
      - **Update (PUT):** Fill out the form and submit using the `PUT` method via `fetch`.
      - **Delete (DELETE):** Use `fetch` to send a DELETE request to remove student data.

12. **JavaScript Client-side Validation:**
    - Implement JavaScript validation for form fields before submitting the form to the server:
    ```javascript
    document.getElementById("studentForm").addEventListener("submit", function (event) {
        if (!validateForm()) {
            event.preventDefault(); // Prevent form submission and show error message
        }
    });

    function validateForm() {
        // Apply necessary validations and show errors to the user
        // For example, check for empty fields and uniqueness
    }
    ```

## Technologies Used:
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Database
- JavaScript (for client-side validation)
- HTML Forms
- Fetch API
