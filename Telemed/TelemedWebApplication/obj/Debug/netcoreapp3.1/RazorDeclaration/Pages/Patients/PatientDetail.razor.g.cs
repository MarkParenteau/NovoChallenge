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
#line 3 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Patients\PatientDetail.razor"
using TelemedWebApplication.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Patients\PatientDetail.razor"
using Utils.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/patientdetail/{patientId}")]
    public partial class PatientDetail : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 93 "B:\dev\repo\NovoChallenge\MarkParenteau\NovoChallenge\Telemed\TelemedWebApplication\Pages\Patients\PatientDetail.razor"
       
    [Parameter]
    public string patientId { get; set; }
    private Patient patient { get; set; }
    private LineChart<double> lineChart { get; set; }
    private List<string> backgroundColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 0.2f), ChartColor.FromRgba(54, 162, 235, 0.2f), ChartColor.FromRgba(255, 206, 86, 0.2f), ChartColor.FromRgba(75, 192, 192, 0.2f), ChartColor.FromRgba(153, 102, 255, 0.2f), ChartColor.FromRgba(255, 159, 64, 0.2f) };
    private List<string> borderColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 1f), ChartColor.FromRgba(54, 162, 235, 1f), ChartColor.FromRgba(255, 206, 86, 1f), ChartColor.FromRgba(75, 192, 192, 1f), ChartColor.FromRgba(153, 102, 255, 1f), ChartColor.FromRgba(255, 159, 64, 1f) };

    protected override async Task OnInitializedAsync()
    {
        lineChart = new LineChart<double>();
        //There is most likely a way to just pass the patient as an object instead of calling the API here - Could store all patients in memory
        patient = await patientService.GetPatient(patientId);
    }

    private void HandleSubmit()
    {
        patientService.UpdatePatient(patient);
        StateHasChanged();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await HandleRedraw();
        }
    }

    private double GetAverageTemperature()
    {
        List<double> temperatures = patient.VitalSigns.Select(vs => vs.Temperature).ToList();
        return temperatures.Sum() / temperatures.Count;
    }

    private double GetAverageCardiacFrequency()
    {
        List<int> cardiacFrequencies = patient.VitalSigns.Select(vs => vs.CardiacFrequency).ToList();
        return cardiacFrequencies.Sum() / cardiacFrequencies.Count;
    }

    private double GetAverageSpO2()
    {
        List<double> spO2s = patient.VitalSigns.Select(vs => vs.SpO2).ToList();
        return spO2s.Sum() / spO2s.Count;
    }

    async Task HandleRedraw()
    {
        await lineChart.Clear();

        await lineChart.AddDataSet(GetCardiacFrequencyLineChartDataset());
        await lineChart.AddDataSet(GetSPO2LineChartDataset());
        await lineChart.AddLabelsDatasetsAndUpdate(GetTimeLabelsForDay(), GetTemperatureLineChartDataset());
    }

    LineChartDataset<double> GetTemperatureLineChartDataset()
    {
        return new LineChartDataset<double>
        {
            Label = "Temperature",
            Data = GetTemperatures(),
            BackgroundColor = backgroundColors[3],
            BorderColor = borderColors[3],
            Fill = true,
            PointRadius = 2,
            BorderDash = new List<int> { }
        };
    }

    LineChartDataset<double> GetCardiacFrequencyLineChartDataset()
    {
        return new LineChartDataset<double>
        {
            Label = "Cardiac Frequency",
            Data = GetCardiacFrequencies(),
            BackgroundColor = backgroundColors[2],
            BorderColor = borderColors[2],
            Fill = true,
            PointRadius = 2,
            BorderDash = new List<int> { }
        };
    }

    LineChartDataset<double> GetSPO2LineChartDataset()
    {
        return new LineChartDataset<double>
        {
            Label = "SpO2",
            Data = GetSpO2s(),
            BackgroundColor = backgroundColors[1],
            BorderColor = borderColors[1],
            Fill = true,
            PointRadius = 2,
            BorderDash = new List<int> { }
        };
    }

    private List<double> GetTemperatures()
    {
        return patient.VitalSigns.Select(vs => vs.Temperature).ToList();
    }

    private List<double> GetCardiacFrequencies()
    {
        return patient.VitalSigns.Select(vs => (double)vs.CardiacFrequency).ToList();
    }

    private List<double> GetSpO2s()
    {
        return patient.VitalSigns.Select(vs => vs.SpO2).ToList();
    }

    private List<string> GetTimeLabelsForDay()
    {
        return patient.VitalSigns.Select(vs => vs.CreationTime.ToShortTimeString()).ToList();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PatientService patientService { get; set; }
    }
}
#pragma warning restore 1591
