using ErrorOr;
using MapsterMapper;
using CyberTutorial.WebApp.Models;
using CyberTutorial.Contracts.Models;
using CyberTutorial.Contracts.Requests.Attempt;
using CyberTutorial.Contracts.Responses.Attempt;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.ViewModels
{
    public class AttemptViewModel
    {
        private readonly IMapper mapper;
        private readonly IAttemptService attemptService;

        public AttemptViewModel(IMapper mapper, IAttemptService attemptService)
        {
            this.mapper = mapper;
            this.attemptService = attemptService;
        }

        public async Task<ControllerResultModel> AddAttemptAsync(AttemptModel attempt)
        {
            ControllerResultModel result;

            AddAttemptRequest request = mapper.Map<AddAttemptRequest>(attempt);

            ErrorOr<AddAttemptResponse> response = await attemptService.AddAttemptAsync(request);
            
            if (response.IsError)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = response.FirstError.Description,
                    Data = response
                };
            }
            else
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = true,
                    Message = "Successfully added attempt",
                    Data = response.Value.AttemptId
                };
            }
            return result;
        }
    }
}