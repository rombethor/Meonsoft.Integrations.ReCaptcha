using System;
using System.Collections.Generic;
using System.Text;

namespace Meonsoft.Integrations.ReCaptcha
{

    /// <summary>
    /// Possible error codes for ReCaptcha response "error-codes" parameter.
    /// </summary>
    public static class ReCaptchaErrorCodes
    {
        /// <summary>
        /// The secret parameter is missing.
        /// </summary>
        public const string MissingInputSecret = "missing-input-secret";

        /// <summary>
        /// The secret parameter is invalid or malformed.
        /// </summary>
        public const string InvalidInputSecret = "invalid-input-secret";

        /// <summary>
        /// The response parameter is missing.
        /// </summary>
        public const string MissingInputResponse = "missing-input-response";

        /// <summary>
        /// The response parameter is invalid or malformed.
        /// </summary>
        public const string InvalidInputResponse = "invalid-input-response";

        /// <summary>
        /// The request is invalid or malformed.
        /// </summary>
        public const string BadRequest = "bad-request";

        /// <summary>
        /// The response is no longer valid: either is too old or has been used previously.
        /// </summary>
        public const string TimeoutOrDuplicate = "timeout-or-duplicate";
    }
}
