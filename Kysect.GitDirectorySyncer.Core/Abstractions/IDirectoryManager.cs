using Kysect.GitDirectorySyncer.Core.Models;

namespace Kysect.GitDirectorySyncer.Core.Abstractions;

public interface IDirectoryManager
{
    IReadOnlyCollection<SyncedDirectoryInfo> GetDirectories();
    SyncedDirectoryInfo AddDirectory(string sourcePath, string targetPath);
    void UpdateLastSync(string sourcePath, string targetPath);
}