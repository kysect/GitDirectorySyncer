using Kysect.CommonLib.Paths;

namespace Kysect.GitDirectorySyncer.Core.Abstractions;

public interface IFileSyncFilter
{
    IReadOnlyCollection<PartialPath> Filter(IReadOnlyCollection<PartialPath> files);
}