using SuggestionApp.DatabaseConnection;

EmployeeDbContext employeeDbContext = new EmployeeDbContext();

Console.WriteLine("--------------------------Teams Information From Database----------------------------");
var teams = employeeDbContext.Teams.ToList();
foreach(var team in teams)
{
    Console.WriteLine(" Team Leader: "+ team.TeamLeader + " Team Name:" + team.TeamName);
}
Console.WriteLine("----------------Employees Information From Database---------------------");
//var employees = employeeDbContext.Employees.ToList();
//foreach(var employee in employees)
//{
   // Console.WriteLine("Employee Details= Employee username :"+employee.Username +"Employee Name"+ employee.FirstName + " "+employee.LastName);
//}
Console.WriteLine("Suggestions Information From Database");
var suggestions = employeeDbContext.Suggestions.ToList();
foreach (var suggestion in suggestions)
{
    Console.WriteLine(suggestion.PriorityLevel);
}
