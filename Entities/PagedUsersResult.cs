namespace EmployeeApi.Entities
{
    public class PagedUsersResult
    {
        public required IEnumerable<EmployeeEntity> Employees { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
         public bool HasNextPage { get; set; }
      public bool HasPreviousPage { get; set; }
    }
}