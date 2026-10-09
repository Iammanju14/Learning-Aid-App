# Learning Aid App

An Android and ASP.NET web-based learning platform developed as an MCA academic project to support access to educational materials and learning resources.

## Project Overview

Learning Aid App consists of two components:

- **StudyCatalog:** An Android application for accessing learning materials.
- **Gnana Jyothi:** An ASP.NET web application for managing and accessing educational resources.

## Technologies Used

### Android Application — StudyCatalog
- Java
- Android SDK
- XML for user interface layouts
- Gradle

### Web Application — Gnana Jyothi
- ASP.NET Web Forms
- C#
- HTML and CSS
- JavaScript
- SQL Server

## Project Structure

```text
Learning-Aid-App/
├── StudyCatalog/   # Android application
├── Gnana Jyothi/   # ASP.NET web application
├── .gitignore
└── README.md
```

## Key Features

The source code includes components for:
- User registration and login
- Learning material listing and viewing
- Material management
- Feedback submission and viewing
- Separate administrative and lecturer interfaces in the web application

## Setup and Configuration

### StudyCatalog
1. Open the `StudyCatalog` folder in Android Studio.
2. Allow Gradle to synchronize the project.
3. Configure the database connection using your own development credentials.
4. Run the application on a compatible Android device or emulator.

### Gnana Jyothi
1. Open the project file in Visual Studio.
2. Configure the database connection in `Web.config` using your own development credentials.
3. Restore any required dependencies.
4. Run the web application using a compatible ASP.NET development environment.

**Important:** Do not commit real database passwords, private keys, or other secrets to GitHub.

## Academic Project

Developed as part of the Master of Computer Applications (MCA) program.

---

*This repository is intended for academic reference and learning.*
