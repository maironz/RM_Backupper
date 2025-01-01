// <copyright file="Backup.cs" company="Massimo Ronzulli">
// Copyright (c) Massimo Ronzulli. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace RM_Backupper.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a backup record in the database.
    /// </summary>
    public class Backup
    {
        /// <summary>
        /// Gets or sets the Backup Id.
        /// </summary>
        [Key] // Define this as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indicates that this column is auto-incremented
        [Column("BackupId")] // Optionally specify column name if different
        public int BackupId { get; set; }

        /// <summary>
        /// Gets or sets the Backup Name.
        /// </summary>
        [Column("BackupName")] // Column mapping
        [MaxLength(255)] // Optional: limit the length of string
        public string BackupName { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the Backup Type (complete, incremental or differential).
        /// </summary>
        [Column("BackupType")]
        [MaxLength(50)] // Optional: restrict length of string
        public string BackupType { get; set; }

        /// <summary>
        /// Gets or sets the Backup Status (e.g. Complete, Failed).
        /// </summary>
        [Column("Status")]
        [MaxLength(50)] // Optional: restrict length of string
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the Source Device (e.g. the name of your PC or mobile device).
        /// </summary>
        [Column("SourceDevice")]
        [MaxLength(100)] // Optional: limit string length
        public string SourceDevice { get; set; }

        /// <summary>
        /// Gets or sets the Source Path.
        /// </summary>
        [Column("SourcePath")]
        [MaxLength(255)] // Optional: limit string length
        public string SourcePath { get; set; }

        /// <summary>
        /// Gets or sets the Destination Device.
        /// </summary>
        [Column("DestinationDevice")]
        [MaxLength(100)] // Optional: limit string length
        public string DestinationDevice { get; set; }

        /// <summary>
        /// Gets or sets the Destination Path.
        /// </summary>
        [Column("DestinationPath")]
        [MaxLength(255)] // Optional: limit string length
        public string DestinationPath { get; set; }

        /// <summary>
        /// Gets or sets the Backup Size in bytes.
        /// </summary>
        [Column("SizeInBytes")]
        public long? SizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the Backup Compression.
        /// </summary>
        [Column("Compression")]
        [MaxLength(50)] // Optional: limit string length
        public string Compression { get; set; }

        /// <summary>
        /// Gets or sets the Backup Encryption.
        /// </summary>
        [Column("Encryption")]
        [MaxLength(50)] // Optional: limit string length
        public string Encryption { get; set; }

        /// <summary>
        /// Gets or sets the Backup Checksum.
        /// </summary>
        [Column("Checksum")]
        [MaxLength(100)] // Optional: limit string length
        public string Checksum { get; set; }

        /// <summary>
        /// Gets or sets the User who created the backup.
        /// </summary>
        [Column("UserId")]
        [MaxLength(128)] // Optional: User ID length (e.g., for ASP.NET Identity)
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the Last Check date.
        /// </summary>
        [Column("LastVerifiedAt")]
        public DateTime? LastVerifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the Periodic Backup Expiration date.
        /// </summary>
        [Column("ExpirationDate")]
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the Tag or Category.
        /// </summary>
        [Column("Tags")]
        [MaxLength(255)] // Optional: limit string length
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the Notes.
        /// </summary>
        [Column("Notes")]
        [MaxLength(1000)] // Optional: limit string length for Notes
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the Software Version it was built with.
        /// </summary>
        [Column("AppVersion")]
        [MaxLength(50)] // Optional: limit string length
        public string AppVersion { get; set; }
    }
}
