using Kysect.CommonLib.Paths;
using Kysect.GitDirectorySyncer.Core.Models;

namespace Kysect.GitDirectorySyncer.Core.Abstractions;

public interface IFileSyncer
{
    void Sync(SyncedDirectoryInfo directory, IReadOnlyCollection<PartialPath> paths);
}