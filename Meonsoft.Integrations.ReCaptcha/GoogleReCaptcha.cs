using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Meonsoft.Integrations.ReCaptcha
{

    /// <summary>
    /// For verifying ReCaptcha server-side using HttpClient.  Designed for ReCaptcha v2 but should work up to v3.
    /// </summary>
    public static class GoogleReCaptcha
    {
        const string recaptchaEndpoint = "https://www.google.com/recaptcha/api/siteverify";

        /// <summary>
        /// Verifies the response to the ReCaptcha client using the secret.
        /// </summary>
        /// <param name="secret">Secret for the domain</param>
        /// <param name="response">Response provided to the client from ReCaptcha</param>
        /// <param name="remoteip">(Optional)The remote location of the website.</param>
        /// <param name="endpoint">(Optional)The recaptcha endpoint, set by default but may be overwritten if necessary.</param>
        /// <returns>Information about the response: <see cref="ReCaptchaResponse"/></returns>
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
