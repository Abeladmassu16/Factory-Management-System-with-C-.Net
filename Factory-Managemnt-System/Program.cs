namespace Factory_Managemnt_System
{
    internal static class Program
    {
        private static TextBox textBoxInstance;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Home(textBoxInstance));

        }
    }
}