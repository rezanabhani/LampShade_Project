using _0_Framework.Application.Sms;
using Microsoft.Extensions.Configuration;
using SmsIrRestful;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class SmsService : ISmsService
{
    public class VerifySendParameterModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class VerifySendModel
    {
        public string Mobile { get; set; }

        public int TemplateId { get; set; }

        public VerifySendParameterModel[] Parameters { get; set; }
    }


    public async Task<bool> SendVerificationCodeAsync(string phoneNumber, string verificationCode)
    {
        HttpClient httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Add("x-api-key",
            "XBWbrdy3TShY2Vbc7jS4avjb4dhDtvZ5oSo4J2tY6r8OhBassgTmch2Efw6hxewB");

        VerifySendModel model = new VerifySendModel()
        {
            Mobile = phoneNumber,
            TemplateId = 210098,
            Parameters = new VerifySendParameterModel[]
            {
                new VerifySendParameterModel { Name = "Verifycode", Value = verificationCode }
            }
        };

        string payload = JsonSerializer.Serialize(model);
        StringContent stringContent = new(payload, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await httpClient.PostAsync("https://api.sms.ir/v1/send/verify", stringContent);

        if (response.IsSuccessStatusCode)
        {
            // SMS sent successfully
            return true;
        }
        else
        {
            // Handle the case when SMS sending fails
            // You can log the error or throw an exception as needed
            return false;
        }
    }

    public async Task<bool> SendOrderMessageAsync(string phoneNumber, string ISSUETRACKINGNO)
    {
        HttpClient httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Add("x-api-key",
            "XBWbrdy3TShY2Vbc7jS4avjb4dhDtvZ5oSo4J2tY6r8OhBassgTmch2Efw6hxewB");

        VerifySendModel model = new VerifySendModel()
        {
            Mobile = phoneNumber,
            TemplateId = 691610,
            Parameters = new VerifySendParameterModel[]
            {
                new VerifySendParameterModel { Name = "ISSUETRACKINGNO", Value = ISSUETRACKINGNO }
            }
        };

        string payload = JsonSerializer.Serialize(model);
        StringContent stringContent = new(payload, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await httpClient.PostAsync("https://api.sms.ir/v1/send/verify", stringContent);

        if (response.IsSuccessStatusCode)
        {
            // SMS sent successfully
            return true;
        }
        else
        {
            // Handle the case when SMS sending fails
            // You can log the error or throw an exception as needed
            return false;
        }
    }
}