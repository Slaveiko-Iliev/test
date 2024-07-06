using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;

using StudentSystemContext context = new StudentSystemContext();

var addresses = await context.Students
    .Select(s => s.Homeworks)
    .ToListAsync();
;