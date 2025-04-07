namespace apbd_tutorial_6.Models;

public class Animal
{
    private static int counter = 0;
    public int Id { get; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string FurColor { get; set; }

    public Animal(string name, string category, string furColor)
    {
        Id = ++counter;
        Name = name;
        Category = category;
        FurColor = furColor;
    }
}