using SoftUni.Data;
using SoftUni.Models;

static string RemoveTown(SoftUniContext context)
{
    var townToDelete = context
        .Towns
        .First(t => t.Name == "Seattle");

    IQueryable<Address> addressesToDelete =
        context
            .Addresses
            .Where(a => a.TownId == townToDelete.TownId);

    int addressesCount = addressesToDelete.Count();

    IQueryable<Employee> employeesOnDeletedAddresses =
        context
            .Employees
            .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

    foreach (var employee in employeesOnDeletedAddresses)
    {
        employee.AddressId = null;
    }

    foreach (var address in addressesToDelete)
    {
        context.Addresses.Remove(address);
    }

    context.Remove(townToDelete);

    context.SaveChanges();

    return $"{addressesCount} addresses in Seattle were deleted";

}