namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages
{
    public class ExperienceManagementErrorMessage
    {
        public ExperienceManagementErrorMessage(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"کد پیام: {Code}\t متن پیام: {Message}";
        }

        public ExperienceManagementErrorMessage AddSqlErrorCode(int sqlErrorCode)
        {
            return new ExperienceManagementErrorMessage(Code + $" ({sqlErrorCode}) ", Message);
        }
    }
}