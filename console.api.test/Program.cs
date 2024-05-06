List<BankAccount> bankAccounts = new List<BankAccount>()
{
    new BankAccount("Ivanov", 10010, new DateTime(2001,12,12), false),
    new BankAccount("Petrov", 15066, new DateTime(1997,06,11), false),
    new BankAccount("Sidorov", 51000, new DateTime(1999,12,04), true),
    new BankAccount("Ivanova", 11012, new DateTime(2000,06,02), false),
    new BankAccount("Garkun", 21005, new DateTime(2003,02,03), false),
    new BankAccount("Yarullin", 10, new DateTime(2003,03,03), true),
    new BankAccount("Yapparov", 31001, new DateTime(2000,05,10), false)
};

//1
var bal1 = bankAccounts.Where(x => x.Balance >= 11000).ToList();
foreach (var t in bal1)
    Console.WriteLine($"{t.Name} more then 11k:{t.Balance}");

//2
Console.WriteLine($"\n");
var nam = bankAccounts.OrderBy(x => x.Name).ToList();
foreach (var t in nam)
    Console.WriteLine($"sort by name: {t.Name} {t.Balance}");
var nam2 = bankAccounts.OrderByDescending(x => x.Name).ToList();
foreach (var t in nam2)
    Console.WriteLine($"sort by name (descending): {t.Name} {t.Balance}");
Console.WriteLine($"\n");
var bal2 = bankAccounts.OrderBy(x => x.Balance).ToList();
foreach (var t in bal2)
    Console.WriteLine($" sort by balance: {t.Name} {t.Balance}");
var bal22 = bankAccounts.OrderByDescending(x => x.Balance).ToList();
foreach (var t in bal22)
    Console.WriteLine($" sort by balance (descending): {t.Name} {t.Balance}");

//3
Console.WriteLine($"\n");
var bal3 = bankAccounts.Where(x => x.Balance <= 10000 && x.IsBan == true).ToList();
foreach (var t in bal3)
    Console.WriteLine($"{t.Name} ban and less then 10k: {t.Balance}");

//4
Console.WriteLine($"\n");
var date = bankAccounts.Where(x => x.Birthday.Year < 2000).ToList();
foreach (var t in date)
    Console.WriteLine($"{t.Name} born before 2000: {t.Birthday.Year}");

//5
Console.WriteLine($"\n");
BankAccount.ToCommunism(bankAccounts);
foreach (var t in bankAccounts)
    Console.WriteLine($"Name: {t.Name}, Balance: {t.Balance}");

// linq
// T1: Записать в отдельный список все аккаунты с балансом больше чем 11к
// T2: Отсортировать аккаунты по алфавиту, по балансу от больше к меньшему и наоборот
// T3: Вывести все забаненные аккаунты с балансом меньше 10к
// T4: Вывести все аккаунты пользователи которых родились до 2000 года
// T5: Сделать метод  ToCommunism() - который распределит все балансы пользователей поровну между всеми

class BankAccount
{
    public BankAccount(string name, decimal balance, DateTime birthday, bool isBan)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Balance = balance;
        Birthday = birthday;
        IsBan = isBan;
    }

    public string Id { get; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public DateTime Birthday { get; set; }
    public bool IsBan { get; set; }

    public static void ToCommunism(List<BankAccount> t)
    {
        int allAcc = t.Count;
        decimal allBalance = t.Sum(acc => acc.Balance);
        decimal delitsa = allBalance / allAcc;

        foreach (var acc in t)
            acc.Balance = delitsa;
    }
}
