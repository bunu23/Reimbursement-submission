# Reimbursement Submission

This project is a full-stack **Reimbursement Submission System** which includes the basic functionality of submitting and viewing reimbursement receipts. It allows university employees to submit and view receipts for reimbursement, including uploading receipt files, all connected via a RESTful API backed by MySQL.

I built this application from scratch using **ASP.NET Core Web API**, **MySQL**, and **Angular**, following clean architecture practices like Repository and Service layers.

---

## Table of Contents

- [What It Does?](#what-it-does)
- [Tech Stack, Architecture, Best Practices](#architecture-and-stack)
- [Why this Stack?](#why-this-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Time Tracking](#time-tracking)
- [Comments](#comments)
- [Screenshot](#screenshot)

[🔼 Back to Top](#reimbursement-submission)

---

# What It Does

- **Receipt Submission Form**  
  Employees can fill out a simple, user-friendly form to submit reimbursement receipts. The form captures:

  - **Purchase Date** – the date the expense was incurred
  - **Amount** – how much was spent
  - **Description** – a brief reason or context for the purchase (for example., "Conference lunch", "Office supplies")
  - **Receipt File Upload (Optional)** – users may upload a digital copy of their receipt (for example PDF, image, word file.).

- **Data Storage in MySQL**  
  Submitted data is sent to a `.NET Core Web API` using a `POST` request and stored in a MySQL database.
  The data model includes fields for date, amount, description, and an optional file path. Files are stored in a local `Uploads/` folder and linked via their relative path.

- **Receipt Listing**  
  After submission, the receipt appears instantly in a list below the form. This list displays:

  - Receipt ID
  - Submission date
  - Amount and description
  - A “View” link if a receipt file is available

- **Clean, Responsive UI**  
  The UI is built with custom CSS for a clean and modern feel, with:

  - Responsive layout, form alignments
  - Table format for listing receipts clearly

- **Frontend–Backend Integration**  
  The Angular frontend communicates with the backend through RESTful APIs:
  - `POST` to submit a new receipt
  - `GET` to fetch and display all submitted receipts  
    These endpoints use proper CORS setup and return real-time results.

[🔼 Back to Top](#reimbursement-submission)

---

# Architecture and Stack

This project follows a modular, layered architecture to ensure clarity, testability, and scalability:

#### Backend (.NET Core)

- **Repository Pattern**: Data access is abstracted , so data logic stays isolated.
- **Service Layer**: Business logic to keep controllers clean and handle reusable logic.
- **EF Core + MySQL**: Used to integrate with MySQL easily.
- **CORS Enabled**: Allows Angular frontend to talk to the API.
- **Code is modular and extensible** — it would be easy to add user authentication, pagination, or edit/delete features later on.

#### Frontend (Angular Standalone)

- **Angular Standalone Components**: Built entirelyusing the latest Angular features.
- **FormsModule + ngModel**: For two-way binding and simple form validation.
- **HttpClientModule**: REST API integration for GET/POST requests.
- **File Uploads**: Handled using `FormData` and `multipart/form-data` on both ends.
- **Conditional UI Rendering**: Receipt links only show if file is present.

[🔼 Back to Top](#reimbursement-submission)

---

## Why this Stack?

I typically work with **Java, React, and both relational and NoSQL databases**, but I saw this assessment as a great chance to step out of my usual tech stack and get hands-on with **.NET Core and Angular**. I have been meaning to explore them more seriously, and this project gave me the perfect opportunity to do that.

- I chose **.NET Core** because it’s fast, scalable, and well-suited for building clean API services.
- **MySQL** is something I am already comfortable with, and it integrates smoothly.
- On the frontend, I went with **Angular's new standalone component approach**, which felt modern and lightweight.
- I also kept the UI clean and responsive using just **HTML and CSS** — no heavy UI libraries — so everything stays fast and easy to maintain.

Overall, it was a fun challenge and a great learning experience to build a full-stack app independently using this stack!

[🔼 Back to Top](#reimbursement-submission)

---

# Project Structure

### Backend: `REIMBURSEMENT-API`

```
REIMBURSEMENT-API/
├── .vscode/
├── bin/
├── obj/
├── Controllers/
│   └── ReceiptController.cs         # API endpoints
├── Data/
│   └── AppDbContext.cs              # Entity Framework Core DbContext
├── Dto/
│   └── ReceiptFormModel.cs          # DTO for file + form data
├── Models/
│   └── Receipt.cs                   # Receipt entity model
├── Repositories/
│   ├── IReceiptRepository.cs        # Interface for data access
│   └── ReceiptRepository.cs         # EF-based repository implementation
├── Services/
│   └── ReceiptService.cs            # Business logic for receipt processing
├── Uploads/
│   └── <receipt-files>              # Uploaded receipt files are stored here
├── appsettings.json                 # General app configuration
├── appsettings.Development.json
├── launchSettings.json
├── Database-Script.txt              # SQL script
├── Program.cs                       # Application startup and configuration
├── Reimbursement-Api.csproj
└── Reimbursement-Api.sln
```

### Frontend: `Reimbursement-Web`

```
REIMBURSEMENT-WEB/
├── .angular/
├── .vscode/
├── coverage/
├── node_modules/
├── public/
├── src/
│   ├── app/
│   │   ├── app.component.css        # Component-specific styles
│   │   ├── app.component.html       # Main UI template (form + table)
│   │   ├── app.component.spec.ts    # Unit tests for AppComponent
│   │   ├── app.component.ts         # Component logic & data handling
│   │   ├── app.config.ts
│   │   ├── app.routes.ts
│
├── package.json
├── package-lock.json

```

[🔼 Back to Top](#reimbursement-submission)

---

# Getting Started

### ✅ Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- [Node.js + npm](https://nodejs.org/)
- Angular CLI
  ```bash
  npm install -g @angular/cli
  ```

---

### Backend Setup – `REIMBURSEMENT-API`

```bash
cd REIMBURSEMENT-API
```

1. Open `appsettings.json` and update your MySQL connection:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=reimbursements;user=root;password=your_password"
}
```

> Replace `your_password` with your actual MySQL root password.

2. Run the following commands to update the database and start the API:

```bash
dotnet ef database update
dotnet run
```

## Frontend Setup – `Reimbursement-Web`

```bash
cd Reimbursement-Web
```

1. Install dependencies:

```bash
npm install
```

2. Start the Angular development server:

```bash
ng serve
```

App available at: [http://localhost:4200](http://localhost:4200)

[🔼 Back to Top](#reimbursement-submission)

---

# Time Tracking

| Phase                                                | Estimated | Actual  |
| ---------------------------------------------------- | --------- | ------- |
| IDE Setup + Installation + Environment Configuration | 1.5 hrs   | 1 hr    |
| Backend API + DB Setup + Debugging                   | 3 hrs     | 2.5 hrs |
| Angular Frontend UI + Styling + Responsiveness       | 2.5 hrs   | 2 hrs   |
| Documentation                                        | 1 hr      | 35 min  |

---

# Comments

### a. Assumptions

- There is **no authentication or user-specific filtering**, as the focus is on basic functionality.
- File upload is **optional**, but the date, amount, and description are required fields.
- One-page UI with form + table is sufficient
- File uploads are stored on the server under a local `Uploads/` folder, and links are returned in the response for display.
- No pagination or advanced filtering needed

### b. Problems Encountered & Solutions

- **CORS Issue**: Angular couldn't access the API due to CORS restrictions.  
  ➤ **Solved** by adding a CORS policy in `.NET` and enabling it in `Program.cs`.
- **Database Seeding Failed**: Seeding failed due to `ReceiptFilePath` being non-nullable.  
  ➤ **Solved** by making the property nullable and updating the schema.
- **Incorrect File Links**: File paths didn’t render correctly in the UI.  
  ➤ **Solved** by prefixing paths with the backend base URL in Angular.

### c. Highlights in my Code

- Clean, testable backend architecture (**Controller → Service → DTO ->Repository**)
- The backend is designed with **separation of concerns** using IRepository, IService, and Controller layers.
- Modern Angular app using standalone components
- Real file uploads, database storage, and real-time view updates
- Open for Extension, SOLID principle

[🔼 Back to Top](#reimbursement-submission)

# Screenshot

Here is the receipt submission UI:

![](../ReimbursmentPrj/screenshot/ui.png)

---
