using System;

namespace OjsFileSwap
{
    using System.IO;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("OJS file swapper");
            Console.WriteLine("Enter LOCAL to get local working files or REMOTE to get remote working files");
            string input = Console.ReadLine().ToLower();
            while (input != "local" || input != "remote")
            {
                try
                {
                    if (input == "local")
                    {
                        SwapWithLocalFiles();
                        break;
                    }
                    else if (input == "remote")
                    {
                        SwapWithRemoteFiles();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter LOCAL or REMOTE");
                        input = Console.ReadLine().ToLower();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured while trying to copy files");
                    Console.WriteLine($"Error type: {e.GetType()}");
                    Console.WriteLine($"Error message: {e.Message}");
                    break;
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();


        }

        private static void SwapWithRemoteFiles()
        {
            File.Copy(GlobalPaths.RemoteDataAppConfigPath, GlobalPaths.RepoDataAppConfigPath, true);
            Console.WriteLine("Successfully copied remote (Data)App.config to repository - 25%");
            File.Copy(GlobalPaths.RemoteWorkerAppConfigPath, GlobalPaths.RepoWorkerAppConfigPath,true);
            Console.WriteLine("Successfully copied remote (Worker)App.config to repository - 50%");
            File.Copy(GlobalPaths.RemoteWebConfigPath, GlobalPaths.RepoWebConfigPath, true);
            Console.WriteLine("Successfully copied remote Web.config to repository - 75%");
            File.Copy(GlobalPaths.RemoteAccountControllerPath, GlobalPaths.RepoAccountControllerPath, true);
            Console.WriteLine("Successfully copied remote AccountController.cs to repository - 100%");
        }

        private static void SwapWithLocalFiles()
        {
            File.Copy(GlobalPaths.LocalDataAppConfigPath, GlobalPaths.RepoDataAppConfigPath, true);
            Console.WriteLine("Successfully copied local (Data)App.config to repository - 25%");
            File.Copy(GlobalPaths.LocalWorkerAppConfigPath, GlobalPaths.RepoWorkerAppConfigPath, true);
            Console.WriteLine("Successfully copied local (Worker)App.config to repository - 50%");
            File.Copy(GlobalPaths.LocalWebConfigPath, GlobalPaths.RepoWebConfigPath,true);
            Console.WriteLine("Successfully copied local Web.config to repository - 75%");
            File.Copy(GlobalPaths.LocalAccountControllerPath, GlobalPaths.RepoAccountControllerPath, true);
            Console.WriteLine("Successfully copied local AccountCntroller.cs to repository - 100%");
        }
    }
}
