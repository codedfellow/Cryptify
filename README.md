# Cryptify: Encryption/Decryption Web Application

Cryptify is a web application that enables users to encrypt and decrypt text using multiple algorithms, including AES, Caesar Cipher, XOR Cipher, and Base64 encoding/decoding. The backend is built with .NET 9 Web API, and the frontend is an Angular 20 single-page application (SPA). This project was developed for the boot.dev hackathon, showcasing secure and educational cryptography techniques.

## Features
- **Encryption Algorithms**: Supports AES (secure symmetric encryption), Caesar Cipher (educational substitution cipher), XOR Cipher (educational bitwise cipher), and Base64 (encoding/decoding).
- **User-Friendly Interface**: A responsive Angular frontend with Bootstrap 5 forms and a clean output display with copy-to-clipboard functionality.
- **API-Driven Backend**: A .NET 9 Web API with Swagger UI for easy endpoint exploration.
- **Configurable**: Backend URL is configurable via a `config.json` file in the Angular project.

## Prerequisites

To run Cryptify locally, ensure you have the following installed on your system (Windows, macOS, or Linux):

### Backend (.NET 9 Web API)
- **.NET 9 SDK**: Required to build and run the .NET 9 Web API.
  - **Download**: Install from [Microsoft's .NET 9 download page](https://dotnet.microsoft.com/download/dotnet/9.0).
  - **Verify Installation**: Run `dotnet --version` in a terminal. It should output `9.0.x` (e.g., `9.0.100`).
- **IDE (Optional)**: You can use an IDE for easier development:
  - **Visual Studio 2022** (Windows/macOS): Community, Professional, or Enterprise edition (version 17.8 or later for .NET 9 support).
  - **Visual Studio Code**: With the C# extension (`ms-dotnettools.csharp`).
  - **JetBrains Rider**: A cross-platform .NET IDE.

### Frontend (Angular 20)
- **Node.js**: Version 18.10.0 or later (LTS recommended, e.g., 20.x for Angular 20 compatibility).
  - **Download**: Install from [Node.js official site](https://nodejs.org/en/download/) or use a version manager like `nvm`:
    ```bash
    nvm install 20
    nvm use 20
    ```
  - **Verify Installation**: Run `node --version` (should output `v20.x.x`) and `npm --version`.
- **Angular CLI**: Version 20.x to match Angular 20.
  - **Install**: Run the following command globally:
    ```bash
    npm install -g @angular/cli@20
    ```
  - **Verify Installation**: Run `ng version` to confirm Angular CLI 20.x is installed.
- **Git**: To clone the repository (optional).
  - **Download**: Install from [Git's official site](https://git-scm.com/downloads).
- **Browser**: A modern browser (e.g., Chrome, Firefox, Edge) for testing the Angular app and Swagger UI.

## Project Structure
- **Backend**: A .NET 9 Web API project located in the `criyptifyBackend` folder, containing the API controllers and services for encryption/decryption.
- **Frontend**: An Angular 20 project located in the `cryptifyUI` folder, with components for input forms, output display, and algorithm descriptions.
- **Configuration**: The backend URL is specified in `cryptifyUI/public/configurations/config.json`.

## Setup and Running Locally

### 1. Clone the Repository
Clone the project to your local machine:
```bash
git clone https://github.com/codedfellow/Cryptify.git
cd Cryptify
```

### 2. Set Up and Run the Backend (.NET 9 Web API)
1. **Navigate to the Backend Folder**:
   ```bash
   cd criyptifyBackend
   ```
2. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```
   This downloads all required NuGet packages.
3. **Run the Backend**:
   - **Via CLI**:
     ```bash
     dotnet run
     ```
     The API will start on two URLs:
     - `https://localhost:7004` (default HTTPS)
     - `http://localhost:5275` (default HTTP)
   - **Via IDE**:
     - **Visual Studio**: Open the solution (`Cryptify.sln`), set the startup project to the API project, and press `F5` or click "Run".
     - **VS Code**: Open the `backend` folder, use the C# extension’s "Run" task, or run `dotnet run` in the integrated terminal.
     - **Rider**: Open the solution, select the API project, and click "Run".
4. **Access Swagger UI**:
   - Open a browser and navigate to `https://localhost:7004/swagger` or `http://localhost:5275/swagger`.
   - You can use Swagger to test endpoints.

### 3. Set Up and Run the Frontend (Angular 20)
1. **Navigate to the Frontend Folder**:
   ```bash
   cd cryptifyUI
   ```
2. **Install Dependencies**:
   ```bash
   npm install
   ```
   This installs all required Node.js packages specified in `package.json`.
3. **Configure Backend URL**:
   - Open `cryptifyUI/public/configurations/config.json` and ensure the `apiUrl` matches one of the backend URLs:
     ```json
     {
       "apiUrl": "https://localhost:7004"
     }
     ```
     - Use `https://localhost:7004` for HTTPS (recommended) or `http://localhost:5275` for HTTP.
     - Note: If using HTTPS, you may need to accept the self-signed certificate in your browser for local development.
4. **Serve the Angular App**:
   - Run the development server:
     ```bash
     ng serve
     ```
   - The app will be available at `http://localhost:4200` (default Angular port).
   - Open `http://localhost:4200` in a browser to access the app.
5. **Verify Frontend**:
   - Navigate to the AES, Caesar, XOR, or Base64 pages.
   - Enter sample text and keys (e.g., a Base64-encoded 16-byte key for AES, a shift value for Caesar) to test encryption/decryption.
   - The output will appear in a centered `div` with a "Copy to Clipboard" button.

## Troubleshooting
- **Backend Fails to Start**: Check for port conflicts (7004 or 5275) or missing .NET 9 SDK.
- **Frontend API Calls Fail**: Verify the `apiUrl` in `frontend/src/configurations/config.json` matches the backend URL.
- **Angular Build Issues**: Ensure Node.js 20.x and Angular CLI 20.x are installed. Clear the npm cache (`npm cache clean --force`) if `npm install` fails.
- **Deep Links Don’t Work**: Confirm `app.MapFallbackToFile("index.html")` is in `Program.cs` and `index.html` is in `wwwroot`.

## Contact
For issues or contributions, please open an issue on the repository or contact the team at [your-email@example.com].

Happy coding, and enjoy exploring cryptography with Cryptify!