// See https://aka.ms/new-console-template for more information

using Kysect.CommonLib.Paths;
using Kysect.CommonLib.Reasons;
using Kysect.GitDirectorySyncer.Core.Abstractions;
using Kysect.GitDirectorySyncer.Core.Models;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

//TODO: implement

void Proccess(
    IDirectoryManager directoryManager,
    IDirectorySyncPolicy syncPolicy,
    IFilesDiscoverer filesDiscoverer,
    IFileSyncFilter fileSyncFilter,
    IFileSyncer fileSyncer)
{
    Log.Information("Start sync");
    foreach (SyncedDirectoryInfo directoryInfo in directoryManager.GetDirectories())
    {
        Log.Information($"Sync directory {directoryInfo.SourcePath} with {directoryInfo.TargetPath}. Last update: {directoryInfo.LastSyncTime}");
        Reason<bool> needSync = syncPolicy.NeedSync(directoryInfo);
        if (!needSync)
        {
            Log.Information($"Sync is not needed. Reason: {needSync.Description}");
            continue;
        }

        IReadOnlyCollection<PartialPath> paths = filesDiscoverer.DiscoveryFiles(directoryInfo.SourcePath);
        Log.Debug($"Discovered files count: {paths.Count}");
        IReadOnlyCollection<PartialPath> filteredPaths = fileSyncFilter.Filter(paths);
        Log.Debug($"Files after filter: {filteredPaths.Count}");
        fileSyncer.Sync(directoryInfo, filteredPaths);
        Log.Information($"Directory {directoryInfo.SourcePath} synced with {directoryInfo.TargetPath}");
        directoryManager.UpdateLastSync(directoryInfo.SourcePath, directoryInfo.TargetPath);
    }
}