using Graduation_Thesis_Management_System_BE.Data;
using Graduation_Thesis_Management_System_BE.Repositories.Implementations;
using Graduation_Thesis_Management_System_BE.Repositories.Interfaces;
using Graduation_Thesis_Management_System_BE.Services.Implementations;
using Graduation_Thesis_Management_System_BE.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<GraduationThesisManagementSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ================= CORE =================
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// ================= ACCOUNT / ROLE =================
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<ILecturerRepository, LecturerRepository>();
builder.Services.AddScoped<ILecturerService, LecturerService>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

// ================= ACADEMIC STRUCTURE =================
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IClassService, ClassService>();

builder.Services.AddScoped<IDefenseSessionRepository, DefenseSessionRepository>();
builder.Services.AddScoped<IDefenseSessionService, DefenseSessionService>();

// ================= TOPIC & PROCESS =================
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<ITopicService, TopicService>();

builder.Services.AddScoped<ILecturerAssignmentRepository, LecturerAssignmentRepository>();
builder.Services.AddScoped<ILecturerAssignmentService, LecturerAssignmentService>();

builder.Services.AddScoped<IOutlinePlanRepository, OutlinePlanRepository>();
builder.Services.AddScoped<IOutlinePlanService, OutlinePlanService>();

builder.Services.AddScoped<IProgressReportRepository, ProgressReportRepository>();
builder.Services.AddScoped<IProgressReportService, ProgressReportService>();

builder.Services.AddScoped<IThesisRepository, ThesisRepository>();
builder.Services.AddScoped<IThesisService, ThesisService>();

builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddScoped<IResultService, ResultService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
