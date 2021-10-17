using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Meonsoft.Integrations.ReCaptcha
{


    public static class GoogleReCaptcha
    {
        const string recaptchaEndpoint = "https://www.google.com/recaptcha/api/siteverify";

        public static async Task<ReCaptchaResponse> VerifyAsync(string secret, string response, string remoteip = null, string endpoint = recaptchaEndpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                string ep = $"{endpoint}?secret={secret}&response={response}";
                if (!string.IsNullOrWhiteSpace(remoteip))
                    ep += $"&remoteip={remoteip}";
                var res = await client.PostAsync(ep, null);

                if (!res.IsSuccessStatusCode)
                    return new ReCaptchaResponse() { Success = false };

                var content = await res.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<ReCaptchaResponse>(content);
            }

        }

    }
}
