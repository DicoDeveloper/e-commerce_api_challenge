using System.Collections.Generic;
using Flunt.Notifications;

namespace WAP.E_commerce.Api.Challenge.Domain.Core.Handlers
{
    public class ResultResponse<T>
    {
        public ResultResponse()
        {
            Success = true;
        }
        public ResultResponse(T data)
        {
            Data = data;
            Success = true;
        }
        public ResultResponse(IReadOnlyCollection<Notification> noitications, string errorMessage = "")
        {
            Notifications = noitications;
            Message = errorMessage;
            Success = false;
        }

        public ResultResponse(string errorMessage = "")
        {
            Message = errorMessage;
            Success = false;
        }

        public ResultResponse(T data, bool notError = false)
        {
            if (notError)
            {
                Data = data;
                Success = true;
                return;
            }

            Message = data?.ToString();
            Success = false;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
        public IReadOnlyCollection<Notification> Notifications { get; set; }
        public T Data { get; set; }
    }

    public class ResultResponse : ResultResponse<object>
    {
        public ResultResponse()
        {
        }

        public ResultResponse(object data) : base(data)
        {
        }

        public ResultResponse(IReadOnlyCollection<Notification> noitications, string message = "") : base(noitications, message)
        {
        }
    }
}