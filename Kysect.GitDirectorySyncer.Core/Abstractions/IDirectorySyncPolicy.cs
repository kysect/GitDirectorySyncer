using Kysect.CommonLib.Reasons;
using Kysect.GitDirectorySyncer.Core.Models;

namespace Kysect.GitDirectorySyncer.Core.Abstractions;

public interface IDirectorySyncPolicy
{
    Reason<bool> NeedSync(SyncedDirectoryInfo directoryInfo);
}