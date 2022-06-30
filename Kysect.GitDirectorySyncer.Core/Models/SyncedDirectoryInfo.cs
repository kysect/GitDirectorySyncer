namespace Kysect.GitDirectorySyncer.Core.Models;

public record SyncedDirectoryInfo(string SourcePath, string TargetPath, DateTime? LastSyncTime);