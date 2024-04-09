# Rectangle Resize Project

This project enables interactive manipulation of a rectangle's dimensions using Angular on the frontend and ASP.NET Core with C# on the backend. Users can resize, drag, and download the rectangle's dimensions, managed via API endpoints.

## Technologies

- **Frontend**: Angular
- **Backend**: ASP.NET Core, C#
- **Libraries**: SVG.js for SVG manipulation, Interact.js for drag and resize functionalities

## Features

- **Resize Rectangle**: Users can adjust the rectangle's width and height interactively.
- **Drag Rectangle**: Allows users to move the rectangle across the canvas.
- **API Interaction**: Backend API endpoints to get, update, and download the rectangle's dimensions.

## API Endpoints

- **Get Rectangle Dimensions**
  - **Endpoint**: `/rectangle`
  - **Method**: `GET`
  - **Description**: Returns the current dimensions of the rectangle.
- **Update Rectangle Dimensions**

  - **Endpoint**: `/rectangle`
  - **Method**: `PUT`
  - **Body**:
    ```json
    {
      "width": "number",
      "height": "number"
    }
    ```
  - **Description**: Updates the rectangle's dimensions to the specified width and height.

- **Download Rectangle Dimensions**
  - **Endpoint**: `/rectangle/download`
  - **Method**: `GET`
  - **Description**: Downloads the current rectangle dimensions as a JSON file.

## Setup Instructions

### Prerequisites

- .NET SDK (appropriate version for ASP.NET Core)
- Node.js and npm
- Angular CLI

### Backend Setup

1. Navigate to the backend project directory:

   ```sh
   cd path/to/backend

   ```

2. Restore the ASP.NET Core dependencies:

   ```sh
   dotnet restore

   ```

3. Start the server
   ```sh
   dotnet run
   ```

### Frontend Setup

1. Navigate to the frontend project directory:

   ```sh
   cd path/to/frontend
   ``

   ```

2. Install npm packages:

   ```sh
   npm install
   ```

3. Update `environments/environment.ts` with the base url of your backend server, eg http://localhost:5000

4. Launch the Angular server:
   ```sh
   npm run start
   ```
