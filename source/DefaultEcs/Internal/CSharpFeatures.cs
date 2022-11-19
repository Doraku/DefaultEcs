#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Allow init usage
    /// </summary>
    internal sealed class IsExternalInit { }

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    internal sealed class CallerArgumentExpressionAttribute : Attribute
    {
        public CallerArgumentExpressionAttribute(string parameterName)
        {
            ParameterName = parameterName;
        }

        public string ParameterName { get; }
    }
}
#pragma warning restore IDE0130 // Namespace does not match folder structure
