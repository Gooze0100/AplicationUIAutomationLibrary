using FlaUI.Core.AutomationElements;

namespace AutomationLibrary.Actions;

public class Scroll
{
    public void ScrollIntoView(AutomationElement line)
    {
        if (line != null)
        {
            line.Patterns.ScrollItem.Pattern.ScrollIntoView();
        }
    }
}
