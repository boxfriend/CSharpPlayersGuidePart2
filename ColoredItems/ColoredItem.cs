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

    public ColoredItem() : this(ConsoleColor.Blue) { } //Was going to leave this as default color, but black cannot be seen in console unless background color is changed

    public ColoredItem (ConsoleColor color) : this(new (), color) { }

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public override string ToString () => $"{Color} {Item}";
}
