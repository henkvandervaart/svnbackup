using System;
using System.Collections.Specialized;
using System.Globalization;

namespace svnbackup
{
    public class CommandLine
    {
        // Container for parsed commandline parameters
        public string Argument 
        { 
            get
            {
                return this.argument;
            }
        }

        // Get (read-only) property for Parameters collection
        public StringDictionary Options
        {
            get
            {
                return this.options;
            }
        }

        private StringDictionary options;
        private string argument;

        /// <summary>
        /// Initializes a new instance of the CommandLine class 
        /// </summary>
        public CommandLine()
        {
            ParseCommandLine();
        }

        public string TryGetOption(string option1, string option2)
        {
            if (options.ContainsKey(option1))
            {
                return options[option1];
            }
            else
            {
                return TryGetOption(option2);
            }
        }

        public string TryGetOption(string option)
        {
            return options.ContainsKey(option) ? options[option] : String.Empty;
        }

        /// <summary>
        /// Indicates whether string is parameter in the commandline
        /// Can be either a parameter with value or a boolean parameter
        /// </summary>
        /// <param name="paramName">string tested whether it is a parameter</param>
        /// <returns></returns>
        public bool IsParameter(string paramName)
        {
            try
            {
                return Options.ContainsKey(paramName);
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// Indicates whether boolean parameter flag exists in commandline
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public bool IsParameterTrue(string paramName)
        {
            string paramValue = this.Options[paramName.ToLower(CultureInfo.InvariantCulture)];
            if (paramValue == null)
            {
                return false;
            }

            // A parameter value is found for requested parameter, if value is not equal to "true" then
            // return true in case value is empty or false otherwise
            if (string.Compare(paramValue, "true", StringComparison.OrdinalIgnoreCase) != 0)
            {
                return String.Empty.Equals(paramValue);
            }

            // Parameter value equals "true" so return true ...
            return true;
        }

        /// <summary>
        /// Parses the commandline and populates local dictionary with parameter 
        /// information, i.e. flag name and optional its related value.
        /// For flags without a related value (so called boolean flags) a value
        /// of "true" is added into the local dictionary.
        /// </summary>
        /// <param name="commandLine">The commandline to be parsed</param>
        /// <returns>The dictionary with commandline parameter data</returns>
        protected void ParseCommandLine()
        {
            options = new StringDictionary();

            argument = Environment.GetCommandLineArgs()[1].Trim();

            for (int index = 1; index < Environment.GetCommandLineArgs().Length;  index++)
            {
                // Check if argument is indeed an option 
                if (Environment.GetCommandLineArgs()[index].StartsWith("-") ||
                    Environment.GetCommandLineArgs()[index].StartsWith("--"))
                {
                    string option = Environment.GetCommandLineArgs()[index].TrimStart(new char[] { '-' });

                    // If next argument exists and it is not an option flag use this as option value
                    if ((index <  Environment.GetCommandLineArgs().Length - 1) &&
                        (!Environment.GetCommandLineArgs()[index+1].StartsWith("-")))
                    {
                        string value = Environment.GetCommandLineArgs()[++index];
                        options[option] = value;
                    }
                    else
                    {
                        options[option] = "true";
                    }
                }
            }

            return;
        }

    }

}
