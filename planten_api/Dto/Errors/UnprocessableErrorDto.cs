namespace planten_api.Dto.Errors;

public class UnprocessableErrorDto : BasicErrorDto
{
    public UnprocessableErrorDto(String message)
    {
        this.Message = message;
    }
}