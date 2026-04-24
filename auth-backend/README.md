# Auth Backend (Google OAuth)

This is a minimal Node.js Express backend for Google OAuth 2.0 login.

## Setup

1. Copy `.env.example` to `.env` and fill in your Google credentials:
   - Get credentials from https://console.developers.google.com/
   - Set `GOOGLE_CLIENT_ID`, `GOOGLE_CLIENT_SECRET`, `GOOGLE_CALLBACK_URL`, and `SESSION_SECRET`.
2. Install dependencies:
   ```
npm install
   ```
3. Start the server:
   ```
npm start
   ```
4. Visit [http://localhost:3001/auth/google](http://localhost:3001/auth/google) to test login.

## Endpoints
- `/auth/google` — Start Google login
- `/auth/google/callback` — Google redirects here
- `/auth/success` — Shows login success
- `/auth/failure` — Shows login failure

## Notes
- This backend does not persist users. For production, connect to a database.
- You must set up OAuth consent screen and credentials in Google Cloud Console.
