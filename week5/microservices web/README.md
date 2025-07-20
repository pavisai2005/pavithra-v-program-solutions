# ASP.NET Core JWT Authentication API

This project is an ASP.NET Core Web API that implements JWT (JSON Web Token) authentication. It provides endpoints for user registration and login, allowing users to authenticate and receive a JWT token for secure access to protected resources.

## Project Structure

- **Controllers**
  - `AuthController.cs`: Handles user authentication and registration.
  
- **Models**
  - `UserModel.cs`: Defines the user data structure for authentication.
  
- **Services**
  - `JwtService.cs`: Contains methods for generating and validating JWT tokens.
  
- **Program.cs**: The entry point of the application.
  
- **Startup.cs**: Configures services and the application's request pipeline, including JWT authentication.
  
- **appsettings.json**: Contains configuration settings, including JWT settings.

## Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd AspNetCoreJwtApi
   ```

2. **Install Dependencies**
   Make sure you have the .NET SDK installed. Run the following command to restore the dependencies:
   ```bash
   dotnet restore
   ```

3. **Configure JWT Settings**
   Open `appsettings.json` and set your JWT secret, issuer, and audience:
   ```json
   {
     "Jwt": {
       "Secret": "your_secret_key",
       "Issuer": "your_issuer",
       "Audience": "your_audience"
     }
   }
   ```

4. **Run the Application**
   Use the following command to run the application:
   ```bash
   dotnet run
   ```

5. **API Endpoints**
   - **POST /api/auth/register**: Register a new user.
   - **POST /api/auth/login**: Authenticate a user and receive a JWT token.

## Usage

After running the application, you can use tools like Postman or curl to interact with the API. Make sure to include the JWT token in the Authorization header for protected routes.

## License

This project is licensed under the MIT License.