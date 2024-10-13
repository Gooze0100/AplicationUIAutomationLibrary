using AutomationLibrary.Core;
using FlaUI.Core.AutomationElements;

namespace AutomationLibrary.Actions;

public class InputActions
{
    /// <summary>
    /// Sets value by Legacy pattern to caught element.
    /// </summary>
    /// <param name="automationElement"></param>
    /// <param name="value"></param>
    /// <returns>Caught Automation Element</returns>
    public AutomationElement WriteTextInInput(Func<AutomationElement> automationElement, string value)
    {
        AutomationElementFuctions automationElementFuctions = new();
        AutomationElement input = automationElementFuctions.GetAutomationElement(automationElement, "Could not find input.");

        try
        {
            input.Patterns.LegacyIAccessible.Pattern.SetValue(value);
        }
        catch
        {
            throw new($"automationElement: {automationElement}, value: {value}");
        }

        return input;
    }
}
