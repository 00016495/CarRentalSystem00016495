﻿namespace CarRentalSystem00016495.Api.Service.Exceptions;

public class CustomException : Exception
{
    public int StatusCode { get; set; }
    public CustomException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}
