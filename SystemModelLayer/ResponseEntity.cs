namespace EmployeeManagementSystemModelLayer
{
    using System;
    using System.Net;

    /// <summary>
    /// 'Response Entity' Class.
    /// </summary>
    public class ResponseEntity
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseEntity"/> class.
        /// </summary>
        /// <param name="httpStatusCode">Http Status Code.</param>
        /// <param name="message">Message Of Employee Record Found Or Not Found.</param>
        /// <param name="data">Details Of Employee.</param>
        public ResponseEntity(HttpStatusCode httpStatusCode, string message, object data)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Message = message;
            this.Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseEntity"/> class.
        /// </summary>
        /// <param name="httpStatusCode">Http Status Code.</param>
        /// <param name="message">Message Of Employee Record Found Or Not Found.</param>
        public ResponseEntity(HttpStatusCode httpStatusCode, string message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Message = message;
        }
    }
}
