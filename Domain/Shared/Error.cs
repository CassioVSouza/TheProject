namespace The_Project.Domain.Shared
{
    public record Error(EErrorsList type, string description)
    {
        public static readonly Error None = new(EErrorsList.GenericError, string.Empty);
    }
}
