namespace SiteScriber.Framework.Contracts;

public class ServiceResponse<TErrorRepresentation>
{
    public bool IsSuccess { get; set; }
    public TErrorRepresentation Errors { get; set; }
    public ServiceResponseStatuses Status { get; set; }

    public ServiceResponse()
    {
            
    }
    public ServiceResponse(TErrorRepresentation errors, ServiceResponseStatuses status)
    {
        Errors = errors;
        Status = status;
    }
}
public class ServiceResponse<TResult, TErrorRepresentation> : ServiceResponse<TErrorRepresentation>
{
    public TResult Result { get; set; }

    public ServiceResponse()
    {
            
    }
    public ServiceResponse(TResult result)
    {
        IsSuccess = true;
        Result = result;
    }

    public ServiceResponse(TErrorRepresentation errors, ServiceResponseStatuses status) : base(errors, status)
    {
            
    }
}