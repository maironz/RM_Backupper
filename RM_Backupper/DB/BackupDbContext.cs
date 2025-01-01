// <copyright file="BackupDbContext.cs" company="Massimo Ronzulli">
// Copyright (c) Massimo Ronzulli. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace RM_Backupper.DB
{
    using System.Data.Entity;

    /// <summary>
    /// Database context to manage backups.
    /// </summary>
    public class BackupDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackupDbContext"/> class.
        /// </summary>
        public BackupDbContext()
            : base("name=RM_BackupperDB") // Connection string from the config.
        {
        }

        /// <summary>
        /// Gets or sets ottiene the Backup Table.
        /// </summary>
        public DbSet<Backup> Backups { get; set; }
    }
}
