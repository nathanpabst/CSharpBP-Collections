namespace Acme.Common
{
    /// <summary>
    /// Provides a success flag and message 
    /// useful as a method return type.
    /// </summary>
    
        //changing OperationResult to a generic type by adding T to the class 
        //generics allow us to build reusable, type-neutral classes
    public class OperationResult<T>
    {
        public OperationResult()
        {
        }

        public OperationResult(T result, string message) : this()
        {
            this.Result = result;
            this.Message = message;
        }

        //by using the generic this property can now apply to decimal, boolean, int, etc.
        public T Result { get; set; }
        public string Message { get; set; }
    }

}
