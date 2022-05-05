#nullable disable

#region read inputs
var targetUrl = GetTargetUrl();
var domain = GetDomain();
var listName = GetListName();
var username = GetUsername();
var password = GetPassword();

var credentials = new NetworkCredential(username, password, domain);
#endregion read inputs

ClientContext context = new(targetUrl)
{
    AuthenticationMode = ClientAuthenticationMode.Default,
    Credentials = credentials
};

ListCollection lists = context.Web.Lists;
IEnumerable<List> results = context.LoadQuery(lists.Where(lst => lst.Title == listName));
await context.ExecuteQueryAsync();
var list = results.FirstOrDefault();

if (list == null)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"A list named \"{listName}\" does not exist 😑");
    Console.ReadKey();
    return;
}

Console.WriteLine($"List found, with name {listName} 👌");

Console.ReadLine();


#region methods
/// <summary>
/// Get Target URL
/// </summary>
static string GetTargetUrl()
{
    Console.Write("Target URL: ");
    return Console.ReadLine();
}

/// <summary>
/// Get Domain
/// </summary>
static string GetDomain()
{
    Console.Write("Domain: ");
    return Console.ReadLine();
}

/// <summary>
/// Get List Name
/// </summary>
static string GetListName()
{
    Console.Write("List Name: ");
    return Console.ReadLine();
}

/// <summary>
/// Get Username
/// </summary>
static string GetUsername()
{
    Console.Write("Username: ");
    return Console.ReadLine();
}

/// <summary>
/// Get Password
/// </summary>
static string GetPassword()
{
    Console.Write("Password: ");
    return Console.ReadLine();
}
#endregion methods