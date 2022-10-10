using ErrorOr;

namespace CyberTutorial.Contracts.Errors
{
    public class ErrorWrapper
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        public static List<Error> Convert(List<ErrorWrapper> errors)
        {
            List<Error> result = new List<Error>();
            foreach (ErrorWrapper error in errors)
            {
                if ((int)ErrorType.Failure == error.Type)
                {
                    result.Add(Error.Failure(error.Code, error.Description));
                }
                else if ((int)ErrorType.Unexpected == error.Type)
                {
                    result.Add(Error.Unexpected(error.Code, error.Description));
                }
                else if ((int)ErrorType.Validation == error.Type)
                {
                    result.Add(Error.Validation(error.Code, error.Description));
                }
                else if ((int)ErrorType.Conflict == error.Type)
                {
                    result.Add(Error.Conflict(error.Code, error.Description));
                }
                else
                {
                    result.Add(Error.NotFound(error.Code, error.Description));
                }
            }
            return result;
        }

        public static List<ErrorWrapper> Convert(List<Error> errors)
        {
            List<ErrorWrapper> result = new List<ErrorWrapper>();
            foreach (Error error in errors)
            {
                result.Add(new ErrorWrapper
                {
                    Code = error.Code,
                    Description = error.Description,
                    Type = (int)error.Type
                });
            }
            return result;
        }
    }
}