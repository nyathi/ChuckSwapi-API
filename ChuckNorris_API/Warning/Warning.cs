namespace ChuckNorris_API.Warning
{
    public class Warning
    {
        public Warning(WarningCode code, string customMessage = null)
        {
            Code = code;
            CustomMessage = customMessage;
        }
        private string CustomMessage { get; }
        public WarningCode Code { get; }

        public string Message
        {
            get
            {
                switch (Code)
                {
                    #region Messages

                    // Object
                    case WarningCode.NullJoke:
                        return "The joke field is required";
                    case WarningCode.NullProfile:
                        return "The profile field is required";
                    case WarningCode.NullInput:
                        return "A non-empty request body is required. The input field is required.";
                    default:
                        return "Warning code does not contain a message. Blame the programmer.";
                        #endregion




                }
            }
        }
    }
}
