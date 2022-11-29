using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;
using Telerik.WebReportDesigner.Services.Controllers;

namespace TestingTeleric.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/reportdesigner")]
    [ApiController]
    public class ReportDesignerController : ReportDesignerControllerBase
    {
        public ReportDesignerController(IReportDesignerServiceConfiguration reportDesignerServiceConfiguration,IReportServiceConfiguration reportServiceConfiguration):base(reportDesignerServiceConfiguration,reportServiceConfiguration) { }
    }
}
