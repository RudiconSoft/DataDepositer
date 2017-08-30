/**
 *  RuDiCon Soft (c) 2017
 *  
 *  Class for watching about File System changes (read / write / create / delete/ move)
 *  
 *  @created 2017-08-30 Artem Nikolaev
 * 
 */
using System;
using System.IO;
using System.Security.Permissions;
using log4net;


namespace DataDepositer
{
    public class FileWatcher
    {
        private bool isWatch = false; // for start / stop watch

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void StartWatch(string sPathToWatch)
        {
            try
            {

                // Create a new FileSystemWatcher and set its properties.
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = sPathToWatch;
                /* Watch for changes in LastAccess and LastWrite times, and
                   the renaming of files or directories. */
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.*";

                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);

                // Begin watching.
                watcher.EnableRaisingEvents = true;
                while (isWatch) ;
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
            }
        }

        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // @TODO Specify what is done when a file is changed, created, or deleted.
            //
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            // @TODO Specify what is done when a file is renamed (turn back name).
           
        }
    }
}
