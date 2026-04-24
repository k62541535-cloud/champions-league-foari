using System;
using System.Diagnostics;
using System.IO;

internal static class PulseCupPredictorLauncher
{
    [STAThread]
    private static void Main()
    {
        string appDir = AppDomain.CurrentDomain.BaseDirectory;
        string launcherScript = Path.Combine(appDir, "start-pulse-cup.bat");

        Process.Start(new ProcessStartInfo
        {
            FileName = launcherScript,
            WorkingDirectory = appDir,
            UseShellExecute = true
        });
    }
}
