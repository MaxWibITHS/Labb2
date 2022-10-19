// See https://aka.ms/new-console-template for more information

List<Redskap> items = new List<Redskap>();

Redskap redskap = new Redskap("Kaffekokare", "Mocca Master", true);
Redskap redskap2 = new Redskap("Kniv", "Global", false);

items.Add(redskap);
items.Add(redskap2);


bool endProgram = true;
while (endProgram == true)
{
    try
    {
        PrintHuvudMeny();

        int input = int.Parse(Console.ReadLine());
        if (input < 1 || input > 6)
        {
            Console.WriteLine("Du har matat in ett val som inte finns i listan");
        }

        switch (input)
        {
            case 1:
                NyttRedskap();
                break;

            case 2:
                DeleteTool();
                break;

            case 3:
                int s = 1;

                Console.WriteLine("=== Vilket redskap vill du använda? ===");

                foreach (Redskap item in items)
                {
                    Console.WriteLine(s++ + ". " + item.Name);
                }

                int inputUse = int.Parse(Console.ReadLine());
                redskap = items[inputUse - 1];

                redskap.Use();
                break;

            case 4:
                PrintNoFunction();
                break;

            case 5:
                PrintList();

                break;

            case 6:
                endProgram = false;
                break;

        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Förlåt för otydligheterna men du måste använda siffrorna för att ta dig runt i menyn.");
        continue;
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Hörredudu! Du matade in en siffra som inte fanns i listan.");
    }
}

void PrintHuvudMeny()
{
    string[] huvudmeny = { "==== Välkommen till köket! ====\n",
                                "1. Lägg till redskap: ",
                                "2. Ta bort redskap: ",
                                "3. Använd ett redskap: ",
                                "4. Se redskap som inte fungerar: ",
                                "5. Skriv ut lista på alla redskap ",
                                "6. Avsluta programmet"};
    foreach (string i in huvudmeny)
    {
        Console.WriteLine(i);
    }

}
void NyttRedskap()
{
    bool b = true;
    Console.WriteLine("Skriv redskapet: ");
    string x = Console.ReadLine();
    if (x == "")
    {
        Console.WriteLine("Du matade inte in något.");
        return;
    }
    Console.WriteLine("Skriv märket på redskapet: ");
    string y = Console.ReadLine();
    if (y == "")
    {
        Console.WriteLine("Du matade inte in något.");
        return;
    }

    Console.WriteLine("Fungerar redskapet? j/n");
    string inputFunction = Console.ReadLine();
    while (inputFunction != "n" || inputFunction != "j")
    {

        if (inputFunction == "j")

        {
            b = true;
            Console.WriteLine("=== Redskapet tillagt! ===");
            break;
        }
        if (inputFunction == "n")
        {
            b = false;
            Console.WriteLine("=== Redskapet tillagt! ===");
            break;
        }
        if (inputFunction != "n" || inputFunction != "j")
        {
            Console.WriteLine("Felinmatat värde, mata in 'j' för ja och 'n' för nej");
            return;
        }
    }
    Redskap nyttRedskap = new Redskap(x, y, b);
    items.Add(nyttRedskap);
}
void DeleteTool()
{
    int f = 1;
    Console.WriteLine("=== Vilket redskap vill du ta bort? ===");

    foreach (Redskap item in items)
    {
        Console.WriteLine(f++ + ". " + item.Name);
    }
    int input = int.Parse(Console.ReadLine());
    items.RemoveAt(input - 1);
    Console.WriteLine("=== Redskap borttaget ===");
}
void PrintList()
{
    Console.WriteLine("===== Finns i köket =====");
    foreach (Redskap item in items)
        if (item.Function == true)
        {
            Console.WriteLine("Redskap: " + item.Name + "\nMärke: " + item.Brand + "\nRedskap fungerar!\n");
        }
        else
        {
            Console.WriteLine("Redskap: " + item.Name + "\nMärke: " + item.Brand + "\nRedskap fungerar inte!\n");
        }
    Console.WriteLine("==========================");
}
void PrintNoFunction()
{
    Console.WriteLine("=== Redskap ur funktion ===");
    var redSkapNOFunction = from item in items
                            where item.Function == false
                            select item.Name;
    foreach (var nofunction in redSkapNOFunction)
    {
        Console.WriteLine(nofunction);
    }

}

public interface IKitchen
{
    string Name { get; set; }
    string Brand { get; set; }
    public bool Function { get; set; }
    void Use();

}

class Redskap : IKitchen
{
    public string Name { get; set; }
    public string Brand { get; set; }

    public bool Function { get; set; }

    public void Use()
    {
        if (Function == true)
        {
            Console.WriteLine("Använder " + this.Name);
        }
        if (Function == false)
        {
            Console.WriteLine("Redskapet är sönder!");
        }

    }

    public Redskap(string name, string brand, bool function)
    {
        this.Name = name;
        this.Brand = brand;
        this.Function = function;
    }
}










