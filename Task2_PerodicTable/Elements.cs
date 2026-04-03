using System;

class Element
{
    public int AtomicNumber { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }

    public Element(int number, string name, string category)
    {
        AtomicNumber = number;
        Name = name;
        Category = category;
    }
}