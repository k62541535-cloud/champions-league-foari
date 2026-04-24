# Pulse Cup Predictor

A World Cup 2026 score prediction website with:

- upcoming FIFA World Cup 2026 group-stage fixtures
- automatic schedule refresh from FIFA's official 2026 schedule page on server start
- flag-based matchup cards
- required sign-in with Google
- a shared multiplayer leaderboard stored in a local backend file
- a Render-ready Node web service for stable public hosting
- no framework or package install required

## Run it

Open PowerShell in this folder and run:

```powershell
C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe -ExecutionPolicy Bypass -File .\server.ps1 -Port 8080
```

Then open [http://localhost:8080](http://localhost:8080).

To enable Google sign-in, create `.env` in the project root with:

```env
GOOGLE_CLIENT_ID=your-google-oauth-client-id.apps.googleusercontent.com
```

For Google Cloud, create a `Web application` OAuth client and add these Authorized JavaScript origins:

- `http://localhost:8080`
- your final public site origin, if you expose it online

Google Cloud Console steps:

1. Go to Google Cloud Console and create or open your project.
2. Open `Google Auth Platform` or `APIs & Services`.
3. Configure the OAuth consent screen.
4. Create credentials and choose `OAuth client ID`.
5. Choose application type `Web application`.
6. Add `http://localhost:8080` to `Authorized JavaScript origins`.
7. If you deploy publicly on a stable URL, also add that exact origin, for example `https://your-app.onrender.com`.
8. Copy the generated client ID into `.env` as `GOOGLE_CLIENT_ID`.
9. Restart `server.ps1`.

Important notes for public Google login:

- Google requires exact authorized JavaScript origins for web sign-in.
- Dynamic tunnel URLs like changing `localhost.run` addresses are not a reliable long-term Google login origin.
- For public Google sign-in that works consistently, use a stable host such as a real domain, `onrender.com`, `vercel.app`, or a fixed Cloudflare setup.

For a one-click launcher on Windows, use:

- `start-pulse-cup.bat` in the project folder
- `start-pulse-cup-public.bat` in the project folder for internet sharing
- `Pulse Cup Predictor.bat` on your Desktop
- `Pulse Cup Predictor Public.bat` on your Desktop
- `PulseCupPredictorLauncher.exe` in the project folder
- `PulseCupPredictorPublicLauncher.exe` in the project folder
- `Pulse Cup Predictor.lnk` on your Desktop
- `Pulse Cup Predictor Public.lnk` on your Desktop

The `.exe` launchers are built from `PulseCupPredictorLauncher.cs` and `PulseCupPredictorPublicLauncher.cs`.

## Share Over The Internet

To expose the app publicly from this PC without router setup, use:

- `start-pulse-cup-public.bat`
- `Pulse Cup Predictor Public.bat`

This starts your local server and then opens an SSH tunnel through `localhost.run`.
The public URL is printed in the tunnel window.
Keep that tunnel window open or the public link will stop working.
Because that public URL can change, Google sign-in may fail there unless you move to a stable public hostname.

The server will try to refresh the schedule from FIFA automatically when it starts.
If the refresh fails, the site falls back to the cached local `data/matches.json` file.
You can also trigger a refresh from the `Refresh Matches` button in the UI.
Users must register or sign in before the app will load the shared prediction board.
To open it from another device on the same network, use the LAN URL shown in the app or printed by the server, not `localhost`.

## Deploy To Render

This repo now includes a Render deployment server in `render-server.mjs` and Render config in `render.yaml`.

In Render:

1. Create a new `Web Service`.
2. Connect this project repository.
3. Use the repo root as the service root.
4. Render should detect `render.yaml`, or use:
   - Build command: `npm install`
   - Start command: `npm start`
5. Add these environment variables:
   - `GOOGLE_CLIENT_ID`
   - `SESSION_SECRET`
   - `PUBLIC_BASE_URL`

Set `PUBLIC_BASE_URL` to your final Render URL, for example:

```env
PUBLIC_BASE_URL=https://your-app.onrender.com
```

Then add that same exact origin in Google Cloud:

- `https://your-app.onrender.com`

Important Render note:

- The current shared predictions store is a local JSON file in `data/predictions.json`.
- On a free Render web service, local filesystem writes are not durable across redeploys/restarts.
- That means the shared leaderboard can reset unless you move predictions into a database or persistent disk.

## Files

- `index.html` - app layout
- `styles.css` - visual design and responsive layout
- `script.js` - frontend logic and API calls
- `server.ps1` - local HTTP server and JSON API
- `render-server.mjs` - Render/Node HTTP server and API
- `render.yaml` - Render deployment configuration
- `data/matches.json` - real tournament fixture data
- `data/predictions.json` - shared leaderboard storage
- `.env.example` - Google sign-in configuration template
