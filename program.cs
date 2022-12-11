using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();     

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
                   
app.UseHttpsRedirection();   

app.MapGet("/students", () =>
{
    var students = new List<Student>()
    {
       new Student()
        {
            studentname = "Gopi",
            studentcourse = "iOS",
            studentage = 28,
            studentid = 0
        },
      
     };          
    return students;
})                          
.WithName("GetStudents")
.WithOpenApi();

app.Run();


