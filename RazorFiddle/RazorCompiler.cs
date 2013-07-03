using RazorEngine;

namespace RazorFiddle
{
    internal static class RazorCompiler
    {
        /// <summary>
        /// Parses a script file given to it and returns the parsed script.
        /// </summary>
        /// <param name="script">The script file.</param>
        /// <returns>The parsed result.</returns>
        public static string ParseScript(string script)
        {
            return Razor.Parse(script);
        }
    }
}
