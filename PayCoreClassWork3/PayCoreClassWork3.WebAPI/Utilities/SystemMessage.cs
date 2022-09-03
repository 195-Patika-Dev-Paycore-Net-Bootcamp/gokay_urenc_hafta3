namespace PayCoreClassWork3.WebAPI.Utilities
{
    public class SystemMessage
    {
        public static readonly string ID_NULL = "Id can't be empty.";
        public static readonly string NOT_EMPTY = "Must not be empty.";
        public static readonly string NOT_FOUND = "No item found.";
        public static readonly string ADDED = "Added successfully.";
        public static readonly string UPDATED = "Updated successfully.";
        public static readonly string DELETED = "Deleted successfully.";
        public static readonly string NAME_LENGTH_ERROR = "Length must be between 3 and 50.";
        public static readonly string PLATE_LENGTH_ERROR = "Length must be between 8 and 20.";
        public static readonly string CONTAINER_COUNT_ERROR = "Container count must be at least 2. Otherwise containers can't be clustered.";
        public static readonly string CHUNK_ERROR = "Max element count in each cluster must be at least 1.";
        public static readonly string LESS_COUNT_ERROR = "To cluster containers, max element count must be less than container count.";
    }
}