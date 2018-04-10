namespace DomainDrivenDesignArchitecture.Domain.ReturnModel
{
    public class BaseReturn
    {
        public BaseReturn()
        {
            Error = false;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
