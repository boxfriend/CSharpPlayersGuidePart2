using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredItems;

internal class ColoredItem<T> where T : Item, new()
{
    public T Item { get; init; }
    public ConsoleColor Color { get; init; }

    public ColoredItem()
    {
        Item = new ();
        Color = ConsoleColor.Blue; //Was going to leave this as default, but black cannot be seen in console unless background color is changed
    }

    public ColoredItem (ConsoleColor color) : this() => Color = color;

    public override string ToString () => $"{Color} {Item}";
}
