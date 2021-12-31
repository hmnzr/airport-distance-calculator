namespace AirportDistance.Exceptions
{
    /// <summary>
    /// Thrown when an entity required for use has not been found.
    /// </summary>
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(string message)
            :base(message)
        {

        }
    }
}
