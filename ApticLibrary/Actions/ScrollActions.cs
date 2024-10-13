using FlaUI.Core.AutomationElements;

namespace AutomationLibrary.Actions;

public class ScrollActions
{
    /// <summary>
    /// Scrolls element by pattern into view.
    /// </summary>
    /// <param name="line"></param>
    public void ScrollIntoView(AutomationElement element)
    {
        if (element != null)
        {
            element.Patterns.ScrollItem.Pattern.ScrollIntoView();
        }
        else
        {
            throw new InvalidOperationException("Not possible to scroll this element.");
        }
    }
}
