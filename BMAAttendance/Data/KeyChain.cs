namespace BMAAttendance.Data
{
    /// <summary>
    /// In-app settings not needed to be abstracted to user secrets
    /// </summary>
    public static class KeyChain
    {
        public static string AppName
        {
            get
            {
                return "BMA Attendance Tracker";
            }
        }
        public static string AppCode
        {
            get
            {
                return "BMAAttendance";
            }
        }
        public static string Container
        {
            get
            {
                return "bmafilestorage";
            }
        }
        public static string OwnerEmail
        {
            get
            {
                return "berringerma@yahoo.com";
            }
        }
    }
    public enum Environ
    {
        MainApp
    }

}