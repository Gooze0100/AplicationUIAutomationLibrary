using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using System.Diagnostics;

namespace AutomationLibrary.Core;

public class AplicationStart
{
    private readonly string _applicationPath;

    public AplicationStart(string applicationPath)
    {
        _applicationPath = applicationPath;
    }

    /// <summary>
    /// Getting Application with constructors application path.
    /// </summary>
    /// <returns>Attached or lauched Aplication</returns>
    private Application GetApplication() 
    {
        ProcessStartInfo processStartInfo = new(_applicationPath);
        Application application = Application.AttachOrLaunch(processStartInfo);

        Application newApplication = Retry.WhileNull(() =>
        {
            Process ourProcess = Process.GetProcessById(application.ProcessId);

            if (ourProcess.MainWindowHandle != IntPtr.Zero) 
            {
                return new Application(ourProcess);
            }

            return new Application(null);
        }, 
        TimeSpan.FromSeconds(20),
        TimeSpan.FromMilliseconds(30)
        ).Result;

        return newApplication;
    }

    /// <summary>
    /// Gets Application main window.
    /// </summary>
    /// <returns>Window of Application</returns>
    public Window GetWindow() 
    { 
        Application newApplication = GetApplication();
        Window mainWindow = new UIA3Automation().FromHandle(newApplication.MainWindowHandle).AsWindow();
        return mainWindow;
    }
}
