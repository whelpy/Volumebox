// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using Volumebox.Host.Console;

Console.WriteLine("Volumebox.Host.Console");

var browsersList = new List<string>
    {
        "chrome",
        "firefox",
        "iexplore",
        "safari",
        "opera",
        "edge"
    };

Console.WriteLine("\nProcesses with audio output:");

var worker = new ProcessWorker();
foreach (uint pid in worker.EnumerateApplications())
{
    Console.WriteLine("     Process id: " + pid);

    var process = Process.GetProcessById((int)pid);
    if (process != null)
    {
        Console.WriteLine("     Process name: " + process.ProcessName);
        Console.WriteLine("     Process title: " + process.MainWindowTitle);
    }
    

    // display mute state & volume level (% of master)
    Console.WriteLine("         Mute: " + worker.GetApplicationMute(pid));
    Console.WriteLine("         Volume: " + worker.GetApplicationVolume(pid));



    // mute the application
    //SetApplicationMute(app, true);

    // set the volume to half of master volume (50%)
    //SetApplicationVolume(app, 50);
    Console.WriteLine("");

}
