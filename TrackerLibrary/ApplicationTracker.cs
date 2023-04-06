using System.Runtime.InteropServices;
using System.Text;

namespace TrackerLibrary
{
    public static class ApplicationTracker
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        /// <summary>
        /// Get the name of the Window
        /// </summary>
        /// <param name="hWnd"> Input hWnd </param>
        /// <param name="lpWindowText"> StringBuilder windowText = new StringBuilder(99);</param>
        /// <param name="nMaxLen"> windowText.Capacity </param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxLen);

        /// <summary>
        /// Get Process Id
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns> Process Id </returns>
        public static int GetProcessId(IntPtr hWnd)
        {
            int processId;
            GetWindowThreadProcessId(hWnd, out processId);
            return processId;
        }

        /// <summary>
        /// Wrapper for GetWindowText
        /// </summary>
        /// <param name="hWnd"> hWnd </param>
        /// <returns> Window Title </returns>
        public static string GetWindowTitle(IntPtr hWnd)
        {
            StringBuilder windowText = new StringBuilder(99);
            GetWindowText(hWnd, windowText, windowText.Capacity);
            return windowText.ToString();
        }

    }
}
