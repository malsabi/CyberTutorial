using ErrorOr;

namespace CyberTutorial.WebApp.Models.Common
{
    public class ControllerResultModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public List<string> Metadata { get; set; }
        
        public ControllerResultModel()
        {
            IsSuccess = false;
            Message = string.Empty;
            Data = null;
            Metadata = null;
        }
    }
}