using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using System.Threading;

namespace AutomationLibrary.Actions;

public class ButtonActions
{
    public static Button InvokeButtonByAutomationId(Window window, string automationId)
    {
        Button button = GetButtonByFirstDescendant(window, automationId);
        try
        {
            if (button != null && button.IsEnabled)
            {
                button.WaitUntilEnabled().Patterns.Invoke.Pattern.Invoke();
            }
        }
        catch (Exception ex)
        {
            // Log.Warning(ex, "Cannot Add number to email.");
            Console.WriteLine(ex);
        }

        return button;
    }

    // There is no DRY because most of them are the same
    private static Button GetButtonByFirstDescendant(Window window, string automationId)
    {
        Button button = Retry.WhileNull(
            () => window.FindFirstDescendant(cf => cf.ByAutomationId(automationId)).AsButton(),
            timeout: TimeSpan.FromSeconds(10),
            throwOnTimeout: true,
            timeoutMessage: "Could not find element by: " + automationId
        ).Result;

        return button;
    }

    private static Button GetButtonByFirstDescendant(Window window, string automationId, string timeoutMsg)
    {
        Button button = Retry.WhileNull(
            () => window.FindFirstDescendant(cf => cf.ByAutomationId(automationId)).AsButton(),
            timeout: TimeSpan.FromSeconds(10),
            throwOnTimeout: true,
            timeoutMessage: timeoutMsg
        ).Result;

        return button;
    }

    private static Button GetButtonByFirstDescendant(Window window, ControlType controlType)
    {
        Button button = Retry.WhileNull(
            () => window.FindFirstDescendant(cf => cf.ByControlType(controlType)).AsButton(),
            timeout: TimeSpan.FromSeconds(10),
            throwOnTimeout: true,
            timeoutMessage: "Could not find element by: " + controlType
        ).Result;

        return button;
    }

    private static Button GetButtonByFirstChild(Window window, string automationId)
    {
        Button button = Retry.WhileNull(
            () => window.FindFirstChild(cf => cf.ByAutomationId(automationId)).AsButton(),
            timeout: TimeSpan.FromSeconds(10),
            throwOnTimeout: true,
            timeoutMessage: "Could not find element by: " + automationId
        ).Result;

        return button;
    }

    private static Button GetButtonByFirstChild(Window window, ControlType controlType)
    {
        Button button = Retry.WhileNull(
            () => window.FindFirstChild(cf => cf.ByControlType(controlType)).AsButton(),
            timeout: TimeSpan.FromSeconds(10),
            throwOnTimeout: true,
            timeoutMessage: "Could not find element by: " + controlType
        ).Result;

        return button;
    }

    private static Button GetButtonByFirstChildAnd(Window window, string automationId)
    {
        Button button = Retry.WhileNull(
            () => window.FindFirstChild(cf => cf.ByAutomationId(automationId)).AsButton(),
            timeout: TimeSpan.FromSeconds(10),
            throwOnTimeout: true,
            timeoutMessage: "Could not find element by: " + automationId
        ).Result;

        return button;
    }
}

// jis iesko per TreeScope.Children reiktu paciam pasidaryti kad per tai ieskotu tada su func butu galima paduoti reikiama funkcija
