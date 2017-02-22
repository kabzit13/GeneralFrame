using GeneralFrame.Application.Contracts;

namespace GeneralFrame.Service
{
    public class GeneralFrameService : IGeneralFrameService
    {
        private readonly IGeneralFrameService appService;

        protected GeneralFrameService()
        {
        }

        public GeneralFrameService(IGeneralFrameService appService)
        {
            this.appService = appService;
        }

        public void GetData()
        {
            this.appService.GetData();
        }
    }
}
