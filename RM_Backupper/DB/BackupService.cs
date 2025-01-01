// <copyright file="BackupService.cs" company="Massimo Ronzulli">
// Copyright (c) Massimo Ronzulli. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace RM_Backupper.DB
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides high-level actions for managing backup records and database initialization.
    /// </summary>
    public class BackupService
    {
        private readonly BackupDB repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackupService"/> class.
        /// </summary>
        public BackupService()
        {
            this.repository = new BackupDB();
        }

        /// <summary>
        /// Ensures that the database is created. If the database does not exist, it will be created.
        /// </summary>
        public void InitializeDatabase()
        {
            using (var context = new BackupDbContext())
            {
                // Create the database if it doesn't exist
                if (!context.Database.Exists())
                {
                    context.Database.Create();
                    Console.WriteLine("Database created successfully.");
                }
                else
                {
                    Console.WriteLine("Database already exists.");
                }
            }
        }

        /// <summary>
        /// Creates a new backup record in the database with the specified parameters.
        /// </summary>
        /// <param name="backupName">The name of the backup.</param>
        /// <param name="backupType">The type of the backup (e.g., Full, Incremental).</param>
        /// <param name="sourceDevice">The source device from which the backup originates.</param>
        /// <param name="destinationDevice">The destination device where the backup will be stored.</param>
        /// <returns>
        /// The created <see cref="Backup"/> object, including its database-assigned ID.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="backupName"/>, <paramref name="backupType"/>,
        /// <paramref name="sourceDevice"/>, or <paramref name="destinationDevice"/> is null or empty.
        /// </exception>
        /// <example>
        /// Example usage:
        /// <code>
        /// var service = new BackupService();
        /// var backup = service.CreateBackup("MyBackup", "Full", "Device1", "Device2");
        /// Console.WriteLine($"Backup created with ID: {backup.BackupId}");
        /// </code>
        /// </example>
        public Backup CreateBackup(string backupName, string backupType, string sourceDevice, string destinationDevice)
        {
            if (string.IsNullOrWhiteSpace(backupName))
            {
                throw new ArgumentNullException(nameof(backupName), "Backup name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(backupType))
            {
                throw new ArgumentNullException(nameof(backupType), "Backup type cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(sourceDevice))
            {
                throw new ArgumentNullException(nameof(sourceDevice), "Source device cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(destinationDevice))
            {
                throw new ArgumentNullException(nameof(destinationDevice), "Destination device cannot be null or empty.");
            }

            var newBackup = new Backup
            {
                BackupName = backupName,
                CreatedAt = DateTime.Now,
                BackupType = backupType,
                Status = "In Progress",
                SourceDevice = sourceDevice,
                DestinationDevice = destinationDevice,
            };

            this.repository.CreateBackup(newBackup);
            return newBackup;
        }

        /// <summary>
        /// Retrieves a specific backup record by its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the backup record.</param>
        /// <returns>
        /// The <see cref="Backup"/> object if found; otherwise, <c>null</c>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="id"/> is less than or equal to 0.
        /// </exception>
        /// <example>
        /// Example usage:
        /// <code>
        /// var service = new BackupService();
        /// var backup = service.GetBackupById(1);
        /// if (backup != null)
        /// {
        ///     Console.WriteLine($"Found backup: {backup.BackupName}");
        /// }
        /// else
        /// {
        ///     Console.WriteLine("Backup not found.");
        /// }
        /// </code>
        /// </example>
        public Backup GetBackupById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            return this.repository.GetBackupById(id);
        }

        /// <summary>
        /// Retrieves all backup records from the database.
        /// </summary>
        /// <returns>
        /// A list of all <see cref="Backup"/> objects in the database.
        /// </returns>
        /// <example>
        /// Example usage:
        /// <code>
        /// var service = new BackupService();
        /// var backups = service.GetAllBackups();
        /// foreach (var backup in backups)
        /// {
        ///     Console.WriteLine($"Backup ID: {backup.BackupId}, Name: {backup.BackupName}");
        /// }
        /// </code>
        /// </example>
        public List<Backup> GetAllBackups()
        {
            return this.repository.GetAllBackups();
        }

        /// <summary>
        /// Updates the status of a specific backup record.
        /// </summary>
        /// <param name="id">The unique identifier of the backup record.</param>
        /// <param name="newStatus">The new status to assign to the backup.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="id"/> is less than or equal to 0.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="newStatus"/> is null or empty.
        /// </exception>
        /// <example>
        /// Example usage:
        /// <code>
        /// var service = new BackupService();
        /// service.UpdateBackupStatus(1, "Completed");
        /// Console.WriteLine("Backup status updated.");
        /// </code>
        /// </example>
        public void UpdateBackupStatus(int id, string newStatus)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(newStatus))
            {
                throw new ArgumentNullException(nameof(newStatus), "New status cannot be null or empty.");
            }

            var backup = this.repository.GetBackupById(id);
            if (backup != null)
            {
                backup.Status = newStatus;
                this.repository.UpdateBackup(backup);
            }
            else
            {
                throw new ArgumentException($"Backup with ID {id} not found.");
            }
        }

        /// <summary>
        /// Deletes a specific backup record by its unique ID. This operation performs a logical deletion.
        /// </summary>
        /// <param name="id">The unique identifier of the backup record to delete.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="id"/> is less than or equal to 0.
        /// </exception>
        /// <example>
        /// Example usage:
        /// <code>
        /// var service = new BackupService();
        /// service.DeleteBackup(1);
        /// Console.WriteLine("Backup deleted successfully.");
        /// </code>
        /// </example>
        public void DeleteBackup(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }

            this.repository.DeleteBackup(id);
        }
    }
}