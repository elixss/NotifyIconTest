namespace NotifyIconTest
{
    internal static class Program
    {

        public static NotifyIcon TrayIcon { get; set; } = new();


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadContextMenu();
            Application.Run();
        }

        static void LoadContextMenu()
        {
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.AddRange(new ToolStripMenuItem[]
            {
                new("Send warning", null, (sender, e) => SendWarning()),
                new("Send error", null, (sender, e) => SendError()),
                new("Send question", null, (sender, e) => SendQuestion()),
                new("Terminate", null, (sender, e) => Application.Exit())
            });

            TrayIcon.ContextMenuStrip = contextMenu;
            TrayIcon.Icon = SystemIcons.Information;
            TrayIcon.Visible = true;
        }

        static void SendWarning()
        {
            TrayIcon.Icon = SystemIcons.Warning;
            TrayIcon.BalloonTipText = "Warning";
            TrayIcon.ShowBalloonTip(3);
        }

        static void SendError()
        {
            TrayIcon.Icon = SystemIcons.Error;
            TrayIcon.BalloonTipText = "Error";
            TrayIcon.ShowBalloonTip(3);
        }

        static void SendQuestion()
        {
            TrayIcon.Icon = SystemIcons.Question;
            TrayIcon.BalloonTipText = "Question";
            TrayIcon.ShowBalloonTip(3);
        }
    }
}