using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sotrydniki.Models;

namespace Sotrydniki.Context;

public partial class User9Context : DbContext
{
    public User9Context()
    {
    }

    public User9Context(DbContextOptions<User9Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Abscenetype> Abscenetypes { get; set; }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeeabsence> Employeeabsences { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Firedemployee> Firedemployees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }

    public virtual DbSet<Trainingmaterial> Trainingmaterials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=45.67.56.214;Port=5454;Database=user9;Username=user9;Password=X8C8NTnD");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abscenetype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("abscenetypes_pkey");

            entity.ToTable("abscenetypes", "Sotrydniki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.HasKey(e => e.Calendarid).HasName("calendars_pkey");

            entity.ToTable("calendars", "Sotrydniki");

            entity.Property(e => e.Calendarid).HasColumnName("calendarid");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("candidates_pkey");

            entity.ToTable("candidates", "Sotrydniki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activitydirection)
                .HasMaxLength(255)
                .HasColumnName("activitydirection");
            entity.Property(e => e.Applicationdate).HasColumnName("applicationdate");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasColumnName("fullname");
            entity.Property(e => e.Resume).HasColumnName("resume");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("departments_pkey");

            entity.ToTable("departments", "Sotrydniki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasMany(d => d.Childdepts).WithMany(p => p.Parentdepts)
                .UsingEntity<Dictionary<string, object>>(
                    "Departmenthierarchy",
                    r => r.HasOne<Department>().WithMany()
                        .HasForeignKey("Childdeptid")
                        .HasConstraintName("departmenthierarchy_childdeptid_fkey"),
                    l => l.HasOne<Department>().WithMany()
                        .HasForeignKey("Parentdeptid")
                        .HasConstraintName("departmenthierarchy_parentdeptid_fkey"),
                    j =>
                    {
                        j.HasKey("Parentdeptid", "Childdeptid").HasName("departmenthierarchy_pkey");
                        j.ToTable("departmenthierarchy", "Sotrydniki");
                        j.IndexerProperty<int>("Parentdeptid").HasColumnName("parentdeptid");
                        j.IndexerProperty<int>("Childdeptid").HasColumnName("childdeptid");
                    });

            entity.HasMany(d => d.Parentdepts).WithMany(p => p.Childdepts)
                .UsingEntity<Dictionary<string, object>>(
                    "Departmenthierarchy",
                    r => r.HasOne<Department>().WithMany()
                        .HasForeignKey("Parentdeptid")
                        .HasConstraintName("departmenthierarchy_parentdeptid_fkey"),
                    l => l.HasOne<Department>().WithMany()
                        .HasForeignKey("Childdeptid")
                        .HasConstraintName("departmenthierarchy_childdeptid_fkey"),
                    j =>
                    {
                        j.HasKey("Parentdeptid", "Childdeptid").HasName("departmenthierarchy_pkey");
                        j.ToTable("departmenthierarchy", "Sotrydniki");
                        j.IndexerProperty<int>("Parentdeptid").HasColumnName("parentdeptid");
                        j.IndexerProperty<int>("Childdeptid").HasColumnName("childdeptid");
                    });
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pkey");

            entity.ToTable("employees", "Sotrydniki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Additionalinfo).HasColumnName("additionalinfo");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Mobilephone)
                .HasMaxLength(20)
                .HasColumnName("mobilephone");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Office)
                .HasMaxLength(10)
                .HasColumnName("office");
            entity.Property(e => e.Workphone)
                .HasMaxLength(20)
                .HasColumnName("workphone");

            entity.HasMany(d => d.Assistants).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeAssistant",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("AssistantId")
                        .HasConstraintName("employee_assistant_employees_fk_1"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("employee_assistant_employees_fk"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "AssistantId").HasName("employee_assistant_pk");
                        j.ToTable("employee_assistant", "Sotrydniki");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("AssistantId").HasColumnName("assistant_id");
                    });

            entity.HasMany(d => d.Departments).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeDepartment",
                    r => r.HasOne<Department>().WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("employee_department_departments_fk"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("employee_department_employees_fk"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "DepartmentId").HasName("employee_department_pk");
                        j.ToTable("employee_department", "Sotrydniki");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("DepartmentId").HasColumnName("department_id");
                    });

            entity.HasMany(d => d.Employees).WithMany(p => p.Assistants)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeAssistant",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("employee_assistant_employees_fk"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("AssistantId")
                        .HasConstraintName("employee_assistant_employees_fk_1"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "AssistantId").HasName("employee_assistant_pk");
                        j.ToTable("employee_assistant", "Sotrydniki");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("AssistantId").HasColumnName("assistant_id");
                    });

            entity.HasMany(d => d.EmployeesNavigation).WithMany(p => p.Supervisors)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeSupervisor",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("employee_supervisor_employees_fk"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("SupervisorId")
                        .HasConstraintName("employee_supervisor_employees_fk_1"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "SupervisorId").HasName("employee_supervisor_pk");
                        j.ToTable("employee_supervisor", "Sotrydniki");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("SupervisorId").HasColumnName("supervisor_id");
                    });

            entity.HasMany(d => d.Positions).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "Employeeposition",
                    r => r.HasOne<Position>().WithMany()
                        .HasForeignKey("Positionid")
                        .HasConstraintName("employeepositions_positionid_fkey"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("Employeeid")
                        .HasConstraintName("employeepositions_employeeid_fkey"),
                    j =>
                    {
                        j.HasKey("Employeeid", "Positionid").HasName("employeepositions_pkey");
                        j.ToTable("employeepositions", "Sotrydniki");
                        j.IndexerProperty<int>("Employeeid").HasColumnName("employeeid");
                        j.IndexerProperty<int>("Positionid").HasColumnName("positionid");
                    });

            entity.HasMany(d => d.Supervisors).WithMany(p => p.EmployeesNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeSupervisor",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("SupervisorId")
                        .HasConstraintName("employee_supervisor_employees_fk_1"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("employee_supervisor_employees_fk"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "SupervisorId").HasName("employee_supervisor_pk");
                        j.ToTable("employee_supervisor", "Sotrydniki");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("SupervisorId").HasColumnName("supervisor_id");
                    });

            entity.HasMany(d => d.Training).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "Employeetraining",
                    r => r.HasOne<Training>().WithMany()
                        .HasForeignKey("Trainingid")
                        .HasConstraintName("employeetrainings_trainingid_fkey"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("Employeeid")
                        .HasConstraintName("employeetrainings_employeeid_fkey"),
                    j =>
                    {
                        j.HasKey("Employeeid", "Trainingid").HasName("employeetrainings_pkey");
                        j.ToTable("employeetrainings", "Sotrydniki");
                        j.IndexerProperty<int>("Employeeid").HasColumnName("employeeid");
                        j.IndexerProperty<int>("Trainingid").HasColumnName("trainingid");
                    });
        });

        modelBuilder.Entity<Employeeabsence>(entity =>
        {
            entity.HasKey(e => e.Absenceid).HasName("employeeabsences_pkey");

            entity.ToTable("employeeabsences", "Sotrydniki");

            entity.Property(e => e.Absenceid).HasColumnName("absenceid");
            entity.Property(e => e.AbsencetypeId).HasColumnName("absencetypeID");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Replacementid).HasColumnName("replacementid");
            entity.Property(e => e.Startdate).HasColumnName("startdate");

            entity.HasOne(d => d.Absencetype).WithMany(p => p.Employeeabsences)
                .HasForeignKey(d => d.AbsencetypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeabsences_abscenetypes_fk");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeabsenceEmployees)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("employeeabsences_employeeid_fkey");

            entity.HasOne(d => d.Replacement).WithMany(p => p.EmployeeabsenceReplacements)
                .HasForeignKey(d => d.Replacementid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("employeeabsences_replacementid_fkey");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events", "Sotrydniki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(255)
                .HasColumnName("eventtype");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasMany(d => d.Employees).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "Eventresponsible",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("Employeeid")
                        .HasConstraintName("eventresponsibles_employeeid_fkey"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("Eventid")
                        .HasConstraintName("eventresponsibles_eventid_fkey"),
                    j =>
                    {
                        j.HasKey("Eventid", "Employeeid").HasName("eventresponsibles_pkey");
                        j.ToTable("eventresponsibles", "Sotrydniki");
                        j.IndexerProperty<int>("Eventid").HasColumnName("eventid");
                        j.IndexerProperty<int>("Employeeid").HasColumnName("employeeid");
                    });
        });

        modelBuilder.Entity<Firedemployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("firedemployees_pkey");

            entity.ToTable("firedemployees", "Sotrydniki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Additionalinfo).HasColumnName("additionalinfo");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Dismissdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dismissdate");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Mobilephone)
                .HasMaxLength(20)
                .HasColumnName("mobilephone");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("positions_pkey");

            entity.ToTable("positions", "Sotrydniki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trainings_pkey");

            entity.ToTable("trainings", "Sotrydniki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Classification)
                .HasMaxLength(255)
                .HasColumnName("classification");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Time).HasColumnName("time");
        });

        modelBuilder.Entity<Trainingmaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trainingmaterials_pkey");

            entity.ToTable("trainingmaterials", "Sotrydniki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Approvaldate).HasColumnName("approvaldate");
            entity.Property(e => e.Area)
                .HasMaxLength(255)
                .HasColumnName("area");
            entity.Property(e => e.Authorid).HasColumnName("authorid");
            entity.Property(e => e.Lastmodifieddate).HasColumnName("lastmodifieddate");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");

            entity.HasOne(d => d.Author).WithMany(p => p.Trainingmaterials)
                .HasForeignKey(d => d.Authorid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("trainingmaterials_authorid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
