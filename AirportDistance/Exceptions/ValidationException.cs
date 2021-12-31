using Carter.ModelBinding;

namespace AirportDistance.Exceptions
{
    /// <summary>
    /// Throws an exception when input is not correct.
    /// </summary>
    public class ValidationException: Exception
    {
        public IEnumerable<ModelError> Errors;

        public ValidationException(IEnumerable<ModelError> Errors)
        {
            this.Errors = Errors;
        }

        public ValidationException(string message)
            : base(message)
        {

        }
    }
}
