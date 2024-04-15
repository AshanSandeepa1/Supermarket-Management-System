using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_Management_System
{
    public static class Session
    {
        // Static properties to store session information
        public static string Username { get; private set; }
        public static string Role { get; private set; }

        // Method to start a new session
        public static void StartSession(string username, string role)
        {
            Username = username;
            Role = role;
        }

        // Method to end the current session
        public static void EndSession()
        {
            Username = null;
            Role = null;
        }

        // Method to check if a session is active
        public static bool IsSessionActive()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Role);
        }
    }
}
