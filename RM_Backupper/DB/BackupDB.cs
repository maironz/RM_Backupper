// <copyright file="BackupDB.cs" company="Massimo Ronzulli">
// Copyright (c) Massimo Ronzulli. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace RM_Backupper.DB
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Repository to manage database operations related to backups.
    /// </summary>
    public class BackupDB
    {
        private readonly BackupDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackupDB"/> class.
        /// </summary>
        public BackupDB()
        {
            this.context = new BackupDbContext();
        }

        /// <summary>
        /// Adds a new backup to the database.
        /// </summary>
        /// <param name="backup">The backup to add.</param>
        public void CreateBackup(Backup backup)
        {
            this.context.Backups.Add(backup);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all backups from the database.
        /// </summary>
        /// <returns>A list of all backups.</returns>
        public List<Backup> GetAllBackups()
        {
            return this.context.Backups.ToList();
        }

        /// <summary>
        /// Retrieves a backup by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the backup.</param>
        /// <returns>The backup with the specified ID, or null if not found.</returns>
        public Backup GetBackupById(int id)
        {
            return this.context.Backups.FirstOrDefault(b => b.BackupId == id);
        }

        /// <summary>
        /// Updates an existing backup in the database.
        /// </summary>
        /// <param name="updatedBackup">The updated backup data.</param>
        public void UpdateBackup(Backup updatedBackup)
        {
            var existingBackup = this.context.Backups.FirstOrDefault(b => b.BackupId == updatedBackup.BackupId);
            if (existingBackup != null)
            {
                existingBackup.BackupName = updatedBackup.BackupName;
                existingBackup.CreatedAt = updatedBackup.CreatedAt;
                existingBackup.BackupType = updatedBackup.BackupType;
                existingBackup.Status = updatedBackup.Status;
                existingBackup.SourceDevice = updatedBackup.SourceDevice;
                existingBackup.SourcePath = updatedBackup.SourcePath;
                existingBackup.DestinationDevice = updatedBackup.DestinationDevice;
                existingBackup.DestinationPath = updatedBackup.DestinationPath;
                existingBackup.SizeInBytes = updatedBackup.SizeInBytes;
                existingBackup.Compression = updatedBackup.Compression;
                existingBackup.Encryption = updatedBackup.Encryption;
                existingBackup.Checksum = updatedBackup.Checksum;
                existingBackup.UserId = updatedBackup.UserId;
                existingBackup.LastVerifiedAt = updatedBackup.LastVerifiedAt;
                existingBackup.ExpirationDate = updatedBackup.ExpirationDate;
                existingBackup.Tags = updatedBackup.Tags;
                existingBackup.Notes = updatedBackup.Notes;
                existingBackup.AppVersion = updatedBackup.AppVersion;

                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a backup from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the backup to delete.</param>
        public void DeleteBackup(int id)
        {
            var backup = this.context.Backups.FirstOrDefault(b => b.BackupId == id);
            if (backup != null)
            {
                this.context.Backups.Remove(backup);
                this.context.SaveChanges();
            }
        }
    }

    /*
    /// <summary>
    /// Represents the entry point for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method, the entry point of the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            var backupDB = new BackupDB();

            // Example: Create a new backup
            var newBackup = new Backup
            {
                BackupName = "Backup1",
                CreatedAt = DateTime.Now,
                BackupType = "Completo",
                Status = "Completo",
                SourceDevice = "PC1",
                DestinationDevice = "Server",
                SizeInBytes = 102400,
                Compression = "Zip",
                Encryption = "AES256",
                UserId = "User1"
            };

            backupRepository.CreateBackup(newBackup);

            // Example: Retrieve all backups
            var allBackups = backupRepository.GetAllBackups();
            foreach (var backup in allBackups)
            {
                Console.WriteLine($"Backup ID: {backup.BackupId}, Nome: {backup.BackupName}");
            }

            // Example: Update a backup
            newBackup.Status = "In corso";
            backupRepository.UpdateBackup(newBackup);

            // Example: Delete a backup
            backupRepository.DeleteBackup(newBackup.BackupId);
        }
    }
    */
}
