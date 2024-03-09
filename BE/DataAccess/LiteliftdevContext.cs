using System;
using System.Collections.Generic;
using BE.Models;
using Microsoft.EntityFrameworkCore;

namespace BE.DataAccess;

public partial class LiteliftdevContext : DbContext
{
    public LiteliftdevContext()
    {
    }

    public LiteliftdevContext(DbContextOptions<LiteliftdevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Routine> Routines { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Username=jordan;Password=elephant1;Database=liteliftdev");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("follows_pkey");

            entity.ToTable("follows");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FollowedUserId).HasColumnName("followed_user_id");
            entity.Property(e => e.FollowingUserId).HasColumnName("following_user_id");

            entity.HasOne(d => d.FollowedUser).WithMany(p => p.FollowFollowedUsers)
                .HasForeignKey(d => d.FollowedUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("follows_followed_user_id_fkey");

            entity.HasOne(d => d.FollowingUser).WithMany(p => p.FollowFollowingUsers)
                .HasForeignKey(d => d.FollowingUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("follows_following_user_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
        });

        modelBuilder.Entity<Routine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("routine_pkey");

            entity.ToTable("routine");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Status).WithMany(p => p.Routines)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("routine_status_id_fkey");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("set_pkey");

            entity.ToTable("set");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Reps).HasColumnName("reps");
            entity.Property(e => e.RoutineId).HasColumnName("routine_id");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.Weight).HasColumnName("weight");
            entity.Property(e => e.WorkoutId).HasColumnName("workout_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Sets)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("set_category_id_fkey");

            entity.HasOne(d => d.Routine).WithMany(p => p.Sets)
                .HasForeignKey(d => d.RoutineId)
                .HasConstraintName("set_routine_id_fkey");

            entity.HasOne(d => d.Unit).WithMany(p => p.Sets)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("set_unit_id_fkey");

            entity.HasOne(d => d.Workout).WithMany(p => p.Sets)
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("set_workout_id_fkey");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unit_pkey");

            entity.ToTable("unit");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("users_role_id_fkey");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("workout_pkey");

            entity.ToTable("workout");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.RoutineId).HasColumnName("routine_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Routine).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.RoutineId)
                .HasConstraintName("workout_routine_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("workout_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        return base.SaveChanges();
    }
}
