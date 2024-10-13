using FlaUI.Core.Input;
using System.Drawing;

namespace AutomationLibrary.Actions;

public class MovementActions
{
    /// <summary>
    /// Moves to specific position and clicks it.
    /// </summary>
    /// <param name="positionX"></param>
    /// <param name="positionY"></param>
    public void MoveToAndClick(Rectangle positionX, Rectangle positionY)
    {
        Mouse.MoveTo(positionX.X, positionY.Y);
        Mouse.LeftClick();
    }
}
