namespace EVManager.Api.Dtos
{
    public class OperationResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public OperationResultDto(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}