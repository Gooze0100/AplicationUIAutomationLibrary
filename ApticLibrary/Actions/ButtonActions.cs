using AutomationLibrary.Core;
using FlaUI.Core.AutomationElements;

namespace AutomationLibrary.Actions;

public class ButtonActions
{
    /// <summary>
    /// Invokes caught button by default, otherwise clicks.
    /// </summary>
    /// <param name="automationElement"></param>
    /// <param name="invokeButton"></param>
    /// <returns>Caught button</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public Button CallButton(Func<Button> automationElement, bool invokeButton = true)
    {
        AutomationElementFuctions automationElementFuctions = new();
        Button button = automationElementFuctions.GetAutomationElement(automationElement);

        try
        {
            if (button != null && button.IsEnabled)
            {
                if (invokeButton)
                {
                    button.WaitUntilEnabled().Patterns.Invoke.Pattern.Invoke();
                }
                else
                {
                    button.WaitUntilEnabled().Click();
                }
            }
            else
            {
                throw new ArgumentNullException("automationElement: " + automationElement);
            }
        }
        catch (Exception ex)
        {
            // Log.Warning(ex, "Cannot Add number to email.");
            Console.WriteLine(ex);
        }

        return button;
    }
}