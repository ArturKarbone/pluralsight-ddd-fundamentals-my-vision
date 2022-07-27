﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ClinicManagement.Core.Appointment_Types.Domain;
using ClinicManagement.Core.Clients.Domain;
using ClinicManagement.Core.Doctors.Domain;
using ClinicManagement.Core.Patiens.Domain;
using ClinicManagement.Core.Rooms.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PluralsightDdd.SharedKernel;

namespace ClinicManagement.Infrastructure.Data
{
  public class AppDbContext : DbContext
  {
    private readonly IMediator _mediator;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
        : base(options)
    {
      _mediator = mediator;
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<AppointmentType> AppointmentTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

      // ignore events if no dispatcher provided
      if (_mediator == null) return result;

      var entitiesWithEvents = ChangeTracker
          .Entries()
          .Select(e => e.Entity as BaseEntity<Guid>)
          .Where(e => e?.Events != null && e.Events.Any())
          .ToArray();

      foreach (var entity in entitiesWithEvents)
      {
        var events = entity.Events.ToArray();
        entity.Events.Clear();
        foreach (var domainEvent in events)
        {
          await _mediator.Publish(domainEvent).ConfigureAwait(false);
        }
      }

      return result;
    }

    public override int SaveChanges()
    {
      return SaveChangesAsync().GetAwaiter().GetResult();
    }
  }
}
