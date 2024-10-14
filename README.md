# Xcelerate

Xcelerate is a .NET Core 8 API for uploading and processing large Excel files, with a focus on efficient data storage in an MSSQL database. This project utilizes Hangfire for background task processing, ensuring smooth management of long-running tasks such as file parsing, data validation, and record storage.

## Features

- **Large File Uploading**: Designed to handle large Excel files with robust error handling and retry mechanisms.
- **Data Parsing and Validation**: Comprehensive parsing of Excel data with customizable validation rules to ensure data integrity.
- **Background Task Processing**: Hangfire integration for asynchronous task management, allowing resource-intensive processes to run in the background without blocking main application threads.
- **MSSQL Database Storage**: Uses MSSQL as the primary data store, providing secure and efficient data handling capabilities.
- **Error Monitoring**: Real-time error logging for troubleshooting, with detailed log information to support debugging.
- **Dashboard Monitoring**: Integrates with Hangfire’s dashboard to monitor job statuses, retries, and completion metrics.
- **Scalability and Performance**: Optimized to support large datasets, asynchronous processing, and multiple simultaneous uploads.

## Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/CtrlAltDevelop/Xcelerate.git
   cd Xcelerate
   ```
2. **Configure MSSQL Connection Update the MSSQL connection string in ```appsettings.json```.**
3. **Install Dependencies**.
   ```bash
   dotnet restore
   ```
4. **Apply Database Migrations**
   ```bash
   dotnet ef database update
   ```
5. **Run the Application**
   ```bash
   dotnet run
   ```

# Usage
1. Upload a File: Use the endpoint to upload an Excel file.
2. Monitor Processing: Hangfire dashboard provides insights into task progress and status.
3. Check Results: Processed data is stored in the MSSQL database, accessible via the provided API endpoints.


# Technologies
* .NET Core 8
* Hangfire: For background task processing
* MSSQL: Primary database for record storage

# Contributing
Feel free to submit issues or pull requests. For major changes, please open an issue first to discuss your ideas.
