using FlaUI.Core.Tools;

namespace AutomationLibrary.Core;

public class AutomationElementFuctions
{
    /// <summary>
    /// Always write type to the end. Example - AsButton()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="automationElement"></param>
    /// <returns>Automation element which was passed</returns>
    public T GetAutomationElement<T>(Func<T> automationElement)
    where T : class
    {
        T foundAutomationElement = Retry.WhileNull(
            automationElement,
            timeout: TimeSpan.FromSeconds(10),
            throwOnTimeout: true,
            timeoutMessage: "No described automation element found."
        ).Result;

        return foundAutomationElement;
    }

    /// <summary>
    /// Always write type to the end. Example - AsButton()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="automationElement"></param>
    /// <param name="timeoutMessage"></param>
    /// <returns>Automation element which was passed</returns>
    public T GetAutomationElement<T>(Func<T> automationElement, string timeoutMessage)
        where T : class
    {
        T foundAutomationElement = Retry.WhileNull(
            automationElement,
            timeout: TimeSpan.FromSeconds(10),
            throwOnTimeout: true,
            timeoutMessage: timeoutMessage
        ).Result;

        return foundAutomationElement;
    }

    /// <summary>
    /// Always write type to the end. Example - AsButton()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="automationElement"></param>
    /// <param name="timeout"></param>
    /// <param name="throwMessageOnTimeout"></param>
    /// <param name="timeoutMessage"></param>
    /// <returns>Automation element which was passed</returns>
    public T GetAutomationElement<T>(Func<T> automationElement, TimeSpan timeout, bool throwMessageOnTimeout, string timeoutMessage)
        where T : class
    {
        T foundAutomationElement = Retry.WhileNull(
            automationElement,
            timeout: timeout,
            throwOnTimeout: throwMessageOnTimeout,
            timeoutMessage: timeoutMessage
        ).Result;

        return foundAutomationElement;
    }
}
