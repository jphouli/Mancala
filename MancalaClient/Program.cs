namespace Mancala
{
    /// <summary>
    /// Filename: Program.cs
    /// Part of Project: Mancala
    /// 
    /// File Purpose: This is the driver that starts the main application GUI form up.
    /// 
    /// Program Purpose: This is a client-side program that implements the game of Mancala in a server/client TCP format.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}