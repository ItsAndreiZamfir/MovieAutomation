### Movies API Client & Service

### Features

- Uses `HttpClient` to interact with TMDb's REST API.
- Supports searching and filtering movies by title and other criteria.
- Repository and service patterns for clean separation of concerns.

### Configuration

**Bearer Token Required:**  
To send API requests, you must provide a valid Bearer token for TMDb.  
The token and request format are configured currently directly in the `MovieClient` class.
