﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnightsArcadeV2.Models
{
    public partial class KnightsArcadeContext : DbContext
    {
        public KnightsArcadeContext()
        {
        }

        public KnightsArcadeContext(DbContextOptions<KnightsArcadeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Submissions> Submissions { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<TestsQueue> Testsqueue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.ToTable("games");

                entity.HasIndex(e => e.GameName)
                    .HasName("game_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.GameId)
                    .HasColumnName("game_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GameControls)
                    .IsRequired()
                    .HasColumnName("game_controls")
                    .HasColumnType("text");

                entity.Property(e => e.GameCreatorId)
                    .HasColumnName("game_creator_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GameCreatorName)
                    .IsRequired()
                    .HasColumnName("game_creatorname")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameDescription)
                    .IsRequired()
                    .HasColumnName("game_description")
                    .HasColumnType("text");

                entity.Property(e => e.GameGenres)
                    .IsRequired()
                    .HasColumnName("game_genres")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.GameImage0)
                    .IsRequired()
                    .HasColumnName("game_image0")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameImage1)
                    .HasColumnName("game_image1")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameImage2)
                    .HasColumnName("game_image2")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameImage3)
                    .HasColumnName("game_image3")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameImage4)
                    .HasColumnName("game_image4")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasColumnName("game_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameOnArcade)
                    .HasColumnName("game_onarcade")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.GamePath)
                    .IsRequired()
                    .HasColumnName("game_path")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameReviewDateUtc)
                    .HasColumnName("game_reviewdate_utc")
                    .HasColumnType("timestamp");

                entity.Property(e => e.GameStatus)
                    .IsRequired()
                    .HasColumnName("game_status")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.GameSubmissionDateUtc)
                    .HasColumnName("game_submissiondate_utc")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.GameVideolink)
                    .HasColumnName("game_videolink")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Submissions>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.ToTable("submissions");

                entity.Property(e => e.GameId)
                    .HasColumnName("game_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubmissionDateUtc)
                    .HasColumnName("submission_date_utc")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.SubmissionImage0)
                    .IsRequired()
                    .HasColumnName("submission_image0")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SubmissionName)
                    .IsRequired()
                    .HasColumnName("submission_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SubmissionReviewDateUtc)
                    .HasColumnName("submission_reviewdate_utc")
                    .HasColumnType("timestamp");

                entity.Property(e => e.SubmissionStatus)
                    .IsRequired()
                    .HasColumnName("submission_status")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.CreatorId)
                    .HasColumnName("creator_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Tests>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.ToTable("tests");

                entity.Property(e => e.GameId)
                    .HasColumnName("game_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Test5min)
                    .HasColumnName("test_5min")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.TestAttempts)
                    .HasColumnName("test_attempts")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TestCloses)
                    .HasColumnName("test_closes")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.TestOpens)
                    .HasColumnName("test_opens")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.TestRandombuttons)
                    .HasColumnName("test_randombuttons")
                    .HasColumnType("tinyint(4)");

            });

            modelBuilder.Entity<TestsQueue>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.ToTable("testsqueue");

                entity.Property(e => e.GameId)
                    .HasColumnName("game_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RetryCount)
                    .HasColumnName("retry_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });
        }
    }

}
