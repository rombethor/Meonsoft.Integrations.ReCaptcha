using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Meonsoft.Integrations.ReCaptcha
{
    public class ReCaptchaResponse
    {
        /// <summary>
        /// Whether the check was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// The date and time of the challenge.  All challenges must be verified within two minutes or else they are void.
        /// </summary>
        [JsonPropertyName("challenge_ts")]
        public DateTime Challenge_ts { get; set; }

        /// <summary>
        /// Hostname of the website where requested.
        /// </summary>
        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Android only!  The name of the package making the check.
        /// </summary>
        [JsonPropertyName("apk-package-name")]
        public string ApkPackageName { get; set; }
        
        /// <summary>
        /// Error codes if any, if success is false.
        /// </summary>
        [JsonPropertyName("error-codes")]
        public IEnumerable<string> ErrorCodes { get; set; }
    }
}
