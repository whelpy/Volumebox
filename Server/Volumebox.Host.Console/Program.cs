// See https://aka.ms/new-console-template for more information
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

Console.WriteLine("Active browser tab names:");
var browserHelper = new BrowserHelper();
browserHelper.PrintBrowserTabName();

Console.WriteLine("\nProcesses with audio output:");

var worker = new ProcessWorker();
foreach (string name in worker.EnumerateApplications())
{
    Console.WriteLine("     Process name: " + name);


    // display mute state & volume level (% of master)
    Console.WriteLine("         Mute: " + worker.GetApplicationMute(name));
    Console.WriteLine("         Volume: " + worker.GetApplicationVolume(name));



    // mute the application
    //SetApplicationMute(app, true);

    // set the volume to half of master volume (50%)
    //SetApplicationVolume(app, 50);

}
