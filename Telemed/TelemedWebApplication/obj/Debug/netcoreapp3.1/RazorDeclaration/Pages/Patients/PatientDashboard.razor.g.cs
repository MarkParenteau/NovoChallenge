// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TelemedWebApplication.Pages.Patients
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using TelemedWebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using TelemedWebApplication.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\_Imports.razor"
using Blazorise.Charts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Patients\PatientDashboard.razor"
using TelemedWebApplication.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Patients\PatientDashboard.razor"
using Utils.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Patients\PatientDashboard.razor"
using System.Timers;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/patientdashboard")]
    public partial class PatientDashboard : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 60 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Patients\PatientDashboard.razor"
       
    public List<Patient> patients { get; set; }
    private Timer timer;

    protected override async Task OnInitializedAsync()
    {
        patients = await patientService.GetPatients();
        StartReadingsTimer();
    }

    //Create a timer to simulate readings on patients
    private void StartReadingsTimer()
    {
        timer = new Timer();
        timer.Elapsed += new ElapsedEventHandler(GetPatientReadings);
        timer.Interval = 5000;
        timer.Start();
    }

    private void GetPatientReadings(object sender, EventArgs e)
    {
        foreach (var patient in patients)
        {
            var test = patientService.TakeNewVitalSignReading(patient).Result;
        }
    }

    private void DeletePatient(string patientId)
    {
        //Should be a confirmation message here
        patientService.DeletePatient(patientId);
        patients.Remove(patients.Where(p => p.Id == patientId).FirstOrDefault());
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PatientService patientService { get; set; }
    }
}
#pragma warning restore 1591
