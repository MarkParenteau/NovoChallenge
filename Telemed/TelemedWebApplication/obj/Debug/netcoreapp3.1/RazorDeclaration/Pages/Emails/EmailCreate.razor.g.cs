// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TelemedWebApplication.Pages.Emails
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
#line 7 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Emails\EmailCreate.razor"
using TelemedWebApplication.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Emails\EmailCreate.razor"
using Utils.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Emails\EmailCreate.razor"
using System.Net.Mail;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/emailsender/{patientId}")]
    public partial class EmailCreate : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Emails\EmailCreate.razor"
      

    //I couldn't find another way to get the patient in here. I would have liked to pass the whole patient object somehow, but couldn't figure it out in the small amount of time I had to put on this.
    //So for now, I'll just pass the ID and fetch it on the server so that it works
    [Parameter]
    public string patientId { get; set; }

    //Keeping the email super simple for now. I would definitely ask what kind of email are we trying to send, do we want to send any information on vital signs etc.
    //If yes, then I'd look for a way to pass the data/charts around in an email (Either through a excel sheet or the charts directly, or something along those lines)
    private EmailModel emailModel { get; set; }
    private Patient patient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        emailModel = new EmailModel();
        patient = await patientService.GetPatient(patientId);
    }

    private void HandleSubmit()
    {
        email
            .To(patient.Email)
            .Subject(emailModel.Subject)
            .Body(emailModel.Body)
            .SendAsync();

        NavManager.NavigateTo($"/patientdetail/{patientId}");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FluentEmail.Core.IFluentEmail email { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PatientService patientService { get; set; }
    }
}
#pragma warning restore 1591
