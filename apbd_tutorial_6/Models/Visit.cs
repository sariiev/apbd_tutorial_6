namespace apbd_tutorial_6.Models;

public class Visit
{
    private static int counter = 0;
    public int Id { get; }
    public Animal Animal { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public Visit(Animal animal, DateTime date, string description, double price)
    {
        Id = ++counter;
        Animal = animal;
        Date = date;
        Description = description;
        Price = price;
    }
}