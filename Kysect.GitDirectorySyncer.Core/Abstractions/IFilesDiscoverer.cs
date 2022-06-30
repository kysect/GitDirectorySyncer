using Kysect.CommonLib.Paths;

namespace Kysect.GitDirectorySyncer.Core.Abstractions;

public interface IFilesDiscoverer
{
    IReadOnlyCollection<PartialPath> DiscoveryFiles(string directoryPath);
}